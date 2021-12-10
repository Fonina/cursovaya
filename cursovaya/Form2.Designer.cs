namespace curs
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvIngridients = new System.Windows.Forms.DataGridView();
            this.cbIngridient = new System.Windows.Forms.ComboBox();
            this.btnAddIngridient = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddType = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGramm = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngridients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страна";
            // 
            // cbCountry
            // 
            this.cbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(62, 10);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(331, 21);
            this.cbCountry.TabIndex = 1;
            this.cbCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCountry_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Автор";
            // 
            // cbAuthor
            // 
            this.cbAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(458, 10);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(331, 21);
            this.cbAuthor.TabIndex = 3;
            this.cbAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAuthor_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ингридиент";
            // 
            // dgvIngridients
            // 
            this.dgvIngridients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngridients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngridients.Location = new System.Drawing.Point(7, 96);
            this.dgvIngridients.Name = "dgvIngridients";
            this.dgvIngridients.Size = new System.Drawing.Size(777, 150);
            this.dgvIngridients.TabIndex = 5;
            this.dgvIngridients.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvIngridients_UserDeletingRow);
            // 
            // cbIngridient
            // 
            this.cbIngridient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbIngridient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbIngridient.FormattingEnabled = true;
            this.cbIngridient.Location = new System.Drawing.Point(93, 49);
            this.cbIngridient.Name = "cbIngridient";
            this.cbIngridient.Size = new System.Drawing.Size(272, 21);
            this.cbIngridient.TabIndex = 6;
            this.cbIngridient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbIngridient_KeyDown);
            // 
            // btnAddIngridient
            // 
            this.btnAddIngridient.Location = new System.Drawing.Point(663, 47);
            this.btnAddIngridient.Name = "btnAddIngridient";
            this.btnAddIngridient.Size = new System.Drawing.Size(121, 23);
            this.btnAddIngridient.TabIndex = 7;
            this.btnAddIngridient.Text = "Добавить в рецепт";
            this.btnAddIngridient.UseVisualStyleBackColor = true;
            this.btnAddIngridient.Click += new System.EventHandler(this.btnAddIngridient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ингридиенты рецепта:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Типы рецепта:";
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(386, 254);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(121, 23);
            this.btnAddType.TabIndex = 12;
            this.btnAddType.Text = "Добавить в рецепт";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // cbType
            // 
            this.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(44, 256);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(321, 21);
            this.cbType.TabIndex = 11;
            this.cbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbType_KeyDown);
            // 
            // dgvTypes
            // 
            this.dgvTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypes.Location = new System.Drawing.Point(7, 303);
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.Size = new System.Drawing.Size(777, 150);
            this.dgvTypes.TabIndex = 10;
            this.dgvTypes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTypes_UserDeletingRow);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Тип";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(383, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Грамм";
            // 
            // tbGramm
            // 
            this.tbGramm.Location = new System.Drawing.Point(440, 50);
            this.tbGramm.Name = "tbGramm";
            this.tbGramm.Size = new System.Drawing.Size(201, 20);
            this.tbGramm.TabIndex = 15;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(7, 460);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(83, 13);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "Наименование";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(97, 460);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(687, 20);
            this.tbName.TabIndex = 17;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(10, 491);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(57, 13);
            this.lbDescription.TabIndex = 18;
            this.lbDescription.Text = "Описание";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(93, 491);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(691, 20);
            this.tbDescription.TabIndex = 19;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(10, 523);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(40, 13);
            this.lbTime.TabIndex = 20;
            this.lbTime.Text = "Время";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(62, 520);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(201, 20);
            this.tbTime.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 548);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbGramm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.dgvTypes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddIngridient);
            this.Controls.Add(this.cbIngridient);
            this.Controls.Add(this.dgvIngridients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngridients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvIngridients;
        private System.Windows.Forms.ComboBox cbIngridient;
        private System.Windows.Forms.Button btnAddIngridient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGramm;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Button btnSave;
    }
}