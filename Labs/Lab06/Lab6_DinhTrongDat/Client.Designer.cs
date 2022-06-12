namespace Lab6_DinhTrongDat
{
    partial class Client
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
            if (disposing && (components != null))
            {
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
            this.btn_Connect_Client = new System.Windows.Forms.Button();
            this.btn_DisConnect_Client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMess = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Connect_Client
            // 
            this.btn_Connect_Client.Location = new System.Drawing.Point(100, 54);
            this.btn_Connect_Client.Name = "btn_Connect_Client";
            this.btn_Connect_Client.Size = new System.Drawing.Size(135, 68);
            this.btn_Connect_Client.TabIndex = 0;
            this.btn_Connect_Client.Text = "Connect";
            this.btn_Connect_Client.UseVisualStyleBackColor = true;
            this.btn_Connect_Client.Click += new System.EventHandler(this.btn_Connect_Client_Click);
            // 
            // btn_DisConnect_Client
            // 
            this.btn_DisConnect_Client.Location = new System.Drawing.Point(339, 54);
            this.btn_DisConnect_Client.Name = "btn_DisConnect_Client";
            this.btn_DisConnect_Client.Size = new System.Drawing.Size(127, 68);
            this.btn_DisConnect_Client.TabIndex = 1;
            this.btn_DisConnect_Client.Text = "Dis Connect";
            this.btn_DisConnect_Client.UseVisualStyleBackColor = true;
            this.btn_DisConnect_Client.Click += new System.EventHandler(this.btn_DisConnect_Client_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text receive from client";
            // 
            // txtMess
            // 
            this.txtMess.Location = new System.Drawing.Point(100, 179);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(293, 27);
            this.txtMess.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(420, 179);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 29);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(100, 228);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(366, 124);
            this.listBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(246, 380);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 27);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Connection Status";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_DisConnect_Client);
            this.Controls.Add(this.btn_Connect_Client);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect_Client;
        private System.Windows.Forms.Button btn_DisConnect_Client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMess;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}