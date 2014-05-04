namespace exeCutie
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.text1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtChangelog = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_DStuse = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownDStuse_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownER_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDB_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSW_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDBTS_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRC_HP = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPoC = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDStuse_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownER_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDB_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSW_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBTS_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC_HP)).BeginInit();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(121, 358);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(100, 20);
            this.text1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(659, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(740, 587);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 549);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.txtChangelog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(806, 523);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "exeCutie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::exeCutie.Properties.Resources.codingbad_cropped;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 338);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtChangelog
            // 
            this.txtChangelog.Location = new System.Drawing.Point(3, 347);
            this.txtChangelog.Multiline = true;
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.Size = new System.Drawing.Size(800, 173);
            this.txtChangelog.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_DStuse);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownDStuse_HP);
            this.groupBox1.Controls.Add(this.numericUpDownER_HP);
            this.groupBox1.Controls.Add(this.numericUpDownDB_HP);
            this.groupBox1.Controls.Add(this.numericUpDownSW_HP);
            this.groupBox1.Controls.Add(this.numericUpDownDBTS_HP);
            this.groupBox1.Controls.Add(this.numericUpDownRC_HP);
            this.groupBox1.Location = new System.Drawing.Point(308, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 205);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defensive";
            // 
            // checkbox_DStuse
            // 
            this.checkbox_DStuse.AutoSize = true;
            this.checkbox_DStuse.Location = new System.Drawing.Point(146, 145);
            this.checkbox_DStuse.Name = "checkbox_DStuse";
            this.checkbox_DStuse.Size = new System.Drawing.Size(15, 14);
            this.checkbox_DStuse.TabIndex = 54;
            this.checkbox_DStuse.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "RallyingCry HP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "ShieldWall HP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "DieByTheSword HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Demobanner HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "EnragedRegeneration HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "DefStance use";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "DefStance HP";
            // 
            // numericUpDownDStuse_HP
            // 
            this.numericUpDownDStuse_HP.Location = new System.Drawing.Point(142, 170);
            this.numericUpDownDStuse_HP.Name = "numericUpDownDStuse_HP";
            this.numericUpDownDStuse_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDStuse_HP.TabIndex = 46;
            // 
            // numericUpDownER_HP
            // 
            this.numericUpDownER_HP.Location = new System.Drawing.Point(142, 118);
            this.numericUpDownER_HP.Name = "numericUpDownER_HP";
            this.numericUpDownER_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownER_HP.TabIndex = 45;
            // 
            // numericUpDownDB_HP
            // 
            this.numericUpDownDB_HP.Location = new System.Drawing.Point(142, 92);
            this.numericUpDownDB_HP.Name = "numericUpDownDB_HP";
            this.numericUpDownDB_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDB_HP.TabIndex = 44;
            // 
            // numericUpDownSW_HP
            // 
            this.numericUpDownSW_HP.Location = new System.Drawing.Point(142, 40);
            this.numericUpDownSW_HP.Name = "numericUpDownSW_HP";
            this.numericUpDownSW_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownSW_HP.TabIndex = 43;
            // 
            // numericUpDownDBTS_HP
            // 
            this.numericUpDownDBTS_HP.Location = new System.Drawing.Point(142, 66);
            this.numericUpDownDBTS_HP.Name = "numericUpDownDBTS_HP";
            this.numericUpDownDBTS_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDBTS_HP.TabIndex = 42;
            // 
            // numericUpDownRC_HP
            // 
            this.numericUpDownRC_HP.Location = new System.Drawing.Point(142, 14);
            this.numericUpDownRC_HP.Name = "numericUpDownRC_HP";
            this.numericUpDownRC_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownRC_HP.TabIndex = 41;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Arms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPoC
            // 
            this.btnPoC.Location = new System.Drawing.Point(541, 587);
            this.btnPoC.Name = "btnPoC";
            this.btnPoC.Size = new System.Drawing.Size(75, 23);
            this.btnPoC.TabIndex = 12;
            this.btnPoC.Text = "PoC";
            this.btnPoC.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(824, 616);
            this.Controls.Add(this.btnPoC);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.text1);
            this.Name = "Form1";
            this.Text = "exeCutie Premium by CodingBad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDStuse_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownER_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDB_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSW_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBTS_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC_HP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPoC;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtChangelog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkbox_DStuse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownDStuse_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownER_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownDB_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownSW_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownDBTS_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownRC_HP;
    }
}

