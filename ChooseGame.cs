using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class ChooseGame : Form
    {
        public ChooseGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameClass.gameMod = "easy";
            Game gm = new Game();
            this.Hide();
            gm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameClass.gameMod = "middle";
            Game gm = new Game();
            this.Hide();
            gm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameClass.gameMod = "hard";
            Game gm = new Game();
            this.Hide();
            gm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainMenu mm = new mainMenu();
            this.Hide();
            mm.ShowDialog();
        }
    }
}
