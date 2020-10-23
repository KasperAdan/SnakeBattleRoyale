using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    class CustomLabel : Label
    {
        public CustomLabel(int x, int y, int width, int height, Color color)
        {
            Location = new Point(y, x);
            Size = new Size(width, height);
            BackColor = color;
            Enabled = false;
        }    
    }
}
