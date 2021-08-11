
namespace BartlomiejJagielloLab2ZadDom.Main
{
    partial class FormViewWorkouts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewWorkouts));
            this.dataGridViewWorkouts = new System.Windows.Forms.DataGridView();
            this.buttonReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkouts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWorkouts
            // 
            this.dataGridViewWorkouts.AllowUserToAddRows = false;
            this.dataGridViewWorkouts.AllowUserToDeleteRows = false;
            this.dataGridViewWorkouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkouts.Location = new System.Drawing.Point(77, 48);
            this.dataGridViewWorkouts.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewWorkouts.Name = "dataGridViewWorkouts";
            this.dataGridViewWorkouts.RowHeadersWidth = 51;
            this.dataGridViewWorkouts.Size = new System.Drawing.Size(920, 351);
            this.dataGridViewWorkouts.TabIndex = 0;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReturn.Location = new System.Drawing.Point(16, 463);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(220, 76);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "RETURN";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // FormViewWorkouts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.dataGridViewWorkouts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormViewWorkouts";
            this.Text = "FormViewWorkouts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkouts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWorkouts;
        private System.Windows.Forms.Button buttonReturn;
    }
}