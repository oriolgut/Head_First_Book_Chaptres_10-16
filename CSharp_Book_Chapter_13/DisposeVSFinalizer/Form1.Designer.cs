namespace DisposeVSFinalizer
{
    partial class Form1
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
            this.buttonCreateClone1 = new System.Windows.Forms.Button();
            this.buttonCreateClone2 = new System.Windows.Forms.Button();
            this.buttonGarbageCollector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateClone1
            // 
            this.buttonCreateClone1.Location = new System.Drawing.Point(27, 12);
            this.buttonCreateClone1.Name = "buttonCreateClone1";
            this.buttonCreateClone1.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateClone1.TabIndex = 0;
            this.buttonCreateClone1.Text = "Clone #1";
            this.buttonCreateClone1.UseVisualStyleBackColor = true;
            this.buttonCreateClone1.Click += new System.EventHandler(this.OnButtonCreateClone1Click);
            // 
            // buttonCreateClone2
            // 
            this.buttonCreateClone2.Location = new System.Drawing.Point(27, 41);
            this.buttonCreateClone2.Name = "buttonCreateClone2";
            this.buttonCreateClone2.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateClone2.TabIndex = 1;
            this.buttonCreateClone2.Text = "Clone #2";
            this.buttonCreateClone2.UseVisualStyleBackColor = true;
            this.buttonCreateClone2.Click += new System.EventHandler(this.OnButtonCreateClone2Click);
            // 
            // buttonGarbageCollector
            // 
            this.buttonGarbageCollector.Location = new System.Drawing.Point(27, 70);
            this.buttonGarbageCollector.Name = "buttonGarbageCollector";
            this.buttonGarbageCollector.Size = new System.Drawing.Size(75, 23);
            this.buttonGarbageCollector.TabIndex = 2;
            this.buttonGarbageCollector.Text = "GC";
            this.buttonGarbageCollector.UseVisualStyleBackColor = true;
            this.buttonGarbageCollector.Click += new System.EventHandler(this.OnButtonGarbageCollectorClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(139, 109);
            this.Controls.Add(this.buttonGarbageCollector);
            this.Controls.Add(this.buttonCreateClone2);
            this.Controls.Add(this.buttonCreateClone1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateClone1;
        private System.Windows.Forms.Button buttonCreateClone2;
        private System.Windows.Forms.Button buttonGarbageCollector;
    }
}

