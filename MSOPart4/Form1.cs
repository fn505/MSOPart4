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
            panel1.Size = new Size(200, 200);
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
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
