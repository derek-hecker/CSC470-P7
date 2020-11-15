namespace Builder
{
    partial class FormSelectFeature
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dataGridViewFeatures = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeatures)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(569, 373);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(115, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select Feature";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewFeatures
            // 
            this.dataGridViewFeatures.AllowUserToAddRows = false;
            this.dataGridViewFeatures.AllowUserToDeleteRows = false;
            this.dataGridViewFeatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeatures.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFeatures.Name = "dataGridViewFeatures";
            this.dataGridViewFeatures.ReadOnly = true;
            this.dataGridViewFeatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFeatures.Size = new System.Drawing.Size(672, 355);
            this.dataGridViewFeatures.TabIndex = 2;
            this.dataGridViewFeatures.SelectionChanged += new System.EventHandler(this.dataGridViewFeatures_SelectionChanged);
            // 
            // FormSelectFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 409);
            this.Controls.Add(this.dataGridViewFeatures);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.button1);
            this.Name = "FormSelectFeature";
            this.Text = "Select feature";
            this.Load += new System.EventHandler(this.FormSelectFeature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeatures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dataGridViewFeatures;
    }
}