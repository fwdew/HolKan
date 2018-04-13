using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configure;

namespace Server
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         if (ConfigurationNeeded()) {
            Application.Run(new ConfigurationForm());
            if (!ConfigurationNeeded()) {
               Application.Run(new HolKanServerForm());
            }
         } else {
            Application.Run(new HolKanServerForm());
         }
      }

      // Check if all configuration files already exist.
      private static bool ConfigurationNeeded()
      {
         // DEBUG
         return false;

         var path = "1";
         if (File.Exists(path)) {
            return false;
         }
         return true;
      }
   }
}
