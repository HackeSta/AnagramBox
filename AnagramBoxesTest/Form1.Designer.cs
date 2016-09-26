namespace AnagramBoxesTest
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
            this.buttonPush = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.pushBox = new System.Windows.Forms.TextBox();
            this.buttonUnShuffle = new System.Windows.Forms.Button();
            this.buttonFont = new System.Windows.Forms.Button();
            this.anagramBox = new AnagramBox.AnagramBox();
            this.SuspendLayout();
            // 
            // buttonPush
            // 
            this.buttonPush.Location = new System.Drawing.Point(37, 263);
            this.buttonPush.Name = "buttonPush";
            this.buttonPush.Size = new System.Drawing.Size(75, 23);
            this.buttonPush.TabIndex = 1;
            this.buttonPush.Text = "PUSH";
            this.buttonPush.UseVisualStyleBackColor = true;
            this.buttonPush.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(118, 263);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 3;
            this.buttonShuffle.Text = "SHUFFLE";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.button2_Click);
            // 
            // pushBox
            // 
            this.pushBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pushBox.Location = new System.Drawing.Point(182, 166);
            this.pushBox.Name = "pushBox";
            this.pushBox.Size = new System.Drawing.Size(100, 20);
            this.pushBox.TabIndex = 5;
            // 
            // buttonUnShuffle
            // 
            this.buttonUnShuffle.Location = new System.Drawing.Point(199, 263);
            this.buttonUnShuffle.Name = "buttonUnShuffle";
            this.buttonUnShuffle.Size = new System.Drawing.Size(83, 23);
            this.buttonUnShuffle.TabIndex = 7;
            this.buttonUnShuffle.Text = "UNSHUFFLE";
            this.buttonUnShuffle.UseVisualStyleBackColor = true;
            this.buttonUnShuffle.Click += new System.EventHandler(this.buttonUnShuffle_Click);
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(288, 263);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(75, 23);
            this.buttonFont.TabIndex = 8;
            this.buttonFont.Text = "FONT";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // anagramBox
            // 
            this.anagramBox.Location = new System.Drawing.Point(69, 57);
            this.anagramBox.Name = "anagramBox";
            this.anagramBox.NumberOfBoxes = 6;
            this.anagramBox.Size = new System.Drawing.Size(339, 58);
            this.anagramBox.TabIndex = 9;
            this.anagramBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 347);
            this.Controls.Add(this.anagramBox);
            this.Controls.Add(this.buttonFont);
            this.Controls.Add(this.buttonUnShuffle);
            this.Controls.Add(this.pushBox);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonPush);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPush;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.TextBox pushBox;
        private System.Windows.Forms.Button buttonUnShuffle;
        private System.Windows.Forms.Button buttonFont;
        private AnagramBox.AnagramBox anagramBox;
    }
}

