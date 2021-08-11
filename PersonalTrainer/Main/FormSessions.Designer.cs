
namespace BartlomiejJagielloLab2ZadDom.Main
{
    partial class FormSessions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSessions));
            this.dataGridViewSessions = new System.Windows.Forms.DataGridView();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonDeleteSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSessions
            // 
            this.dataGridViewSessions.AllowUserToAddRows = false;
            this.dataGridViewSessions.AllowUserToDeleteRows = false;
            this.dataGridViewSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSessions.Location = new System.Drawing.Point(58, 41);
            this.dataGridViewSessions.MultiSelect = false;
            this.dataGridViewSessions.Name = "dataGridViewSessions";
            this.dataGridViewSessions.RowHeadersWidth = 51;
            this.dataGridViewSessions.Size = new System.Drawing.Size(690, 290);
            this.dataGridViewSessions.TabIndex = 1;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 376);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(165, 62);
            this.buttonReturn.TabIndex = 3;
            this.buttonReturn.Text = "RETURN";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonDeleteSession
            // 
            this.buttonDeleteSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteSession.Location = new System.Drawing.Point(628, 336);
            this.buttonDeleteSession.Name = "buttonDeleteSession";
            this.buttonDeleteSession.Size = new System.Drawing.Size(173, 102);
            this.buttonDeleteSession.TabIndex = 6;
            this.buttonDeleteSession.Text = "DELETE SESSION\r\n";
            this.buttonDeleteSession.UseVisualStyleBackColor = true;
            this.buttonDeleteSession.Click += new System.EventHandler(this.buttonDeleteSession_Click);
            // 
            // FormSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDeleteSession);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.dataGridViewSessions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSessions";
            this.Text = "FormSessions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSessions;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonDeleteSession;
    }
}