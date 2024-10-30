using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSOPart4
{
    public partial class Form1 : Form
    {
        public Program program;
        public int gridWidth;
        public int gridHeight;
        public Form1(Program program)
        {
            this.program = program;
            gridWidth = program.character.grid.width;
            gridHeight = program.character.grid.height;
            InitializeComponent();
            panel1.Size = new Size(300, 300);
        }

        //draw grid
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int cellSize = panel1.Size.Width / gridWidth;


            for (int x = 0; x <= gridWidth; x++)
            {
                g.DrawLine(Pens.Black, x * cellSize, 0, x * cellSize, gridWidth * cellSize);

                for (int y = 0; y <= gridHeight; y++)
                {
                    g.DrawLine(Pens.Black, 0, y * cellSize, gridHeight * cellSize, y * cellSize);
                }


            }
            DrawCharacter(g, cellSize);
        }

        public void DrawCharacter(Graphics g, int cellSize)
        {
            int x = program.character.position.Item1;
            int y = program.character.position.Item2;

            int xPos = x * cellSize;
            int yPos = y * cellSize;

            int adjustedCellSize = (int)(cellSize * 0.9);


            int offset = (cellSize - adjustedCellSize) / 2;

            Image characterImage = program.character.getCharacterImage();
            g.DrawImage(characterImage, xPos + offset, yPos + offset, adjustedCellSize, adjustedCellSize);


        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            switch(selectedItem) 
            {
                case "From File":
                    textBox2.Text = "file select";
                    break;
                case "Basic":
                    textBox2.Text = "basic select";
                    break;
                case "Advanced":
                    textBox2.Text = "advanced select";
                    break;
                case "Expert":
                    textBox2.Text = "expert select";
                    break;
                default: 
                    break;
                




            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            program.Execute();
            textBox1.Text = program.output;
            panel1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }
    }
}
