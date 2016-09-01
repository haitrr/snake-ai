using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MySnake
{
    class Map
    {
        private int _height;
        private int _width;
        private int _nodeheight;
        private int _nodewidth;
        private int _lineamount;
        private int _columnamount;
        private Node[,] _nodes;

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Nodeheight
        {
            get
            {
                return _nodeheight;
            }

            set
            {
                _nodeheight = value;
            }
        }

        public int Nodewidth
        {
            get
            {
                return _nodewidth;
            }

            set
            {
                _nodewidth = value;
            }
        }

        public int Lineamount
        {
            get
            {
                return _lineamount;
            }

            set
            {
                _lineamount = value;
            }
        }

        public int Columnamount
        {
            get
            {
                return _columnamount;
            }

            set
            {
                _columnamount = value;
            }
        }

        internal Node[,] Nodes
        {
            get
            {
                return _nodes;
            }

            set
            {
                _nodes = value;
            }
        }

        public Map(int height,int width,string file)
        {
            StreamReader f = new StreamReader(file,System.Text.Encoding.UTF8);
            Nodewidth = Int32.Parse(f.ReadLine());
            Nodeheight = Int32.Parse(f.ReadLine());
            Width = width;
            Height = height;
            Lineamount = Height / Nodeheight;
            Columnamount = Width / Nodewidth;
            Nodes = new Node[Lineamount,Columnamount];
            for(int i=0;i< Lineamount;i++)
            {
                string t = f.ReadLine();
                string[] temp = t.Split(' ');
                for(int j=0;j< Columnamount;j++)
                {
                    Nodes[i, j] = new Node();
                    Nodes[i, j].X = i;
                    Nodes[i, j].Y = j;
                    Nodes[i, j].Value = Int32.Parse(temp[j]);
                }
            }
        }
        public Map()
        {

        }
        public void DrawFrame(Graphics g,Pen pen)
        {
            g.DrawLine(pen, 0, 0, 0, Height - 1);
            g.DrawLine(pen, 0, 0, Width - 1, 0);
            g.DrawLine(pen, Width - 1, Height - 1, 0, Height - 1);
            g.DrawLine(pen, Width - 1, Height - 1, Width - 1, 0);
        }
        public void DrawMap(Graphics g)
        {
            for(int i=0;i<_lineamount;i++)
            {
                for(int j=0;j<_columnamount;j++)
                {
                    if (_nodes[i, j].Value == 1) _nodes[i, j].DrawNodeWall(g, _nodewidth, _nodeheight);
                }
            }
        }
    }
}
