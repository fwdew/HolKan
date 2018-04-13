using System;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using Settings;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Client
{
   public partial class MainForm : HolkanBehaviorForm
   {
      private const string COLUMN_SHOW_TIME = "date_time_event";

      // prevent showing more than 1 message in a time
      private volatile bool _messageOnline = false;

      private static IPEndPoint ServerIpEndPoint;

      public MainForm()
      {
         InitializeComponent();
         SetUpStartUpConfiguration();
         new Thread(new ThreadStart(ShowMessageHandler)).Start();
         InformServerAboutStartUp();
      }

      private void SetUpStartUpConfiguration()
      {
         base.checkedListBoxUsers = checkedListBoxUsers;
         ReceiverPort = Const.serverPort;
         Datagrams = new DatagramList(dataGridViewListOfOrders, this);

         // UNCOMMENT in realize
         //this.Enabled = false;
         FormClosing += HolKanClient_FormClosing;

         ServerIpEndPoint = new IPEndPoint(Const.serverIpAdress, Const.serverPort);
         localIpAdress = GetLocalIPAddress();

         if (localIpAdress == null) {
            // TODO: LogLocalError
            throw new Exception("Local IP Address Not Found!");
         }

         ipLastNumber = GetLastPartFromIp(localIpAdress);

         CreateMenu();

         timerCurrentDateTime.Start();

         comboBoxRemindAfter.Items.AddRange(Const.timeStepsList.ToArray());
         comboBoxPeriod.Items.AddRange(Const.timeStepsList.ToArray());
         comboBoxRemindAfter.Text = Const.timeStepsList.FirstOrDefault();
         comboBoxPeriod.Text = Const.timeStepsList.FirstOrDefault();
      }

      #region Sending data
      private void SendMessageToAllCheckedUsers()
      {
         for (var i = 0; i < checkedListBoxUsers.Items.Count; i++) {
            if (checkedListBoxUsers.GetItemChecked(i)) {
               var checkedUser = GetUserFromListBoxName(checkedListBoxUsers.Items[i].ToString());
               if (checkedUser == null) {
                  continue;
               }
               AddToSendingPool(CreatePackets(checkedUser));
            }
         }
      }

      private IEnumerable<Packet> CreatePackets(User user)
      {
         foreach (var datagram in CreateDatagrams(user.Ip)) {
            yield return new Packet(user, datagram);
         }
      }

      // TODO: implement limit number of message per day per current sender user
      private IEnumerable<Datagram> CreateDatagrams(IPAddress recipientIp)
      {
         var message = textBoxMessage.Text;
         var alertMe = checkBoxAlertOnConfirm.Checked;

         if (!checkBoxAdditionalOptions.Checked) {
            yield return new Datagram(message, alertMe, recipientIp);
         } else {
            if (radioButtonImmideatly.Checked) {
               yield return new Datagram(message, alertMe, recipientIp);
            }
            if (radioButtonAfter.Checked) {
               yield return new Datagram(
                  DateTime.Now.AddSeconds(GetTotalSecondsToNextShowTime(numericUpDownRemindAfter, comboBoxRemindAfter)),
                  message, alertMe, recipientIp);
            }
            if (radioButtonExact.Checked) {
               yield return new Datagram(
                  GetShowTimeExact(dateTimePickerDate, dateTimePickerTime),
                  message, alertMe, recipientIp);
            }

            if (checkBoxPeriod.Checked) {
               var tick = GetTotalSecondsToNextShowTime(numericUpDownPeriod, comboBoxPeriod);
               var i = 1;
               var showNextTime = DateTime.Now.AddSeconds(tick);

               if (radioButtonLastEventCount.Checked) {
                  while (i <= (int)numericUpDownSeveralTimes.Value) {
                     yield return new Datagram(showNextTime, message, alertMe, recipientIp);
                     showNextTime = DateTime.Now.AddSeconds(tick * ++i);
                  }
               }
               if (radioButtonLastEventDateTime.Checked) {
                  var dateTimeLimit = GetShowTimeExact(dateTimePickerLastShowEventDate, dateTimePickerLastShowEventTime);
                  while (showNextTime <= dateTimeLimit) {
                     yield return new Datagram(showNextTime, message, alertMe, recipientIp);
                     showNextTime = DateTime.Now.AddSeconds(tick * ++i);
                  }
               }
            }
         }
      }

      protected internal static double GetTotalSecondsToNextShowTime(NumericUpDown numericUpDownValue, ComboBox comboBoxTimeStep)
      {
         var dtNow = DateTime.Now;
         var showTime = DateTime.Now;

         switch (Enum.Parse(typeof(TimeSteps), comboBoxTimeStep.SelectedItem.ToString())) {
            case TimeSteps.seconds:
               showTime = DateTime.Now.AddSeconds((int)numericUpDownValue.Value);
               break;
            case TimeSteps.minutes:
               showTime = DateTime.Now.AddMinutes((int)numericUpDownValue.Value);
               break;
            case TimeSteps.hours:
               showTime = DateTime.Now.AddHours((int)numericUpDownValue.Value);
               break;
            case TimeSteps.days:
               showTime = DateTime.Now.AddDays((int)numericUpDownValue.Value);
               break;
            case TimeSteps.weeks:
               showTime = DateTime.Now.AddDays(7 * (int)numericUpDownValue.Value);
               break;
            case TimeSteps.months:
               showTime = DateTime.Now.AddMonths((int)numericUpDownValue.Value);
               break;
            case TimeSteps.years:
               showTime = DateTime.Now.AddYears((int)numericUpDownValue.Value);
               break;
            default:
               DateTime.Now.AddSeconds((int)numericUpDownValue.Value);
               break;
         }

         return (showTime - dtNow).TotalSeconds;
      }

      protected internal static DateTime GetShowTimeExact(DateTimePicker datePicker, DateTimePicker timePicker)
      {
         var date = datePicker.Value;
         var time = timePicker.Value;
         return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
      }
      #endregion

      #region Analyzing income data
      // TODO:
      protected override void AnalyzeIncomeTextDatagram(Datagram datagram)
      {
         switch (datagram.Type) {
            case Settings.Type.Message:
               // 
               break;
            case Settings.Type.UpdateMessage:
               break;
            case Settings.Type.DeleteMessage:
               break;
         }
      }

      protected override void AnalyzeIncomeConfigDatagram(Datagram datagram)
      {
         switch (datagram.Type) {
            case Settings.Type.UserCredential:
               UpdateUser(datagram.SystemMessage);
               break;
            case Settings.Type.UserStatus:
               UpdateUserStatus(datagram.SystemMessage);
               break;
         }
      }

      protected override void AnalyzeIncomeCommandDatagram(Datagram datagram)
      {
         switch (datagram.Type) {
            case Settings.Type.Restart:
               Process.Start("shutdown", "/r /t 0");
               break;
            case Settings.Type.SoftShutdown:
               Process.Start("shutdown", "/s /t 120");
               break;
            case Settings.Type.HardShutdown:
               Process.Start("shutdown", "/s /t 0 /f");
               break;
         }
      }
      #endregion

      #region Working with events
      private void ShowMessageHandler()
      {
         while (!_shouldExit) {
            try {
               if (!_messageOnline && dataGridViewListOfOrders.RowCount > 0) {
                  // show always first order because of already sorted rows.
                  var firstRow = dataGridViewListOfOrders.Rows[0];
                  var showTime = Convert.ToDateTime(firstRow.Cells[COLUMN_SHOW_TIME].Value);
                  if (showTime < DateTime.Now) {
                     var datagram = Datagrams.GetFirst();
                     if (datagram.IsValid) {
                        ShowMessage(
                           datagram.Id,
                           datagram.SenderName,
                           datagram.Message,
                           datagram.ShowTime);
                     }
                     //ShowMessage(
                     //   long.Parse(firstRow.Cells["id_event"].Value.ToString()),
                     //   GetUserFromListBoxName(firstRow.Cells["sender_name_event"].Value.ToString()),
                     //   firstRow.Cells["message_event"].Value.ToString(),
                     //   showTime);
                  }
               }
               Thread.Sleep(ONE_SEC);
            }
            catch (Exception ex) {
               MessageBox.Show("err 1053: " + ex.Message);
            }
         }
      }

      // TODO: edit
      private void dataGridViewListOfEventInsertRow(long id, DateTime currentDateTime, User senderName, string message)
      {
         var numberOfRows = dataGridViewListOfOrders.Rows.Count;
         if (numberOfRows == 0) {
            dataGridViewListOfOrders.Rows.Insert(0, id, currentDateTime, senderName, message);
         } else {
            if (currentDateTime <= Convert.ToDateTime(dataGridViewListOfOrders.Rows[0].Cells[COLUMN_SHOW_TIME].Value)) {
               dataGridViewListOfOrders.Rows.Insert(0, id, currentDateTime, senderName, message);
            } else if (currentDateTime >= Convert.ToDateTime(dataGridViewListOfOrders.Rows[numberOfRows - 1].Cells["date_time_event"].Value)) {
               dataGridViewListOfOrders.Rows.Insert(numberOfRows, id, currentDateTime, senderName, message);
            } else {
               var rowIndex = -1;
               for (var i = 0; i < numberOfRows - 1; i++) {
                  var dtCurr = Convert.ToDateTime(dataGridViewListOfOrders.Rows[i].Cells[COLUMN_SHOW_TIME].Value);
                  var dtNext = Convert.ToDateTime(dataGridViewListOfOrders.Rows[i + 1].Cells[COLUMN_SHOW_TIME].Value);
                  if ((currentDateTime >= dtCurr) & (currentDateTime <= dtNext)) {
                     rowIndex = ++i;
                     break;
                  }
               }
               if (rowIndex == -1) {
                  dataGridViewListOfOrders.Rows.Insert(numberOfRows, id, currentDateTime, senderName, message);
               } else {
                  dataGridViewListOfOrders.Rows.Insert(rowIndex, id, currentDateTime, senderName, message);
               }
            }
         }
      }

      // TODO: edit
      private void UpdateCurrentEvent(string datagram)
      {
         var message = datagram.Split(new string[] { Const.dataSepar }, StringSplitOptions.None);

         var id = message[1];
         var date = message[2];
         var sender_ip = message[3];
         var recipient_ip = message[4];
         var type = message[5];
         var message_text = message[6].ToString().Replace(Const.interchangeableSymbolsDataSepar, Const.dataSepar);
         var status_message = message[7];
         var confirm_reply = message[8];
         var cancel_pressed = message[9];
         var got_id = Convert.ToBoolean(message[10]);

         UpdateRowMethod(id, date, sender_ip, recipient_ip, type, message_text, status_message, confirm_reply, cancel_pressed, got_id);
      }

      // TODO
      private bool RemoveMessagesRowById(string id)
      {
         var rowIndex = -1;
         try {
            foreach (DataGridViewRow row in dataGridViewMessages.Rows) {
               if (row.Cells["id"].Value.Equals(id)) {
                  rowIndex = row.Index;
                  break;
               }
            }

            if (rowIndex == -1) {
               return false;
            }

            dataGridViewMessages.Rows.RemoveAt(rowIndex);
            return true;
         }
         catch {
            return false;
         }
      }
      #endregion

      #region Delegates methods
      // TODO:
      private void UpdateRowMethod(string id, string date, string sender_ip, string recipient_ip, string type, string message, string status_message, string confirm_reply, string cancel_pressed, bool got_id)
      {
         Invoke((MethodInvoker)(() => {
            var rowIndex = -1;
            try {
               foreach (DataGridViewRow row in dataGridViewMessages.Rows) {
                  if (row.Cells["id"].Value.Equals(id)) {
                     rowIndex = row.Index;
                     break;
                  }
               }

               if (rowIndex != -1) {
                  dataGridViewMessages.Rows[rowIndex].Cells["status_message"].Value = status_message;
                  dataGridViewMessages.Rows[rowIndex].Cells["confirm_reply"].Value = confirm_reply;
                  dataGridViewMessages.Rows[rowIndex].Cells["cancel_pressed"].Value = cancel_pressed;
                  dataGridViewMessages.Rows[rowIndex].Cells["got_id"].Value = got_id;
               } else {
                  dataGridViewMessages.Rows.Add(id, date, sender_ip, recipient_ip, type, message, status_message, confirm_reply, cancel_pressed, got_id);
                  //CreateEventHandler(id, sender_ip, message);
               }
            }
            catch (Exception) { }

            Thread.Sleep(MIN_TICK);
         }));
      }

      // TODO:
      private void ShowMessage(long id, string senderName, string message, DateTime showTime)
      {
         Invoke((MethodInvoker)(() => {
            var messageForm = new MessageForm(id, senderName, message, showTime);

            _messageOnline = true;

            var respond = messageForm.ShowDialog(this);
            switch (messageForm.RespondStatus) {
               case DialogResult.OK:
                  // TODO: confirming
                  DataGridViewListOfEventsUpdateRowMethod(id, true, DateTime.Now);
                  break;
               case DialogResult.Ignore:
                  // TODO: dalaying
                  DataGridViewListOfEventsUpdateRowMethod(id, true, DateTime.Now);
                  var currentDateTime = DateTime.Now.AddSeconds(messageForm.SecondsRemindAfter);
                  DataGridViewListOfEventsUpdateRowMethod(id, false, currentDateTime, GetUserFromListBoxName(senderName), message);
                  break;
               default:
                  MessageBox.Show("error 1313 : Unknown \"DialogResult\" command");
                  break;
            }
            // TODO: Message send to server and than update row.
            messageForm.Dispose();
            _messageOnline = false;
         }));
      }

      // TODO: 
      private void DataGridViewListOfEventsUpdateRowMethod(long id, bool delete, DateTime currentDateTime, User sender_name = default(User), string message = "")
      {
         Invoke((MethodInvoker)(() => {
            if ((dataGridViewListOfOrders.RowCount > 0) && delete) {
               dataGridViewListOfOrders.Rows.RemoveAt(0);
            } else { // if (!delete)
               dataGridViewListOfEventInsertRow(id, currentDateTime, sender_name, message);
            }
         }));
      }

      public override void DataGridViewListOfEventsUpdateRowMethod(DataGridView dgv, long id, bool delete, DateTime currentDateTime, User sender_name = default(User), string message = "")
      {
         Invoke((MethodInvoker)(() => {
            if ((dgv.RowCount > 0) && delete) {
               dgv.Rows.RemoveAt(0);
            } else { // if (!delete)
               dataGridViewListOfEventInsertRow(id, currentDateTime, sender_name, message);
            }
         }));
      }
      #endregion

      #region Communication with form
      #region Form events
      private void HolKanClient_Load(object sender, EventArgs e)
      {
         //label1.Text = "Connecting to the database...";
         // TODO: buttonSend.Enabled = false;
      }

      private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         Show();
         WindowState = FormWindowState.Normal;
      }

      // Hide form in a tray
      private void ResizeForm(object sender, EventArgs e)
      {
         if (FormWindowState.Minimized == WindowState) {
            Hide();
         }
      }

      private void timerCurrentDateTime_Tick(object sender, EventArgs e)
      {
         // **** DEBUG
         if (Users.Any()) {
            if (DateTime.Now.Second % 3 == 0) {
               Users[0].IsOnline = true;
               Users[1].IsOnline = false;

            } else {
               Users[0].IsOnline = false;
               Users[1].IsOnline = true;


            }
            UpdateUsersList(Users[0]);
            UpdateUsersList(Users[1]);
         }
         // **** DEBUG

         labelCurrentTime.Text = DateTime.Now.ToString(LABEL_TIME_FORMAT);
      }

      private void HolKanClient_FormClosing(object sender, FormClosingEventArgs e)
      {
         Enabled = false;
         _shouldExit = true;
         Thread.Sleep(CLOSE_ALL_LOOPS_TIMEOUT);
         Application.Exit();
      }

      private void ClearForm()
      {
         CheckAllUsers(false);
         textBoxMessage.Text = string.Empty;
      }
      #endregion

      #region MainMenu
      private void CreateMenu()
      {
         // Create empty menu structure.
         // Menu
         //    Service
         //       Options
         //    Help
         //       About
         var mainMenu = new MainMenu();
         var topMenuItemService = new MenuItem();
         var menuItemOptions = new MenuItem();
         var topMenuItemHelp = new MenuItem();
         var menuItemAbout = new MenuItem();

         topMenuItemService.Text = "&Service";
         menuItemOptions.Text = "&Options";

         topMenuItemHelp.Text = "&Help";
         menuItemAbout.Text = "&About";

         topMenuItemService.MenuItems.Add(menuItemOptions);
         mainMenu.MenuItems.Add(topMenuItemService);

         topMenuItemHelp.MenuItems.Add(menuItemAbout);
         mainMenu.MenuItems.Add(topMenuItemHelp);

         // Add functionality to the menu items using the Click event.
         menuItemOptions.Click += new EventHandler(menuItemOptions_Click);
         menuItemAbout.Click += new EventHandler(menuItemAbout_Click);

         // Assign mainMenu to the form
         Menu = mainMenu;
      }

      // TODO:
      private void menuItemOptions_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Not supported in this version.");
      }

      // TODO:
      private void menuItemAbout_Click(object sender, EventArgs e)
      {
         // Run About forms with feedback input field.
         MessageBox.Show("Not supported in this version.");
      }
      #endregion

      #region ButtonPressed
      private void buttonCheckOnline_Click(object sender, EventArgs e)
      {
         CheckAllUsers(false);
         for (var i = 0; i < checkedListBoxUsers.Items.Count; i++) {
            var user = GetUserFromListBoxName(checkedListBoxUsers.Items[i].ToString());
            if (user.IsOnline) {
               checkedListBoxUsers.SetItemChecked(i, true);
            } else {
               checkedListBoxUsers.SetItemChecked(i, false);
            }
         }
      }

      private void buttonSend_Click(object sender, EventArgs e)
      {
         SendMessageToAllCheckedUsers();
         ClearForm();
      }

      //DELETE for testing
      private void button1_Click(object sender, EventArgs e)
      {
         DataGridViewListOfEventsUpdateRowMethod(33, false, DateTime.Now, new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true), "message2 test");
      }
      //DELETE for testing
      private void button2_Click(object sender, EventArgs e)
      {
         Datagrams.Add(new Datagram(DateTime.Now.AddSeconds(3), "helo", false, IPAddress.Parse("192.168.1.220")));
         //DataGridViewListOfEventsUpdateRowMethod(31, false, DateTime.Now.AddSeconds(1), new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true), "message2111 test");
         //DataGridViewListOfEventsUpdateRowMethod(23, false, DateTime.Now.AddSeconds(20), new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true), "message2 test");
         //DataGridViewListOfEventsUpdateRowMethod(24, false, DateTime.Now.AddSeconds(35), new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true), "message2222 test");
      }
      //DELETE for testing
      private void button3_Click(object sender, EventArgs e)
      {
         var user1 = new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true);
         var user2 = new User(2, IPAddress.Parse("192.168.1.221"), "Федчак Ольга11", false);
         UpdateUsersList(user1);
         UpdateUsersList(user2);
         //Users.Add(user1);
         //Users.Add(user2);
      }
      // DELETE in realize
      private void button4_Click(object sender, EventArgs e)
      {
         HolKanClient_FormClosing(this, null);
      }
      #endregion

      #region CheckBoxChangingValue
      private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
      {
         checkBoxAll.Checked = true;
         CheckAllUsers(true);
      }

      private void checkBoxNone_CheckedChanged(object sender, EventArgs e)
      {
         checkBoxNone.Checked = false;
         CheckAllUsers(false);
      }

      private void CheckAllUsers(bool value)
      {
         for (var i = 0; i < checkedListBoxUsers.Items.Count; i++) {
            checkedListBoxUsers.SetItemChecked(i, value);
         }
      }

      private void checkBoxAdditionalOptions_CheckedChanged(object sender, EventArgs e)
      {
         groupBoxSendersOptions.Visible = checkBoxAdditionalOptions.Checked;
      }

      private void checkBoxPeriod_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownPeriod.Visible
            = comboBoxPeriod.Visible
            = radioButtonLastEventCount.Visible
            = numericUpDownSeveralTimes.Visible
            = labelSeveralTimes.Visible
            = radioButtonLastEventDateTime.Visible
            = dateTimePickerLastShowEventDate.Visible
            = dateTimePickerLastShowEventTime.Visible
            = checkBoxPeriod.Checked;
      }
      #endregion

      #region RadioBoxChangingChoise
      private void ChangeEnablingMainOptions_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownRemindAfter.Enabled
            = comboBoxRemindAfter.Enabled
            = radioButtonAfter.Checked;

         dateTimePickerDate.Enabled
            = dateTimePickerTime.Enabled
            = radioButtonExact.Checked;
      }

      private void ChangeEnablingPeriodicalOptions_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownSeveralTimes.Enabled
            = labelSeveralTimes.Enabled
            = radioButtonLastEventCount.Checked;

         dateTimePickerLastShowEventDate.Enabled
            = dateTimePickerLastShowEventTime.Enabled
            = !radioButtonLastEventCount.Checked;
      }
      #endregion
      #endregion
   }
}