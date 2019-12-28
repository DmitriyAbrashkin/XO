using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class Cell
    {
        /// <summary>
        /// Координата Х
        /// </summary>
        public int X;
        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y;
        /// <summary>
        /// Статус ячейки
        /// </summary>
        public CellStatus Status;

        public Cell(int x, int y, CellStatus cellStatus)
        {
            X = x;
            Y = y;
            Status = cellStatus;
        }
        
    }
}
