using Settings;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
   public partial class MessageForm : Form
   {
      private const byte DELAY_5_MINUTES = 5;
      private const byte DELAY_10_MINUTES = 10;
      private const byte DELAY_IGNORE_MINUTES = 15;
      private const int minutesDelay5 = DELAY_5_MINUTES * 60;
      private const int minutesDelay10 = DELAY_10_MINUTES * 60;
      private const int minutesDelayIgnore = DELAY_IGNORE_MINUTES * 60;
      private const int COUNTDOWN_TIMER_START_SECONDS = 3;
      private const int AUTO_CLOSE_FORM_SECONDS = 10;
      private const string TIME_FORMAT = MainForm.LABEL_TIME_FORMAT;

      private readonly long id;
      private readonly string senderName;
      private readonly string message;
      private readonly DateTime showTime; // datetime when message must be shown

      private DateTime lastActivity = DateTime.Now;
      private volatile bool _shouldStop = false;
      private int secondsLeft = 0;

      // respond number of seconds after which reshow current message
      public double SecondsRemindAfter { get; private set; }
      // respond status of OK (confirm) or Ignore (Ignoring or dalaying) current message
      public DialogResult RespondStatus { get; private set; }

      #region Constructor
      public MessageForm(long id, string senderName, string message, DateTime showTime)
      {
         InitializeComponent();

         this.id = id;
         this.senderName = senderName;
         this.message = message;
         this.showTime = showTime;

         ConfigureForm();

         new Thread(new ThreadStart(AutoShowTimer)).Start();
      }

      private void ConfigureForm()
      {
         comboBoxRemindAfter.Items.AddRange(Const.timeStepsList.ToArray());
         comboBoxRemindAfter.Text = TimeSteps.seconds.ToString();
         dateTimePickerDate.MaxDate = DateTime.Now.AddYears(10);

         buttonDelay5.Text = DELAY_5_MINUTES.ToString();
         buttonDelay10.Text = DELAY_10_MINUTES.ToString();

         labelExact.Visible
            = labelAfter.Visible
            = numericUpDownRemindAfter.Visible
            = comboBoxRemindAfter.Visible
            = buttonRemindExact.Visible
            = buttonRemindAfter.Visible
            = dateTimePickerDate.Visible
            = dateTimePickerTime.Visible
            = buttonWait.Visible
            = false;

         Text = id.ToString();
         textBoxMessage.Text = message;
         labelShowTime.Text = $"{showTime.ToString(TIME_FORMAT)}";
         labelUserSendMessage.Text = $"{senderName} sent you a message.";

         labelAutoClosing.Text = "";
         secondsLeft = AUTO_CLOSE_FORM_SECONDS - COUNTDOWN_TIMER_START_SECONDS;
         timer.Stop();

         // just in case
         SecondsRemindAfter = 0;
         RespondStatus = DialogResult.Ignore;
      }
      #endregion

      #region Timer's event
      private void AutoShowTimer()
      {
         while (!_shouldStop) {
            try {
               if (DateTime.Now > lastActivity.AddSeconds(COUNTDOWN_TIMER_START_SECONDS)) {
                  Tick();

                  if (DateTime.Now > lastActivity.AddSeconds(AUTO_CLOSE_FORM_SECONDS)) {
                     CloseForm();
                  }

                  Thread.Sleep(Const.ONE_SEC);
               }
            }
            catch (Exception ex) {
               // TODO:
               MessageBox.Show("err 1054: " + ex.Message);
            }
         }
      }

      private void CloseForm()
      {
         Invoke((MethodInvoker)(() => {
            DialogResult = DialogResult.OK;
            Exit(DialogResult.Ignore, minutesDelayIgnore);
         }));
      }

      private void ResetWaitTimer(object sender = null, object e = null)
      {
         secondsLeft = AUTO_CLOSE_FORM_SECONDS - COUNTDOWN_TIMER_START_SECONDS;
         lastActivity = DateTime.Now;
         labelAutoClosing.Text = "";
         buttonWait.Invoke((MethodInvoker)(() => buttonWait.Visible = false));
      }

      private void Tick(object sender = null, EventArgs e = null)
      {
         labelAutoClosing.Invoke((MethodInvoker)(() => labelAutoClosing.Text = $"Auto close window after {secondsLeft} sec."));
         buttonWait.Invoke((MethodInvoker)(() => buttonWait.Visible = true));
         secondsLeft--;
      }
      #endregion

      #region Communication with form
      private void checkBoxAdditionalOptions_CheckedChanged(object sender, EventArgs e)
      {
         ResetWaitTimer();
         labelExact.Visible
            = labelAfter.Visible
            = numericUpDownRemindAfter.Visible
            = comboBoxRemindAfter.Visible
            = buttonRemindExact.Visible
            = buttonRemindAfter.Visible
            = dateTimePickerDate.Visible
            = dateTimePickerTime.Visible
            = checkBoxAdditionalOptions.Checked;
      }

      private void buttonConfirm_Click(object sender, EventArgs e)
      {
         Exit(DialogResult.OK);
      }

      private void buttonDelay5_Click(object sender, EventArgs e)
      {
         Exit(DialogResult.Ignore, minutesDelay5);
      }

      private void buttonDelay10_Click(object sender, EventArgs e)
      {
         Exit(DialogResult.Ignore, minutesDelay10);
      }

      private void buttonRemindAfter_Click(object sender, EventArgs e)
      {
         Exit(DialogResult.Ignore,
            MainForm.GetTotalSecondsToNextShowTime(numericUpDownRemindAfter, comboBoxRemindAfter));
      }

      private void buttonRemindExact_Click(object sender, EventArgs e)
      {
         Exit(DialogResult.Ignore,
            (MainForm.GetShowTimeExact(dateTimePickerDate, dateTimePickerTime) - DateTime.Now).TotalSeconds);
      }

      private void buttonWait_Click(object sender, EventArgs e)
      {
         ResetWaitTimer();
      }
      #endregion

      private void Exit(DialogResult respondStatus, double secondsRemindAfter = 0)
      {
         _shouldStop = true;
         RespondStatus = respondStatus;
         SecondsRemindAfter = secondsRemindAfter;
      }
   }
}