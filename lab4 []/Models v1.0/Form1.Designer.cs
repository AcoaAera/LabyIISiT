namespace Models_v1._0
{
    partial class Form1
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
            this.select = new System.Windows.Forms.Button();
            this.variantsAnswers = new System.Windows.Forms.ListBox();
            this.preferencesUsers = new System.Windows.Forms.ListBox();
            this.clearAnswers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.countUsers = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vote = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(161, 22);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 0;
            this.select.Text = "Выбрать";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.button1_Click);
            // 
            // variantsAnswers
            // 
            this.variantsAnswers.FormattingEnabled = true;
            this.variantsAnswers.Location = new System.Drawing.Point(12, 22);
            this.variantsAnswers.Name = "variantsAnswers";
            this.variantsAnswers.Size = new System.Drawing.Size(120, 108);
            this.variantsAnswers.TabIndex = 1;
            // 
            // preferencesUsers
            // 
            this.preferencesUsers.FormattingEnabled = true;
            this.preferencesUsers.Location = new System.Drawing.Point(270, 22);
            this.preferencesUsers.Name = "preferencesUsers";
            this.preferencesUsers.Size = new System.Drawing.Size(120, 108);
            this.preferencesUsers.TabIndex = 2;
            // 
            // clearAnswers
            // 
            this.clearAnswers.Location = new System.Drawing.Point(161, 65);
            this.clearAnswers.Name = "clearAnswers";
            this.clearAnswers.Size = new System.Drawing.Size(75, 23);
            this.clearAnswers.TabIndex = 3;
            this.clearAnswers.Text = "Очистить";
            this.clearAnswers.UseVisualStyleBackColor = true;
            this.clearAnswers.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите число избирателей:";
            // 
            // countUsers
            // 
            this.countUsers.Location = new System.Drawing.Point(170, 155);
            this.countUsers.Name = "countUsers";
            this.countUsers.Size = new System.Drawing.Size(66, 20);
            this.countUsers.TabIndex = 5;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(170, 181);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(66, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Избиратель №";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // vote
            // 
            this.vote.Location = new System.Drawing.Point(161, 107);
            this.vote.Name = "vote";
            this.vote.Size = new System.Drawing.Size(75, 23);
            this.vote.TabIndex = 9;
            this.vote.Text = "Голосовать";
            this.vote.UseVisualStyleBackColor = true;
            this.vote.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 272);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(378, 103);
            this.textBox1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Профиль голосования:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(404, 386);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.vote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.countUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearAnswers);
            this.Controls.Add(this.preferencesUsers);
            this.Controls.Add(this.variantsAnswers);
            this.Controls.Add(this.select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Лабораторная №4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.ListBox variantsAnswers;
        private System.Windows.Forms.ListBox preferencesUsers;
        private System.Windows.Forms.Button clearAnswers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countUsers;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button vote;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}

