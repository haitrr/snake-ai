using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Snake
    {
        private List<Node> _body;
        private int _direction;
        public Snake(Node node)
        {
            Body = new List<Node>();
            Body.Add(node);
        }
        public Snake()
        {

        }

        public int Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        internal List<Node> Body
        {
            get
            {
                return _body;
            }

            set
            {
                _body = value;
            }
        }

        public void DrawSnake( Graphics g,int nodewidth,int nodeheight)
        {
            for(int i=0;i<Body.Count;i++)
            {
                Body[i].DrawNode(g,nodeheight,nodewidth);
            }
        }
    }
}
