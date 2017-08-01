using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HexLib
{
    public class HGrid
    {
        private int _rows;
        private int _cols;

        private HCell[] _cells;



        public int Rows { get { return _rows; } private set { _rows = value; } }
        public int Cols { get { return _cols; } private set { _cols = value; } }

        public HCell[] Cells { get { return _cells; } private set { _cells = value; } }

        public HGrid(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;

            _cells = new HCell[_rows * _cols];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Cells[col + Cols * row] = new HCell(this, row, col);
                }
            }

            return;
        }




    }
}
