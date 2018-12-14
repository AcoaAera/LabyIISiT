namespace NeuralTrainings
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RecognitionBtn = new System.Windows.Forms.Button();
            this.PbClearBtn = new System.Windows.Forms.Button();
            this.StudyModeRB = new System.Windows.Forms.RadioButton();
            this.RecognitionModeRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // RecognitionBtn
            // 
            this.RecognitionBtn.Location = new System.Drawing.Point(218, 97);
            this.RecognitionBtn.Name = "RecognitionBtn";
            this.RecognitionBtn.Size = new System.Drawing.Size(132, 32);
            this.RecognitionBtn.TabIndex = 9;
            this.RecognitionBtn.Text = "Распознать";
            this.RecognitionBtn.UseVisualStyleBackColor = true;
            this.RecognitionBtn.Click += new System.EventHandler(this.RecognitionBtn_Click);
            // 
            // PbClearBtn
            // 
            this.PbClearBtn.Location = new System.Drawing.Point(218, 258);
            this.PbClearBtn.Name = "PbClearBtn";
            this.PbClearBtn.Size = new System.Drawing.Size(132, 39);
            this.PbClearBtn.TabIndex = 10;
            this.PbClearBtn.Text = "Очистить  поверхность рисования";
            this.PbClearBtn.UseVisualStyleBackColor = true;
            this.PbClearBtn.Click += new System.EventHandler(this.PbClearBtn_Click);
            // 
            // StudyModeRB
            // 
            this.StudyModeRB.AutoSize = true;
            this.StudyModeRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StudyModeRB.Location = new System.Drawing.Point(12, 12);
            this.StudyModeRB.Name = "StudyModeRB";
            this.StudyModeRB.Size = new System.Drawing.Size(306, 22);
            this.StudyModeRB.TabIndex = 11;
            this.StudyModeRB.TabStop = true;
            this.StudyModeRB.Text = "Включить режим обучения (с учителем)";
            this.StudyModeRB.UseVisualStyleBackColor = true;
            this.StudyModeRB.CheckedChanged += new System.EventHandler(this.StudyModeRB_CheckedChanged);
            // 
            // RecognitionModeRB
            // 
            this.RecognitionModeRB.AutoSize = true;
            this.RecognitionModeRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecognitionModeRB.Location = new System.Drawing.Point(12, 40);
            this.RecognitionModeRB.Name = "RecognitionModeRB";
            this.RecognitionModeRB.Size = new System.Drawing.Size(254, 22);
            this.RecognitionModeRB.TabIndex = 12;
            this.RecognitionModeRB.TabStop = true;
            this.RecognitionModeRB.Text = "Включить режим распознавания";
            this.RecognitionModeRB.UseVisualStyleBackColor = true;
            this.RecognitionModeRB.CheckedChanged += new System.EventHandler(this.RecognitionModeRB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 314);
            this.Controls.Add(this.RecognitionModeRB);
            this.Controls.Add(this.StudyModeRB);
            this.Controls.Add(this.PbClearBtn);
            this.Controls.Add(this.RecognitionBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "LAB 5: PERCEPTRON";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button RecognitionBtn;
        private System.Windows.Forms.Button PbClearBtn;
        private System.Windows.Forms.RadioButton StudyModeRB;
        private System.Windows.Forms.RadioButton RecognitionModeRB;
    }
}

