using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp.UnityGame
{
    class CellCoordinate
    {
        public int x;
        public int y;
        public CellCoordinate()
        {
        }
        public CellCoordinate(int x, int y)
        {
            Set(x, y);
        }
        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Set(CellCoordinate c)
        {
            Set(c.x, c.y);
        }
        public bool Same(CellCoordinate c)
        {
            return c.x == x && c.y == y;
        }
        public override int GetHashCode()
        {
            return string.Format("{0},{1}", x, y).ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is CellCoordinate)
                return Same((CellCoordinate)obj);
            else
                return false;
        }
    }
}
