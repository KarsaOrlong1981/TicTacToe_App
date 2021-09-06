using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage ( new Start()) { BarBackgroundColor = Color.Magenta, BarTextColor = Color.LawnGreen };
          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
