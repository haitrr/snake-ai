using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Game
    {
        private Snake _snake;
        private Map _map;
        private int _score;
        private Item _item;
        public bool SnakeMove(Graphics g,Color c,int nodewidth,int nodeheight)
        {
            switch(_snake.Direction)
            {
                case 4:if (_snake.Body[_snake.Body.Count - 1].X + 1 == _map.Lineamount) _snake.Body.Add(_map.Nodes[0, _snake.Body[_snake.Body.Count - 1].Y]); else _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X + 1, _snake.Body[_snake.Body.Count - 1].Y]); break;
                case 3: if (_snake.Body[_snake.Body.Count - 1].X - 1 == -1) _snake.Body.Add(_map.Nodes[_map.Lineamount-1, _snake.Body[_snake.Body.Count - 1].Y]); else _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X-1, _snake.Body[_snake.Body.Count - 1].Y]); break;
                case 2: if (_snake.Body[_snake.Body.Count - 1].Y - 1 == -1) _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X, _map.Columnamount-1]); else _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X, _snake.Body[_snake.Body.Count - 1].Y - 1]); break;
                case 1: if (_snake.Body[_snake.Body.Count - 1].Y + 1 == _map.Columnamount) _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X, 0]); else _snake.Body.Add(_map.Nodes[_snake.Body[_snake.Body.Count - 1].X, _snake.Body[_snake.Body.Count - 1].Y + 1]); break;
            }
            if (_snake.Body[_snake.Body.Count - 1].Value == 1 || _snake.Body[_snake.Body.Count - 1].Value == 3) return false;
            if (_snake.Body[_snake.Body.Count - 1].Value != 2)
            {
                _snake.Body[0].Value = 0;
                _snake.Body[0].ClearNode(g, c, nodewidth, nodeheight);
                _snake.Body.RemoveAt(0);
            }
            _snake.Body[_snake.Body.Count - 1].Value = 3;
            _snake.Body[_snake.Body.Count - 1].DrawNode(g,nodewidth,nodeheight);
            return true;
        }
        public List<int> AutoPlay()
        {
            for(int i=0;i<_map.Lineamount;i++)
            {
                for (int j = 0; j < _map.Columnamount; j++)
                {
                    _map.Nodes[i, j].Isinclose = false;
                    _map.Nodes[i, j].Isinopen = false;
                }
            }
            Node temp1;
            List<Node> BackupBody = new List<Node>();
            for(int i=0;i<Snake.Body.Count;i++)
            {
                temp1 = new Node();
                temp1.X = Snake.Body[i].X;
                temp1.Y = Snake.Body[i].Y;
                BackupBody.Add(temp1);
            }
            int[,] BackUpMap = new int[Map.Lineamount, Map.Columnamount];
            for(int i=0;i< Map.Lineamount;i++)
                for(int j=0;j<Map.Columnamount;j++)
                {
                    BackUpMap[i, j] = Map.Nodes[i, j].Value;
                }
            Node s, g,p;
            s = _snake.Body[_snake.Body.Count - 1];
            g = _item.Position;
            List<Node> open, close;
            open = new List<Node>();
            open.Add(s);
            close = new List<Node>();
            s.G = 0;
            s.F = heuristic(s,g);
            s.Isinopen = true;
            while(open.Count!=0)
            {
                Snake.Body = new List<Node>();
                for (int i = 0; i < BackupBody.Count; i++)
                {
                    _snake.Body.Add(_map.Nodes[BackupBody[i].X, BackupBody[i].Y]);
                }
                for (int i = 0; i < Map.Lineamount; i++)
                    for (int j = 0; j < Map.Columnamount; j++)
                    {
                        Map.Nodes[i, j].Value = BackUpMap[i, j];
                    }
                        p = FindNode(open);
                Node t = p;
                if (p != s)
                {
                    Node[] tn = new Node[t.G];
                    tn[0] = t;
                    for (int i = 1; i < t.G; i++)
                    {
                        tn[i] = t.From;
                        t = t.From;
                    }
                    for (int i = t.G - 1; i >= 0; i--)
                    {
                        Snake.Body.Add(tn[i]);
                        tn[i].Value = 3;
                        Snake.Body[0].Value = 0;
                        Snake.Body.RemoveAt(0);
                    }
                }
                if (p == g)
                {
                     Snake.Body = new List<Node>();
                    for (int i = 0; i < BackupBody.Count; i++)
                    {
                        _snake.Body.Add(_map.Nodes[BackupBody[i].X, BackupBody[i].Y]);
                    }
                    for (int i = 0; i < Map.Lineamount; i++)
                        for (int j = 0; j < Map.Columnamount; j++)
                        {
                            Map.Nodes[i, j].Value = BackUpMap[i, j];
                        }
                    List<int> rs = new List<int>();
                    Node temp = g;
                    while (temp != s)
                    {
                        if (temp.From.X + 1 == _map.Lineamount) { if (_map.Nodes[0, temp.From.Y] == temp) rs.Add(4); } else if (_map.Nodes[temp.From.X + 1, temp.From.Y] == temp) rs.Add(4);
                        if (temp.From.X - 1 == -1) { if (_map.Nodes[_map.Lineamount - 1, temp.From.Y] == temp) rs.Add(3); } else if (_map.Nodes[temp.From.X - 1, temp.From.Y] == temp) rs.Add(3);
                        if (temp.From.Y - 1 == -1) { if (_map.Nodes[temp.From.X, _map.Columnamount - 1] == temp) rs.Add(2); } else if (_map.Nodes[temp.From.X, temp.From.Y - 1] == temp) rs.Add( 2);
                        if (temp.From.Y + 1 == Map.Columnamount) { if (_map.Nodes[temp.From.X, 0] == temp) rs.Add(1); } else if (_map.Nodes[temp.From.X, temp.From.Y + 1] == temp) rs.Add(1);
                        temp = temp.From;
                    }
                    return rs;
                }
                open.Remove(p);
                p.Isinopen = false;
                close.Add(p);
                p.Isinclose = true;
                if (p.X + 1 == _map.Lineamount) AddOpen(g,p, _map.Nodes[0, p.Y], open, close); else AddOpen(g,p, _map.Nodes[p.X + 1, p.Y], open, close);
                if (p.X - 1 == -1) AddOpen(g,p, _map.Nodes[_map.Lineamount - 1, p.Y], open, close);else AddOpen(g,p, _map.Nodes[p.X - 1, p.Y], open, close);
                if (p.Y + 1 == Map.Columnamount) AddOpen(g,p, _map.Nodes[p.X, 0], open, close); else AddOpen(g,p, _map.Nodes[p.X , p.Y+1], open, close);
                if (p.Y - 1 == -1) AddOpen(g,p, _map.Nodes[p.X, _map.Columnamount - 1], open, close); else AddOpen(g,p, _map.Nodes[p.X , p.Y-1], open, close);
            }
            return null;
        }
        public void Recusion()
        {
            
        }

        public void AddOpen(Node g,Node p,Node a,List<Node> open,List<Node> close)
        {
            if (a.Value == 1 || a.Value == 3) return;
            if (a.Isinclose == true) return;
            int temp = p.G + 1;
            if (a.Isinopen == false)
            {
                open.Add(a);
                a.Isinopen = true;
            }
            else if (temp < a.G) return;
            a.From = p;
            a.G = temp;
            a.F = temp + heuristic(a,g);
        }
        public Node FindNode(List<Node> open)
        {
            int min = Int32.MaxValue, choose=0;
            for(int i=0;i<open.Count;i++)
            {
                if(open[i].F<min)
                {
                    min = open[i].F;
                    choose = i;
                }
            }
            return open[choose];
        }
        public int heuristic(Node a,Node g)
        {
            return 0;
        }
        public void CreatItem()
        {
            Random r = new Random();
            int x, y;
            do
            {
                x = r.Next(0, _map.Lineamount);
                y = r.Next(0, _map.Columnamount);
            }
            while (_map.Nodes[x, y].Value != 0);
            _map.Nodes[x, y].Value = 2;
            _item = new Item(_map.Nodes[x, y]);
        }
        internal Snake Snake
        {
            get
            {
                return _snake;
            }

            set
            {
                _snake = value;
            }
        }

        internal Map Map
        {
            get
            {
                return _map;
            }

            set
            {
                _map = value;
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }

        internal Item Item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
            }
        }
    }
}
