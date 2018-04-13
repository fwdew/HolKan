using System;
using System.Windows.Forms;
using Settings;

namespace Client
{
   public partial class OptionsForm : Form
   {
      public OptionsForm()
      {
         InitializeComponent();
         SetDefaultValues();
      }

      private void SetDefaultValues()
      {
         numericUpDownDelayButton5.Value = Const.delayButton5;
         numericUpDownDelayButton10.Value = Convert.ToDecimal(Const.delayButton10);
         numericUpDownDelayIgnoring.Value = Convert.ToDecimal(Const.delayIgnoring);
         numericUpDownStartCountdown.Value = Convert.ToDecimal(Const.countdownStart);
         numericUpDownAutoCloseForm.Value = Convert.ToDecimal(Const.autoCloseForm);
         checkBoxEnableSound.Checked = Convert.ToBoolean(Const.beep);
      }

      private void buttonOk_Click(object sender, EventArgs e)
      {
         Const.delayButton5 = (int)numericUpDownDelayButton5.Value;
         Const.delayButton10 = (int)numericUpDownDelayButton10.Value;
         Const.delayIgnoring = (int)numericUpDownDelayIgnoring.Value;
         Const.countdownStart = (int)numericUpDownStartCountdown.Value;
         Const.autoCloseForm = (int)numericUpDownAutoCloseForm.Value;
         Const.beep = Convert.ToInt32(checkBoxEnableSound.Checked);
      }
      private const string setupfile_xml = "setup_timers.xml";
   }
}
