using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace Settings
{
   public class Packet
   {
      public long Id { get; private set; }
      public IPAddress RecipientIp { get; private set; }
      public Datagram Datagram { get; private set; }

      public Packet(byte[] rawBytes)
      {
         try {
            using (var binaryReader = new BinaryReader(new MemoryStream(rawBytes))) {
               Id = binaryReader.ReadInt64();
               Datagram = new Datagram(binaryReader.ReadBytes(rawBytes.Length - sizeof(long)));
            }
         }
         catch (Exception ex) { // TODO:
            //throw new Exception("" + "Problem with parsing income packet" + ex.Message);
         }
      }

      public Packet(IPAddress recipientIp, Datagram datagram)
      {
         Id = HolkanBehaviorForm.CreateId();
         RecipientIp = recipientIp;
         Datagram = datagram;
      }

      public Packet(User user, Datagram datagram) : this(user.Ip, datagram) { }

      public byte[] ToByteArray()
      {
         return BitConverter.GetBytes(Id)
            .Concat(Datagram.ToByteArray())
            .ToArray();
      }

      // maybe needless
      public bool Equals(Packet packet)
      {
         if (ReferenceEquals(null, packet)) return false;
         if (ReferenceEquals(this, packet)) return true;
         return Equals(Id, packet.Id)
            && Equals(RecipientIp, packet.RecipientIp)
            && Equals(Datagram, packet.Datagram);
      }

      public override string ToString()
      {
         return $"{Id}[{RecipientIp}]";
      }
   }
}
