namespace RandomNumbers
{
    partial class RandomNumbersForm
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
            this.RandomizeButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.CreateOrderedButton = new System.Windows.Forms.Button();
            this.OpenListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RandomizeButton
            // 
            this.RandomizeButton.Location = new System.Drawing.Point(293, 223);
            this.RandomizeButton.Name = "RandomizeButton";
            this.RandomizeButton.Size = new System.Drawing.Size(117, 23);
            this.RandomizeButton.TabIndex = 0;
            this.RandomizeButton.Text = "Randomize Numbers";
            this.RandomizeButton.UseVisualStyleBackColor = true;
            this.RandomizeButton.Click += new System.EventHandler(this.RandomizeListButtonClick);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(12, 59);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(478, 20);
            this.ResultTextBox.TabIndex = 2;
            this.ResultTextBox.TabStop = false;
            this.ResultTextBox.Text = "Click \"Create List\" to generate a sorted list";
            this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // CreateOrderedButton
            // 
            this.CreateOrderedButton.Location = new System.Drawing.Point(293, 194);
            this.CreateOrderedButton.Name = "CreateOrderedButton";
            this.CreateOrderedButton.Size = new System.Drawing.Size(117, 23);
            this.CreateOrderedButton.TabIndex = 3;
            this.CreateOrderedButton.Text = "Create Sorted List";
            this.CreateOrderedButton.UseVisualStyleBackColor = true;
            this.CreateOrderedButton.Click += new System.EventHandler(this.CreateSortedButtonClick);
            // 
            // OpenListButton
            // 
            this.OpenListButton.Location = new System.Drawing.Point(293, 252);
            this.OpenListButton.Name = "OpenListButton";
            this.OpenListButton.Size = new System.Drawing.Size(117, 23);
            this.OpenListButton.TabIndex = 4;
            this.OpenListButton.Text = "Open List";
            this.OpenListButton.UseVisualStyleBackColor = true;
            this.OpenListButton.Click += new System.EventHandler(this.OpenListButton_Click);
            // 
            // RandomNumbersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 300);
            this.Controls.Add(this.OpenListButton);
            this.Controls.Add(this.CreateOrderedButton);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.RandomizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RandomNumbersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RandomizeButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button CreateOrderedButton;
        private System.Windows.Forms.Button OpenListButton;
    }
}

