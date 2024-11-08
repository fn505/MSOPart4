using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public ProgramReader newReader;

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
            int currentPosX = program.character.position.Item1;
            int currentPosY = program.character.position.Item2; 
            foreach (Cell cell in program.character.grid.cells)
            {
                
                Rectangle cellRectangle = new Rectangle(cell.x * cellSize, cell.y * cellSize, cellSize, cellSize);

                if (cell.x == currentPosX && cell.y == currentPosY)
                {
                    g.DrawRectangle(Pens.Black, cellRectangle);
                    continue;
                }

                if (cell.isOccupied )
                {
                   
                    g.FillRectangle(Brushes.DarkOrange, cellRectangle);
                 
                }
                else
                {
                    g.FillRectangle(Brushes.White, cellRectangle);
                }

                g.DrawRectangle(Pens.Black, cellRectangle);
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

        //file explorer
        public List<string> FileImporter()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            List<string> newContent = new List<string>();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);

                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }


            }
            newContent.Add(filePath);
            newContent.Add(fileContent);
            return newContent;

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);


        }


        //conrtol i = tab
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();


            switch (selectedItem)
            {
                case "From File":
                    List<string> fileInfo = FileImporter();
                    string path = fileInfo.ElementAt(0);
                    string content = fileInfo.ElementAt(1);
                    textBox2.Text = content;
                    break;
                case "Basic":
                    textBox2.Text = program.getExampleProgram(ProgramDifficulty.basic);
                    break;
                case "Advanced":
                    textBox2.Text = program.getExampleProgram(ProgramDifficulty.advanced);
                    break;
                case "Expert":
                    textBox2.Text = program.getExampleProgram(ProgramDifficulty.expert);

                    break;
                default:
                    break;
            }

        }

        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
            
                    UpdateProgram();
                    Debug.WriteLine(program.commands.Count);
                    textBox1.Text = program.output;

                    if(program.commands.Count == 0)
                    {
                     textBox1.Text = "";
                    }
                  
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing commands: " + ex.Message);
            }
        }
        private void UpdateProgram()
        {
            // zet de strings in textbox om in een lijst van strings
            List<string> lines = textBox2.Lines.ToList();
            List<Command> commands = new List<Command>();
            // maak een lijst van commands van lines
            program.programReader.ParseFile(lines, commands);
            // geef de commands mee aan program
            program.SetCommands(commands);
            //run de program
            program.Execute();
            //herteken de grid 
            panel1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PathFindingExercise_Click(object sender, EventArgs e)
        {
            string filePath = "Resources/grids/grid1.txt";
            program.currentExercise = new PathfindingExercise(program.character.grid);
            program.currentExercise.LoadGrid(filePath);
            panel1.Invalidate();
        }
    }
}
