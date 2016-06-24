using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestViews
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    /// <summary>
    /// configuration of the game    
    /// </summary>
    class Settings
    {
        public static int Speed { get; set; }
        public static int Size { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Size = 40; // size of the snake ellipses
            //Speed = 120; // normal speed
            Score = 0; // counter of points
            Points = 100; // points win every time there is a successful eat
            GameOver = false; // status of the game
            direction = Direction.Down; // default direction of the snake            
        }
    }
}
