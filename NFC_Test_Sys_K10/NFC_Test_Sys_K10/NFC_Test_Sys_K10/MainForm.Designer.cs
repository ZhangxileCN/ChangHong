namespace NFC_Test_Sys_K10
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbState = new System.Windows.Forms.TextBox();
            this.btnNFCinit = new System.Windows.Forms.Button();
            this.tbSN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvDisplay = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbJobNum = new System.Windows.Forms.TextBox();
            this.tbICCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSN0 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPassRate = new System.Windows.Forms.TextBox();
            this.tbFail = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuFile = new System.Windows.Forms.MenuStrip();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbState);
            this.groupBox1.Controls.Add(this.btnNFCinit);
            this.groupBox1.Location = new System.Drawing.Point(68, 286);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(311, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NFC工具初始化";
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(16, 87);
            this.tbState.Margin = new System.Windows.Forms.Padding(2);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(260, 54);
            this.tbState.TabIndex = 13;
            // 
            // btnNFCinit
            // 
            this.btnNFCinit.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNFCinit.Location = new System.Drawing.Point(16, 30);
            this.btnNFCinit.Margin = new System.Windows.Forms.Padding(2);
            this.btnNFCinit.Name = "btnNFCinit";
            this.btnNFCinit.Size = new System.Drawing.Size(259, 38);
            this.btnNFCinit.TabIndex = 12;
            this.btnNFCinit.Text = "初始化NFC工具";
            this.btnNFCinit.UseVisualStyleBackColor = true;
            this.btnNFCinit.Click += new System.EventHandler(this.btnNFCinit_Click);
            // 
            // tbSN
            // 
            this.tbSN.Location = new System.Drawing.Point(532, 18);
            this.tbSN.Margin = new System.Windows.Forms.Padding(2);
            this.tbSN.Name = "tbSN";
            this.tbSN.Size = new System.Drawing.Size(534, 21);
            this.tbSN.TabIndex = 1;
            this.tbSN.TextChanged += new System.EventHandler(this.tbSN_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(472, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "条码";
            // 
            // lvDisplay
            // 
            this.lvDisplay.HideSelection = false;
            this.lvDisplay.Location = new System.Drawing.Point(476, 48);
            this.lvDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.lvDisplay.Name = "lvDisplay";
            this.lvDisplay.Size = new System.Drawing.Size(810, 617);
            this.lvDisplay.TabIndex = 3;
            this.lvDisplay.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSure);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbJobNum);
            this.groupBox2.Controls.Add(this.tbICCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbSN0);
            this.groupBox2.Location = new System.Drawing.Point(68, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(311, 214);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品信息";
            // 
            // btnSure
            // 
            this.btnSure.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.Location = new System.Drawing.Point(16, 142);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(259, 37);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确认产品信息";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 102);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "订单号";
            // 
            // tbJobNum
            // 
            this.tbJobNum.Location = new System.Drawing.Point(113, 95);
            this.tbJobNum.Margin = new System.Windows.Forms.Padding(2);
            this.tbJobNum.Name = "tbJobNum";
            this.tbJobNum.Size = new System.Drawing.Size(162, 21);
            this.tbJobNum.TabIndex = 4;
            // 
            // tbICCode
            // 
            this.tbICCode.Location = new System.Drawing.Point(113, 58);
            this.tbICCode.Margin = new System.Windows.Forms.Padding(2);
            this.tbICCode.Name = "tbICCode";
            this.tbICCode.Size = new System.Drawing.Size(162, 21);
            this.tbICCode.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "扫码识别产品信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "ICCode";
            // 
            // tbSN0
            // 
            this.tbSN0.Location = new System.Drawing.Point(113, 20);
            this.tbSN0.Margin = new System.Windows.Forms.Padding(2);
            this.tbSN0.Name = "tbSN0";
            this.tbSN0.Size = new System.Drawing.Size(162, 21);
            this.tbSN0.TabIndex = 0;
            this.tbSN0.TextChanged += new System.EventHandler(this.tbSN0_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPassRate);
            this.groupBox3.Controls.Add(this.tbFail);
            this.groupBox3.Controls.Add(this.tbPass);
            this.groupBox3.Controls.Add(this.tbTotal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(68, 503);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(311, 161);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试状态统计";
            // 
            // tbPassRate
            // 
            this.tbPassRate.Location = new System.Drawing.Point(129, 120);
            this.tbPassRate.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassRate.Name = "tbPassRate";
            this.tbPassRate.Size = new System.Drawing.Size(146, 21);
            this.tbPassRate.TabIndex = 7;
            // 
            // tbFail
            // 
            this.tbFail.Location = new System.Drawing.Point(129, 86);
            this.tbFail.Margin = new System.Windows.Forms.Padding(2);
            this.tbFail.Name = "tbFail";
            this.tbFail.Size = new System.Drawing.Size(146, 21);
            this.tbFail.TabIndex = 6;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(129, 56);
            this.tbPass.Margin = new System.Windows.Forms.Padding(2);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(146, 21);
            this.tbPass.TabIndex = 5;
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(129, 27);
            this.tbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(146, 21);
            this.tbTotal.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "测试通过率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "测试未通过pcs：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "测试通过pcs：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "共测试pcs：";
            // 
            // menuFile
            // 
            this.menuFile.Location = new System.Drawing.Point(0, 0);
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(1304, 24);
            this.menuFile.TabIndex = 6;
            this.menuFile.Text = "文件";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFC_Test_Sys_K10.Properties.Resources.NFC_new;
            this.ClientSize = new System.Drawing.Size(1304, 682);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvDisplay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuFile);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuFile;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "NFC_TP_K1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Button btnNFCinit;
        private System.Windows.Forms.TextBox tbSN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbJobNum;
        private System.Windows.Forms.TextBox tbICCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSN0;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbPassRate;
        private System.Windows.Forms.TextBox tbFail;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuFile;
    }
}

