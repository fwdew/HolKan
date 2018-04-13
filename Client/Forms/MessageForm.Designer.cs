namespace Client
{
   partial class MessageForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.textBoxMessage = new System.Windows.Forms.TextBox();
         this.labelUserSendMessage = new System.Windows.Forms.Label();
         this.labelAutoClosing = new System.Windows.Forms.Label();
         this.labelRemindAfter = new System.Windows.Forms.Label();
         this.labelMinutes = new System.Windows.Forms.Label();
         this.labelAfter = new System.Windows.Forms.Label();
         this.labelExact = new System.Windows.Forms.Label();
         this.buttonWait = new System.Windows.Forms.Button();
         this.buttonConfirm = new System.Windows.Forms.Button();
         this.buttonDelay5 = new System.Windows.Forms.Button();
         this.buttonDelay10 = new System.Windows.Forms.Button();
         this.buttonRemindAfter = new System.Windows.Forms.Button();
         this.buttonRemindExact = new System.Windows.Forms.Button();
         this.checkBoxAdditionalOptions = new System.Windows.Forms.CheckBox();
         this.numericUpDownRemindAfter = new System.Windows.Forms.NumericUpDown();
         this.comboBoxRemindAfter = new System.Windows.Forms.ComboBox();
         this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
         this.labelShowTime = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindAfter)).BeginInit();
         this.SuspendLayout();
         // 
         // notifyIcon
         // 
         this.notifyIcon.Text = "Message";
         this.notifyIcon.Visible = true;
         // 
         // timer
         // 
         this.timer.Interval = 1000;
         this.timer.Tick += new System.EventHandler(this.Tick);
         // 
         // textBoxMessage
         // 
         this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxMessage.Location = new System.Drawing.Point(12, 75);
         this.textBoxMessage.Multiline = true;
         this.textBoxMessage.Name = "textBoxMessage";
         this.textBoxMessage.ReadOnly = true;
         this.textBoxMessage.Size = new System.Drawing.Size(418, 183);
         this.textBoxMessage.TabIndex = 21;
         this.textBoxMessage.Text = "MessageText";
         this.textBoxMessage.MouseHover += new System.EventHandler(this.ResetWaitTimer);
         // 
         // labelUserSendMessage
         // 
         this.labelUserSendMessage.AutoSize = true;
         this.labelUserSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
         this.labelUserSendMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelUserSendMessage.Location = new System.Drawing.Point(12, 51);
         this.labelUserSendMessage.Name = "labelUserSendMessage";
         this.labelUserSendMessage.Size = new System.Drawing.Size(245, 20);
         this.labelUserSendMessage.TabIndex = 15;
         this.labelUserSendMessage.Text = "{UserName} sent you a message.";
         // 
         // labelAutoClosing
         // 
         this.labelAutoClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.labelAutoClosing.AutoSize = true;
         this.labelAutoClosing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelAutoClosing.Location = new System.Drawing.Point(145, 7);
         this.labelAutoClosing.Name = "labelAutoClosing";
         this.labelAutoClosing.Size = new System.Drawing.Size(85, 13);
         this.labelAutoClosing.TabIndex = 22;
         this.labelAutoClosing.Text = "Form close after ";
         this.labelAutoClosing.MouseHover += new System.EventHandler(this.ResetWaitTimer);
         // 
         // labelRemindAfter
         // 
         this.labelRemindAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelRemindAfter.AutoSize = true;
         this.labelRemindAfter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelRemindAfter.Location = new System.Drawing.Point(161, 269);
         this.labelRemindAfter.Name = "labelRemindAfter";
         this.labelRemindAfter.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.labelRemindAfter.Size = new System.Drawing.Size(86, 13);
         this.labelRemindAfter.TabIndex = 16;
         this.labelRemindAfter.Text = "Remaind me in a";
         // 
         // labelMinutes
         // 
         this.labelMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelMinutes.AutoSize = true;
         this.labelMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelMinutes.Location = new System.Drawing.Point(348, 269);
         this.labelMinutes.Name = "labelMinutes";
         this.labelMinutes.Size = new System.Drawing.Size(43, 13);
         this.labelMinutes.TabIndex = 19;
         this.labelMinutes.Text = "minutes";
         // 
         // labelAfter
         // 
         this.labelAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelAfter.AutoSize = true;
         this.labelAfter.Location = new System.Drawing.Point(162, 316);
         this.labelAfter.Name = "labelAfter";
         this.labelAfter.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.labelAfter.Size = new System.Drawing.Size(29, 13);
         this.labelAfter.TabIndex = 25;
         this.labelAfter.Text = "After";
         // 
         // labelExact
         // 
         this.labelExact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelExact.AutoSize = true;
         this.labelExact.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelExact.Location = new System.Drawing.Point(162, 346);
         this.labelExact.Name = "labelExact";
         this.labelExact.Size = new System.Drawing.Size(46, 13);
         this.labelExact.TabIndex = 20;
         this.labelExact.Text = "Exact at";
         // 
         // buttonWait
         // 
         this.buttonWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonWait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonWait.Location = new System.Drawing.Point(356, 3);
         this.buttonWait.Name = "buttonWait";
         this.buttonWait.Size = new System.Drawing.Size(74, 21);
         this.buttonWait.TabIndex = 23;
         this.buttonWait.Text = "Wait";
         this.buttonWait.UseVisualStyleBackColor = true;
         this.buttonWait.Click += new System.EventHandler(this.buttonWait_Click);
         // 
         // buttonConfirm
         // 
         this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonConfirm.Location = new System.Drawing.Point(12, 264);
         this.buttonConfirm.Name = "buttonConfirm";
         this.buttonConfirm.Size = new System.Drawing.Size(79, 48);
         this.buttonConfirm.TabIndex = 13;
         this.buttonConfirm.Text = "Confirm";
         this.buttonConfirm.UseVisualStyleBackColor = true;
         this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
         // 
         // buttonDelay5
         // 
         this.buttonDelay5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonDelay5.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonDelay5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonDelay5.Location = new System.Drawing.Point(282, 265);
         this.buttonDelay5.Name = "buttonDelay5";
         this.buttonDelay5.Size = new System.Drawing.Size(27, 21);
         this.buttonDelay5.TabIndex = 14;
         this.buttonDelay5.Text = "5";
         this.buttonDelay5.UseVisualStyleBackColor = true;
         this.buttonDelay5.Click += new System.EventHandler(this.buttonDelay5_Click);
         // 
         // buttonDelay10
         // 
         this.buttonDelay10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonDelay10.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonDelay10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonDelay10.Location = new System.Drawing.Point(315, 265);
         this.buttonDelay10.Name = "buttonDelay10";
         this.buttonDelay10.Size = new System.Drawing.Size(27, 21);
         this.buttonDelay10.TabIndex = 17;
         this.buttonDelay10.Text = "10";
         this.buttonDelay10.UseVisualStyleBackColor = true;
         this.buttonDelay10.Click += new System.EventHandler(this.buttonDelay10_Click);
         // 
         // buttonRemindAfter
         // 
         this.buttonRemindAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonRemindAfter.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonRemindAfter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonRemindAfter.Location = new System.Drawing.Point(354, 312);
         this.buttonRemindAfter.Name = "buttonRemindAfter";
         this.buttonRemindAfter.Size = new System.Drawing.Size(74, 21);
         this.buttonRemindAfter.TabIndex = 18;
         this.buttonRemindAfter.Text = "Remind";
         this.buttonRemindAfter.UseVisualStyleBackColor = true;
         this.buttonRemindAfter.Click += new System.EventHandler(this.buttonRemindAfter_Click);
         // 
         // buttonRemindExact
         // 
         this.buttonRemindExact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonRemindExact.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonRemindExact.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonRemindExact.Location = new System.Drawing.Point(354, 344);
         this.buttonRemindExact.Name = "buttonRemindExact";
         this.buttonRemindExact.Size = new System.Drawing.Size(74, 21);
         this.buttonRemindExact.TabIndex = 32;
         this.buttonRemindExact.Text = "Remind";
         this.buttonRemindExact.UseVisualStyleBackColor = true;
         this.buttonRemindExact.Click += new System.EventHandler(this.buttonRemindExact_Click);
         // 
         // checkBoxAdditionalOptions
         // 
         this.checkBoxAdditionalOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxAdditionalOptions.AutoSize = true;
         this.checkBoxAdditionalOptions.Location = new System.Drawing.Point(164, 292);
         this.checkBoxAdditionalOptions.Name = "checkBoxAdditionalOptions";
         this.checkBoxAdditionalOptions.Size = new System.Drawing.Size(111, 17);
         this.checkBoxAdditionalOptions.TabIndex = 24;
         this.checkBoxAdditionalOptions.Text = "Additional Options";
         this.checkBoxAdditionalOptions.UseVisualStyleBackColor = true;
         this.checkBoxAdditionalOptions.CheckedChanged += new System.EventHandler(this.checkBoxAdditionalOptions_CheckedChanged);
         // 
         // numericUpDownRemindAfter
         // 
         this.numericUpDownRemindAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.numericUpDownRemindAfter.Location = new System.Drawing.Point(214, 313);
         this.numericUpDownRemindAfter.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
         this.numericUpDownRemindAfter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownRemindAfter.Name = "numericUpDownRemindAfter";
         this.numericUpDownRemindAfter.Size = new System.Drawing.Size(40, 20);
         this.numericUpDownRemindAfter.TabIndex = 38;
         this.numericUpDownRemindAfter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // comboBoxRemindAfter
         // 
         this.comboBoxRemindAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.comboBoxRemindAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxRemindAfter.FormattingEnabled = true;
         this.comboBoxRemindAfter.Location = new System.Drawing.Point(260, 313);
         this.comboBoxRemindAfter.Name = "comboBoxRemindAfter";
         this.comboBoxRemindAfter.Size = new System.Drawing.Size(88, 21);
         this.comboBoxRemindAfter.TabIndex = 26;
         // 
         // dateTimePickerDate
         // 
         this.dateTimePickerDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerDate.Location = new System.Drawing.Point(214, 344);
         this.dateTimePickerDate.Name = "dateTimePickerDate";
         this.dateTimePickerDate.ShowUpDown = true;
         this.dateTimePickerDate.Size = new System.Drawing.Size(78, 20);
         this.dateTimePickerDate.TabIndex = 36;
         // 
         // dateTimePickerTime
         // 
         this.dateTimePickerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.dateTimePickerTime.CustomFormat = "HH:mm";
         this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dateTimePickerTime.Location = new System.Drawing.Point(298, 344);
         this.dateTimePickerTime.Name = "dateTimePickerTime";
         this.dateTimePickerTime.ShowUpDown = true;
         this.dateTimePickerTime.Size = new System.Drawing.Size(50, 20);
         this.dateTimePickerTime.TabIndex = 37;
         // 
         // labelShowTime
         // 
         this.labelShowTime.AutoSize = true;
         this.labelShowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
         this.labelShowTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelShowTime.Location = new System.Drawing.Point(12, 31);
         this.labelShowTime.Name = "labelShowTime";
         this.labelShowTime.Size = new System.Drawing.Size(93, 20);
         this.labelShowTime.TabIndex = 39;
         this.labelShowTime.Text = "{ShowTime}";
         // 
         // MessageForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(439, 391);
         this.ControlBox = false;
         this.Controls.Add(this.labelShowTime);
         this.Controls.Add(this.numericUpDownRemindAfter);
         this.Controls.Add(this.dateTimePickerTime);
         this.Controls.Add(this.dateTimePickerDate);
         this.Controls.Add(this.buttonRemindExact);
         this.Controls.Add(this.comboBoxRemindAfter);
         this.Controls.Add(this.labelAfter);
         this.Controls.Add(this.checkBoxAdditionalOptions);
         this.Controls.Add(this.buttonWait);
         this.Controls.Add(this.labelAutoClosing);
         this.Controls.Add(this.textBoxMessage);
         this.Controls.Add(this.labelExact);
         this.Controls.Add(this.labelMinutes);
         this.Controls.Add(this.buttonRemindAfter);
         this.Controls.Add(this.buttonDelay10);
         this.Controls.Add(this.labelRemindAfter);
         this.Controls.Add(this.labelUserSendMessage);
         this.Controls.Add(this.buttonDelay5);
         this.Controls.Add(this.buttonConfirm);
         this.Name = "MessageForm";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "id event";
         this.TopMost = true;
         this.LocationChanged += new System.EventHandler(this.ResetWaitTimer);
         this.MouseHover += new System.EventHandler(this.ResetWaitTimer);
         this.Resize += new System.EventHandler(this.ResetWaitTimer);
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindAfter)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.NotifyIcon notifyIcon;
      private System.Windows.Forms.Timer timer;
      private System.Windows.Forms.TextBox textBoxMessage;
      private System.Windows.Forms.Label labelUserSendMessage;
      private System.Windows.Forms.Label labelAutoClosing;
      private System.Windows.Forms.Label labelRemindAfter;
      private System.Windows.Forms.Label labelMinutes;
      private System.Windows.Forms.Label labelAfter;
      private System.Windows.Forms.Label labelExact;
      private System.Windows.Forms.Button buttonWait;
      private System.Windows.Forms.Button buttonConfirm;
      private System.Windows.Forms.Button buttonDelay5;
      private System.Windows.Forms.Button buttonDelay10;
      private System.Windows.Forms.Button buttonRemindAfter;
      private System.Windows.Forms.Button buttonRemindExact;
      private System.Windows.Forms.CheckBox checkBoxAdditionalOptions;
      private System.Windows.Forms.NumericUpDown numericUpDownRemindAfter;
      private System.Windows.Forms.ComboBox comboBoxRemindAfter;
      private System.Windows.Forms.DateTimePicker dateTimePickerDate;
      private System.Windows.Forms.DateTimePicker dateTimePickerTime;
      private System.Windows.Forms.Label labelShowTime;
   }
}