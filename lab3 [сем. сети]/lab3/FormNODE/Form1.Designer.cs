namespace FormNODE
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
            this.NodesCmb1 = new System.Windows.Forms.ComboBox();
            this.QuestionsCmb = new System.Windows.Forms.ComboBox();
            this.NodesCmb2 = new System.Windows.Forms.ComboBox();
            this.GetConclusionBtn = new System.Windows.Forms.Button();
            this.ChildsNodesListBox = new System.Windows.Forms.ListBox();
            this.GetChildsNodesBtn = new System.Windows.Forms.Button();
            this.NodesCmb3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ExplanationComponentCallBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NodesCmb1
            // 
            this.NodesCmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodesCmb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodesCmb1.FormattingEnabled = true;
            this.NodesCmb1.Location = new System.Drawing.Point(15, 50);
            this.NodesCmb1.Name = "NodesCmb1";
            this.NodesCmb1.Size = new System.Drawing.Size(186, 26);
            this.NodesCmb1.TabIndex = 0;
            // 
            // QuestionsCmb
            // 
            this.QuestionsCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuestionsCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionsCmb.FormattingEnabled = true;
            this.QuestionsCmb.Location = new System.Drawing.Point(251, 50);
            this.QuestionsCmb.Name = "QuestionsCmb";
            this.QuestionsCmb.Size = new System.Drawing.Size(157, 26);
            this.QuestionsCmb.TabIndex = 1;
            // 
            // NodesCmb2
            // 
            this.NodesCmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodesCmb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodesCmb2.FormattingEnabled = true;
            this.NodesCmb2.Location = new System.Drawing.Point(449, 50);
            this.NodesCmb2.Name = "NodesCmb2";
            this.NodesCmb2.Size = new System.Drawing.Size(185, 26);
            this.NodesCmb2.TabIndex = 2;
            // 
            // GetConclusionBtn
            // 
            this.GetConclusionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetConclusionBtn.Location = new System.Drawing.Point(251, 102);
            this.GetConclusionBtn.Name = "GetConclusionBtn";
            this.GetConclusionBtn.Size = new System.Drawing.Size(157, 30);
            this.GetConclusionBtn.TabIndex = 3;
            this.GetConclusionBtn.Text = "Проверить";
            this.GetConclusionBtn.UseVisualStyleBackColor = true;
            this.GetConclusionBtn.Click += new System.EventHandler(this.GetConclusionBtn_Click);
            // 
            // ChildsNodesListBox
            // 
            this.ChildsNodesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChildsNodesListBox.FormattingEnabled = true;
            this.ChildsNodesListBox.ItemHeight = 16;
            this.ChildsNodesListBox.Location = new System.Drawing.Point(173, 34);
            this.ChildsNodesListBox.Name = "ChildsNodesListBox";
            this.ChildsNodesListBox.Size = new System.Drawing.Size(438, 164);
            this.ChildsNodesListBox.TabIndex = 4;
            // 
            // GetChildsNodesBtn
            // 
            this.GetChildsNodesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetChildsNodesBtn.Location = new System.Drawing.Point(6, 102);
            this.GetChildsNodesBtn.Name = "GetChildsNodesBtn";
            this.GetChildsNodesBtn.Size = new System.Drawing.Size(158, 40);
            this.GetChildsNodesBtn.TabIndex = 5;
            this.GetChildsNodesBtn.Text = "Показать дочерние вершины";
            this.GetChildsNodesBtn.UseVisualStyleBackColor = true;
            this.GetChildsNodesBtn.Click += new System.EventHandler(this.GetChildsNodesBtn_Click);
            // 
            // NodesCmb3
            // 
            this.NodesCmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodesCmb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodesCmb3.FormattingEnabled = true;
            this.NodesCmb3.Location = new System.Drawing.Point(6, 53);
            this.NodesCmb3.Name = "NodesCmb3";
            this.NodesCmb3.Size = new System.Drawing.Size(158, 26);
            this.NodesCmb3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выберите первую вершину:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(446, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выберите вторую вершину:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(248, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Выберите тип вопроса:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ChildsNodesListBox);
            this.groupBox1.Controls.Add(this.NodesCmb3);
            this.groupBox1.Controls.Add(this.GetChildsNodesBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 209);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Просмотр дочерних вершин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Выберите вершину:";
            // 
            // ExplanationComponentCallBtn
            // 
            this.ExplanationComponentCallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExplanationComponentCallBtn.Location = new System.Drawing.Point(214, 157);
            this.ExplanationComponentCallBtn.Name = "ExplanationComponentCallBtn";
            this.ExplanationComponentCallBtn.Size = new System.Drawing.Size(240, 31);
            this.ExplanationComponentCallBtn.TabIndex = 11;
            this.ExplanationComponentCallBtn.Text = "Показать пройденные вершины";
            this.ExplanationComponentCallBtn.UseVisualStyleBackColor = true;
            this.ExplanationComponentCallBtn.Click += new System.EventHandler(this.ExplanationComponentCallBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 415);
            this.Controls.Add(this.ExplanationComponentCallBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetConclusionBtn);
            this.Controls.Add(this.NodesCmb2);
            this.Controls.Add(this.QuestionsCmb);
            this.Controls.Add(this.NodesCmb1);
            this.Name = "Form1";
            this.Text = "LAB 3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NodesCmb1;
        private System.Windows.Forms.ComboBox QuestionsCmb;
        private System.Windows.Forms.ComboBox NodesCmb2;
        private System.Windows.Forms.Button GetConclusionBtn;
        private System.Windows.Forms.ListBox ChildsNodesListBox;
        private System.Windows.Forms.Button GetChildsNodesBtn;
        private System.Windows.Forms.ComboBox NodesCmb3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ExplanationComponentCallBtn;
    }
}

