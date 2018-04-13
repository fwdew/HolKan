using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Settings
{
   public class User
   {
      private const string ONLINE_TEXT = " (online)";
      private const string OFFLINE_TEXT = "";

      public int Id { get; private set; }
      public IPAddress Ip { get; private set; }
      public string Name { get; private set; }
      public bool IsOnline { get; set; }

      // server side property
      // indicates whether user already synchronyzed with server
      // (all configurations are delivered to the user
      // and we can send him all datagrams)
      public bool isReady = false;

      public string ListViewName => Name + ((IsOnline) ? ONLINE_TEXT : OFFLINE_TEXT);

      public User(int id, IPAddress ip, string name, bool online = false)
      {
         Id = id;
         Ip = ip;
         Name = name;
         IsOnline = online;
      }

      public User(byte[] rawBytes)
      {
         try {
            using (var br = new BinaryReader(new MemoryStream(rawBytes))) {
               Id = br.ReadInt32();
               Ip = IPAddress.Parse(br.ReadString());
               Name = br.ReadString();
               IsOnline = false;
            }
         }
         catch (Exception ex) { // TODO:
            throw new Exception("" + "Problem with parsing user byte array" + ex.Message);
         }
      }

      /// <summary>
      /// Save Id, Ip, Name in byte array.
      /// </summary>
      /// <returns>Return credential for creating new user.</returns>
      public byte[] CredentialsToByteArray()
      {
         byte[] rawBytes = null;
         using (var bw = new BinaryWriter(new MemoryStream(rawBytes))) {
            bw.Write(Id);
            bw.Write(Ip.ToString());
            bw.Write(Name);
         }
         return rawBytes;
      }

      public void UpdateCredentials(User newUser)
      {
         Ip = newUser.Ip;
         Name = newUser.Name;
      }

      public static Tuple<int, bool> GetStatusFromByteArray(byte[] rawBytes)
      {
         var id = BitConverter.ToInt32(rawBytes, 0);
         var online = BitConverter.ToBoolean(rawBytes, 4);

         return Tuple.Create(id, online);
      }

      public byte[] StatusToByteArray()
      {
         return BitConverter.GetBytes(Id)
            .Concat(BitConverter.GetBytes(IsOnline))
            .ToArray();
      }

      public bool Equals(User user)
      {
         if (user == null) return false;
         if (user == this) return true;
         if (Id == user.Id) return true;
         return false;
      }

      public bool Equals(string listViewUserName)
      {
         return string.Equals(Name, listViewUserName.Replace(ONLINE_TEXT, OFFLINE_TEXT));
      }

      public override string ToString()
      {
         return $"[{Ip}] {ListViewName}";
      }
   }
}