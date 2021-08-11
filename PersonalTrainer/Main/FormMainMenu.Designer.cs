
namespace BartlomiejJagielloLab2ZadDom.Main
{
    partial class FormMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonWorkouts = new System.Windows.Forms.Button();
            this.buttonSessions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.Location = new System.Drawing.Point(328, 370);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(148, 55);
            this.buttonExit.TabIndex = 45;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOptions.Location = new System.Drawing.Point(313, 288);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(178, 55);
            this.buttonOptions.TabIndex = 46;
            this.buttonOptions.Text = "OPTIONS";
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonWorkouts
            // 
            this.buttonWorkouts.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonWorkouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWorkouts.Location = new System.Drawing.Point(291, 206);
            this.buttonWorkouts.Name = "buttonWorkouts";
            this.buttonWorkouts.Size = new System.Drawing.Size(222, 55);
            this.buttonWorkouts.TabIndex = 47;
            this.buttonWorkouts.Text = "WORKOUTS";
            this.buttonWorkouts.UseVisualStyleBackColor = true;
            this.buttonWorkouts.Click += new System.EventHandler(this.buttonWorkouts_Click);
            // 
            // buttonSessions
            // 
            this.buttonSessions.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSessions.Location = new System.Drawing.Point(291, 124);
            this.buttonSessions.Name = "buttonSessions";
            this.buttonSessions.Size = new System.Drawing.Size(222, 55);
            this.buttonSessions.TabIndex = 48;
            this.buttonSessions.Text = "SESSIONS";
            this.buttonSessions.UseVisualStyleBackColor = true;
            this.buttonSessions.Click += new System.EventHandler(this.buttonSessions_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 528);
            this.Controls.Add(this.buttonSessions);
            this.Controls.Add(this.buttonWorkouts);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.buttonExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Button buttonWorkouts;
        private System.Windows.Forms.Button buttonSessions;
    }
}