namespace WinForms
{
    partial class Test
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
            this.testPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Answer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testPanel
            // 
            this.testPanel.Location = new System.Drawing.Point(1, 66);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(787, 338);
            this.testPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Попереднє";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Наступне";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(367, 411);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(80, 38);
            this.Answer.TabIndex = 3;
            this.Answer.Text = "Відповісти";
            this.Answer.UseVisualStyleBackColor = true;
            this.Answer.Click += new System.EventHandler(this.Answer_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.testPanel);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel testPanel;
        private Button button1;
        private Button button2;
        private Button Answer;
    }
}