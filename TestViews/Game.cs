using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestViews
{
    /// Interface that contains the behavior of the game, with main methods

    interface Game
    {
        void startGame();

        void eat();

        void generateFood();

        void paint();

        void die();
    }
}
