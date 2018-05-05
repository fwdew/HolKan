using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Settings
{
   public enum Type
   {
      // Text
      Message,
      UpdateMessage,
      DeleteMessage,

      // System
      Online,
      //Offline,

      // Configuration
      UserCredential,
      UserStatus,

      // Command
      Restart,
      SoftShutdown,
      HardShutdown,

      // Respond
      Respond
   }

   public enum TypeGroup
   {
      Text,
      System,
      Configuration,
      Command,
      Respond
   }

   public enum StatusMessage
   {
      NonActive,
      // TODO: there is no diff between Active and InQueue
      Active,
      InQueue,
      Confirm
   }

   public class Datagram
   {
      private const long NOT_VALID_ID = -1;
      public bool IsValid => Id != NOT_VALID_ID;

      public static bool owner;

      public long Id { get; set; }
      public long ServerId { get; set; }
      public DateTime CreationTime { get; set; }
      public DateTime ShowTime { get; set; }
      public string Message { get; set; }
      public byte[] SystemMessage { get; set; }
      public bool AlertOnConfirm { get; set; }
      public string ConnectorName { get; set; }
      public string SenderName { get; set; }
      public IPAddress SenderIp { get; set; }
      public byte SenderId { get; set; }
      public string RecipientName { get; set; }
      public IPAddress RecipientIp { get; set; }
      public int RecipientId { get; set; }
      public Type Type { get; set; }
      public TypeGroup TypeGroup {
         get {
            switch (Type) {
               case Type.Message:
               case Type.UpdateMessage:
               case Type.DeleteMessage:
                  return TypeGroup.Text;

               case Type.Online:
               //case Type.Offline:
                  return TypeGroup.System;

               case Type.UserCredential:
               case Type.UserStatus:
                  return TypeGroup.Configuration;

               case Type.Restart:
               case Type.SoftShutdown:
               case Type.HardShutdown:
                  return TypeGroup.Command;

               case Type.Respond:
               default:
                  return TypeGroup.Respond;
            }
         }
      }
      public string Status {
         get {
            switch (statusMessage) {
               case StatusMessage.Confirm:
                  return "Recipient already confirm";
               case StatusMessage.InQueue:
                  return "Recipient got the message";
               case StatusMessage.Active:
                  return "Server got";
               case StatusMessage.NonActive:
               default:
                  return "Send to server";
            }
         }
      }
      public IList<Tuple<DateTime, string>> StatusHistory { get; set; }

      private StatusMessage statusMessage = StatusMessage.NonActive;

      #region Constructor
      public Datagram()
      {
         Id = NOT_VALID_ID;
      }

      public Datagram(byte[] rawBytes)
      {
         try {
            using (var br = new BinaryReader(new MemoryStream(rawBytes))) {
               Id = br.ReadInt64();
               CreationTime = GetTimeFromSeconds(br.ReadDouble());
               ShowTime = GetTimeFromSeconds(br.ReadDouble());
               Message = br.ReadString();
               var systemMessageLength = br.ReadInt32();
               SystemMessage = br.ReadBytes(systemMessageLength);
               AlertOnConfirm = br.ReadBoolean();
            }
         }
         catch (Exception ex) { // TODO:
            throw new Exception("" + "Problem with parsing user byte array" + ex.Message);
         }
      }

      public Datagram(Type type, long id = NOT_VALID_ID)
      {
         Type = type;
         Id = (id == NOT_VALID_ID) ? HolkanBehaviorForm.CreateId() : id;
      }

      // TODO:
      public Datagram(User user)
      {
         Id = HolkanBehaviorForm.CreateId();
         Type = Type.UserCredential;
         SystemMessage = user.CredentialsToByteArray();
      }

      // TODO:
      public Datagram(string message, bool alertMe, IPAddress recipientIp)
      {
         Id = HolkanBehaviorForm.CreateId();
         CreationTime = DateTime.Now;
         ShowTime = DateTime.Now;
         Message = message;
         AlertOnConfirm = alertMe;
         // SenderIp = LocalIp;
         RecipientIp = recipientIp;
         Type = Type.Message;
      }

      public Datagram(DateTime showTime, string message, bool alertMe, IPAddress recipientIp)
         : this(message, alertMe, recipientIp)
      {
         ShowTime = showTime;
      }
      #endregion

      // TODO:
      public void SaveToDB()
      {
         HolKanDao.SaveMessage(
            Id,
            ServerId, GetSecondsFromTime(CreationTime), GetSecondsFromTime(ShowTime), Message, SystemMessage, AlertOnConfirm, SenderId, RecipientId, Type
            );
      }

      private double GetSecondsFromTime(DateTime dateTime)
      {
         return (dateTime - Const.START_EPOCH_TIME).TotalSeconds;
      }

      private DateTime GetTimeFromSeconds(double seconds)
      {
         return Const.START_EPOCH_TIME.AddSeconds(seconds);
      }

      private static byte GetLastPartFromIp(IPAddress ip)
      {
         return ip.GetAddressBytes()[3];
      }

      public byte[] ToByteArray()
      {
         byte[] rawBytes = null;

         using (var bw = new BinaryWriter(new MemoryStream(rawBytes))) {
            bw.Write(Id);
            bw.Write(GetSecondsFromTime(CreationTime));
            bw.Write(GetSecondsFromTime(ShowTime));
            bw.Write(Message);
            bw.Write(SystemMessage.Length);
            bw.Write(SystemMessage);
            bw.Write(AlertOnConfirm);
         }

         return rawBytes;
      }

      public override string ToString()
      {
         return $"[{Id}][from:{SenderIp}][to:{RecipientIp}]";
      }
   }

   public class DatagramList
   {
      private SortedList<DateTime, List<Datagram>> DatagramsSortedList { get; set; }
      private DataGridView DGV { get; set; }
      private HolkanBehaviorForm Parent { get; set; }

      public DatagramList(DataGridView dgv, HolkanBehaviorForm parent)
      {
         DatagramsSortedList = new SortedList<DateTime, List<Datagram>>();
         DGV = dgv;
         Parent = parent;

         foreach (DataGridViewColumn column in DGV.Columns) {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
         }
      }

      public void Add(Datagram datagram)
      {
         AddToDatagramList(datagram);
         AddToDGV();
      }

      // TODO:
      public void Update(Datagram datagram)
      {
         
      }

      public Datagram GetFirst()
      {
         if (DatagramsSortedList.Count == 0) {
            return new Datagram();
         }

         var datagram = DatagramsSortedList.Values[0][0];

         RemoveFirstDatagramFromDatagramList();
         RemoveFromDGV(datagram.Id);

         return datagram;
      }

      #region Datagram List methods
      /// <summary>
      /// Add datagram to list, sorted by own showTime.
      /// </summary>
      private void AddToDatagramList(Datagram datagram)
      {
         var key = datagram.ShowTime;
         if (DatagramsSortedList.ContainsKey(key)) {
            DatagramsSortedList[key].Add(datagram);
         } else {
            DatagramsSortedList.Add(key, new List<Datagram> { datagram });
         }
      }

      /// <summary>
      /// Remove current first datagram from sorted list.
      /// </summary>
      private void RemoveFirstDatagramFromDatagramList()
      {
         DatagramsSortedList.Values[0].RemoveAt(0);
         if (!DatagramsSortedList.Values[0].Any()) {
            DatagramsSortedList.RemoveAt(0);
         }
      }
      #endregion

      #region DGV methods
      // TODO:
      private void AddToDGV()
      {
         //Parent.DataGridViewListOfEventsUpdateRowMethod(DGV, 31, false, DateTime.Now.AddSeconds(1), new User(1, IPAddress.Parse("192.168.1.220"), "Федчак Ольга", true), "message2111 test");
      }

      // TODO:
      private void RemoveFromDGV(long id)
      {
         for (var i = 0; i < DGV.RowCount; i++) {
            if (Convert.ToInt64(DGV.Rows[i].Cells["id"].Value) == id) {
               DGV.Rows.RemoveAt(i);
               break;
            }
         }
         //if (DatagramsSortedList.Values.Count > 1) {
         //   DatagramsSortedList.Values[0].RemoveAt(0);
         //} else {
         //   DatagramsSortedList.RemoveAt(0);
         //}
      }
      #endregion
   }
}
