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

            HGrid grid = new HGrid(4, 4);



            Color colorGrid = Color.DarkGray;
            Brush brushWall = Brushes.Maroon;
            Brush brushEmpty = Brushes.LightGray;
            Brush brushBot = Brushes.Navy;
            //Brush brushFood = Brushes.Green;
            //Brush brushToxin = Brushes.OrangeRed;

            Font fontBot = new Font(FontFamily.GenericSansSerif, 6.0F, FontStyle.Regular);
            Brush brushFont = Brushes.White;

            //Font fontBot2 = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Bold);
            //Brush brushFont2 = Brushes.Yellow;

            //Font fontBot3 = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold);
            //Brush brushFont3 = Brushes.Yellow;

            Graphics g = _pbGridBufferGraphics.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(colorGrid);

            HCell[] cells = grid.Cells;
            HCell cell;

            float r = 25F;
            float dx = 2.0F * r * (float)Math.Sin(Math.PI / 3);
            float dy = 1.5F * r;


            float r2 = 24F;
            float dx2 = 2.0F * r2 * (float)Math.Sin(Math.PI / 3);
            float dy2 = 1.5F * r2;


            for (int i = 0; i < cells.Length; i++)
            {
                cell = cells[i];

                float x = cell.ColIndex * dx + 1 + (cell.RowIndex % 2 == 0 ? 0 : dx / 2) + r;
                float y = cell.RowIndex * dy + 1 + r;

                PointF[] points = new PointF[]
                {
                        new PointF(x, y - r2),
                        new PointF(x + dx2 / 2, y - r2 / 2),
                        new PointF(x + dx2 / 2, y + r2 / 2),
                        new PointF(x, y + r2),
                        new PointF(x - dx2 / 2, y + r2 / 2),
                        new PointF(x - dx2 / 2, y - r2 / 2)
                };

                byte[] bytes = new byte[] { 1, 1, 1, 1, 1, 1 };

                System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath(points, bytes, System.Drawing.Drawing2D.FillMode.Winding);
                g.FillPath(brushEmpty, p);
            }
            

            cell = cells[15];
            
            HCell[] neiborCells = cell.getNeiborCells();

            for (int i = 0; i < neiborCells.Length; i++)
            {
                HCell neiborCell = neiborCells[i];
                if (neiborCell != null)
                {
                    float x = neiborCell.ColIndex * dx + 1 + (neiborCell.RowIndex % 2 == 0 ? 0 : dx / 2) + r;
                    float y = neiborCell.RowIndex * dy + 1 + r;

                    PointF[] points = new PointF[]
                    {
                        new PointF(x, y - r2),
                        new PointF(x + dx2 / 2, y - r2 / 2),
                        new PointF(x + dx2 / 2, y + r2 / 2),
                        new PointF(x, y + r2),
                        new PointF(x - dx2 / 2, y + r2 / 2),
                        new PointF(x - dx2 / 2, y - r2 / 2)
                    };

                    byte[] bytes = new byte[] { 1, 1, 1, 1, 1, 1 };

                    System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath(points, bytes, System.Drawing.Drawing2D.FillMode.Winding);
                    g.FillPath(brushBot, p);
                }
            }
            
            for (int i = 0; i < cells.Length; i++)
            {
                cell = cells[i];

                float x = cell.ColIndex * dx + 1 + (cell.RowIndex % 2 == 0 ? 0 : dx / 2) + r;
                float y = cell.RowIndex * dy + 1 + r;
                
                g.DrawString(cell.RowIndex.ToString() + "," + cell.ColIndex.ToString(), fontBot, brushFont, x - r / 3, y - r / 3);
            }
            
            //_pbGridBufferGraphics.Render();
            _pbGridBufferGraphics.Render(pbGrid.CreateGraphics());
            
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
