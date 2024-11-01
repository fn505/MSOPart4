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
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            openFileDialog1 = new OpenFileDialog();
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
            // button1
            // 
            button1.Location = new Point(203, 10);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 5;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(343, 10);
            button2.Name = "button2";
            button2.Size = new Size(111, 33);
            button2.TabIndex = 6;
            button2.Text = "Metrics";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 744);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Panel panel1;
        private OpenFileDialog openFileDialog1;
    }
}