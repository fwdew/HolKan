using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Settings;

namespace Server
{
   public partial class HolKanServerForm : HolkanBehaviorForm
   {
      public HolKanServerForm()
      {
         InitializeComponent();
         SetUpPrimaryConfiguration();
      }

      // TODO
      private void SetUpPrimaryConfiguration()
      {
         base.checkedListBoxUsers = checkedListBoxUsers;
         ReceiverPort = Const.clientPort;

         //ipLastNumber = GetLastPartFromIp(Const.adminIpAdress);

         //CreateUsersList();

         dataGridViewEvents.Columns["message"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
         dataGridViewEvents.Sort(dataGridViewEvents.Columns["id"], ListSortDirection.Ascending);

         // Create or just use local DB.
         HolKanDao.CreateDB();
      }

      // TODO
      private void AddNewRowMethod(string id, string date, string senderIp, string recipientIp, string type, string message, string statusMessage, string confirmReply, string cancelPressed, bool gotId)
      {
         Invoke((MethodInvoker)(() => {
            dataGridViewEvents.Rows.Add(id, date, senderIp, recipientIp, type, message, statusMessage, confirmReply, cancelPressed, gotId);
            Thread.Sleep(MIN_TICK);
         }));
      }

      // TODO
      //private static string GetLastPartFromIp(string ip)
      //{
      //   return ip.Split(new string[] { "." }, StringSplitOptions.None)[3];
      //}

      // TODO
      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         //    var senderGrid = (DataGridView)sender;
         //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
         //        e.RowIndex >= 0)
         //    {
         //        string id = "";
         //        bool got_id = false;
         //        try
         //        {
         //            id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
         //            got_id = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["got_id"].Value);
         //        }
         //        catch (Exception) { }

         //        DialogResult confirm = ((id != "") && (got_id)) ?
         //            MessageBox.Show("Delete event № " + id + " ?", "Warning!!!", MessageBoxButtons.YesNo) :
         //            System.Windows.Forms.DialogResult.No;

         //        if (confirm == System.Windows.Forms.DialogResult.Yes)
         //        {
         //            string sender_ip = dataGridView1.CurrentRow.Cells["sender_ip"].Value.ToString();
         //            string recipient_ip = dataGridView1.CurrentRow.Cells["recipient_ip"].Value.ToString();
         //            //Send(system + Const.dataSepar + "erase" + Const.dataSepar + id, sender_ip);
         //            //if (!(sender_ip.Equals(recipient_ip)))
         //            //{
         //            //    Send(system + Const.dataSepar + "erase" + Const.dataSepar + id, recipient_ip);
         //            //}
         //            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
         //            //dataGridView1.Rows.RemoveAt(e.RowIndex);
         //            //DeleteEventFromXml(id);
         //        }
         //    }
      }

      #region Sending data
      // TODO
      private string FormingDatagram(string sendingDatagramType, params string[] parameters)
      {
         return /*new MessageSPEC(*/sendingDatagramType/*, parameters).ToString()*/;
      }

      // TODO:
      private void SendAllEventsAboutCurrentIp(string recipientIp)
      {
         //TODO:
         try {
            var rowIndex = -1;
            foreach (DataGridViewRow row in dataGridViewEvents.Rows) {
               var sender_id = row.Cells["sender_ip"].Value.ToString();
               var recipient_id = row.Cells["recipient_ip"].Value.ToString();

               if ((recipientIp.Equals(sender_id)) || (recipientIp.Equals(recipient_id))) {
                  rowIndex = row.Index;

                  var id = dataGridViewEvents.Rows[rowIndex].Cells["id"].Value.ToString();
                  var date = dataGridViewEvents.Rows[rowIndex].Cells["date"].Value.ToString();
                  var sender_ip = dataGridViewEvents.Rows[rowIndex].Cells["sender_ip"].Value.ToString();
                  var recipient_ip = dataGridViewEvents.Rows[rowIndex].Cells["recipient_ip"].Value.ToString();
                  var type = dataGridViewEvents.Rows[rowIndex].Cells["type"].Value.ToString();
                  var message = dataGridViewEvents.Rows[rowIndex].Cells["message"].Value.ToString();
                  var status_message = dataGridViewEvents.Rows[rowIndex].Cells["status_message"].Value.ToString();
                  var confirm_reply = dataGridViewEvents.Rows[rowIndex].Cells["confirm_reply"].Value.ToString();
                  var cancel_pressed = dataGridViewEvents.Rows[rowIndex].Cells["cancel_pressed"].Value.ToString();
                  var got_id = dataGridViewEvents.Rows[rowIndex].Cells["got_id"].Value.ToString();

                  message.Replace(Const.dataSepar, Const.interchangeableSymbolsDataSepar);
                  //SendDatagram(Const.eventData
                  //    + Const.dataSepar + id
                  //    + Const.dataSepar + date
                  //    + Const.dataSepar + sender_ip
                  //    + Const.dataSepar + recipient_ip
                  //    + Const.dataSepar + type
                  //    + Const.dataSepar + message
                  //    + Const.dataSepar + status_message
                  //    + Const.dataSepar + confirm_reply
                  //    + Const.dataSepar + cancel_pressed
                  //    + Const.dataSepar + got_id
                  //    , recipientIp);
               }
            }
            //TODO: SendDatagram(Const.system + Const.dataSepar + Const.allEventsSynchronized, message[2]);
         }
         catch (Exception ex) {
            // TODO: send "system" message to restart program. After 3 times restart in a row close program with reporting Error message
            MessageBox.Show(recipientIp + " can't synchronizing some events: " + ex.Message);
         }

      }

      // TODO
      private void SendAllUsers(User recipientUser)
      {
         Users.ForEach(user => AddToSendingPool(new Packet(recipientUser, new Datagram(user))));
      }
      #endregion

      #region Analyzing income data
      // TODO:
      protected override void AnalyzeIncomeTextDatagram(Datagram datagram)
      {
         switch (datagram.Type) {
            case Settings.Type.Message:
               // Create message with new id
               // send message to recepient user
               // update message to sender user
               break;
            case Settings.Type.UpdateMessage:
               // update message
               // send message to recepient user
               // update message to sender user
               break;
            case Settings.Type.DeleteMessage:
               // mark as delete message
               // send del message command to recepient user
               // update del message command to sender user
               break;
         }
      }

      protected override void AnalyzeIncomeSystemDatagram(Datagram datagram)
      {
         // user = datagram.GetUser()
         switch (datagram.Type) {
            case Settings.Type.Online:
               // UpdateUsersList
               // Synchronyzing configs with user
               // if synchronyzed set IsReady to true
               // send all messages
               break;
            //case Settings.Type.Offline:
               // RemoveFromSendingPool(user);
               // send all 
               break;
         }
      }
      #endregion

      #region Updating user list
      // TODO:
      private void CreateUsersList()
      {
         var xmlDoc = new XmlDocument();

         try {
            xmlDoc.Load(setupFileXml);

            foreach (XmlNode node in xmlDoc.SelectSingleNode("//main//users").ChildNodes) {
               //UpdateUsersListMethod(new User(node.Attributes["ip"].InnerText, node.InnerText, Const.offlineText.ToString()));
            }
         }
         catch (Exception ex) {
            LogError("X1 : " + ex.ToString());
         }
      }
      #endregion
   }
}