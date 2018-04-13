using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Settings
{
   public enum TimeSteps
   {
      seconds,
      minutes,
      hours,
      days,
      weeks,
      months,
      years
   }

   public static class Const
   {
      private const string SETUP_FILE_XML = "D:\\HolKanSettings.xml";

      #region exception markers
      public const int EX_01 = 1000;
      public const int EX_02 = 1001; // not in use
      public const int EX_03 = 1002; // not in use
      public const int EX_04 = 1001; // not in use
      public const int EX_05 = 1002; // not in use
      public const int EX_06 = 1001; // not in use
      public const int EX_07 = 1002; // not in use
      public const int EX_08 = 1001; // not in use
      public const int EX_09 = 1002; // not in use
      #endregion

      // TODO: put this constant in Client side only
      public static IList<string> timeStepsList;

      #region static readonly int
      public static readonly int serverPort = 5016;
      public static readonly int clientPort = 5017;
      public static readonly int datagramLength;
      #endregion

      public static DateTime START_EPOCH_TIME = new DateTime(2018, 04, 01, 0, 0, 0, 0, DateTimeKind.Utc);

      #region static readonly string
      public static readonly IPAddress serverIpAdress = IPAddress.Parse("192.168.1.2");
      // TODO: remove
      public static readonly string adminIpAdress;

      public static readonly string request;
      public static readonly string respond;
      public static readonly string system;
      public static readonly string eventData;
      public static readonly string config;
      public static readonly string settings;

      public static readonly string dataTypeSepar;
      public static readonly string dataSepar;
      public static readonly string datagramSeparator;
      public static readonly string interchangeableSymbolsDataTypeSepar;
      public static readonly string interchangeableSymbolsDataSepar;
      public static readonly string interchangeableSymbolsEndOfDatagram;

      public static readonly string startingProgram;
      public static readonly string closingProgram;
      public static readonly string allEventsSynchronized;
      public static readonly string error;
      public static readonly string erase;

      public static readonly string onlineText = " (online)";
      public static readonly string offlineText = "";

      // TODO: maybe needless at all
      public static readonly string seconds;
      public static readonly string minutes;
      public static readonly string hours;
      public static readonly string days;
      public static readonly string weeks;
      public static readonly string months;
      public static readonly string years;
      // TODO: maybe needless at all
      public static readonly string immediatly;
      public static readonly string after;
      public static readonly string exact;
      #endregion

      #region static int
      // TODO: put this constant in Client side only
      public static int delayButton5 = 5;
      public static int delayButton10 = 10;
      public static int delayIgnoring = 15;
      public static int countdownStart = 3;
      public static int autoCloseForm = 7;
      // TODO: int => bool
      public static int beep;
      #endregion

      public const int ONE_SEC = 1000;

      static Const()
      {
         timeStepsList = new List<string>();
         timeStepsList.Add(TimeSteps.seconds.ToString());
         timeStepsList.Add(TimeSteps.minutes.ToString());
         timeStepsList.Add(TimeSteps.hours.ToString());
         timeStepsList.Add(TimeSteps.days.ToString());
         timeStepsList.Add(TimeSteps.weeks.ToString());
         timeStepsList.Add(TimeSteps.months.ToString());
         timeStepsList.Add(TimeSteps.years.ToString());

         var xmlDoc = new XmlDocument();
         var examType = typeof(Const);

         try {
            xmlDoc.Load(SETUP_FILE_XML);

            foreach (XmlNode node in xmlDoc.SelectSingleNode("//main//constantsInt").ChildNodes) {
               var piShared = examType.GetField(node.LocalName);
               piShared.SetValue(null, Convert.ToInt32(node.InnerText));
            }

            foreach (XmlNode node in xmlDoc.SelectSingleNode("//main//constantsString").ChildNodes) {
               var piShared = examType.GetField(node.LocalName);
               piShared.SetValue(null, node.InnerText);
            }

            foreach (XmlNode node in xmlDoc.SelectSingleNode("//main//commands").ChildNodes) {
               var piShared = examType.GetField(node.LocalName);
               piShared.SetValue(null, node.InnerText);
            }

            foreach (XmlNode node in xmlDoc.SelectSingleNode("//main//localSettings").ChildNodes) {
               var piShared = examType.GetField(node.LocalName);
               piShared.SetValue(null, Convert.ToInt32(node.InnerText));
            }
         }
         catch /*(Exception ex)*/ {
            //TODO:
            //HolKanServerForm.LogErrors("C1 : " + ex.ToString());
         }
      }
   }
}
