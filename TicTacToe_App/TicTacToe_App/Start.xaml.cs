using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TicTacToe_App
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
            
        }

        private void ToolbarItemInfo_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Info", "Image by IStock\nIcons by Icons8\nCreated by J.Thomas\n2021", "Verstanden");
            
        }

        private void ToolbarItemWeiter_Clicked(object sender, EventArgs e)
        {
            SeitenWechsel();
        }
        async void SeitenWechsel()
        {
            NamenEingeben benutzer = new NamenEingeben();
            await Navigation.PushAsync(benutzer);
        }
    }
}