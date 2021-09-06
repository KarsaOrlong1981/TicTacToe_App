using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace TicTacToe_App
{



    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NamenEingeben : ContentPage
    {
        public string Username;
        public bool hardMode, impossibleMode;
        public bool GameMode;


        public NamenEingeben()
        {
            InitializeComponent();


            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en" || CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
            {
                lab_NameEingeben.Text = "Enter Your Name";
               
                entry_EingabeName.Placeholder = "Username";
                lab_hard.Text = "Choose your difficulty";
                btn_Einfach.Text = "Easy";
                btn_Schwer.Text = "Hard";
                btn_Unmoeglich.Text = "Impossible";
                lab_Modus.Text = "Choose Game mode";
            }

        }


        void btn_Einfach_Click(object sender, EventArgs e)
        {
            btn_Einfach.BackgroundColor = Color.Gray;
            btn_Einfach.TextColor = Color.Black;
            btn_Schwer.BackgroundColor = Color.Orange;
            btn_Schwer.TextColor = Color.White ;
            btn_Unmoeglich.BackgroundColor = Color.Red ;
            btn_Unmoeglich.TextColor = Color.White;
            btn_Unmoeglich.IsEnabled = true;
            btn_Einfach.IsEnabled = false ;
            btn_Schwer.IsEnabled = true;
            hardMode = false;
            impossibleMode = false;
           
        }
        void btn_Scwer_Click(object sender, EventArgs e)
        {
            btn_Schwer.BackgroundColor = Color.Gray;
            btn_Schwer.TextColor = Color.Black;
            btn_Unmoeglich.BackgroundColor = Color.Red;
            btn_Unmoeglich.TextColor = Color.White;
            btn_Einfach.BackgroundColor = Color.Green ;
            btn_Einfach.TextColor = Color.White;
            btn_Unmoeglich.IsEnabled = true ;
            btn_Einfach.IsEnabled = true;
            btn_Schwer.IsEnabled = false;
            hardMode = true;
            impossibleMode = false;
            
        }
        void btn_Unmoeglich_Click(object sender, EventArgs e)
        {
            btn_Unmoeglich.BackgroundColor = Color.Gray;
            btn_Unmoeglich.TextColor = Color.Black;
            btn_Einfach.BackgroundColor = Color.Green;
            btn_Einfach.TextColor = Color.White;
            btn_Schwer.BackgroundColor = Color.Orange;
            btn_Schwer.TextColor = Color.White;
            btn_Unmoeglich.IsEnabled = false;
            btn_Einfach.IsEnabled = true;
            btn_Schwer.IsEnabled = true;
            impossibleMode = true;
            hardMode = false;
        }

        private void btn_1vs1_Clicked(object sender, EventArgs e)
        {
            GameMode = true;
            btn_1vs1.BackgroundColor = Color.Gray;
            btn_1vs1.TextColor = Color.Black;
            btn_vsCom.BackgroundColor = Color.Cyan ;
            
            btn_vsCom.IsEnabled = true;
            btn_1vs1.IsEnabled = false;
        }

        private void btn_vsCom_Clicked(object sender, EventArgs e)
        {
            GameMode = false;
            btn_1vs1.BackgroundColor = Color.Cyan  ;
            
            btn_vsCom.BackgroundColor = Color.Gray ;
            btn_vsCom.TextColor = Color.Black ;
            btn_vsCom.IsEnabled = false ;
            btn_1vs1.IsEnabled = true ;
        }

      
        async void SeitenWechsel()
        {
            Username = entry_EingabeName.Text;



            MainPage Benutzer = new MainPage(Username, hardMode, impossibleMode, GameMode);




            await Navigation.PushAsync(Benutzer);
        }
         void Bestaetigen_Clicked(object sender, EventArgs e)
        {

            if (entry_EingabeName.Text == null)
            {
                DisplayAlert("fehlende Eingabe", "Bitte einen Benutzernamen eingeben.", "Verstanden");
                entry_EingabeName.Focus();
            }
            else
                SeitenWechsel();

            
        }



    }      
        
    
}