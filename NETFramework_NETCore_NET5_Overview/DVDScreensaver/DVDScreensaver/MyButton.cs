using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDScreensaver
{
    class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(SystemBrushes.Control, ClientRectangle);
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pevent.Graphics.FillEllipse(Brushes.Aqua, ClientRectangle);
            pevent.Graphics.DrawEllipse(new Pen(Brushes.Red, 3), ClientRectangle);

            var sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            pevent.Graphics.DrawString(Text, SystemFonts.CaptionFont, Brushes.Blue, ClientRectangle,sf);
        }

    }
}
