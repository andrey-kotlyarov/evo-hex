using HexLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HexApp
{
    public partial class FormDebug : Form
    {
        private BufferedGraphicsContext _bufferedGraphicsContext;
        private BufferedGraphics _pbGridBufferGraphics;



        public FormDebug()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            txtReport.Text += "Btn Test Click" + "\r\n";
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {
            _bufferedGraphicsContext = BufferedGraphicsManager.Current;
            _pbGridBufferGraphics = _bufferedGraphicsContext.Allocate(pbGrid.CreateGraphics(), pbGrid.DisplayRectangle);

            //_pbGridBufferGraphics = BufferedGraphicsManager.Current.Allocate(pbGrid.CreateGraphics(), pbGrid.DisplayRectangle);

        }

        private void FormDebug_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pbGridBufferGraphics.Dispose();
        }



        private void drawGrid()
        {

            HGrid grid = new HGrid(10, 10);



            Color colorGrid = Color.DarkGray;
            Brush brushWall = Brushes.Maroon;
            Brush brushEmpty = Brushes.LightGray;
            Brush brushBot = Brushes.Navy;
            Brush brushFood = Brushes.Green;
            Brush brushToxin = Brushes.OrangeRed;

            Font fontBot = new Font(FontFamily.GenericSansSerif, 6.0F, FontStyle.Regular);
            Brush brushFont = Brushes.White;

            Font fontBot2 = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Bold);
            Brush brushFont2 = Brushes.Yellow;

            Font fontBot3 = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold);
            Brush brushFont3 = Brushes.Yellow;

            Graphics g = _pbGridBufferGraphics.Graphics;


            g.Clear(colorGrid);


            HCell[,] cells = grid.Cells;

            int size = 24;


            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Cols; col++)
                {
                    int px = col * size + 1;
                    int py = row * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    Rectangle rc = new Rectangle(px + 3, py + 3, size - 6, size - 6);

                    g.FillRectangle(brushEmpty, r);
                }
            }
            /*
            for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
            {
                for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
                {
                    int px = x * size + 1;
                    int py = y * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    Rectangle rc = new Rectangle(px + 3, py + 3, size - 6, size - 6);


                    if (cells[x, y].type == ECellType.EMPTY)
                    {
                        g.FillRectangle(brushEmpty, r);
                    }
                    if (cells[x, y].type == ECellType.WALL)
                    {
                        g.FillRectangle(brushWall, r);
                    }
                    if (cells[x, y].type == ECellType.FOOD)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushFood, rc);
                    }
                    if (cells[x, y].type == ECellType.TOXIN)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushToxin, rc);
                    }
                    if (cells[x, y].type == ECellType.BOT)
                    {
                        //
                        //
                    }
                }
            }
            */


            /*
            for (int i = 0; i < grid.bots.Length; i++)
            {
                EBot bot = grid.bots[i];


                if (bot.alive)
                {
                    int px = bot.point.x * size + 1;
                    int py = bot.point.y * size + 1;


                    if (bot.traceIndex >= 0)
                    {
                        Brush bTrace = new SolidBrush(ESetting.TRACE_COLOR[bot.traceIndex]);
                        Rectangle rTrace = new Rectangle(px - 2, py - 2, size + 4, size + 4);
                        g.FillRectangle(bTrace, rTrace);
                    }


                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    g.FillRectangle(brushBot, r);




                    g.DrawString(bot.health.ToString(), fontBot, brushFont, px + 1, py + 2);
                    g.DrawString(bot.generation.ToString(), fontBot2, brushFont2, px + 10, py + 12);


                }

            }
            */

            //_pbGridBufferGraphics.Render();
            _pbGridBufferGraphics.Render(pbGrid.CreateGraphics());

            /*
            if (_evoEngine == null) return;

            EGrid grid = _evoEngine.eGrid;

            //var brush = new SolidColorBrush(Color.FromArgb(255, (byte)R, (byte)G, (byte)B));
            //Brush bb = new SolidBrush(Color.Red);


            Color colorGrid = Color.DarkGray;
            Brush brushWall = Brushes.Maroon;
            Brush brushEmpty = Brushes.LightGray;
            Brush brushBot = Brushes.Navy;
            Brush brushFood = Brushes.Green;
            Brush brushToxin = Brushes.OrangeRed;

            Font fontBot = new Font(FontFamily.GenericSansSerif, 6.0F, FontStyle.Regular);
            Brush brushFont = Brushes.White;

            Font fontBot2 = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Bold);
            Brush brushFont2 = Brushes.Yellow;

            Font fontBot3 = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold);
            Brush brushFont3 = Brushes.Yellow;

            Graphics g = _pbGridBufferGraphics.Graphics;


            g.Clear(colorGrid);


            ECell[,] cells = grid.cells;

            int size = 24;

            for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
            {
                for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
                {
                    int px = x * size + 1;
                    int py = y * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    Rectangle rc = new Rectangle(px + 3, py + 3, size - 6, size - 6);


                    if (cells[x, y].type == ECellType.EMPTY)
                    {
                        g.FillRectangle(brushEmpty, r);
                    }
                    if (cells[x, y].type == ECellType.WALL)
                    {
                        g.FillRectangle(brushWall, r);
                    }
                    if (cells[x, y].type == ECellType.FOOD)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushFood, rc);
                    }
                    if (cells[x, y].type == ECellType.TOXIN)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushToxin, rc);
                    }
                    if (cells[x, y].type == ECellType.BOT)
                    {
                        //
                        //
                    }
                }
            }

            for (int i = 0; i < grid.bots.Length; i++)
            {
                EBot bot = grid.bots[i];


                if (bot.alive)
                {
                    int px = bot.point.x * size + 1;
                    int py = bot.point.y * size + 1;


                    if (bot.traceIndex >= 0)
                    {
                        Brush bTrace = new SolidBrush(ESetting.TRACE_COLOR[bot.traceIndex]);
                        Rectangle rTrace = new Rectangle(px - 2, py - 2, size + 4, size + 4);
                        g.FillRectangle(bTrace, rTrace);
                    }


                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    g.FillRectangle(brushBot, r);




                    g.DrawString(bot.health.ToString(), fontBot, brushFont, px + 1, py + 2);
                    g.DrawString(bot.generation.ToString(), fontBot2, brushFont2, px + 10, py + 12);

                    
                }

            }

            //_pbGridBufferGraphics.Render();
            _pbGridBufferGraphics.Render(pbGrid.CreateGraphics());
            */
            return;
        }


        private static int paintCount = 0;
        private void FormDebug_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            txtReport.Text = "Form Paint: " + (++paintCount) + "\r\n";
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            drawGrid();
        }
    }
}
