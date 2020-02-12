using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper2.Models
{
    public class CellModel
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int liveNeighbors { get; set; }
        public bool IsLive { get; set; }
        public bool IsVisible { get; set; }
        public bool isValid { get; set; }
        public int ID { get; set; }

        public CellModel(int x, int y, int z)
        {
            RowNumber = x;
            ColumnNumber = y;
            ID = z;
            liveNeighbors = 0;
            IsVisible = false;
        }//end constructor
    }//end CellModel
}//end namespace