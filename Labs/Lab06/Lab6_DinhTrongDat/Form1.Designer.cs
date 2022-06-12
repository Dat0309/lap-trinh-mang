namespace Lab6_DinhTrongDat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start_server = new System.Windows.Forms.Button();
            this.btn_stop_server = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_start_server
            // 
            this.btn_start_server.Location = new System.Drawing.Point(115, 35);
            this.btn_start_server.Name = "btn_start_server";
            this.btn_start_server.Size = new System.Drawing.Size(151, 66);
            this.btn_start_server.TabIndex = 0;
            this.btn_start_server.Text = "Start Server";
            this.btn_start_server.UseVisualStyleBackColor = true;
            this.btn_start_server.Click += new System.EventHandler(this.btn_start_server_Click);
            // 
            // btn_stop_server
            // 
            this.btn_stop_server.Location = new System.Drawing.Point(374, 35);
            this.btn_stop_server.Name = "btn_stop_server";
            this.btn_stop_server.Size = new System.Drawing.Size(151, 66);
            this.btn_stop_server.TabIndex = 1;
            this.btn_stop_server.Text = "Stop Server";
            this.btn_stop_server.UseVisualStyleBackColor = true;
            this.btn_stop_server.Click += new System.EventHandler(this.btn_stop_server_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "text receive from client";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(115, 162);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(410, 184);
            this.listBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "connect status";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(235, 376);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 27);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_stop_server);
            this.Controls.Add(this.btn_start_server);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start_server;
        private System.Windows.Forms.Button btn_stop_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
