using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HexLib
{
    public class HCell
    {
        private int _rowIndex;
        private int _colIndex;

        private HCellEntity _cellEntity;


        public int RowIndex { get { return _rowIndex; } private set { _rowIndex = value; } }
        public int ColIndex { get { return _colIndex; } private set { _colIndex = value; } }

        public HCellEntity CellEntity { get { return _cellEntity; } private set { _cellEntity = value; } }
        


        public HCell(int rowIndex, int colIndex)
        {
            _rowIndex = rowIndex;
            _colIndex = colIndex;

            _cellEntity = null;
        }
    }
}
