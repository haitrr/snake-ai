using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Item
    {
        private Node _position;
        public void DrawItem(Graphics g,int nodewidth,int nodeheight)
        {
            g.DrawImage(new Bitmap(".\\Item.png"), _position.Y * nodewidth, _position.X * nodeheight);
        }
        public Item()
        {
        }
        public Item(Node a)
        {
            _position = a;
        }
        internal Node Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
    }
}
