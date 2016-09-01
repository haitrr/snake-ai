using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Node
    {
        private Bitmap i1,i2;
        private int _x;
        private int _y;
        private int _value;
        private int _f;
        private int _g;
        private bool _isinopen;
        private bool _isinclose;
        private Node _from;
        public void DrawNodeWall(Graphics g,int nodewidth,int nodeheight)
        {
            i2 = new Bitmap(".\\Wall.png");
            g.DrawImage(i2, _y*nodewidth,_x*nodeheight );
        }
        public void DrawNode(Graphics g, int nodewidth, int nodeheight)
        {
            i1 = new Bitmap(".\\SnakeNode.png");
            g.DrawImage(i1, _y * nodewidth, _x * nodeheight);
        }
        public void ClearNode(Graphics g,Color c, int nodewidth, int nodeheight)
        {
            g.FillRectangle(new SolidBrush(c), _y * nodewidth, _x * nodeheight, 10, 10);
        }
        public Node()
        {
            _isinopen = _isinclose = false;
        }
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        public int F
        {
            get
            {
                return _f;
            }

            set
            {
                _f = value;
            }
        }

        public int G
        {
            get
            {
                return _g;
            }

            set
            {
                _g = value;
            }
        }

        public bool Isinopen
        {
            get
            {
                return _isinopen;
            }

            set
            {
                _isinopen = value;
            }
        }

        public bool Isinclose
        {
            get
            {
                return _isinclose;
            }

            set
            {
                _isinclose = value;
            }
        }

        internal Node From
        {
            get
            {
                return _from;
            }

            set
            {
                _from = value;
            }
        }
    }
}
