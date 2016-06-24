using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace TestViews
{
    /// <summary>
    /// class that handles the keypressed events 
    /// </summary>
    public sealed partial class GamePanel
    {
        // event handler
        private void onUpdate(object sender, object e)
        {
            // check for game over status
            if (Settings.GameOver == true)
            {
                // check if enter key is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    Settings.GameOver = false;
                    startGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                {
                    Settings.direction = Direction.Right;
                }
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                {
                    Settings.direction = Direction.Left;
                }
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                {
                    Settings.direction = Direction.Up;
                }
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                {
                    Settings.direction = Direction.Down;
                }

                // render the snake 
                paint();
            }
        }

        private void setDefaultDirection()
        {
            Input.ChangeState(Keys.Enter, false);
            Input.ChangeState(Keys.Up, false);
            Input.ChangeState(Keys.Left, false);
            Input.ChangeState(Keys.Down, true);
            Input.ChangeState(Keys.Right, false);
        }

        // key pressed event
        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Up":
                    Input.ChangeState(Keys.Up, true);
                    Input.ChangeState(Keys.Down, false);
                    Input.ChangeState(Keys.Left, false);
                    Input.ChangeState(Keys.Right, false);
                    break;
                case "Down":
                    Input.ChangeState(Keys.Down, true);
                    Input.ChangeState(Keys.Left, false);
                    Input.ChangeState(Keys.Right, false);
                    Input.ChangeState(Keys.Up, false);
                    break;
                case "Right":
                    Input.ChangeState(Keys.Right, true);
                    Input.ChangeState(Keys.Up, false);
                    Input.ChangeState(Keys.Down, false);
                    Input.ChangeState(Keys.Left, false);
                    break;
                case "Left":
                    Input.ChangeState(Keys.Left, true);
                    Input.ChangeState(Keys.Up, false);
                    Input.ChangeState(Keys.Right, false);
                    Input.ChangeState(Keys.Down, false);
                    break;
                case "Enter":
                    if (Settings.GameOver)
                    {
                        Input.ChangeState(Keys.Enter, true);
                    }
                    break;
            }
        }
    }
}
