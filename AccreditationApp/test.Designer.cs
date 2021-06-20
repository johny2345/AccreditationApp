
namespace AccreditationApp
{
    partial class test
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgDocuments = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.txtFilePath2 = new System.Windows.Forms.TextBox();
            this.refresh = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(44, 32);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(291, 23);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Location = new System.Drawing.Point(341, 31);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(82, 25);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Document 1";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(439, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 56);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgDocuments
            // 
            this.dgDocuments.AllowUserToDeleteRows = false;
            this.dgDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDocuments.Location = new System.Drawing.Point(44, 121);
            this.dgDocuments.Name = "dgDocuments";
            this.dgDocuments.RowTemplate.Height = 25;
            this.dgDocuments.Size = new System.Drawing.Size(472, 225);
            this.dgDocuments.TabIndex = 3;
            this.dgDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDocuments_CellContentClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(44, 92);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.AutoSize = true;
            this.btnBrowse2.Location = new System.Drawing.Point(341, 63);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(82, 25);
            this.btnBrowse2.TabIndex = 5;
            this.btnBrowse2.Text = "Document 2";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // txtFilePath2
            // 
            this.txtFilePath2.Location = new System.Drawing.Point(44, 63);
            this.txtFilePath2.Name = "txtFilePath2";
            this.txtFilePath2.Size = new System.Drawing.Size(291, 23);
            this.txtFilePath2.TabIndex = 6;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(125, 92);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 7;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(226, 93);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.txtFilePath2);
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dgDocuments);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgDocuments;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.TextBox txtFilePath2;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button clear;
    }
}