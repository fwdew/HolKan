namespace Client
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.labelCurrentTime = new System.Windows.Forms.Label();
         this.tabControl = new System.Windows.Forms.TabControl();
         this.tabPageSendMessage = new System.Windows.Forms.TabPage();
         this.buttonCheckOnline = new System.Windows.Forms.Button();
         this.checkBoxNone = new System.Windows.Forms.CheckBox();
         this.checkBoxAll = new System.Windows.Forms.CheckBox();
         this.groupBoxSendersOptions = new System.Windows.Forms.GroupBox();
         this.groupBoxPeriodical = new System.Windows.Forms.GroupBox();
         this.dateTimePickerLastShowEventTime = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerLastShowEventDate = new System.Windows.Forms.DateTimePicker();
         this.labelSeveralTimes = new System.Windows.Forms.Label();
         this.numericUpDownSeveralTimes = new System.Windows.Forms.NumericUpDown();
         this.radioButtonLastEventDateTime = new System.Windows.Forms.RadioButton();
         this.radioButtonLastEventCount = new System.Windows.Forms.RadioButton();
         this.numericUpDownPeriod = new System.Windows.Forms.NumericUpDown();
         this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
         this.checkBoxPeriod = new System.Windows.Forms.CheckBox();
         this.numericUpDownRemindAfter = new System.Windows.Forms.NumericUpDown();
         this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
         this.comboBoxRemindAfter = new System.Windows.Forms.ComboBox();
         this.radioButtonExact = new System.Windows.Forms.RadioButton();
         this.radioButtonAfter = new System.Windows.Forms.RadioButton();
         this.radioButtonImmideatly = new System.Windows.Forms.RadioButton();
         this.checkBoxAdditionalOptions = new System.Windows.Forms.CheckBox();
         this.checkBoxAlertOnConfirm = new System.Windows.Forms.CheckBox();
         this.checkedListBoxUsers = new System.Windows.Forms.CheckedListBox();
         this.buttonSend = new System.Windows.Forms.Button();
         this.textBoxMessage = new System.Windows.Forms.TextBox();
         this.tabPageAllMessageList = new System.Windows.Forms.TabPage();
         this.dataGridViewMessages = new System.Windows.Forms.DataGridView();
         this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.sender_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.sender_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.recipient_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.status_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.confirm_reply = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.cancel_pressed = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
         this.got_id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.tabPageNotRaisedMessageList = new System.Windows.Forms.TabPage();
         this.dataGridViewListOfOrders = new System.Windows.Forms.DataGridView();
         this.id_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.date_time_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.sender_name_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.message_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
         this.timerCurrentDateTime = new System.Windows.Forms.Timer(this.components);
         this.button2 = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.button4 = new System.Windows.Forms.Button();
         this.labelCurrentTimeText = new System.Windows.Forms.Label();
         this.tabControl.SuspendLayout();
         this.tabPageSendMessage.SuspendLayout();
         this.groupBoxSendersOptions.SuspendLayout();
         this.groupBoxPeriodical.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeveralTimes)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriod)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindAfter)).BeginInit();
         this.tabPageAllMessageList.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessages)).BeginInit();
         this.tabPageNotRaisedMessageList.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfOrders)).BeginInit();
         this.SuspendLayout();
         // 
         // labelCurrentTime
         // 
         this.labelCurrentTime.AutoSize = true;
         this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
         this.labelCurrentTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelCurrentTime.Location = new System.Drawing.Point(12, 21);
         this.labelCurrentTime.Name = "labelCurrentTime";
         this.labelCurrentTime.Size = new System.Drawing.Size(0, 16);
         this.labelCurrentTime.TabIndex = 31;
         // 
         // tabControl
         // 
         this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl.Controls.Add(this.tabPageSendMessage);
         this.tabControl.Controls.Add(this.tabPageAllMessageList);
         this.tabControl.Controls.Add(this.tabPageNotRaisedMessageList);
         this.tabControl.Location = new System.Drawing.Point(12, 37);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedIndex = 0;
         this.tabControl.Size = new System.Drawing.Size(507, 405);
         this.tabControl.TabIndex = 30;
         // 
         // tabPageSendMessage
         // 
         this.tabPageSendMessage.Controls.Add(this.buttonCheckOnline);
         this.tabPageSendMessage.Controls.Add(this.checkBoxNone);
         this.tabPageSendMessage.Controls.Add(this.checkBoxAll);
         this.tabPageSendMessage.Controls.Add(this.groupBoxSendersOptions);
         this.tabPageSendMessage.Controls.Add(this.checkBoxAdditionalOptions);
         this.tabPageSendMessage.Controls.Add(this.checkBoxAlertOnConfirm);
         this.tabPageSendMessage.Controls.Add(this.checkedListBoxUsers);
         this.tabPageSendMessage.Controls.Add(this.buttonSend);
         this.tabPageSendMessage.Controls.Add(this.textBoxMessage);
         this.tabPageSendMessage.Location = new System.Drawing.Point(4, 22);
         this.tabPageSendMessage.Name = "tabPageSendMessage";
         this.tabPageSendMessage.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageSendMessage.Size = new System.Drawing.Size(499, 379);
         this.tabPageSendMessage.TabIndex = 1;
         this.tabPageSendMessage.Text = "Sending";
         this.tabPageSendMessage.UseVisualStyleBackColor = true;
         // 
         // buttonCheckOnline
         // 
         this.buttonCheckOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonCheckOnline.Location = new System.Drawing.Point(51, 5);
         this.buttonCheckOnline.Name = "buttonCheckOnline";
         this.buttonCheckOnline.Size = new System.Drawing.Size(15, 15);
         this.buttonCheckOnline.TabIndex = 34;
         this.buttonCheckOnline.UseVisualStyleBackColor = true;
         this.buttonCheckOnline.Click += new System.EventHandler(this.buttonCheckOnline_Click);
         // 
         // checkBoxNone
         // 
         this.checkBoxNone.AutoSize = true;
         this.checkBoxNone.Location = new System.Drawing.Point(30, 6);
         this.checkBoxNone.Name = "checkBoxNone";
         this.checkBoxNone.Size = new System.Drawing.Size(15, 14);
         this.checkBoxNone.TabIndex = 33;
         this.checkBoxNone.UseVisualStyleBackColor = true;
         this.checkBoxNone.CheckedChanged += new System.EventHandler(this.checkBoxNone_CheckedChanged);
         // 
         // checkBoxAll
         // 
         this.checkBoxAll.AutoSize = true;
         this.checkBoxAll.Checked = true;
         this.checkBoxAll.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxAll.Location = new System.Drawing.Point(9, 6);
         this.checkBoxAll.Name = "checkBoxAll";
         this.checkBoxAll.Size = new System.Drawing.Size(15, 14);
         this.checkBoxAll.TabIndex = 32;
         this.checkBoxAll.UseVisualStyleBackColor = true;
         this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
         // 
         // groupBoxSendersOptions
         // 
         this.groupBoxSendersOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBoxSendersOptions.Controls.Add(this.groupBoxPeriodical);
         this.groupBoxSendersOptions.Controls.Add(this.numericUpDownRemindAfter);
         this.groupBoxSendersOptions.Controls.Add(this.dateTimePickerTime);
         this.groupBoxSendersOptions.Controls.Add(this.dateTimePickerDate);
         this.groupBoxSendersOptions.Controls.Add(this.comboBoxRemindAfter);
         this.groupBoxSendersOptions.Controls.Add(this.radioButtonExact);
         this.groupBoxSendersOptions.Controls.Add(this.radioButtonAfter);
         this.groupBoxSendersOptions.Controls.Add(this.radioButtonImmideatly);
         this.groupBoxSendersOptions.Location = new System.Drawing.Point(158, 170);
         this.groupBoxSendersOptions.Name = "groupBoxSendersOptions";
         this.groupBoxSendersOptions.Size = new System.Drawing.Size(325, 203);
         this.groupBoxSendersOptions.TabIndex = 30;
         this.groupBoxSendersOptions.TabStop = false;
         this.groupBoxSendersOptions.Text = "Parameters";
         this.groupBoxSendersOptions.Visible = false;
         // 
         // groupBoxPeriodical
         // 
         this.groupBoxPeriodical.Controls.Add(this.dateTimePickerLastShowEventTime);
         this.groupBoxPeriodical.Controls.Add(this.dateTimePickerLastShowEventDate);
         this.groupBoxPeriodical.Controls.Add(this.labelSeveralTimes);
         this.groupBoxPeriodical.Controls.Add(this.numericUpDownSeveralTimes);
         this.groupBoxPeriodical.Controls.Add(this.radioButtonLastEventDateTime);
         this.groupBoxPeriodical.Controls.Add(this.radioButtonLastEventCount);
         this.groupBoxPeriodical.Controls.Add(this.numericUpDownPeriod);
         this.groupBoxPeriodical.Controls.Add(this.comboBoxPeriod);
         this.groupBoxPeriodical.Controls.Add(this.checkBoxPeriod);
         this.groupBoxPeriodical.Location = new System.Drawing.Point(3, 88);
         this.groupBoxPeriodical.Name = "groupBoxPeriodical";
         this.groupBoxPeriodical.Size = new System.Drawing.Size(306, 108);
         this.groupBoxPeriodical.TabIndex = 54;
         this.groupBoxPeriodical.TabStop = false;
         // 
         // dateTimePickerLastShowEventTime
         // 
         this.dateTimePickerLastShowEventTime.CustomFormat = "HH:mm";
         this.dateTimePickerLastShowEventTime.Enabled = false;
         this.dateTimePickerLastShowEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dateTimePickerLastShowEventTime.Location = new System.Drawing.Point(242, 79);
         this.dateTimePickerLastShowEventTime.Name = "dateTimePickerLastShowEventTime";
         this.dateTimePickerLastShowEventTime.ShowUpDown = true;
         this.dateTimePickerLastShowEventTime.Size = new System.Drawing.Size(50, 20);
         this.dateTimePickerLastShowEventTime.TabIndex = 53;
         this.dateTimePickerLastShowEventTime.Visible = false;
         // 
         // dateTimePickerLastShowEventDate
         // 
         this.dateTimePickerLastShowEventDate.Enabled = false;
         this.dateTimePickerLastShowEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerLastShowEventDate.Location = new System.Drawing.Point(158, 79);
         this.dateTimePickerLastShowEventDate.Name = "dateTimePickerLastShowEventDate";
         this.dateTimePickerLastShowEventDate.ShowUpDown = true;
         this.dateTimePickerLastShowEventDate.Size = new System.Drawing.Size(78, 20);
         this.dateTimePickerLastShowEventDate.TabIndex = 52;
         this.dateTimePickerLastShowEventDate.Visible = false;
         // 
         // labelSeveralTimes
         // 
         this.labelSeveralTimes.AutoSize = true;
         this.labelSeveralTimes.Location = new System.Drawing.Point(205, 59);
         this.labelSeveralTimes.Name = "labelSeveralTimes";
         this.labelSeveralTimes.Size = new System.Drawing.Size(31, 13);
         this.labelSeveralTimes.TabIndex = 51;
         this.labelSeveralTimes.Text = "times";
         this.labelSeveralTimes.Visible = false;
         // 
         // numericUpDownSeveralTimes
         // 
         this.numericUpDownSeveralTimes.Location = new System.Drawing.Point(158, 55);
         this.numericUpDownSeveralTimes.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
         this.numericUpDownSeveralTimes.Name = "numericUpDownSeveralTimes";
         this.numericUpDownSeveralTimes.Size = new System.Drawing.Size(41, 20);
         this.numericUpDownSeveralTimes.TabIndex = 50;
         this.numericUpDownSeveralTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownSeveralTimes.Visible = false;
         // 
         // radioButtonLastEventDateTime
         // 
         this.radioButtonLastEventDateTime.Location = new System.Drawing.Point(27, 79);
         this.radioButtonLastEventDateTime.Name = "radioButtonLastEventDateTime";
         this.radioButtonLastEventDateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.radioButtonLastEventDateTime.Size = new System.Drawing.Size(125, 17);
         this.radioButtonLastEventDateTime.TabIndex = 49;
         this.radioButtonLastEventDateTime.Text = "repeat till";
         this.radioButtonLastEventDateTime.UseVisualStyleBackColor = true;
         this.radioButtonLastEventDateTime.Visible = false;
         this.radioButtonLastEventDateTime.CheckedChanged += new System.EventHandler(this.ChangeEnablingPeriodicalOptions_CheckedChanged);
         // 
         // radioButtonLastEventCount
         // 
         this.radioButtonLastEventCount.Checked = true;
         this.radioButtonLastEventCount.Location = new System.Drawing.Point(27, 56);
         this.radioButtonLastEventCount.Name = "radioButtonLastEventCount";
         this.radioButtonLastEventCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.radioButtonLastEventCount.Size = new System.Drawing.Size(125, 19);
         this.radioButtonLastEventCount.TabIndex = 48;
         this.radioButtonLastEventCount.TabStop = true;
         this.radioButtonLastEventCount.Text = "repeat once more";
         this.radioButtonLastEventCount.UseVisualStyleBackColor = true;
         this.radioButtonLastEventCount.Visible = false;
         this.radioButtonLastEventCount.CheckedChanged += new System.EventHandler(this.ChangeEnablingPeriodicalOptions_CheckedChanged);
         // 
         // numericUpDownPeriod
         // 
         this.numericUpDownPeriod.Location = new System.Drawing.Point(158, 21);
         this.numericUpDownPeriod.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
         this.numericUpDownPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownPeriod.Name = "numericUpDownPeriod";
         this.numericUpDownPeriod.Size = new System.Drawing.Size(40, 20);
         this.numericUpDownPeriod.TabIndex = 47;
         this.numericUpDownPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownPeriod.Visible = false;
         // 
         // comboBoxPeriod
         // 
         this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxPeriod.FormattingEnabled = true;
         this.comboBoxPeriod.Location = new System.Drawing.Point(209, 20);
         this.comboBoxPeriod.Name = "comboBoxPeriod";
         this.comboBoxPeriod.Size = new System.Drawing.Size(83, 21);
         this.comboBoxPeriod.TabIndex = 46;
         this.comboBoxPeriod.Visible = false;
         // 
         // checkBoxPeriod
         // 
         this.checkBoxPeriod.Location = new System.Drawing.Point(3, 20);
         this.checkBoxPeriod.Name = "checkBoxPeriod";
         this.checkBoxPeriod.Size = new System.Drawing.Size(149, 20);
         this.checkBoxPeriod.TabIndex = 45;
         this.checkBoxPeriod.Text = "Show periodicaly every";
         this.checkBoxPeriod.UseVisualStyleBackColor = true;
         this.checkBoxPeriod.CheckedChanged += new System.EventHandler(this.checkBoxPeriod_CheckedChanged);
         // 
         // numericUpDownRemindAfter
         // 
         this.numericUpDownRemindAfter.Enabled = false;
         this.numericUpDownRemindAfter.Location = new System.Drawing.Point(161, 39);
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
         this.numericUpDownRemindAfter.TabIndex = 44;
         this.numericUpDownRemindAfter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // dateTimePickerTime
         // 
         this.dateTimePickerTime.CustomFormat = "HH:mm";
         this.dateTimePickerTime.Enabled = false;
         this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dateTimePickerTime.Location = new System.Drawing.Point(245, 65);
         this.dateTimePickerTime.Name = "dateTimePickerTime";
         this.dateTimePickerTime.ShowUpDown = true;
         this.dateTimePickerTime.Size = new System.Drawing.Size(50, 20);
         this.dateTimePickerTime.TabIndex = 43;
         // 
         // dateTimePickerDate
         // 
         this.dateTimePickerDate.Enabled = false;
         this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerDate.Location = new System.Drawing.Point(161, 65);
         this.dateTimePickerDate.Name = "dateTimePickerDate";
         this.dateTimePickerDate.ShowUpDown = true;
         this.dateTimePickerDate.Size = new System.Drawing.Size(78, 20);
         this.dateTimePickerDate.TabIndex = 42;
         // 
         // comboBoxRemindAfter
         // 
         this.comboBoxRemindAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxRemindAfter.Enabled = false;
         this.comboBoxRemindAfter.FormattingEnabled = true;
         this.comboBoxRemindAfter.Location = new System.Drawing.Point(207, 39);
         this.comboBoxRemindAfter.Name = "comboBoxRemindAfter";
         this.comboBoxRemindAfter.Size = new System.Drawing.Size(88, 21);
         this.comboBoxRemindAfter.TabIndex = 40;
         // 
         // radioButtonExact
         // 
         this.radioButtonExact.AutoSize = true;
         this.radioButtonExact.Location = new System.Drawing.Point(6, 65);
         this.radioButtonExact.Name = "radioButtonExact";
         this.radioButtonExact.Size = new System.Drawing.Size(93, 17);
         this.radioButtonExact.TabIndex = 2;
         this.radioButtonExact.Text = "Show exact at";
         this.radioButtonExact.UseVisualStyleBackColor = true;
         this.radioButtonExact.CheckedChanged += new System.EventHandler(this.ChangeEnablingMainOptions_CheckedChanged);
         // 
         // radioButtonAfter
         // 
         this.radioButtonAfter.AutoSize = true;
         this.radioButtonAfter.Location = new System.Drawing.Point(6, 42);
         this.radioButtonAfter.Name = "radioButtonAfter";
         this.radioButtonAfter.Size = new System.Drawing.Size(76, 17);
         this.radioButtonAfter.TabIndex = 1;
         this.radioButtonAfter.Text = "Show after";
         this.radioButtonAfter.UseVisualStyleBackColor = true;
         this.radioButtonAfter.CheckedChanged += new System.EventHandler(this.ChangeEnablingMainOptions_CheckedChanged);
         // 
         // radioButtonImmideatly
         // 
         this.radioButtonImmideatly.AutoSize = true;
         this.radioButtonImmideatly.Checked = true;
         this.radioButtonImmideatly.Location = new System.Drawing.Point(6, 19);
         this.radioButtonImmideatly.Name = "radioButtonImmideatly";
         this.radioButtonImmideatly.Size = new System.Drawing.Size(103, 17);
         this.radioButtonImmideatly.TabIndex = 0;
         this.radioButtonImmideatly.TabStop = true;
         this.radioButtonImmideatly.Text = "Show immideatly";
         this.radioButtonImmideatly.UseVisualStyleBackColor = true;
         this.radioButtonImmideatly.CheckedChanged += new System.EventHandler(this.ChangeEnablingMainOptions_CheckedChanged);
         // 
         // checkBoxAdditionalOptions
         // 
         this.checkBoxAdditionalOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxAdditionalOptions.AutoSize = true;
         this.checkBoxAdditionalOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBoxAdditionalOptions.Location = new System.Drawing.Point(158, 147);
         this.checkBoxAdditionalOptions.Name = "checkBoxAdditionalOptions";
         this.checkBoxAdditionalOptions.Size = new System.Drawing.Size(136, 20);
         this.checkBoxAdditionalOptions.TabIndex = 29;
         this.checkBoxAdditionalOptions.Text = "Additional settings";
         this.checkBoxAdditionalOptions.UseVisualStyleBackColor = true;
         this.checkBoxAdditionalOptions.CheckedChanged += new System.EventHandler(this.checkBoxAdditionalOptions_CheckedChanged);
         // 
         // checkBoxAlertOnConfirm
         // 
         this.checkBoxAlertOnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxAlertOnConfirm.AutoSize = true;
         this.checkBoxAlertOnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkBoxAlertOnConfirm.Location = new System.Drawing.Point(158, 128);
         this.checkBoxAlertOnConfirm.Name = "checkBoxAlertOnConfirm";
         this.checkBoxAlertOnConfirm.Size = new System.Drawing.Size(147, 20);
         this.checkBoxAlertOnConfirm.TabIndex = 28;
         this.checkBoxAlertOnConfirm.Text = "Alert me if confirmed";
         this.checkBoxAlertOnConfirm.UseVisualStyleBackColor = true;
         // 
         // checkedListBoxUsers
         // 
         this.checkedListBoxUsers.FormattingEnabled = true;
         this.checkedListBoxUsers.Location = new System.Drawing.Point(6, 26);
         this.checkedListBoxUsers.Name = "checkedListBoxUsers";
         this.checkedListBoxUsers.Size = new System.Drawing.Size(144, 349);
         this.checkedListBoxUsers.Sorted = true;
         this.checkedListBoxUsers.TabIndex = 22;
         // 
         // buttonSend
         // 
         this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonSend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.buttonSend.Location = new System.Drawing.Point(156, 100);
         this.buttonSend.Name = "buttonSend";
         this.buttonSend.Size = new System.Drawing.Size(327, 22);
         this.buttonSend.TabIndex = 8;
         this.buttonSend.Text = "Send";
         this.buttonSend.UseVisualStyleBackColor = true;
         this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
         // 
         // textBoxMessage
         // 
         this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBoxMessage.Location = new System.Drawing.Point(156, 26);
         this.textBoxMessage.Multiline = true;
         this.textBoxMessage.Name = "textBoxMessage";
         this.textBoxMessage.Size = new System.Drawing.Size(327, 68);
         this.textBoxMessage.TabIndex = 7;
         // 
         // tabPageAllMessageList
         // 
         this.tabPageAllMessageList.Controls.Add(this.dataGridViewMessages);
         this.tabPageAllMessageList.Location = new System.Drawing.Point(4, 22);
         this.tabPageAllMessageList.Name = "tabPageAllMessageList";
         this.tabPageAllMessageList.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAllMessageList.Size = new System.Drawing.Size(499, 379);
         this.tabPageAllMessageList.TabIndex = 0;
         this.tabPageAllMessageList.Text = "Messages";
         this.tabPageAllMessageList.UseVisualStyleBackColor = true;
         // 
         // dataGridViewMessages
         // 
         this.dataGridViewMessages.AllowUserToAddRows = false;
         this.dataGridViewMessages.AllowUserToDeleteRows = false;
         this.dataGridViewMessages.AllowUserToOrderColumns = true;
         this.dataGridViewMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridViewMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.sender_ip,
            this.sender_name,
            this.recipient_ip,
            this.type,
            this.message,
            this.status_message,
            this.confirm_reply,
            this.cancel_pressed,
            this.delete,
            this.got_id});
         this.dataGridViewMessages.Location = new System.Drawing.Point(0, 0);
         this.dataGridViewMessages.MultiSelect = false;
         this.dataGridViewMessages.Name = "dataGridViewMessages";
         this.dataGridViewMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridViewMessages.Size = new System.Drawing.Size(700, 396);
         this.dataGridViewMessages.TabIndex = 20;
         // 
         // id
         // 
         this.id.HeaderText = "id";
         this.id.Name = "id";
         this.id.ReadOnly = true;
         this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // 
         // date
         // 
         this.date.HeaderText = "date";
         this.date.Name = "date";
         this.date.ReadOnly = true;
         // 
         // sender_ip
         // 
         this.sender_ip.HeaderText = "sender ip";
         this.sender_ip.Name = "sender_ip";
         this.sender_ip.ReadOnly = true;
         // 
         // sender_name
         // 
         this.sender_name.HeaderText = "sender name";
         this.sender_name.Name = "sender_name";
         this.sender_name.ReadOnly = true;
         // 
         // recipient_ip
         // 
         this.recipient_ip.HeaderText = "recipient ip";
         this.recipient_ip.Name = "recipient_ip";
         this.recipient_ip.ReadOnly = true;
         // 
         // type
         // 
         this.type.HeaderText = "type";
         this.type.Name = "type";
         this.type.ReadOnly = true;
         // 
         // message
         // 
         this.message.HeaderText = "message";
         this.message.Name = "message";
         this.message.ReadOnly = true;
         // 
         // status_message
         // 
         this.status_message.HeaderText = "status message";
         this.status_message.Name = "status_message";
         this.status_message.ReadOnly = true;
         // 
         // confirm_reply
         // 
         this.confirm_reply.HeaderText = "given confirm reply";
         this.confirm_reply.Name = "confirm_reply";
         this.confirm_reply.ReadOnly = true;
         // 
         // cancel_pressed
         // 
         this.cancel_pressed.HeaderText = "cancel pressed";
         this.cancel_pressed.Name = "cancel_pressed";
         this.cancel_pressed.ReadOnly = true;
         // 
         // delete
         // 
         this.delete.HeaderText = "Delete";
         this.delete.Name = "delete";
         this.delete.ReadOnly = true;
         this.delete.Text = "Delete";
         this.delete.UseColumnTextForButtonValue = true;
         // 
         // got_id
         // 
         this.got_id.HeaderText = "sender got id";
         this.got_id.Name = "got_id";
         this.got_id.ReadOnly = true;
         this.got_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         // 
         // tabPageNotRaisedMessageList
         // 
         this.tabPageNotRaisedMessageList.Controls.Add(this.dataGridViewListOfOrders);
         this.tabPageNotRaisedMessageList.Location = new System.Drawing.Point(4, 22);
         this.tabPageNotRaisedMessageList.Name = "tabPageNotRaisedMessageList";
         this.tabPageNotRaisedMessageList.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageNotRaisedMessageList.Size = new System.Drawing.Size(499, 379);
         this.tabPageNotRaisedMessageList.TabIndex = 2;
         this.tabPageNotRaisedMessageList.Text = "ListOfEvents";
         this.tabPageNotRaisedMessageList.UseVisualStyleBackColor = true;
         // 
         // dataGridViewListOfEvent
         // 
         this.dataGridViewListOfOrders.AllowUserToAddRows = false;
         this.dataGridViewListOfOrders.AllowUserToDeleteRows = false;
         this.dataGridViewListOfOrders.AllowUserToResizeColumns = false;
         this.dataGridViewListOfOrders.AllowUserToResizeRows = false;
         this.dataGridViewListOfOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridViewListOfOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewListOfOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_event,
            this.date_time_event,
            this.sender_name_event,
            this.message_event,
            this.Status});
         this.dataGridViewListOfOrders.Enabled = false;
         this.dataGridViewListOfOrders.Location = new System.Drawing.Point(3, 3);
         this.dataGridViewListOfOrders.Name = "dataGridViewListOfEvent";
         this.dataGridViewListOfOrders.Size = new System.Drawing.Size(703, 394);
         this.dataGridViewListOfOrders.TabIndex = 0;
         // 
         // id_event
         // 
         this.id_event.HeaderText = "id";
         this.id_event.Name = "id_event";
         this.id_event.Width = 200;
         // 
         // date_time_event
         // 
         this.date_time_event.HeaderText = "DateTime";
         this.date_time_event.Name = COLUMN_SHOW_TIME;
         this.date_time_event.Width = 200;
         // 
         // sender_name_event
         // 
         this.sender_name_event.HeaderText = "sender_name";
         this.sender_name_event.Name = "sender_name_event";
         // 
         // message_event
         // 
         this.message_event.HeaderText = "Message";
         this.message_event.Name = "message_event";
         // 
         // Status
         // 
         this.Status.HeaderText = "Status";
         this.Status.Name = "Status";
         // 
         // notifyIcon
         // 
         this.notifyIcon.Text = "HK";
         this.notifyIcon.Visible = true;
         this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
         // 
         // timerCurrentDateTime
         // 
         this.timerCurrentDateTime.Interval = 1000;
         this.timerCurrentDateTime.Tick += new System.EventHandler(this.timerCurrentDateTime_Tick);
         // 
         // button2
         // 
         this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.button2.Location = new System.Drawing.Point(311, -12);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(37, 83);
         this.button2.TabIndex = 33;
         this.button2.Text = "button2";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // button1
         // 
         this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.button1.Location = new System.Drawing.Point(261, 3);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(44, 50);
         this.button1.TabIndex = 32;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(180, 4);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(75, 23);
         this.button3.TabIndex = 31;
         this.button3.Text = "add users";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // button4
         // 
         this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.button4.Location = new System.Drawing.Point(474, 4);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(25, 27);
         this.button4.TabIndex = 34;
         this.button4.Text = "X";
         this.button4.UseVisualStyleBackColor = true;
         this.button4.Click += new System.EventHandler(this.button4_Click);
         // 
         // labelCurrentTimeText
         // 
         this.labelCurrentTimeText.AutoSize = true;
         this.labelCurrentTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
         this.labelCurrentTimeText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelCurrentTimeText.Location = new System.Drawing.Point(13, 4);
         this.labelCurrentTimeText.Name = "labelCurrentTimeText";
         this.labelCurrentTimeText.Size = new System.Drawing.Size(78, 16);
         this.labelCurrentTimeText.TabIndex = 35;
         this.labelCurrentTimeText.Text = "Current time";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(521, 446);
         this.Controls.Add(this.labelCurrentTimeText);
         this.Controls.Add(this.button4);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.labelCurrentTime);
         this.Controls.Add(this.tabControl);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "HolKan";
         this.Load += new System.EventHandler(this.HolKanClient_Load);
         this.Resize += new System.EventHandler(this.ResizeForm);
         this.tabControl.ResumeLayout(false);
         this.tabPageSendMessage.ResumeLayout(false);
         this.tabPageSendMessage.PerformLayout();
         this.groupBoxSendersOptions.ResumeLayout(false);
         this.groupBoxSendersOptions.PerformLayout();
         this.groupBoxPeriodical.ResumeLayout(false);
         this.groupBoxPeriodical.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeveralTimes)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriod)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindAfter)).EndInit();
         this.tabPageAllMessageList.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessages)).EndInit();
         this.tabPageNotRaisedMessageList.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfOrders)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelCurrentTime;
      private System.Windows.Forms.TabControl tabControl;
      private System.Windows.Forms.TabPage tabPageSendMessage;
      private System.Windows.Forms.CheckedListBox checkedListBoxUsers;
      private System.Windows.Forms.Button buttonSend;
      private System.Windows.Forms.TextBox textBoxMessage;
      private System.Windows.Forms.TabPage tabPageAllMessageList;
      private System.Windows.Forms.DataGridView dataGridViewMessages;
      private System.Windows.Forms.DataGridViewTextBoxColumn id;
      private System.Windows.Forms.DataGridViewTextBoxColumn date;
      private System.Windows.Forms.DataGridViewTextBoxColumn sender_ip;
      private System.Windows.Forms.DataGridViewTextBoxColumn sender_name;
      private System.Windows.Forms.DataGridViewTextBoxColumn recipient_ip;
      private System.Windows.Forms.DataGridViewTextBoxColumn type;
      private System.Windows.Forms.DataGridViewTextBoxColumn message;
      private System.Windows.Forms.DataGridViewTextBoxColumn status_message;
      private System.Windows.Forms.DataGridViewTextBoxColumn confirm_reply;
      private System.Windows.Forms.DataGridViewTextBoxColumn cancel_pressed;
      private System.Windows.Forms.DataGridViewButtonColumn delete;
      private System.Windows.Forms.DataGridViewCheckBoxColumn got_id;
      private System.Windows.Forms.TabPage tabPageNotRaisedMessageList;
      private System.Windows.Forms.DataGridView dataGridViewListOfOrders;
      private System.Windows.Forms.NotifyIcon notifyIcon;
      private System.Windows.Forms.Timer timerCurrentDateTime;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.CheckBox checkBoxAlertOnConfirm;
      private System.Windows.Forms.DataGridViewTextBoxColumn id_event;
      private System.Windows.Forms.DataGridViewTextBoxColumn date_time_event;
      private System.Windows.Forms.DataGridViewTextBoxColumn sender_name_event;
      private System.Windows.Forms.DataGridViewTextBoxColumn message_event;
      private System.Windows.Forms.DataGridViewTextBoxColumn Status;
      private System.Windows.Forms.CheckBox checkBoxAdditionalOptions;
      private System.Windows.Forms.GroupBox groupBoxSendersOptions;
      private System.Windows.Forms.RadioButton radioButtonExact;
      private System.Windows.Forms.RadioButton radioButtonAfter;
      private System.Windows.Forms.RadioButton radioButtonImmideatly;
      private System.Windows.Forms.NumericUpDown numericUpDownPeriod;
      private System.Windows.Forms.ComboBox comboBoxPeriod;
      private System.Windows.Forms.CheckBox checkBoxPeriod;
      private System.Windows.Forms.NumericUpDown numericUpDownRemindAfter;
      private System.Windows.Forms.DateTimePicker dateTimePickerTime;
      private System.Windows.Forms.DateTimePicker dateTimePickerDate;
      private System.Windows.Forms.ComboBox comboBoxRemindAfter;
      private System.Windows.Forms.DateTimePicker dateTimePickerLastShowEventTime;
      private System.Windows.Forms.DateTimePicker dateTimePickerLastShowEventDate;
      private System.Windows.Forms.Label labelSeveralTimes;
      private System.Windows.Forms.NumericUpDown numericUpDownSeveralTimes;
      private System.Windows.Forms.RadioButton radioButtonLastEventDateTime;
      private System.Windows.Forms.RadioButton radioButtonLastEventCount;
      private System.Windows.Forms.GroupBox groupBoxPeriodical;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.Label labelCurrentTimeText;
      private System.Windows.Forms.CheckBox checkBoxAll;
      private System.Windows.Forms.CheckBox checkBoxNone;
      private System.Windows.Forms.Button buttonCheckOnline;
   }
}