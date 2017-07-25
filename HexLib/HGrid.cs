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

        private HCell[,] _cells;

        public HGrid(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;

            _cells = new HCell[_rows, _cols];
        }




    }
}
