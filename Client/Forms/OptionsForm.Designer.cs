namespace Client
{
   partial class OptionsForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
         this.groupBoxFormMain = new System.Windows.Forms.GroupBox();
         this.labelDefaultLanguage = new System.Windows.Forms.Label();
         this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
         this.buttonOk = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.groupBoxFormShowMessage = new System.Windows.Forms.GroupBox();
         this.checkBoxEnableSound = new System.Windows.Forms.CheckBox();
         this.labelAutoCloseForm = new System.Windows.Forms.Label();
         this.labelStartCountdown = new System.Windows.Forms.Label();
         this.labelMinutesIgnoring = new System.Windows.Forms.Label();
         this.labelDelayButton10 = new System.Windows.Forms.Label();
         this.numericUpDownAutoCloseForm = new System.Windows.Forms.NumericUpDown();
         this.labelSeconds2 = new System.Windows.Forms.Label();
         this.numericUpDownStartCountdown = new System.Windows.Forms.NumericUpDown();
         this.labelSeconds1 = new System.Windows.Forms.Label();
         this.numericUpDownDelayIgnoring = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownDelayButton10 = new System.Windows.Forms.NumericUpDown();
         this.labelMinutes3 = new System.Windows.Forms.Label();
         this.labelMinutes2 = new System.Windows.Forms.Label();
         this.labelMinutes1 = new System.Windows.Forms.Label();
         this.numericUpDownDelayButton5 = new System.Windows.Forms.NumericUpDown();
         this.labelDelayButton5 = new System.Windows.Forms.Label();
         this.groupBoxFormMain.SuspendLayout();
         this.groupBoxFormShowMessage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoCloseForm)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartCountdown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayIgnoring)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayButton10)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayButton5)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBoxFormMain
         // 
         this.groupBoxFormMain.Controls.Add(this.labelDefaultLanguage);
         this.groupBoxFormMain.Controls.Add(this.comboBoxLanguage);
         this.groupBoxFormMain.Enabled = false;
         this.groupBoxFormMain.Location = new System.Drawing.Point(12, 12);
         this.groupBoxFormMain.Name = "groupBoxFormMain";
         this.groupBoxFormMain.Size = new System.Drawing.Size(312, 247);
         this.groupBoxFormMain.TabIndex = 0;
         this.groupBoxFormMain.TabStop = false;
         this.groupBoxFormMain.Text = "Main Form";
         this.groupBoxFormMain.Visible = false;
         // 
         // labelDefaultLanguage
         // 
         this.labelDefaultLanguage.AutoSize = true;
         this.labelDefaultLanguage.Location = new System.Drawing.Point(16, 22);
         this.labelDefaultLanguage.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelDefaultLanguage.Name = "labelDefaultLanguage";
         this.labelDefaultLanguage.Size = new System.Drawing.Size(104, 13);
         this.labelDefaultLanguage.TabIndex = 1;
         this.labelDefaultLanguage.Text = "Language by default";
         // 
         // comboBoxLanguage
         // 
         this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxLanguage.FormattingEnabled = true;
         this.comboBoxLanguage.Items.AddRange(new object[] {
            "Українська",
            "English"});
         this.comboBoxLanguage.Location = new System.Drawing.Point(159, 19);
         this.comboBoxLanguage.Name = "comboBoxLanguage";
         this.comboBoxLanguage.Size = new System.Drawing.Size(86, 21);
         this.comboBoxLanguage.TabIndex = 2;
         // 
         // buttonOk
         // 
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point(205, 265);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(119, 25);
         this.buttonOk.TabIndex = 1;
         this.buttonOk.Text = "Ok";
         this.buttonOk.UseVisualStyleBackColor = true;
         this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(330, 265);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(119, 25);
         this.buttonCancel.TabIndex = 2;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // groupBoxFormShowMessage
         // 
         this.groupBoxFormShowMessage.Controls.Add(this.checkBoxEnableSound);
         this.groupBoxFormShowMessage.Controls.Add(this.labelAutoCloseForm);
         this.groupBoxFormShowMessage.Controls.Add(this.labelStartCountdown);
         this.groupBoxFormShowMessage.Controls.Add(this.labelMinutesIgnoring);
         this.groupBoxFormShowMessage.Controls.Add(this.labelDelayButton10);
         this.groupBoxFormShowMessage.Controls.Add(this.numericUpDownAutoCloseForm);
         this.groupBoxFormShowMessage.Controls.Add(this.labelSeconds2);
         this.groupBoxFormShowMessage.Controls.Add(this.numericUpDownStartCountdown);
         this.groupBoxFormShowMessage.Controls.Add(this.labelSeconds1);
         this.groupBoxFormShowMessage.Controls.Add(this.numericUpDownDelayIgnoring);
         this.groupBoxFormShowMessage.Controls.Add(this.numericUpDownDelayButton10);
         this.groupBoxFormShowMessage.Controls.Add(this.labelMinutes3);
         this.groupBoxFormShowMessage.Controls.Add(this.labelMinutes2);
         this.groupBoxFormShowMessage.Controls.Add(this.labelMinutes1);
         this.groupBoxFormShowMessage.Controls.Add(this.numericUpDownDelayButton5);
         this.groupBoxFormShowMessage.Controls.Add(this.labelDelayButton5);
         this.groupBoxFormShowMessage.Location = new System.Drawing.Point(330, 12);
         this.groupBoxFormShowMessage.Name = "groupBoxFormShowMessage";
         this.groupBoxFormShowMessage.Size = new System.Drawing.Size(312, 247);
         this.groupBoxFormShowMessage.TabIndex = 1;
         this.groupBoxFormShowMessage.TabStop = false;
         this.groupBoxFormShowMessage.Text = "Message Form";
         // 
         // checkBoxEnableSound
         // 
         this.checkBoxEnableSound.AutoSize = true;
         this.checkBoxEnableSound.Checked = true;
         this.checkBoxEnableSound.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxEnableSound.Location = new System.Drawing.Point(19, 219);
         this.checkBoxEnableSound.Name = "checkBoxEnableSound";
         this.checkBoxEnableSound.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.checkBoxEnableSound.Size = new System.Drawing.Size(96, 17);
         this.checkBoxEnableSound.TabIndex = 17;
         this.checkBoxEnableSound.Text = "Enable sounds";
         this.checkBoxEnableSound.UseVisualStyleBackColor = true;
         // 
         // labelAutoCloseForm
         // 
         this.labelAutoCloseForm.AutoSize = true;
         this.labelAutoCloseForm.Location = new System.Drawing.Point(16, 178);
         this.labelAutoCloseForm.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelAutoCloseForm.Name = "labelAutoCloseForm";
         this.labelAutoCloseForm.Size = new System.Drawing.Size(139, 26);
         this.labelAutoCloseForm.TabIndex = 16;
         this.labelAutoCloseForm.Text = "Automatically close window after";
         // 
         // labelStartCountdown
         // 
         this.labelStartCountdown.AutoSize = true;
         this.labelStartCountdown.Location = new System.Drawing.Point(16, 138);
         this.labelStartCountdown.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelStartCountdown.Name = "labelStartCountdown";
         this.labelStartCountdown.Size = new System.Drawing.Size(128, 26);
         this.labelStartCountdown.TabIndex = 15;
         this.labelStartCountdown.Text = "Start countdown to close window after";
         // 
         // labelMinutesIgnoring
         // 
         this.labelMinutesIgnoring.AutoSize = true;
         this.labelMinutesIgnoring.Location = new System.Drawing.Point(16, 99);
         this.labelMinutesIgnoring.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelMinutesIgnoring.Name = "labelMinutesIgnoring";
         this.labelMinutesIgnoring.Size = new System.Drawing.Size(147, 26);
         this.labelMinutesIgnoring.TabIndex = 14;
         this.labelMinutesIgnoring.Text = "Delay reopen message when ignoring";
         // 
         // labelDelayButton10
         // 
         this.labelDelayButton10.AutoSize = true;
         this.labelDelayButton10.Location = new System.Drawing.Point(16, 60);
         this.labelDelayButton10.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelDelayButton10.Name = "labelDelayButton10";
         this.labelDelayButton10.Size = new System.Drawing.Size(105, 13);
         this.labelDelayButton10.TabIndex = 13;
         this.labelDelayButton10.Text = "Second button delay";
         // 
         // numericUpDownAutoCloseForm
         // 
         this.numericUpDownAutoCloseForm.Location = new System.Drawing.Point(169, 178);
         this.numericUpDownAutoCloseForm.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
         this.numericUpDownAutoCloseForm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownAutoCloseForm.Name = "numericUpDownAutoCloseForm";
         this.numericUpDownAutoCloseForm.Size = new System.Drawing.Size(42, 20);
         this.numericUpDownAutoCloseForm.TabIndex = 12;
         this.numericUpDownAutoCloseForm.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // labelSeconds2
         // 
         this.labelSeconds2.AutoSize = true;
         this.labelSeconds2.Location = new System.Drawing.Point(221, 180);
         this.labelSeconds2.Name = "labelSeconds2";
         this.labelSeconds2.Size = new System.Drawing.Size(27, 13);
         this.labelSeconds2.TabIndex = 11;
         this.labelSeconds2.Text = "sec.";
         // 
         // numericUpDownStartCountdown
         // 
         this.numericUpDownStartCountdown.Location = new System.Drawing.Point(169, 138);
         this.numericUpDownStartCountdown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
         this.numericUpDownStartCountdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownStartCountdown.Name = "numericUpDownStartCountdown";
         this.numericUpDownStartCountdown.Size = new System.Drawing.Size(42, 20);
         this.numericUpDownStartCountdown.TabIndex = 10;
         this.numericUpDownStartCountdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // labelSeconds1
         // 
         this.labelSeconds1.AutoSize = true;
         this.labelSeconds1.Location = new System.Drawing.Point(221, 140);
         this.labelSeconds1.Name = "labelSeconds1";
         this.labelSeconds1.Size = new System.Drawing.Size(27, 13);
         this.labelSeconds1.TabIndex = 9;
         this.labelSeconds1.Text = "sec.";
         // 
         // numericUpDownDelayIgnoring
         // 
         this.numericUpDownDelayIgnoring.Location = new System.Drawing.Point(169, 99);
         this.numericUpDownDelayIgnoring.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
         this.numericUpDownDelayIgnoring.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownDelayIgnoring.Name = "numericUpDownDelayIgnoring";
         this.numericUpDownDelayIgnoring.Size = new System.Drawing.Size(42, 20);
         this.numericUpDownDelayIgnoring.TabIndex = 8;
         this.numericUpDownDelayIgnoring.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
         // 
         // numericUpDownDelayButton10
         // 
         this.numericUpDownDelayButton10.Location = new System.Drawing.Point(167, 60);
         this.numericUpDownDelayButton10.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
         this.numericUpDownDelayButton10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownDelayButton10.Name = "numericUpDownDelayButton10";
         this.numericUpDownDelayButton10.Size = new System.Drawing.Size(42, 20);
         this.numericUpDownDelayButton10.TabIndex = 7;
         this.numericUpDownDelayButton10.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // labelMinutes3
         // 
         this.labelMinutes3.AutoSize = true;
         this.labelMinutes3.Location = new System.Drawing.Point(221, 101);
         this.labelMinutes3.Name = "labelMinutes3";
         this.labelMinutes3.Size = new System.Drawing.Size(26, 13);
         this.labelMinutes3.TabIndex = 6;
         this.labelMinutes3.Text = "min.";
         // 
         // labelMinutes2
         // 
         this.labelMinutes2.AutoSize = true;
         this.labelMinutes2.Location = new System.Drawing.Point(219, 62);
         this.labelMinutes2.Name = "labelMinutes2";
         this.labelMinutes2.Size = new System.Drawing.Size(26, 13);
         this.labelMinutes2.TabIndex = 5;
         this.labelMinutes2.Text = "min.";
         // 
         // labelMinutes1
         // 
         this.labelMinutes1.AutoSize = true;
         this.labelMinutes1.Location = new System.Drawing.Point(219, 24);
         this.labelMinutes1.Name = "labelMinutes1";
         this.labelMinutes1.Size = new System.Drawing.Size(26, 13);
         this.labelMinutes1.TabIndex = 4;
         this.labelMinutes1.Text = "min.";
         // 
         // numericUpDownDelayButton5
         // 
         this.numericUpDownDelayButton5.Location = new System.Drawing.Point(167, 22);
         this.numericUpDownDelayButton5.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
         this.numericUpDownDelayButton5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownDelayButton5.Name = "numericUpDownDelayButton5";
         this.numericUpDownDelayButton5.Size = new System.Drawing.Size(42, 20);
         this.numericUpDownDelayButton5.TabIndex = 3;
         this.numericUpDownDelayButton5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
         // 
         // labelDelayButton5
         // 
         this.labelDelayButton5.AutoSize = true;
         this.labelDelayButton5.Location = new System.Drawing.Point(16, 22);
         this.labelDelayButton5.MaximumSize = new System.Drawing.Size(150, 0);
         this.labelDelayButton5.Name = "labelDelayButton5";
         this.labelDelayButton5.Size = new System.Drawing.Size(87, 13);
         this.labelDelayButton5.TabIndex = 2;
         this.labelDelayButton5.Text = "First button delay";
         // 
         // FormOptions
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(653, 301);
         this.Controls.Add(this.groupBoxFormShowMessage);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.groupBoxFormMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormOptions";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Form1";
         this.groupBoxFormMain.ResumeLayout(false);
         this.groupBoxFormMain.PerformLayout();
         this.groupBoxFormShowMessage.ResumeLayout(false);
         this.groupBoxFormShowMessage.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoCloseForm)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartCountdown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayIgnoring)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayButton10)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayButton5)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxFormMain;
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.GroupBox groupBoxFormShowMessage;
      private System.Windows.Forms.Label labelDelayButton5;
      private System.Windows.Forms.Label labelDefaultLanguage;
      private System.Windows.Forms.ComboBox comboBoxLanguage;
      private System.Windows.Forms.Label labelMinutes2;
      private System.Windows.Forms.Label labelMinutes1;
      private System.Windows.Forms.NumericUpDown numericUpDownDelayButton5;
      private System.Windows.Forms.Label labelMinutes3;
      private System.Windows.Forms.NumericUpDown numericUpDownDelayButton10;
      private System.Windows.Forms.NumericUpDown numericUpDownDelayIgnoring;
      private System.Windows.Forms.NumericUpDown numericUpDownAutoCloseForm;
      private System.Windows.Forms.Label labelSeconds2;
      private System.Windows.Forms.NumericUpDown numericUpDownStartCountdown;
      private System.Windows.Forms.Label labelSeconds1;
      private System.Windows.Forms.Label labelAutoCloseForm;
      private System.Windows.Forms.Label labelStartCountdown;
      private System.Windows.Forms.Label labelMinutesIgnoring;
      private System.Windows.Forms.Label labelDelayButton10;
      private System.Windows.Forms.CheckBox checkBoxEnableSound;

   }
}