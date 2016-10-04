namespace SecretIngredients
{
    partial class FormSecretIngredient
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
            this.buttonGetIngredient = new System.Windows.Forms.Button();
            this.buttonGetSuzanneDelegate = new System.Windows.Forms.Button();
            this.buttonGetAmyDelegate = new System.Windows.Forms.Button();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetIngredient
            // 
            this.buttonGetIngredient.Location = new System.Drawing.Point(8, 12);
            this.buttonGetIngredient.Name = "buttonGetIngredient";
            this.buttonGetIngredient.Size = new System.Drawing.Size(203, 23);
            this.buttonGetIngredient.TabIndex = 0;
            this.buttonGetIngredient.Text = "Get the ingredient";
            this.buttonGetIngredient.UseVisualStyleBackColor = true;
            this.buttonGetIngredient.Click += new System.EventHandler(this.OnButtonGetIngredient_Click);
            // 
            // buttonGetSuzanneDelegate
            // 
            this.buttonGetSuzanneDelegate.Location = new System.Drawing.Point(8, 41);
            this.buttonGetSuzanneDelegate.Name = "buttonGetSuzanneDelegate";
            this.buttonGetSuzanneDelegate.Size = new System.Drawing.Size(294, 23);
            this.buttonGetSuzanneDelegate.TabIndex = 1;
            this.buttonGetSuzanneDelegate.Text = "Get Suzanne\'s delegate";
            this.buttonGetSuzanneDelegate.UseVisualStyleBackColor = true;
            this.buttonGetSuzanneDelegate.Click += new System.EventHandler(this.OnButtonGetSuzanneDelegate_Click);
            // 
            // buttonGetAmyDelegate
            // 
            this.buttonGetAmyDelegate.Location = new System.Drawing.Point(8, 70);
            this.buttonGetAmyDelegate.Name = "buttonGetAmyDelegate";
            this.buttonGetAmyDelegate.Size = new System.Drawing.Size(294, 23);
            this.buttonGetAmyDelegate.TabIndex = 2;
            this.buttonGetAmyDelegate.Text = "Get Amy\'s delegate";
            this.buttonGetAmyDelegate.UseVisualStyleBackColor = true;
            this.buttonGetAmyDelegate.Click += new System.EventHandler(this.OnButtonGetAmyDelegate_Click);
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(217, 15);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownAmount.TabIndex = 3;
            // 
            // FormSecretIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 107);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.buttonGetAmyDelegate);
            this.Controls.Add(this.buttonGetSuzanneDelegate);
            this.Controls.Add(this.buttonGetIngredient);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSecretIngredient";
            this.Text = "Secret Ingredients";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetIngredient;
        private System.Windows.Forms.Button buttonGetSuzanneDelegate;
        private System.Windows.Forms.Button buttonGetAmyDelegate;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
    }
}

