using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkshopGame.UI
{
    public partial class AliansVsHeroesForm : Form
    {
        public AliansVsHeroesForm()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWindow newGameWindow = new GameWindow();
            newGameWindow.Show();
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
