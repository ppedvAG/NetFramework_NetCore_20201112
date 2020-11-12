using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDScreensaver
{
    public partial class Form1 : Form
    {
        int nachLinks = 3;
        int nachOben = 3;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           if (myButton1.Right >= ClientRectangle.Right || myButton1.Left <= 0)
               nachLinks *= -1;

           if (myButton1.Bottom >= ClientRectangle.Bottom || myButton1.Top <= 0)
               nachOben *= -1;

            myButton1.Left += nachLinks;
            myButton1.Top += nachOben;

        }
    }
}
