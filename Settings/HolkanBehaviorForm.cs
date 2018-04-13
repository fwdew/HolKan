using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Settings
{
   public class HolkanBehaviorForm : Form
   {
      private const int packageLength = 2;
      protected const string setupFileXml = "D:\\HolKanUsers.xml";
      private const string file_path_xml = "test.xml";
      private const string errorsDirectoryPath = "D:\\Errs";
      private const string errorsFilePath = "errors.txt";
      private const string datagramsDirectoryPath = "D:\\Data";
      private const string datagramsFilePath = "data.txt";
      private const string logFileNameFormatStart = "yyyy-MM-dd-";
      protected static int countDownToExit = 5;
      protected const int lastPartIdNumberLength = 3;
      protected const string ipLastNumberFormat = "000";
      protected const string idDateTimeFormat = "yyyyMMddHHmmssfffffff";
      protected static int idLength = ipLastNumberFormat.Length + idDateTimeFormat.Length + lastPartIdNumberLength;
      protected static int lastPartIdNumber = 0;
      protected static int lastPartIdNumberModule = Convert.ToInt32(Math.Pow(10, lastPartIdNumberLength));
      protected static IPAddress localIpAdress;
      protected static string ipLastNumber;
      protected static string lastPartIdNumberFormat = new String('0', lastPartIdNumberLength);

      protected const int ONE_SEC = Const.ONE_SEC;
      protected const int MIN_TICK = 15;
      protected const int RECEIVE_TIMEOUT = ONE_SEC;
      protected static int CLOSE_ALL_LOOPS_TIMEOUT = Math.Max(Math.Max(ONE_SEC, MIN_TICK), RECEIVE_TIMEOUT) + 1;

      public const string LABEL_TIME_FORMAT = "dd.MM.yyyy HH:mm:ss";

      protected List<User> Users = new List<User>();
      protected List<Packet> OutcomePacketList = new List<Packet>();
      protected DatagramList Datagrams { get; set; }// = new DatagramSortedList();

      protected CheckedListBox checkedListBoxUsers;
      protected volatile bool _shouldExit = false;
      protected static int ReceiverPort;

      // Disable close button main form
      protected override CreateParams CreateParams {
         get {
            var paramsWithoutCloseButton = base.CreateParams;
            paramsWithoutCloseButton.ClassStyle |= 0x200;
            return paramsWithoutCloseButton;
         }
      }

      public HolkanBehaviorForm()
      {
         new Thread(new ThreadStart(ReceivePacket)).Start();
         new Thread(new ThreadStart(SendingPool)).Start();
      }

      public static long CreateId()
      {
         Thread.Sleep(1);
         return (long)DateTime.Now.Subtract(Const.START_EPOCH_TIME).TotalMilliseconds;
      }

      #region IpAddress
      protected static IPAddress GetLocalIPAddress()
      {
         return Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)?.First();
      }

      // TODO: edit to {0:N0}
      protected static string GetLastPartIdNumber()
      {
         lastPartIdNumber++;
         lastPartIdNumber %= lastPartIdNumberModule;
         return lastPartIdNumber.ToString(lastPartIdNumberFormat);
      }

      // TODO: needless anymore
      protected static string GetLastPartFromIp(IPAddress ip)
      {
         return Convert.ToInt32(ip.ToString().Split(new string[] { "." }, StringSplitOptions.None)[3]).ToString(ipLastNumberFormat);
      }

      private static IPEndPoint GetRecipientIPEndPoint(IPAddress ip)
      {
         return new IPEndPoint(ip, Const.serverPort);
      }
      #endregion

      #region Users
      // TODO:
      protected User GetUserFromIp(IPAddress ip)
      {
         return Users.FirstOrDefault(user => user.Ip == ip);
      }

      // TODO: move to Client form
      protected User GetUserFromListBoxName(string listBoxName)
      {
         return Users.FirstOrDefault(user => user.Equals(listBoxName));
      }

      protected void UpdateUser(byte[] rawBytes)
      {
         var newUser = new User(rawBytes);
         foreach (var user in Users.Where(x => x.Equals(newUser))) {
            user.UpdateCredentials(newUser);
            // TODO: recreate user list from Users
            //UpdateUsersList(user);
            return;
         }
         //Users.Add(newUser);
         UpdateUsersList(newUser);
      }

      protected void UpdateUserStatus(byte[] rawBytes)
      {
         var userWithStatus = User.GetStatusFromByteArray(rawBytes);
         var user = Users.Where(x => x.Id == userWithStatus.Item1).First();
         user.IsOnline = userWithStatus.Item2;
         UpdateUsersList(user);
      }

      protected void UpdateUsersList(User user)
      {
         if (string.IsNullOrEmpty(user.Name)) {
            return;
         }

         checkedListBoxUsers.Invoke((MethodInvoker)(() => {
            var createNewUser = true;

            for (var i = 0; i < checkedListBoxUsers.Items.Count; i++) {
               var userFromList = GetUserFromListBoxName(checkedListBoxUsers.Items[i].ToString());
               if (user.Equals(userFromList)) {
                  userFromList.IsOnline = !user.IsOnline;
                  checkedListBoxUsers.Items[i] = userFromList.ListViewName;
                  createNewUser = false;
                  break;
               }
            }

            if (createNewUser) {
               Users.Add(user);
               checkedListBoxUsers.Items.Add(user.ListViewName);
            }
         }));
      }
      #endregion

      #region Send packets
      private static void SendPacket(Packet packet)
      {
         try {
            using (var sender = new UdpClient(GetRecipientIPEndPoint(packet.RecipientIp))) {
               var bytesToSend = packet.ToByteArray();
               sender.Send(bytesToSend, bytesToSend.Length);
            }
         }
         catch (Exception ex) {
            LogError(Const.EX_01, ex, false);
         }
      }

      private void SendingPool()
      {
         while (!_shouldExit) {
            try {
               foreach (var packet in OutcomePacketList) {
                  SendPacket(packet);
               }
               Thread.Sleep(ONE_SEC);
            }
            catch (Exception ex) {
               LogError("P1 : " + ex.ToString());
            }
         }
      }

      protected void AddToSendingPool(IEnumerable<Packet> packets)
      {
         foreach (var packet in packets) {
            AddToSendingPool(packet);
         }
      }

      protected void AddToSendingPool(Packet packet)
      {
         try {
            OutcomePacketList.Add(packet);
         }
         catch (Exception ex) {
            LogError("P1 : " + ex.ToString());
         }
      }

      private void SendRespond(long incomeId, IPAddress senderIp)
      {
         SendPacket(CreateRespondPacket(incomeId, senderIp));
      }

      private Packet CreateRespondPacket(long incomeId, IPAddress senderIp)
      {
         return new Packet(
            senderIp,
            new Datagram(Type.Respond, incomeId));
      }

      protected void SendDatagramToEveryOnlineUsers(Datagram datagram)
      {
         Users.Where(user => user.IsOnline).ToList().ForEach(user => AddToSendingPool(new Packet(user, datagram)));
      }

      // TODO:
      protected void InformServerAboutStartUp()
      {
         AddToSendingPool(
            new Packet(
               Const.serverIpAdress,
               new Datagram(Type.Online))
            );
      }
      #endregion

      #region Receive packets
      private void RemoveFromSendingPool(long id)
      {
         try { OutcomePacketList.RemoveAll(packet => packet.Id == id); }
         catch { }
      }

      protected void RemoveFromSendingPool(User user)
      {
         try { OutcomePacketList.RemoveAll(packet => packet.RecipientIp == user.Ip); }
         catch { }
      }

      private void ReceivePacket()
      {
         while (!_shouldExit) {
            using (var receiver = new UdpClient(ReceiverPort)) {
               receiver.Client.ReceiveTimeout = RECEIVE_TIMEOUT;
               var remoteIp = new IPEndPoint(IPAddress.Any, 0);
               try {
                  var rawBytes = receiver.Receive(ref remoteIp);
                  AnalyzeIncomePacket(new Packet(rawBytes), remoteIp.Address);
               }
               catch (Exception ex) {
                  LogError("P1 : " + ex.ToString());
               }
            }
         }
      }

      private void AnalyzeIncomePacket(Packet packet, IPAddress senderIp)
      {
         switch (packet.Datagram.TypeGroup) {
            case TypeGroup.Text:
               AnalyzeIncomeTextDatagram(packet.Datagram);
               break;

            case TypeGroup.System:
               AnalyzeIncomeSystemDatagram(packet.Datagram);
               break;

            case TypeGroup.Configuration:
               AnalyzeIncomeConfigDatagram(packet.Datagram);
               break;

            case TypeGroup.Command:
               AnalyzeIncomeCommandDatagram(packet.Datagram);
               break;

            case TypeGroup.Respond:
               RemoveFromSendingPool(packet.Datagram.Id);
               return;
         }
         SendRespond(packet.Id, senderIp);
      }

      protected virtual void AnalyzeIncomeTextDatagram(Datagram datagram) { }

      protected virtual void AnalyzeIncomeSystemDatagram(Datagram datagram) { }

      protected virtual void AnalyzeIncomeConfigDatagram(Datagram datagram) { }

      protected virtual void AnalyzeIncomeCommandDatagram(Datagram datagram) { }
      #endregion

      #region LogToFile
      public static void LogToLocalFile(string text)
      {
         LogToFile(text, datagramsDirectoryPath, datagramsFilePath);
      }

      // TODO: Maybe just send error to the server and let him to save in his local file
      // to avoid not thread saving writting
      public static void LogToNetworkFile(string text)
      {
         LogToFile(text, datagramsDirectoryPath, datagramsFilePath);
      }

      public static void LogToFile(string text, string directory, string fileName)
      {
         //DEBUG
         return;
         if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
         }

         var filePath = Path.Combine(directory, DateTime.Now.ToString(logFileNameFormatStart) + fileName);
         var logger = (!File.Exists(filePath))
            ? new StreamWriter(filePath)
            : File.AppendText(filePath);

         logger.WriteLine($"{DateTime.Now} : {text}");
         logger.Close();
      }

      // TODO: why?
      public static void LogDatagramsTraffic(string text)
      {
         LogToFile(text, datagramsDirectoryPath, datagramsFilePath);
      }

      // TODO: Maybe remove description
      public static void LogError(int exceptionIndex, Exception ex, bool show = false, string description = "")
      {
         var exception = $"[{exceptionIndex}]{description}: {ex.ToString()}\n{ex.Message}";
         if (show) {
            MessageBox.Show(exception);
         }
         LogError(exception);
      }

      // TODO: maybe logToLocalFile and logToNetworkFile
      public static void LogError(string text)
      {
         LogToFile(text, errorsDirectoryPath, errorsFilePath);
      }
      #endregion

      public virtual void DataGridViewListOfEventsUpdateRowMethod(DataGridView dgv, long id, bool delete, DateTime currentDateTime, User sender_name = default(User), string message = "")
      {
         
      }
   }
}
