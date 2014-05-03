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
            this.button1 = new System.Windows.Forms.Button();
            this.lblRC_HP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRC_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSW_HP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDB_HP = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSW_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDB_HP)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRC_HP
            // 
            this.lblRC_HP.AutoSize = true;
            this.lblRC_HP.Location = new System.Drawing.Point(64, 72);
            this.lblRC_HP.Name = "lblRC_HP";
            this.lblRC_HP.Size = new System.Drawing.Size(80, 13);
            this.lblRC_HP.TabIndex = 4;
            this.lblRC_HP.Text = "Rallying Cry HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ShieldWall HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DemoBanner HP";
            // 
            // numericUpDownRC_HP
            // 
            this.numericUpDownRC_HP.Location = new System.Drawing.Point(150, 70);
            this.numericUpDownRC_HP.Name = "numericUpDownRC_HP";
            this.numericUpDownRC_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownRC_HP.TabIndex = 7;
            // 
            // numericUpDownSW_HP
            // 
            this.numericUpDownSW_HP.Location = new System.Drawing.Point(150, 122);
            this.numericUpDownSW_HP.Name = "numericUpDownSW_HP";
            this.numericUpDownSW_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownSW_HP.TabIndex = 8;
            // 
            // numericUpDownDB_HP
            // 
            this.numericUpDownDB_HP.Location = new System.Drawing.Point(150, 96);
            this.numericUpDownDB_HP.Name = "numericUpDownDB_HP";
            this.numericUpDownDB_HP.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDB_HP.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(631, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDownDB_HP);
            this.Controls.Add(this.numericUpDownSW_HP);
            this.Controls.Add(this.numericUpDownRC_HP);
            this.Controls.Add(this.lblRC_HP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSW_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDB_HP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRC_HP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRC_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownSW_HP;
        private System.Windows.Forms.NumericUpDown numericUpDownDB_HP;
        private System.Windows.Forms.Button button2;
    }
}

