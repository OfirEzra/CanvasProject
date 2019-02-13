using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas
{
    class MyButton
    {
        protected Point topLeft;
        protected Point bottomRight;

        private int width;
        private int height;

        internal MyButton(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            CalculateWidth();
            CalculateHeight();
        }

        private void CalculateWidth()
        {
            width = bottomRight.GetX() - topLeft.GetX();
        }
        private void CalculateHeight()
        {
            width = topLeft.GetY() - bottomRight.GetY();
        }

        internal int GetWidth()
        {
            return width;
        }
        internal int GetHeight()
        {
            return height;
        }

        internal Point GetTopLeft()
        {
            return topLeft;
        }
        internal Point GetBottomRight()
        {
            return bottomRight;
        }

        internal bool SetTopLeft(Point NewTopLeft)
        {
            if(NewTopLeft.GetX()<bottomRight.GetX() & NewTopLeft.GetY() > bottomRight.GetY())
            {
                this.topLeft = NewTopLeft;
                CalculateWidth();
                CalculateHeight();
                return true;
            }
            return false;
        }
        internal bool SetBottomRight(Point NewBottomRight)
        {
            if (NewBottomRight.GetX() > topLeft.GetX() & NewBottomRight.GetY() < topLeft.GetY())
            {
                this.bottomRight = NewBottomRight;
                CalculateWidth();
                CalculateHeight();
                return true;
            }
            return false;
        }
        public int[,] Create2dRange()
        {
            int[,] toReturn = new int[2, 2];
            toReturn[0, 0] = topLeft.GetX();
            toReturn[1, 0] = bottomRight.GetX();
            toReturn[0, 1] = topLeft.GetY();
            toReturn[1, 1] = bottomRight.GetY();

            return toReturn;
        }

        public override string ToString()
        {
            return topLeft.ToString() + bottomRight.ToString() + "Width:" + width + " Height:" + height;
        }
    }
}
