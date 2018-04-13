using System;
using System.IO;
using System.Windows.Forms;

namespace Configure
{
   public partial class ConfigurationForm : Form
   {
      public ConfigurationForm()
      {
         InitializeComponent();
      }

      #region Buttons
      private void buttonConfigure_Click(object sender, EventArgs e)
      {
         RewriteConfigFiles();
      }

      private void buttonReset_Click(object sender, EventArgs e)
      {

      }
      #endregion

      // TODO: create config files outside of ProgramFiles (Application folder)
      private static void RewriteConfigFiles()
      {
         var path = @"1";
         if (!File.Exists(path)) {
            File.Create(path);
         }
      }
   }
}
