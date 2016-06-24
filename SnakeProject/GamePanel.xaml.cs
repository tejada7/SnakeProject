using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TestViews
{
    public sealed partial class GamePanel : Page
    {

        private DispatcherTimer timer = new DispatcherTimer();

        public GamePanel()
        {
            // set settings to default
            new Settings();

            // set the size of the page
            ApplicationView.PreferredLaunchViewSize = new Size(825, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            // set game speed and start timer
            timer.Interval = TimeSpan.FromMilliseconds(Settings.Speed);
            timer.Tick += onUpdate;
            timer.Start();

            // initialize components
            this.InitializeComponent();

            //start new game
            startGame();
        }

        // Exit the game
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
