namespace Ble_LocalName
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜索蓝牙";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.搜索蓝牙);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 118);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1840, 250);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(23, 428);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1840, 250);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keep only packets type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Get higher";
            // 
            // numericEdit1
            // 
            this.numericEdit1.Location = new System.Drawing.Point(365, 68);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(120, 38);
            this.numericEdit1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 45);
            this.button2.TabIndex = 6;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.清除);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1892, 1001);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
        private System.Windows.Forms.Button button2;
    }
}

