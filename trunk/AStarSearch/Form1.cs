using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PathFinder pathFinder = new PathFinder();
            pathFinder.map = new Structs.Tile[100];
            int index = 0;
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    pathFinder.map[index].x = x;
                    pathFinder.map[index].y = y;
                    pathFinder.map[index].walkable = true;
                    if (x == 5)
                    {
                        if (y == 4 | y == 5 | y == 6)
                        {
                            pathFinder.map[index].walkable = false;
                        }
                    }
                    index++;
                }
            }
            CheckBox[] chbs = new CheckBox[100];
            int i = 0;
            foreach (Structs.Tile tile in pathFinder.map)
            {
                CheckBox chb = new CheckBox();
                chb.Width = 20;
                chb.Text = "";
                Point loc = new Point();
                loc.X = tile.x * 20;
                loc.Y = tile.y * 20;
                chb.Location = loc;
                if (!tile.walkable)
                {
                    chb.Enabled = false;
                }
                chbs[i] = chb;
                i++;
            }
            this.Controls.AddRange(chbs);   
        }
    }
}
