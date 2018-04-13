namespace Configure
{
   partial class ConfigurationForm
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
         this.buttonConfigure = new System.Windows.Forms.Button();
         this.buttonReset = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // buttonConfigure
         // 
         this.buttonConfigure.Location = new System.Drawing.Point(12, 226);
         this.buttonConfigure.Name = "buttonConfigure";
         this.buttonConfigure.Size = new System.Drawing.Size(75, 23);
         this.buttonConfigure.TabIndex = 0;
         this.buttonConfigure.Text = "Configure";
         this.buttonConfigure.UseVisualStyleBackColor = true;
         this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
         // 
         // buttonReset
         // 
         this.buttonReset.Location = new System.Drawing.Point(93, 226);
         this.buttonReset.Name = "buttonReset";
         this.buttonReset.Size = new System.Drawing.Size(75, 23);
         this.buttonReset.TabIndex = 1;
         this.buttonReset.Text = "Reset";
         this.buttonReset.UseVisualStyleBackColor = true;
         this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
         // 
         // ConfigurationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(180, 261);
         this.Controls.Add(this.buttonReset);
         this.Controls.Add(this.buttonConfigure);
         this.Name = "ConfigurationForm";
         this.Text = "Configuration";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonConfigure;
      private System.Windows.Forms.Button buttonReset;
   }
}

