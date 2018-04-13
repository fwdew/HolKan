namespace Server
{
   partial class HolKanServerForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolKanServerForm));
         this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
         this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.sender_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.recipient_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.status_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.confirm_reply = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.cancel_pressed = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.got_id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.Erased = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
         this.checkedListBoxUsers = new System.Windows.Forms.CheckedListBox();
         this.labelCurrentTimeText = new System.Windows.Forms.Label();
         this.labelCurrentTime = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGridViewEvents
         // 
         this.dataGridViewEvents.AllowUserToAddRows = false;
         this.dataGridViewEvents.AllowUserToDeleteRows = false;
         this.dataGridViewEvents.AllowUserToOrderColumns = true;
         this.dataGridViewEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.sender_ip,
            this.recipient_ip,
            this.type,
            this.message,
            this.status_message,
            this.confirm_reply,
            this.cancel_pressed,
            this.got_id,
            this.Erased,
            this.delete});
         this.dataGridViewEvents.Location = new System.Drawing.Point(172, 13);
         this.dataGridViewEvents.MultiSelect = false;
         this.dataGridViewEvents.Name = "dataGridViewEvents";
         this.dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridViewEvents.Size = new System.Drawing.Size(619, 318);
         this.dataGridViewEvents.TabIndex = 0;
         this.dataGridViewEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
         // 
         // id
         // 
         this.id.HeaderText = "id";
         this.id.Name = "id";
         this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // 
         // date
         // 
         this.date.HeaderText = "date";
         this.date.Name = "date";
         // 
         // sender_ip
         // 
         this.sender_ip.HeaderText = "sender ip";
         this.sender_ip.Name = "sender_ip";
         // 
         // recipient_ip
         // 
         this.recipient_ip.HeaderText = "recipient ip";
         this.recipient_ip.Name = "recipient_ip";
         // 
         // type
         // 
         this.type.HeaderText = "type";
         this.type.Name = "type";
         // 
         // message
         // 
         this.message.HeaderText = "message";
         this.message.Name = "message";
         // 
         // status_message
         // 
         this.status_message.HeaderText = "status message";
         this.status_message.Name = "status_message";
         // 
         // confirm_reply
         // 
         this.confirm_reply.HeaderText = "given confirm reply";
         this.confirm_reply.Name = "confirm_reply";
         // 
         // cancel_pressed
         // 
         this.cancel_pressed.HeaderText = "cancel pressed";
         this.cancel_pressed.Name = "cancel_pressed";
         // 
         // got_id
         // 
         this.got_id.HeaderText = "sender got id";
         this.got_id.Name = "got_id";
         this.got_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         // 
         // Erased
         // 
         this.Erased.HeaderText = "Erased";
         this.Erased.Name = "Erased";
         // 
         // delete
         // 
         this.delete.HeaderText = "Delete";
         this.delete.Name = "delete";
         this.delete.Text = "Delete";
         this.delete.UseColumnTextForButtonValue = true;
         // 
         // checkedListBoxUsers
         // 
         this.checkedListBoxUsers.FormattingEnabled = true;
         this.checkedListBoxUsers.Location = new System.Drawing.Point(12, 42);
         this.checkedListBoxUsers.Name = "checkedListBoxUsers";
         this.checkedListBoxUsers.Size = new System.Drawing.Size(144, 289);
         this.checkedListBoxUsers.Sorted = true;
         this.checkedListBoxUsers.TabIndex = 23;
         // 
         // labelCurrentTimeText
         // 
         this.labelCurrentTimeText.AutoSize = true;
         this.labelCurrentTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
         this.labelCurrentTimeText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelCurrentTimeText.Location = new System.Drawing.Point(9, 9);
         this.labelCurrentTimeText.Name = "labelCurrentTimeText";
         this.labelCurrentTimeText.Size = new System.Drawing.Size(78, 16);
         this.labelCurrentTimeText.TabIndex = 37;
         this.labelCurrentTimeText.Text = "Current time";
         // 
         // labelCurrentTime
         // 
         this.labelCurrentTime.AutoSize = true;
         this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
         this.labelCurrentTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.labelCurrentTime.Location = new System.Drawing.Point(12, 25);
         this.labelCurrentTime.Name = "labelCurrentTime";
         this.labelCurrentTime.Size = new System.Drawing.Size(0, 16);
         this.labelCurrentTime.TabIndex = 36;
         // 
         // HolKanServerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(837, 376);
         this.Controls.Add(this.labelCurrentTimeText);
         this.Controls.Add(this.labelCurrentTime);
         this.Controls.Add(this.checkedListBoxUsers);
         this.Controls.Add(this.dataGridViewEvents);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "HolKanServerForm";
         this.Text = "Голкан";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridViewEvents;
      private System.Windows.Forms.CheckedListBox checkedListBoxUsers;
      private System.Windows.Forms.DataGridViewTextBoxColumn id;
      private System.Windows.Forms.DataGridViewTextBoxColumn date;
      private System.Windows.Forms.DataGridViewTextBoxColumn sender_ip;
      private System.Windows.Forms.DataGridViewTextBoxColumn recipient_ip;
      private System.Windows.Forms.DataGridViewTextBoxColumn type;
      private System.Windows.Forms.DataGridViewTextBoxColumn message;
      private System.Windows.Forms.DataGridViewTextBoxColumn status_message;
      private System.Windows.Forms.DataGridViewTextBoxColumn confirm_reply;
      private System.Windows.Forms.DataGridViewTextBoxColumn cancel_pressed;
      private System.Windows.Forms.DataGridViewCheckBoxColumn got_id;
      private System.Windows.Forms.DataGridViewCheckBoxColumn Erased;
      private System.Windows.Forms.DataGridViewButtonColumn delete;
      private System.Windows.Forms.Label labelCurrentTimeText;
      private System.Windows.Forms.Label labelCurrentTime;
   }
}