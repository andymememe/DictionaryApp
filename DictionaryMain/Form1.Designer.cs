namespace DictionaryMain
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fromBox = new System.Windows.Forms.ComboBox();
            this.toBox = new System.Windows.Forms.ComboBox();
            this.wayLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.inputBox.Location = new System.Drawing.Point(85, 11);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(241, 38);
            this.inputBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "原文:";
            // 
            // fromBox
            // 
            this.fromBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromBox.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fromBox.FormattingEnabled = true;
            this.fromBox.Location = new System.Drawing.Point(381, 11);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(140, 37);
            this.fromBox.TabIndex = 3;
            // 
            // toBox
            // 
            this.toBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toBox.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toBox.FormattingEnabled = true;
            this.toBox.Location = new System.Drawing.Point(584, 11);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(140, 37);
            this.toBox.TabIndex = 4;
            // 
            // wayLabel
            // 
            this.wayLabel.AutoSize = true;
            this.wayLabel.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.wayLabel.Location = new System.Drawing.Point(527, 14);
            this.wayLabel.Name = "wayLabel";
            this.wayLabel.Size = new System.Drawing.Size(51, 30);
            this.wayLabel.TabIndex = 5;
            this.wayLabel.Text = "-->";
            this.wayLabel.Click += new System.EventHandler(this.wayLabel_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.submitBtn.Location = new System.Drawing.Point(742, 11);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 38);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "搜尋";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.resultBox.Location = new System.Drawing.Point(17, 64);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(800, 122);
            this.resultBox.TabIndex = 7;
            this.resultBox.Text = "(提醒: 按下\"-->\"可交換兩邊語言)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 198);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.wayLabel);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "字典";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fromBox;
        private System.Windows.Forms.ComboBox toBox;
        private System.Windows.Forms.Label wayLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.RichTextBox resultBox;
    }
}

