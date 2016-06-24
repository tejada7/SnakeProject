using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace TestViews
{
    /// <summary>
    /// graphical manipulation
    /// </summary>
    public sealed partial class GamePanel : Game
    {
        private List<Ellipse> Snake = new List<Ellipse>();
        private Ellipse food;
        ImageBrush image1 = new ImageBrush();
        ImageBrush image2 = new ImageBrush();
        ImageBrush image3 = new ImageBrush();
        ImageBrush skin = new ImageBrush();

        // set the head of the snake on the main frame
        public void startGame()
        {
            // set settings to default
            new Settings();
            image1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/fruit1.png"));
            image2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/fruit2.png"));
            image3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/fruit3.png"));
            skin.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/skin.png"));
            imageGameOver.Visibility = Visibility.Collapsed;

            // set position of object             
            Canvas.SetLeft(circle, Settings.Size);
            Canvas.SetTop(circle, Settings.Size);
            setDefaultDirection();

            Snake.Clear();
            circle.Width = circle.Height = Settings.Size;
            circle.Visibility = Visibility.Visible;
            //circle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            Snake.Add(circle);

            lblscore.Text = Settings.Score.ToString();
            generateFood();
        }

        // place random food on the frame 
        public void generateFood()
        {
            int maxXPos = (int)panel.Width;
            int maxYPos = (int)panel.Height;
            int size = Settings.Size;
            Random random = new Random();
            food = new Ellipse();
            food.Width = size;
            food.Height = size;

            int randomx = random.Next(0, maxXPos);
            int randomy = random.Next(0, maxYPos);

            if (randomx < maxXPos / 3)
            {
                food.Fill = image1;
            }
            else if (randomx > maxXPos / 3 && randomx < maxXPos * 2 / 3)
            {
                food.Fill = image2;
            }
            else
            {
                food.Fill = image3;
            }
            randomx = (int)(randomx / size) * size;
            randomy = (int)(randomy / size) * size;

            Canvas.SetLeft(food, randomx);
            Canvas.SetTop(food, randomy);
            panel.Children.Add(food);
        }

        // movement of the snake, by traversing the List of Ellipses
        public void paint()
        {
            int top, left;
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //move head
                if (i == 0)
                {
                    left = (int)Canvas.GetLeft(Snake[i]);
                    top = (int)Canvas.GetTop(Snake[i]);
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            left += Settings.Size;
                            Canvas.SetLeft(Snake[i], left);
                            break;
                        case Direction.Left:
                            left -= Settings.Size;
                            Canvas.SetLeft(Snake[i], left);
                            break;
                        case Direction.Up:
                            top -= Settings.Size;
                            Canvas.SetTop(Snake[i], top);
                            break;
                        case Direction.Down:
                            top += Settings.Size;
                            Canvas.SetTop(Snake[i], top);
                            break;
                    }

                    //Get Maximum x and y from the main container
                    int maxXPos = (int)panel.Width;
                    int maxYPos = (int)panel.Height;

                    //Detect collision with borders
                    if (Canvas.GetLeft(Snake[i]) >= maxXPos ||
                        Canvas.GetLeft(Snake[i]) < 0 ||
                        Canvas.GetTop(Snake[i]) >= maxYPos ||
                        Canvas.GetTop(Snake[i]) < 0)
                    {
                        die();
                        return;
                    }

                    //Detect collision with body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Canvas.GetLeft(Snake[i]) == Canvas.GetLeft(Snake[j])
                            && Canvas.GetTop(Snake[i]) == Canvas.GetTop(Snake[j]))
                        {
                            die();
                            return;
                        }
                    }

                    //Detect collision with food ellipse                    
                    if (left == Canvas.GetLeft(food)
                        && top == Canvas.GetTop(food))
                    {
                        eat();
                    }
                }
                else
                {
                    Canvas.SetTop(Snake[i], Canvas.GetTop(Snake[i - 1]));
                    Canvas.SetLeft(Snake[i], Canvas.GetLeft(Snake[i - 1]));
                }
            }
        }

        // add a new ellipse to the snake
        public void eat()
        {
            // create queue to be added to body
            Ellipse queue = new Ellipse();

            // set properties
            queue.Width = Settings.Size;
            queue.Height = Settings.Size;
            //queue.Fill = new SolidColorBrush(Windows.UI.Colors.Green);
            queue.Fill = skin;
            // get position of snake's last element
            int positionX = (int)Canvas.GetLeft(Snake[Snake.Count - 1]);
            int positionY = (int)Canvas.GetTop(Snake[Snake.Count - 1]);

            // set new position
            Canvas.SetLeft(queue, positionX);
            Canvas.SetTop(queue, positionY);

            // add to queue of the snake
            Snake.Add(queue);
            panel.Children.Add(queue);

            // remove previous food
            panel.Children.Remove(food);

            // update Score
            Settings.Score += Settings.Points;
            lblscore.Text = Settings.Score.ToString();

            // create a new food
            generateFood();
        }

        // whenever Snake collides with either border or body
        public void die()
        {
            Snake = clearCanvas();
            circle.Visibility = Visibility.Collapsed;
            Settings.GameOver = true;
            imageGameOver.Visibility = Visibility.Visible;
        }

        private List<Ellipse> clearCanvas()
        {
            for (int i = 1; i < Snake.Count; i++)
            {
                panel.Children.Remove(Snake[i]);
            }
            panel.Children.Remove(food);
            return Snake;
        }
    }
}