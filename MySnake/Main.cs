using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Main : Form
    {
        private Game game;
        private Graphics g;
        List<int> temp;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            g = PNGame.CreateGraphics();
            NewGame();
        }
        public void NewGame()
        {
            g.Clear(PNGame.BackColor);
            game = new Game();
            game.Map = new Map(451, 901, "map1.txt");
            game.Map.DrawFrame(g, new Pen(Color.Black));
            game.Map.DrawMap(g);
            game.Snake = new Snake(game.Map.Nodes[game.Map.Lineamount / 2, game.Map.Columnamount / 2]);
            game.Snake.Direction = 3;
            game.Snake.DrawSnake(g, game.Map.Nodewidth, game.Map.Nodeheight);
            game.CreatItem();
            game.Item.DrawItem(g, game.Map.Nodewidth, game.Map.Nodeheight);
            temp = game.AutoPlay();
            TMDelay.Interval = 500;
            TMDelay.Enabled = true;
            TMDelay.Start();
        }

        private void PNGame_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(PNGame.BackColor);
            game.Map.DrawFrame(g, new Pen(Color.Black));
            game.Map.DrawMap(g);
            game.Snake.DrawSnake(g, game.Map.Nodewidth, game.Map.Nodeheight);
            game.Item.DrawItem(g, game.Map.Nodewidth, game.Map.Nodeheight);
        }

        private void TMDelay_Tick(object sender, EventArgs e)
        {
            //g.Clear(PNGame.BackColor);
            if (temp != null)
            {
                game.Snake.Direction = temp[temp.Count - 1];
                temp.RemoveAt(temp.Count - 1);
            }
            bool rs = game.SnakeMove(g,PNGame.BackColor,game.Map.Nodewidth,game.Map.Nodeheight);
            if(rs==false)
            {
                TMDelay.Stop();
                DialogResult d = MessageBox.Show("Game over!","Try Again?", MessageBoxButtons.YesNo);
                if(d==DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    Application.Exit();
                }
            }
            if (game.Map.Nodes[game.Item.Position.X, game.Item.Position.Y].Value != 2)
            {
                game.CreatItem();
                game.Item.DrawItem(g, game.Map.Nodewidth, game.Map.Nodeheight);
                temp = game.AutoPlay();
            }
            game.Map.DrawFrame(g, new Pen(Color.Black));
            //game.Snake.DrawSnake(g, game.Map.Nodewidth, game.Map.Nodeheight);
            TMDelay.Interval = 500 / game.Snake.Body.Count;
            lbLength.Text = "Length: " + game.Snake.Body.Count.ToString();
            LBDelayTime.Text = "DelayTime: " + TMDelay.Interval.ToString();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                if(game.Snake.Direction!=4) game.Snake.Direction = 3;
            }
            else if(e.KeyCode==Keys.Down)
            {
                if (game.Snake.Direction != 3) game.Snake.Direction = 4;
            }
            else if(e.KeyCode==Keys.Left)
            {
                if (game.Snake.Direction != 1) game.Snake.Direction = 2;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (game.Snake.Direction != 2) game.Snake.Direction = 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbLength_Click(object sender, EventArgs e)
        {

        }
    }
}
