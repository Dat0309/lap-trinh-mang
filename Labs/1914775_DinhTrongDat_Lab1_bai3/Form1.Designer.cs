namespace _1914775_DinhTrongDat_Lab1_bai3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.txtDefaultGateway = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnPhanGiai = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPAddress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subnet Mask";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Default Gateway";
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.ForeColor = System.Drawing.Color.Red;
            this.txtIP.Location = new System.Drawing.Point(211, 8);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(222, 27);
            this.txtIP.TabIndex = 3;
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.Enabled = false;
            this.txtSubnetMask.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txtSubnetMask.Location = new System.Drawing.Point(211, 43);
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.ReadOnly = true;
            this.txtSubnetMask.Size = new System.Drawing.Size(222, 27);
            this.txtSubnetMask.TabIndex = 4;
            // 
            // txtDefaultGateway
            // 
            this.txtDefaultGateway.Enabled = false;
            this.txtDefaultGateway.ForeColor = System.Drawing.Color.Green;
            this.txtDefaultGateway.Location = new System.Drawing.Point(211, 80);
            this.txtDefaultGateway.Name = "txtDefaultGateway";
            this.txtDefaultGateway.ReadOnly = true;
            this.txtDefaultGateway.Size = new System.Drawing.Size(222, 27);
            this.txtDefaultGateway.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phân giải tên miền";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 181);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(421, 27);
            this.txtInput.TabIndex = 7;
            // 
            // btnPhanGiai
            // 
            this.btnPhanGiai.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnPhanGiai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhanGiai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPhanGiai.Location = new System.Drawing.Point(439, 181);
            this.btnPhanGiai.Name = "btnPhanGiai";
            this.btnPhanGiai.Size = new System.Drawing.Size(111, 29);
            this.btnPhanGiai.TabIndex = 8;
            this.btnPhanGiai.Text = "Phân giải";
            this.btnPhanGiai.UseVisualStyleBackColor = false;
            this.btnPhanGiai.Click += new System.EventHandler(this.btnPhanGiai_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kết quả phân giải";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 247);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(421, 27);
            this.txtResult.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 299);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPhanGiai);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDefaultGateway);
            this.Controls.Add(this.txtSubnetMask);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Phân giải tên miền";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtSubnetMask;
        private System.Windows.Forms.TextBox txtDefaultGateway;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnPhanGiai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResult;
    }
}
