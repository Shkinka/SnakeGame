using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public static class GameClass
    {
        public static string gameMod = "";
        public static string oldDirection = "";

        public static void SetDirection(string dirUser)
        {
            string newDirection = dirUser;
            if(oldDirection == "Up" && newDirection == "Down")
            {
                return;
            }
            if (oldDirection == "Left" && newDirection == "Right")
            {
                return;
            }
            if (oldDirection == "Down" && newDirection == "Up")
            {
                return;
            }
            if (oldDirection == "Right" && newDirection == "Left")
            {
                return;
            }
            oldDirection = dirUser;
        }
        
        public static int CheckGameMod()
        {
            if(gameMod == "easy")
            {
                return 30;
            }
            if (gameMod == "middle")
            {
                return 25;
            }
            if (gameMod == "hard")
            {
                return 15;
            }
            return 250;
        }

        public static Rectangle[] MoveSnake(Rectangle[] snake, int score)
        {
            for (int i = score; i > 0; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }

            switch (oldDirection)
            {
                case "Right":
                    snake[0].X += 7;
                    break;

                case "Left":
                    snake[0].X -= 7;
                    break;

                case "Up":
                    snake[0].Y -= 7;
                    break;

                case "Down":
                    snake[0].Y += 7;
                    break;
            }

           
            return snake;
        }

        public static bool CheckPoints(Point windowPoint, Rectangle[] snake, int score)
        {
            if (snake[0].X + 20 >= windowPoint.X || snake[0].Y + 20 >= windowPoint.Y || snake[0].X <= 0 || snake[0].Y <= 45)
            { 
                return true;
            }

            //for (int i = score; i > 0; i--)
            //{
            //    if (snake[0].X + 20 <= snake[i].X && snake[0].Y + 20 <= snake[i].Y)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public static Point MoveFood(Rectangle[] snake, int score)
        {
            Random foodSpawn = new Random();
            Point newFood = new Point(foodSpawn.Next(0, 820), foodSpawn.Next(50, 450));
            for (int i = score; i >= 0; i--)
            {
                if (newFood.X <= snake[i].X && newFood.Y <= snake[i].Y)
                {
                    while (newFood.X <= snake[i].X && newFood.Y <= snake[i].Y)
                    {
                        newFood = new Point(foodSpawn.Next(0, 820), foodSpawn.Next(50, 450));
                    }
                }
            }
            return newFood;
        }

        public static bool CheckEatFood(Rectangle snake, Rectangle food)
        {
            Point newLocation = food.Location;
            newLocation.X += 10;
            newLocation.Y += 10;
            if(snake.Contains(newLocation))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddSnakeArr(Rectangle[] snake, int score)
        {
            Point newLocation = new Point();
            switch (oldDirection)
            {
                case "Right":
                    newLocation = new Point(snake[score - 1].X - 40, snake[0].Y);
                    break;

                case "Left":
                    newLocation = new Point(snake[score - 1].X + 40, snake[0].Y);
                    break;

                case "Up":
                    newLocation = new Point(snake[score - 1].X, snake[0].Y + 40);
                    break;

                case "Down":
                    newLocation = new Point(snake[score - 1].X, snake[0].Y - 40);
                    break;
            }
            snake[score] = new Rectangle(newLocation, snake[0].Size);
        }
    }


}
