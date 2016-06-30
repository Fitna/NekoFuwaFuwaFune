namespace NekoFuwaFuwaFune
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SkirmishBackground = new System.Windows.Forms.PictureBox();
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.AttackBtn = new System.Windows.Forms.Button();
            this.EvadeBtn = new System.Windows.Forms.Button();
            this.CounterBtn = new System.Windows.Forms.Button();
            this.AboutUs = new System.Windows.Forms.Button();
            this.AboutEnemy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkirmishBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // SkirmishBackground
            // 
            this.SkirmishBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkirmishBackground.Location = new System.Drawing.Point(0, 0);
            this.SkirmishBackground.Name = "SkirmishBackground";
            this.SkirmishBackground.Size = new System.Drawing.Size(792, 440);
            this.SkirmishBackground.TabIndex = 0;
            this.SkirmishBackground.TabStop = false;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTextBox.Location = new System.Drawing.Point(105, 12);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.Size = new System.Drawing.Size(675, 416);
            this.MainTextBox.TabIndex = 3;
            this.MainTextBox.Text = "";
            // 
            // AttackBtn
            // 
            this.AttackBtn.Location = new System.Drawing.Point(12, 10);
            this.AttackBtn.Name = "AttackBtn";
            this.AttackBtn.Size = new System.Drawing.Size(87, 23);
            this.AttackBtn.TabIndex = 4;
            this.AttackBtn.Text = "Атака";
            this.AttackBtn.UseVisualStyleBackColor = true;
            this.AttackBtn.Click += new System.EventHandler(this.AttackBtn_Click);
            // 
            // EvadeBtn
            // 
            this.EvadeBtn.Location = new System.Drawing.Point(12, 39);
            this.EvadeBtn.Name = "EvadeBtn";
            this.EvadeBtn.Size = new System.Drawing.Size(87, 23);
            this.EvadeBtn.TabIndex = 5;
            this.EvadeBtn.Text = "Уворот";
            this.EvadeBtn.UseVisualStyleBackColor = true;
            this.EvadeBtn.Click += new System.EventHandler(this.EvadeBtn_Click);
            // 
            // CounterBtn
            // 
            this.CounterBtn.Location = new System.Drawing.Point(12, 68);
            this.CounterBtn.Name = "CounterBtn";
            this.CounterBtn.Size = new System.Drawing.Size(87, 23);
            this.CounterBtn.TabIndex = 6;
            this.CounterBtn.Text = "Контратака";
            this.CounterBtn.UseVisualStyleBackColor = true;
            this.CounterBtn.Click += new System.EventHandler(this.CounterBtn_Click);
            // 
            // AboutUs
            // 
            this.AboutUs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AboutUs.Location = new System.Drawing.Point(12, 324);
            this.AboutUs.Name = "AboutUs";
            this.AboutUs.Size = new System.Drawing.Size(87, 49);
            this.AboutUs.TabIndex = 7;
            this.AboutUs.Text = "Информация о нашей флотилии";
            this.AboutUs.UseVisualStyleBackColor = true;
            this.AboutUs.Click += new System.EventHandler(this.AboutUs_Click);
            // 
            // AboutEnemy
            // 
            this.AboutEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AboutEnemy.Location = new System.Drawing.Point(12, 379);
            this.AboutEnemy.Name = "AboutEnemy";
            this.AboutEnemy.Size = new System.Drawing.Size(87, 49);
            this.AboutEnemy.TabIndex = 10;
            this.AboutEnemy.Text = "Информация о вражеской флотилии";
            this.AboutEnemy.UseVisualStyleBackColor = true;
            this.AboutEnemy.Click += new System.EventHandler(this.AboutEnemy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 440);
            this.Controls.Add(this.AboutEnemy);
            this.Controls.Add(this.AboutUs);
            this.Controls.Add(this.CounterBtn);
            this.Controls.Add(this.EvadeBtn);
            this.Controls.Add(this.AttackBtn);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.SkirmishBackground);
            this.Name = "MainForm";
            this.Text = "Nice Boat";
            ((System.ComponentModel.ISupportInitialize)(this.SkirmishBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SkirmishBackground;
        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.Button AttackBtn;
        private System.Windows.Forms.Button EvadeBtn;
        private System.Windows.Forms.Button CounterBtn;
        private System.Windows.Forms.Button AboutUs;
        private System.Windows.Forms.Button AboutEnemy;
    }
}

