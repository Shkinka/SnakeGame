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
    public partial class Game : Form
    {
        int score = 0;
        Rectangle[] snake = new Rectangle[500];
        Point snakePosition = new Point(300, 100);
        Point windowPoint = new Point(825, 465);
        Rectangle food = new Rectangle(300, 300, 20, 20);

        public Game()
        {
            InitializeComponent();
            snake[0] =  new Rectangle(300, 100, 40, 40);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            SnakeMoveTimer.Interval = GameClass.CheckGameMod();
            this.KeyDown += new KeyEventHandler(OKP);
        }

        private void OKP (object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    GameClass.SetDirection(e.KeyCode.ToString());
                    break;

                case "Left":
                    GameClass.SetDirection(e.KeyCode.ToString());
                    break;

                case "Up":
                    GameClass.SetDirection(e.KeyCode.ToString());
                    break;

                case "Down":
                    GameClass.SetDirection(e.KeyCode.ToString());
                    break;
            }
            SnakeMoveTimer.Start();
        }

        private void паузаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (паузаToolStripMenuItem.Text == "Продолжить")
            {
                паузаToolStripMenuItem.Text = "Пауза";
                SnakeMoveTimer.Start();
            }
            else
            {
                паузаToolStripMenuItem.Text = "Продолжить";
                SnakeMoveTimer.Stop();
            }
            
        }
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseGame cg = new ChooseGame();
            this.Hide();
            cg.ShowDialog();
        }
        private void зановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SnakeMoveTimer.Stop();
            snakePosition = new Point(300, 100);
            snake[0].Location = snakePosition;
            food.Location = new Point(300, 300);
            Array.Clear(snake, 1, 99);
            score = 0;
            label1.Text = "Счет: 0";
            GameClass.oldDirection = "";
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), food);
            for (int i = 0; i<snake.Length; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), snake[i]);
            }
        }

        private void SnakeMoveTimer_Tick(object sender, EventArgs e)
        {
            if(GameClass.CheckEatFood(snake[0], food))
            {
                score++;
                label1.Text = "Счет: " + score.ToString();
                food.Location = GameClass.MoveFood(snake, score);
                GameClass.AddSnakeArr(snake, score);
            }

            if (GameClass.CheckPoints(windowPoint, snake, score))
            {
                SnakeMoveTimer.Stop();
                MessageBox.Show("Игра окончена!", "Поражение", MessageBoxButtons.OK);
                SnakeMoveTimer.Stop();
                snakePosition = new Point(300, 100);
                snake[0].Location = snakePosition;
                food.Location = new Point(300, 300);
                Array.Clear(snake, 1, 99);
                score = 0;
                label1.Text = "Счет: 0";
                GameClass.oldDirection = "";
            }

            snake = GameClass.MoveSnake(snake, score);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        } 
    }
}
