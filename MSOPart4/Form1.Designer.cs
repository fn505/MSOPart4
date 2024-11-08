namespace MSOPart4
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            RunButton = new Button();
            MerticsButton = new Button();
            panel1 = new Panel();
            openFileDialog1 = new OpenFileDialog();
            PathFindingExercise = new Button();
            label1 = new Label();
            ResetButton = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownWidth = 120;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "From File" });
            comboBox1.Location = new Point(11, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 33);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Load Program";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 518);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "<output>";
            textBox1.Size = new Size(471, 89);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.AcceptsTab = true;
            textBox2.Location = new Point(191, 57);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 455);
            textBox2.TabIndex = 4;
            // 
            // RunButton
            // 
            RunButton.Location = new Point(203, 10);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(111, 33);
            RunButton.TabIndex = 5;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += Run_Click;
            // 
            // MerticsButton
            // 
            MerticsButton.Location = new Point(343, 10);
            MerticsButton.Name = "MerticsButton";
            MerticsButton.Size = new Size(111, 33);
            MerticsButton.TabIndex = 6;
            MerticsButton.Text = "Metrics";
            MerticsButton.UseVisualStyleBackColor = true;
            MerticsButton.Click += Metrics_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(487, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 480);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // PathFindingExercise
            // 
            PathFindingExercise.Location = new Point(487, 8);
            PathFindingExercise.Name = "PathFindingExercise";
            PathFindingExercise.Size = new Size(217, 43);
            PathFindingExercise.TabIndex = 7;
            PathFindingExercise.Text = "PathFinding";
            PathFindingExercise.UseVisualStyleBackColor = true;
            PathFindingExercise.Click += PathFindingExercise_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(581, 564);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // button1
            // 
            ResetButton.Location = new Point(717, 14);
            ResetButton.Name = "button1";
            ResetButton.Size = new Size(180, 33);
            ResetButton.TabIndex = 9;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += Reset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 744);
            Controls.Add(ResetButton);
            Controls.Add(label1);
            Controls.Add(PathFindingExercise);
            Controls.Add(MerticsButton);
            Controls.Add(RunButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button RunButton;
        private Button MerticsButton;
        private Panel panel1;
        private OpenFileDialog openFileDialog1;
        private Button PathFindingExercise;
        private Label label1;
        private Button ResetButton;
    }
}