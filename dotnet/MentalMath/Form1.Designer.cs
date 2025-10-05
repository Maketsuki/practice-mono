namespace MentalMath
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblQuestion = new Label();
            txtAnswer = new TextBox();
            btnCheck = new Button();
            btnNext = new Button();
            lblFeedback = new Label();
            lblScore = new Label();
            cmbOps = new ComboBox();
            numMax = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numMax).BeginInit();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(27, 52);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(86, 15);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question Label";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(132, 52);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(100, 23);
            txtAnswer.TabIndex = 1;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(281, 52);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(75, 23);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(648, 388);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Location = new Point(27, 138);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(85, 15);
            lblFeedback.TabIndex = 4;
            lblFeedback.Text = "Feedback label";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(132, 138);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(64, 15);
            lblScore.TabIndex = 5;
            lblScore.Text = "ScoreLabel";
            // 
            // cmbOps
            // 
            cmbOps.FormattingEnabled = true;
            cmbOps.Items.AddRange(new object[] { "+", "-", "×", "÷", "Mix" });
            cmbOps.Location = new Point(396, 53);
            cmbOps.Name = "cmbOps";
            cmbOps.Size = new Size(121, 23);
            cmbOps.TabIndex = 6;
            // 
            // numMax
            // 
            numMax.Location = new Point(397, 119);
            numMax.Name = "numMax";
            numMax.Size = new Size(120, 23);
            numMax.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numMax);
            Controls.Add(cmbOps);
            Controls.Add(lblScore);
            Controls.Add(lblFeedback);
            Controls.Add(btnNext);
            Controls.Add(btnCheck);
            Controls.Add(txtAnswer);
            Controls.Add(lblQuestion);
            Name = "Form1";
            Text = "MentalMath";
            ((System.ComponentModel.ISupportInitialize)numMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private TextBox txtAnswer;
        private Button btnCheck;
        private Button btnNext;
        private Label lblFeedback;
        private Label lblScore;
        private ComboBox cmbOps;
        private NumericUpDown numMax;
    }
}
