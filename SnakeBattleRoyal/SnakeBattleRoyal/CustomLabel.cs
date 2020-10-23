using System.Drawing;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    class CustomLabel : Label
    {
        public CustomLabel(int x, int y, int width, int height, Color color, bool opaque)
        {
            Location = new Point(y, x);
            Size = new Size(width, height);
            Enabled = false;
            if (!opaque)
            {
                BackColor = Color.FromArgb(128, color);
            }
            else
            {
                BackColor = color;
            }
        }    
    }
}
