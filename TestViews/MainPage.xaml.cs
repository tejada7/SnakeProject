using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {            
            if (radioButtonEasy.IsChecked == true) {
                Settings.Speed = 200;
            }
            if (radioButtonMedium.IsChecked == true)
            {
                Settings.Speed = 120;
            }
            if (radioButtonHard.IsChecked == true)
            {
                Settings.Speed = 80;
            }
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(GamePanel), null);
            Window.Current.Activate();
        }
    }
}
