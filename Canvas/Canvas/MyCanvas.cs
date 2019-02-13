using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas
{
    class MyCanvas
    {
        public const int MaxWidth = 800;
        public const int MaxHeight = 600;

        private static int buttonIndex = 0;
        private static int MaxButtons = 3;

        private static MyButton[] buttons = new MyButton[MaxButtons];

        public static bool CreateNewButton(int x1, int y1, int x2, int y2)
        {
            if(buttonIndex == MaxButtons)
            {
                return false;
            }
            MyButton toAdd = CreateTheButton(x1,y1,x2,y2);
            return InsertButton(buttonIndex, toAdd);
        }

        public static bool MoveButton(int buttonNumber, int x, int y)
        {
            if (buttonNumber > buttonIndex)
            {
                return false;
            }
            MyButton buttonToBeReplaced = buttons[buttonNumber];
            MyButton toReplaceWith = CreateTheButton(buttonToBeReplaced.GetTopLeft().GetX()+x,
                                                    buttonToBeReplaced.GetTopLeft().GetY() + y,
                                                    buttonToBeReplaced.GetBottomRight().GetX() + x,
                                                    buttonToBeReplaced.GetBottomRight().GetY() + y);
            return InsertButton(buttonNumber, toReplaceWith);
        }

        private static MyButton CreateTheButton(int x1, int y1, int x2, int y2)
        {
            if (x1 < 0 | x2 < 0 | y1 < 0 | y2 < 0 |
                x1 > MaxWidth | x2 > MaxWidth | y1 > MaxHeight | y2 > MaxHeight)
            {
                return null;
            }

            return new MyButton(new Point(x1, y1), new Point(x2, y2));
        }

        private static bool InsertButton(int i, MyButton toAdd)
        {
            if (toAdd == null)
            {
                return false;
            }
            buttons[i] = toAdd;
            return true;
        }

        public static bool DeleteLastButton()
        {
            if (buttonIndex < 1)
            {
                return false;
            }
            buttons[buttonIndex] = null;
            buttonIndex--;
            return true;
        }
        public static void ClearAllButtons()
        {
            while (buttonIndex>=1)
            {
                DeleteLastButton();
            }
        }
        public static int GetCurrentNumberOfButtons()
        {
            return buttonIndex;
        }
        public static int GetMaxNumberOfButtons()
        {
            return MaxButtons;
        }
        public static int GetTheMaxWidthOfAButton()
        {
            int max = 0;
            for(int i = 0; i < buttonIndex; i++)
            {
                int toCheck = buttons[i].GetWidth();
                if (max < toCheck)
                {
                    max = toCheck;
                }
            }
            return max;
        }
        public static int GetTheMaxHeightOfAButton()
        {
            int max = 0;
            for (int i = 0; i < buttonIndex; i++)
            {
                int toCheck = buttons[i].GetHeight();
                if (max < toCheck)
                {
                    max = toCheck;
                }
            }
            return max;
        }
        public static bool IsPointInsideAButton(int x, int y)
        {
            for (int i = 0; i < buttonIndex; i++)
            {
                MyButton ToCheckWith = buttons[i];
                if (x >= ToCheckWith.GetTopLeft().GetX() &
                    x <= ToCheckWith.GetBottomRight().GetX() &
                    y <= ToCheckWith.GetTopLeft().GetY() &
                    y >= ToCheckWith.GetBottomRight().GetY())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckIfAnyButtonIsOverlapping()
        {
            for (int i = 0; i < buttonIndex; i++)
            {
                for (int j = 0; j < buttonIndex; j++)
                {
                    if (i != j)
                    {
                        int[,] first = buttons[i].Create2dRange();
                        int[,] second = buttons[j].Create2dRange();
                        if ((first[0, 0] >= second[0, 0] & first[0, 0] <= second[1, 0] |
                            first[1, 0] >= second[0, 0] & first[1, 0] <= second[1, 0] )&
                            (first[0, 1] >= second[1, 1] & first[0, 1] <= second[0, 1] |
                            first[1, 1] >= second[0, 1] & first[1, 1] <= second[1, 1]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
