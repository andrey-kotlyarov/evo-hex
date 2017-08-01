using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HexLib
{
    public class HCell
    {
        private HGrid _grid;
        private int _rowIndex;
        private int _colIndex;

        private int _index;

        private HCellEntity _cellEntity;


        public int RowIndex { get { return _rowIndex; } private set { _rowIndex = value; } }
        public int ColIndex { get { return _colIndex; } private set { _colIndex = value; } }

        public int Index { get { return _index; } }

        public HCellEntity CellEntity { get { return _cellEntity; } private set { _cellEntity = value; } }
        


        public HCell(HGrid grid, int rowIndex, int colIndex)
        {
            _grid = grid;

            _rowIndex = rowIndex;
            _colIndex = colIndex;

            _index = colIndex + _grid.Cols * rowIndex;

            _cellEntity = null;
        }

        public HCell[] getNeiborCells()
        {
            HCell[] neiborCells = new HCell[Enum.GetNames(typeof(HGridDirection)).Length];


            int indexR = _index + 1;
            int indexBR = _index + _grid.Rows + 1 - (1 - _rowIndex % 2);
            int indexBL = _index + _grid.Rows - (1 - _rowIndex % 2);
            int indexL = _index - 1;
            int indexTL = _index - _grid.Rows - (1 - _rowIndex % 2);
            int indexTR = _index - _grid.Rows + 1 - (1 - _rowIndex % 2);

            int size = _grid.Rows * _grid.Cols;


            /*
            if (indexR >= size) indexR = 0;
            if (indexL < 0) indexL = size - 1;
            if (indexBR >= size) indexBR -= size;
            if (indexBL >= size) indexBL -= size;
            if (indexTL < 0) indexTL += size;
            if (indexTR < 0) indexTR += size;
            
            neiborCells[(int)HGridDirection.RIGHT] = _grid.Cells[indexR];
            neiborCells[(int)HGridDirection.BOTTOM_RIGHT] = _grid.Cells[indexBR];
            neiborCells[(int)HGridDirection.BOTTOM_LEFT] = _grid.Cells[indexBL];
            neiborCells[(int)HGridDirection.LEFT] = _grid.Cells[indexL];
            neiborCells[(int)HGridDirection.TOP_LEFT] = _grid.Cells[indexTL];
            neiborCells[(int)HGridDirection.TOP_RIGHT] = _grid.Cells[indexTR];
            */
            
            if (indexR < size && _colIndex < _grid.Cols - 1) neiborCells[(int)HGridDirection.RIGHT] = _grid.Cells[indexR];
            if (indexBR < size && (_colIndex < _grid.Cols - 1 || _rowIndex % 2 == 0)) neiborCells[(int)HGridDirection.BOTTOM_RIGHT] = _grid.Cells[indexBR];
            if (indexBL < size && (_colIndex > 0 || _rowIndex % 2 == 1)) neiborCells[(int)HGridDirection.BOTTOM_LEFT] = _grid.Cells[indexBL];
            if (indexL >= 0 && _colIndex > 0) neiborCells[(int)HGridDirection.LEFT] = _grid.Cells[indexL];
            if (indexTL >= 0 && (_colIndex > 0 || _rowIndex % 2 == 1)) neiborCells[(int)HGridDirection.TOP_LEFT] = _grid.Cells[indexTL];
            if (indexTR >= 0 && (_colIndex < _grid.Cols - 1 || _rowIndex % 2 == 0)) neiborCells[(int)HGridDirection.TOP_RIGHT] = _grid.Cells[indexTR];

            return neiborCells;

            //return new HCell[] { _grid.Cells[_rowIndex + 1, _colIndex], _grid.Cells[_rowIndex - 1, _colIndex] };
            //return new HCell[] { _grid.Cells[_colIndex + 1 + (_rowIndex + 1) * _colIndex], _grid.Cells[_colIndex - 1 + (_rowIndex - 1) * _colIndex] };
            //return new HCell[] { _grid.Cells[_colIndex + (_grid.Cols * _rowIndex)] };
        }
    }
}
