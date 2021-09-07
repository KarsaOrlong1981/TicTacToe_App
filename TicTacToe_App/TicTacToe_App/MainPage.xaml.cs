using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.IO;
using System.Reflection;
using Plugin.SimpleAudioPlayer;






namespace TicTacToe_App
{
    public partial class MainPage : ContentPage
    {
        bool musicPlays = false;
        bool vsPlayer = false;
        bool vsCom = false;
        bool PlayerWin = false;
        bool gameOvervsCom = false;
        bool itsDraw = false;
        bool gameOver2 = false;
        bool gameOverCom = false;
        string uebergabe;
        bool uebergabeHardMode,uebergabeUnmoeglichMode;
        bool uebergabeGameMode;
        int zaehlerWinsX = 0;
        int zaehlerWinsO = 0;
        int zaehlerWinsCom = 0, zaehlerWinsXvsCom;
        int aufrufeMethodeOFaengtAn = 0;
        
       

        public MainPage(string BenutzerName,bool hardMode,bool impossibleMode,bool gameMode)
        {
            InitializeComponent();

           /* player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
           
            player.Load("TicTacToeSoundtrack" + ".wav");

            player.Play();*/
            

            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
            {

                btn_Beenden.Text = "Reset";
                if(impossibleMode == true)
                {
                    
                    lab_HardMode.TextColor = Color.Red;
                    lab_HardMode.Text = "Unmöglich";
                }
                else 

                if (hardMode == false)
                {
                    
                    lab_HardMode.TextColor = Color.Green;
                    lab_HardMode.Text = "Einfach";
                }
                else
                {

                    lab_HardMode.TextColor = Color.Orange;
                    lab_HardMode.Text = "Schwer";
                }
            }
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
            {
                lab_Modus.Text = "Difficulty:";
                btn_Beenden.Text = "Reset";
                if (impossibleMode == true)
                {
                    lab_HardMode.TextColor = Color.Red;
                    lab_HardMode.Text = "Impossible";
                }
                else
               if (hardMode == false)
                {
                    lab_HardMode.TextColor = Color.Green;
                    lab_HardMode.Text = "Easy";
                }
                else
                {
                    lab_HardMode.TextColor = Color.Orange;
                    lab_HardMode.Text = "Hard";
                }
            }
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
            {
                lab_Modus.Text = "Difficulty:";
                btn_Beenden.Text = "Reset";
                if (impossibleMode == true)
                {
                    lab_HardMode.TextColor = Color.Red;
                    lab_HardMode.Text = "Impossible";
                }
                else
               if (hardMode == false)
                {
                    lab_HardMode.TextColor = Color.Green;
                    lab_HardMode.Text = "Easy";
                }
                else
                {
                    lab_HardMode.TextColor = Color.Orange;
                    lab_HardMode.Text = "Hard";
                }
            }
            // Den Eintrag des Benutzernamens von der Seite NamenEingeben übernehmen
            uebergabe = BenutzerName;
            lab_SpielerName.Text = uebergabe;
            // Den Schwierigkeitsgrad Übertragen
            uebergabeHardMode = hardMode;
            uebergabeUnmoeglichMode = impossibleMode;
            //den SpielModus übergeben
            uebergabeGameMode = gameMode;

            PlayerWin = false;
            vsCom = false;
            // Die felder leeren und Sperren
           lab_GameKoordinator.Text = "";
            feld_1.IsEnabled = false;
            feld_1.Text = "";
            feld_2.IsEnabled = false;
            feld_2.Text = "";
            feld_3.IsEnabled = false;
            feld_3.Text = "";
            feld_4.IsEnabled = false;
            feld_4.Text = "";
            feld_5.IsEnabled = false;
            feld_5.Text = "";
            feld_6.IsEnabled = false;
            feld_6.Text = "";
            feld_7.IsEnabled = false;
            feld_7.Text = "";
            feld_8.IsEnabled = false;
            feld_8.Text = "";
            feld_9.IsEnabled = false;
            feld_9.Text = "";
            if (uebergabeGameMode == true)
            {
                lab_Modus.Text = "";
                lab_HardMode.Text = "";
                lab_Com.Text = "Spieler 2";
            }
            
        }

        public void CloseApp()
        {
           Application.Current.Quit();
            
        }

        //Methoden zur Überprüfung Unentschieden oder Sieger!!!
        private void GameCom(string O, string X)
        {
        repeat:
            
           
            Random zufall = new Random();

            
            string feld = "feld_" + Convert.ToString(zufall.Next(1, 10));
            //Wenn X gegen Com das letzte freie Feld setzen muss Versucht Com ein freies feld zu finden und bleibt in eine Endlos Schleife hängen....Diese prüfung verhindert das.
            if (feld_1.IsEnabled == false & feld_2.IsEnabled == false & feld_3.IsEnabled  == false & feld_4.IsEnabled == false & feld_5.IsEnabled  == false & feld_6.IsEnabled  == false & feld_7.IsEnabled == false & feld_8.IsEnabled  == false & feld_9.IsEnabled == false)
            {


                feld = "";
                return;
            }




            //Hier muss der Com erkennen ob er eine 3er Reihe bauen kann.
            //Waagerecht
            if (feld_1.Text == O & feld_2.Text == O & feld_3.Text == "")
            {
                feld_3.Text = O ;
                feld_3.IsEnabled = false;
                return;
            }
            if (feld_3.Text == O & feld_2.Text == O & feld_1.Text == "")
            {
                feld_1.Text = O ;
                feld_1.IsEnabled = false;
                return;
            }
            if (feld_4.Text == O & feld_5.Text == O & feld_6.Text == "")
            {
                feld_6.Text = O;
                feld_6.IsEnabled = false;
                return;
            }
            if (feld_6.Text == O & feld_5.Text == O & feld_4.Text == "")
            {
                feld_4.Text = O;
                feld_4.IsEnabled = false;
                return;
            }
            if (feld_7.Text == O & feld_8.Text == O & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == O & feld_8.Text == O & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled  = false;
                return;
            }
            if (feld_1.Text == O & feld_3.Text == O & feld_2.Text == "")
            {
                feld_2.Text = O;
                feld_2.IsEnabled = false;
                return;
            }
            if (feld_4.Text == O & feld_6.Text == O & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            if (feld_7.Text == O & feld_9.Text == O & feld_8.Text == "")
            {
                feld_8.Text = O;
                feld_8.IsEnabled  = false;
                return;
            }
            if (feld_1.Text == O & feld_7.Text == O & feld_4.Text == "")
            {
                feld_4.Text = O;
                feld_4.IsEnabled = false;
                return;
            }
            if (feld_2.Text == O & feld_8.Text == O & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            if (feld_3.Text == O & feld_9.Text == O & feld_6.Text == "")
            {
                feld_6.Text = O;
                feld_6.IsEnabled = false;
                return;
            }
            if (feld_1.Text == O & feld_4.Text == O & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled = false;
                return;
            }
            if (feld_7.Text == O & feld_4.Text == O & feld_1.Text == "")
            {
                feld_1.Text = O;
                feld_1.IsEnabled  = false;
                return;
            }
            if (feld_2.Text == O & feld_5.Text == O & feld_8.Text == "")
            {
                feld_8.Text = O;
                feld_8.IsEnabled = false;
                return;
            }
            if (feld_8.Text == O & feld_5.Text == O & feld_2.Text == "")
            {
                feld_2.Text = O;
                feld_2.IsEnabled = false;
                return;
            }
            if (feld_3.Text == O & feld_6.Text == O & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == O & feld_6.Text == O & feld_3.Text == "")
            {
                feld_3.Text = O;
                feld_3.IsEnabled = false;
                return;
            }
            //Diagonal
            if (feld_1.Text == O & feld_5.Text == O & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == O & feld_5.Text == O & feld_1.Text == "")
            {
                feld_1.Text = O;
                feld_1.IsEnabled = false;
                return;
            }
            if (feld_3.Text == O & feld_5.Text == O & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled = false;
                return;
            }
            if (feld_7.Text == O & feld_5.Text == O & feld_3.Text == "")
            {
                feld_3.Text = O;
                feld_3.IsEnabled = false;
                return;
            }
            if (feld_1.Text == O & feld_9.Text == O & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            if (feld_3.Text == O & feld_7.Text == O & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            //Hier muss der Com erkennen ob Spieler 1 im nächsten zug eine 3er reihe bauen kann
            if (feld_1.Text == X & feld_2.Text == X & feld_3.Text == "")
            {
                feld_3.Text = O;
                feld_3.IsEnabled  = false;
                return;
            }
            if (feld_3.Text == X & feld_2.Text == X & feld_1.Text == "")
            {
                feld_1.Text = O;
                feld_1.IsEnabled = false;
                return;
            }
            if (feld_4.Text == X & feld_5.Text == X & feld_6.Text == "")
            {
                feld_6.Text = O;
                feld_6.IsEnabled = false;
                return;
            }
            if (feld_6.Text == X & feld_5.Text == X & feld_4.Text == "")
            {
                feld_4.Text = O;
                feld_4.IsEnabled = false;
                return;
            }
            if (feld_7.Text == X & feld_8.Text == X & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == X & feld_8.Text == X & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled = false;
                return;
            }
            if (feld_1.Text == X & feld_3.Text == X & feld_2.Text == "")
            {
                feld_2.Text = O;
                feld_2.IsEnabled = false;
                return;
            }
            if (feld_4.Text == X & feld_6.Text == X & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            if (feld_7.Text == X & feld_9.Text == X & feld_8.Text == "")
            {
                feld_8.Text = O;
                feld_8.IsEnabled = false;
                return;
            }
            if (feld_1.Text == X & feld_7.Text == X & feld_4.Text == "")
            {
                feld_4.Text = O;
                feld_4.IsEnabled  = false;
                return;
            }
            if (feld_2.Text == X & feld_8.Text == X & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }
            if (feld_3.Text == X & feld_9.Text == X & feld_6.Text == "")
            {
                feld_6.Text = O;
                feld_6.IsEnabled = false;
                return;
            }
            if (feld_1.Text == X & feld_4.Text == X & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled = false;
                return;
            }
            if (feld_7.Text == X & feld_4.Text == X & feld_1.Text == "")
            {
                feld_1.Text = O;
                feld_1.IsEnabled = false;
                return;
            }
            if (feld_2.Text == X & feld_5.Text == X & feld_8.Text == "")
            {
                feld_8.Text = O;
                feld_8.IsEnabled = false;
                return;
            }
            if (feld_8.Text == X & feld_5.Text == X & feld_2.Text == "")
            {
                feld_2.Text = O;
                feld_2.IsEnabled  = false;
                return;
            }
            if (feld_3.Text == X & feld_6.Text == X & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == X & feld_6.Text == X & feld_3.Text == "")
            {
                feld_3.Text = O;
                feld_3.IsEnabled = false;
                return;
            }
            //Diagonal
            if (feld_1.Text == X & feld_5.Text == X & feld_9.Text == "")
            {
                feld_9.Text = O;
                feld_9.IsEnabled = false;
                return;
            }
            if (feld_9.Text == X & feld_5.Text == X & feld_1.Text == "")
            {
                feld_1.Text = O;
                feld_1.IsEnabled = false;
                return;
            }
            if (feld_3.Text == X & feld_5.Text == X & feld_7.Text == "")
            {
                feld_7.Text = O;
                feld_7.IsEnabled = false;
                return;
            }
            if (feld_7.Text == X & feld_5.Text == X & feld_3.Text == "")
            {
                feld_3.Text = O;
                feld_3.IsEnabled = false;
                return;
            }
            if (feld_1.Text == X & feld_9.Text == X & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled  = false;
                return;
            }
            if (feld_3.Text == X & feld_7.Text == X & feld_5.Text == "")
            {
                feld_5.Text = O;
                feld_5.IsEnabled = false;
                return;
            }

            //Schwierigkeit erhöhen(Harter Modus) , das geschiet nur durch das setzen von feld 5 dadurch sind alle kreuze des feldes verhindert und selbst eingenommen.
            //zusätzlich muss geprüft werden ob nicht X schon die mitte eingenommen hat, wenn dem so ist muss eins der Kreuzfelder 1,3,7 und 9 belegt werden, dass verhindert das leichte spiel für X
            if (uebergabeHardMode == true)
            {


                if (feld_5.Text == "")
                {
                    feld_5.Text = O;
                    feld_5.IsEnabled = false;
                    return;
                }
                if (feld_5.Text == X)
                {
                    if (feld_1.Text == "")
                    {
                        feld_1.Text = O;
                        feld_1.IsEnabled = false;
                        return;
                    }
                    else
                    if (feld_3.Text == "")
                    {
                        feld_3.Text = O;
                        feld_3.IsEnabled = false;
                        return;
                    }
                }

                   
            }
            //Wenn der Unmöglich Modus Aktiviert ist

            if (uebergabeUnmoeglichMode == true)
            {
                if (feld_5.Text == "")
                {
                    feld_5.Text = O;
                    feld_5.IsEnabled = false;
                    return;
                }
                if (feld_5.Text == X)
                {
                    if (feld_1.Text == "")
                    {
                        feld_1.Text = O;
                        feld_1.IsEnabled = false;
                        return;
                    }
                    else
                    if (feld_3.Text == "")
                    {
                        feld_3.Text = O;
                        feld_3.IsEnabled = false;
                        return;
                    }
                    else
                    if (feld_7.Text == "")
                    {
                        feld_7.Text = O;
                        feld_7.IsEnabled = false;
                        return;
                    }
                    else
                    if (feld_9.Text == "")
                    {
                        feld_9.Text = O;
                        feld_9.IsEnabled = false;
                        return;
                    }
                }

            }

            //der fall das keine 3er Reihe möglich ist
            //hier muss ich prüfen ob die zufallsZahl nicht wiederholt vorkommt.Wenn doch soll der
            //Com eine Neue Zufallszahl erstellen únd das solange bis er ein freies Feld findet.
            //Im anderen Fall soll er O setzten das Feld Sperren und die methode verlassen.
            if (feld == "feld_1")
            {
                
               
                if (feld_1.IsEnabled  == true)
                {
                    feld_1.Text = O;
                    feld_1.IsEnabled = false;
                    return;
                }
                if(feld_1.Text == X)
                {
                  

                    goto repeat;
                }
                if (feld_1.Text == O)
                {
                  

                    goto repeat;
                }

            }
            else
             if (feld == "feld_2")
            {
                
                if (feld_2.IsEnabled == true)
                {
                    feld_2.Text = O;
                    feld_2.IsEnabled = false;
                    return;
                }
                if (feld_2.Text == X)
                {
                    

                    goto repeat;
                }
                if (feld_2.Text == O)
                {
                   

                    goto repeat;
                }
            }
            else
             if (feld == "feld_3")
            {
                
                if (feld_3.IsEnabled == true)
                {
                    feld_3.Text = O;
                    feld_3.IsEnabled = false;
                    return;
                }
                if (feld_3.Text == X)
                {
                   

                    goto repeat;
                }
                if (feld_3.Text == O)
                {
                    
                    goto repeat;
                }
            }
            else
             if (feld == "feld_4")
            {
                
                if (feld_4.IsEnabled == true)
                {
                    feld_4.Text = O;
                    feld_4.IsEnabled  = false;
                    return;
                }
                if (feld_4.Text == X)
                {
                  

                    goto repeat;
                }
                if (feld_4.Text == O)
                {
                   

                    goto repeat;
                }
            }
            else
             if (feld == "feld_5")
            {
                
                if (feld_5.IsEnabled == true)
                {
                    feld_5.Text = O;
                    feld_5.IsEnabled = false;
                    return;
                }
                if (feld_5.Text == X)
                {
               

                    goto repeat;
                }
                if (feld_5.Text == O)
                {
                

                    goto repeat;
                }
            }
            else
             if (feld == "feld_6")
            {
              
                if (feld_6.IsEnabled == true)
                {
                    feld_6.Text = O;
                    feld_6.IsEnabled = false;
                    return;
                }
                if (feld_6.Text == X)
                {
                

                    goto repeat;
                }
                if (feld_6.Text == O)
                {
                

                    goto repeat;
                }
            }
            else
             if (feld == "feld_7")
            {
                
                if (feld_7.IsEnabled == true)
                {
                    feld_7.Text = O;
                    feld_7.IsEnabled = false;
                    return;
                }
                if (feld_7.Text == X)
                {
                   

                    goto repeat;
                }
                if (feld_7.Text == O)
                {
                    

                    goto repeat;
                }
            }
            else
             if (feld == "feld_8")
            { 
               

                if (feld_8.IsEnabled  == true)
                {
                    feld_8.Text = O;
                    feld_8.IsEnabled = false;
                    return;
                }
                if (feld_8.Text == X)
                {
                    

                    goto repeat;
                }
                if (feld_8.Text == O)
                {
                    

                    goto repeat;
                }
            }
            else
             if (feld == "feld_9")
            {    
              
                if (feld_9.IsEnabled == true)
                {
                    feld_9.Text = O;
                    feld_9.IsEnabled = false;
                    return;
                }
                if (feld_9.Text == X)
                {
                    

                    goto repeat;
                }
                if (feld_9.Text == O)
                {
                    

                    goto repeat;
                }
                

                    
            }
            
            

        }
        private void Draw()
        {
            

            //Prüfen ob alle felder nicht Leer sind - Trifft das zu wird ein Unentschieden festgelegt.
            if (!(feld_1.Text == "") & !(feld_2.Text == "") & !(feld_3.Text == "") & !(feld_4.Text == "") & !(feld_5.Text == "") & !(feld_6.Text == "") & !(feld_7.Text == "") & !(feld_8.Text == "") & !(feld_9.Text == ""))
            {
               itsDraw = true;
                //Je nach Culture die passende Sprachausgabe wählen.
                if(CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                lab_GameKoordinator.Text = "Unentschieden!!!";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                    lab_GameKoordinator.Text = "Draw!!!";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                    lab_GameKoordinator.Text = "Draw!!!";
                btn_SpielStarten.IsVisible = true;
                lab_GameKoordinator.BackgroundColor = Color.DarkMagenta;
                lab_GameKoordinator.TextColor = Color.LawnGreen ;
            }
            //Wenn alle felder nicht leer sind aber im letzten Zug doch noch eine 3er Reihe ensteht -Prüfen über die Methoden und das Unentschieden überschreiben
            GameOverX();
            GameOverO();
            GameOverCom();
            
            
            
        }
        private void GameOverX()
        {
            
           

            //Prüfen ob irgendwo auf dem spielfeld durch das setzten von X auf 
            // dem aktuellen Feld eine 3er reihe ensteht, was zum Spielende führt.
            if (feld_1.Text == "X" & feld_4.Text == "X" & feld_7.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_1.Text == "X" & feld_2.Text == "X" & feld_3.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_1.Text == "X" & feld_5.Text == "X" & feld_9.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_2.Text == "X" & feld_5.Text == "X" & feld_8.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_3.Text == "X" & feld_6.Text == "X" & feld_9.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_4.Text == "X" & feld_5.Text == "X" & feld_6.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_7.Text == "X" & feld_8.Text == "X" & feld_9.Text == "X")
            {

                gameOvervsCom = true;
            }
            else
                if (feld_7.Text == "X" & feld_5.Text == "X" & feld_3.Text == "X")
            {

                gameOvervsCom = true;
            }

            else

            {
                gameOvervsCom = false;


            }
            if (gameOvervsCom == true)
            {
                
               
                //Text das spieler 1 gewonnen hat und das sperren aller felder
                // damit keine weiteren felder gesetzt werden können
                PlayerWin = true;//nur gegen Com wichtig

                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                    lab_GameKoordinator.Text = "X hat Gewonnen !!! ";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                    lab_GameKoordinator.Text = "X wins !!! ";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                    lab_GameKoordinator.Text = "X wins !!! ";
                        feld_1.IsEnabled  = false;

                feld_2.IsEnabled  = false;
                
                feld_3.IsEnabled  = false;

                feld_4.IsEnabled  = false;

                feld_5.IsEnabled  = false;

                feld_6.IsEnabled  = false;

                feld_7.IsEnabled  = false;

                feld_8.IsEnabled  = false;

                feld_9.IsEnabled  = false;
                lab_GameKoordinator.IsVisible = true;
                lab_GameKoordinator.BackgroundColor = Color.Cyan;
                lab_GameKoordinator.TextColor = Color.Black;
                btn_SpielStarten.IsVisible = true;
                PruefungAufSieg();
            }

            

        }
        void PruefungAufSieg()
        {
            if (zaehlerWinsCom >= 9|| zaehlerWinsO >= 9 || zaehlerWinsX >= 9 || zaehlerWinsXvsCom >= 9)
            {
                if (zaehlerWinsCom >= 9)
                {
                    btn_SpielStarten.IsVisible = false;
                    lab_GameKoordinator.BackgroundColor = Color.LawnGreen ;
                    lab_GameKoordinator.TextColor = Color.Black;
                    lab_ZaehlerO.Text = "10";
                    DisplayAlert("Tic Tac Toe", "Der Computer hat Gewonnen,viel Glück beim nächsten mal", "Verstanden.");
                   
                }
                if (zaehlerWinsO >= 9)
                {
                    btn_SpielStarten.IsVisible = false;
                    lab_GameKoordinator.BackgroundColor = Color.LawnGreen ;
                    lab_GameKoordinator.TextColor = Color.Black;
                    lab_ZaehlerO.Text = "10";
                    DisplayAlert("Tic Tac Toe", "Spieler 2 hat Gewonnen, Herzlichen Glückwunsch", "Verstanden.");
                   
                }
                if (zaehlerWinsX >= 9)
                {
                    btn_SpielStarten.IsVisible = false;
                    lab_GameKoordinator.BackgroundColor = Color.Cyan;
                    lab_GameKoordinator.TextColor = Color.Black;
                    lab_ZaehlerX.Text = "10";
                    DisplayAlert("Tic Tac Toe", lab_SpielerName.Text + " hat Gewonnen, Herzlichen Glückwunsch", "Verstanden.");
                    
                }
                if (zaehlerWinsXvsCom >= 9)
                {
                    btn_SpielStarten.IsVisible = false;
                    lab_GameKoordinator.BackgroundColor = Color.Cyan;
                    lab_GameKoordinator.TextColor = Color.Black;
                    lab_ZaehlerX.Text = "10";
                    DisplayAlert("Tic Tac Toe", lab_SpielerName.Text + " hat Gewonnen, Herzlichen Glückwunsch Sie haben den Computer besiegt", "Verstanden.");
                   
                    
                }
                
            }
        }
       
        
            
            
        
        // Diese Methode prüft Nach jedem setzen von O ob O gewonnen hat.
        private void GameOverO()
        {

            

            if (vsCom == false)
            {

                if (feld_1.Text == "O" & feld_4.Text == "O" & feld_7.Text == "O")
                {

                    gameOver2 = true;
                }

                else
                                  if (feld_1.Text == "O" & feld_2.Text == "O" & feld_3.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                                       if (feld_1.Text == "O" & feld_5.Text == "O" & feld_9.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                                           if (feld_2.Text == "O" & feld_5.Text == "O" & feld_8.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                                           if (feld_3.Text == "O" & feld_6.Text == "O" & feld_9.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                                       if (feld_4.Text == "O" & feld_5.Text == "O" & feld_6.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                                   if (feld_7.Text == "O" & feld_8.Text == "O" & feld_9.Text == "O")
                {

                    gameOver2 = true;
                }
                else
                               if (feld_7.Text == "O" & feld_5.Text == "O" & feld_3.Text == "O")
                {

                    gameOver2 = true;
                }


                else

                {
                    gameOver2 = false;

                }


                if (gameOver2 == true)
                {
                    
                    
                   
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                        lab_GameKoordinator.Text = "O hat Gewonnen !!! ";
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                        lab_GameKoordinator.Text = "O wins !!! ";
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                        lab_GameKoordinator.Text = "O wins !!! ";
                    feld_1.IsEnabled = false;

                    feld_2.IsEnabled = false;

                    feld_3.IsEnabled = false;

                    feld_4.IsEnabled = false;

                    feld_5.IsEnabled = false;

                    feld_6.IsEnabled = false;

                    feld_7.IsEnabled = false;

                    feld_8.IsEnabled = false;

                    feld_9.IsEnabled = false;
                    lab_GameKoordinator.BackgroundColor = Color.LawnGreen ;
                    lab_GameKoordinator.TextColor = Color.Black;

                    btn_SpielStarten.IsVisible = true;
                    PruefungAufSieg();
                   
                }
                
            }
            else
                return;
        }
        // Methode zur prüfung ob der Com gewonnen hat nach dem setzten in einem feld
        private void GameOverCom()
        {

           

            if (vsCom == true)
            {
                if (feld_1.Text == "O" & feld_4.Text == "O" & feld_7.Text == "O")
                {

                    gameOverCom = true;
                }

                else
                              if (feld_1.Text == "O" & feld_2.Text == "O" & feld_3.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                                   if (feld_1.Text == "O" & feld_5.Text == "O" & feld_9.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                                       if (feld_2.Text == "O" & feld_5.Text == "O" & feld_8.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                                       if (feld_3.Text == "O" & feld_6.Text == "O" & feld_9.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                                   if (feld_4.Text == "O" & feld_5.Text == "O" & feld_6.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                               if (feld_7.Text == "O" & feld_8.Text == "O" & feld_9.Text == "O")
                {

                    gameOverCom = true;
                }
                else
                           if (feld_7.Text == "O" & feld_5.Text == "O" & feld_3.Text == "O")
                {

                    gameOverCom = true;
                }


                else

                {
                    gameOverCom = false;

                }


                if (gameOverCom == true)
                {
                    
                   

                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                        lab_GameKoordinator.Text = "Com hat Gewonnen !!! ";
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                        lab_GameKoordinator.Text = "Com wins !!! ";
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                        lab_GameKoordinator.Text = "Com wins !!! ";
                    feld_1.IsEnabled = false;

                    feld_2.IsEnabled = false;

                    feld_3.IsEnabled = false;

                    feld_4.IsEnabled = false;

                    feld_5.IsEnabled = false;

                    feld_6.IsEnabled = false;

                    feld_7.IsEnabled = false;

                    feld_8.IsEnabled = false;

                    feld_9.IsEnabled = false;
                    lab_GameKoordinator.IsVisible = true;
                    lab_GameKoordinator.BackgroundColor = Color.LawnGreen ;
                    lab_GameKoordinator.TextColor = Color.Black;
                    btn_SpielStarten.IsVisible = true;
                    
                    PruefungAufSieg();
                }
            }
            else
                return;
        }

        //Modus 1 vs 1 Starten
        private void btn_SpielStarten_Click(object sender, EventArgs e)
        {
           

            btn_SpielStarten.Text = "Nächste Runde";
            btn_SpielStarten.IsVisible = false;
            lab_GameKoordinator.BackgroundColor = Color.DarkMagenta;
            lab_GameKoordinator.TextColor = Color.LawnGreen;
            feld_1.TextColor = Color.LawnGreen;
            feld_2.TextColor = Color.LawnGreen;
            feld_3.TextColor = Color.LawnGreen;
            feld_4.TextColor = Color.LawnGreen;
            feld_5.TextColor = Color.LawnGreen;
            feld_6.TextColor = Color.LawnGreen;
            feld_7.TextColor = Color.LawnGreen;
            feld_8.TextColor = Color.LawnGreen;
            feld_9.TextColor = Color.LawnGreen;
            //Spiel Modus abfragen
            //Modus 1 vs 1
            if (uebergabeGameMode == true)
            {

                lab_HardMode.Text = "";
                lab_Modus.Text = "";

                lab_Com.Text = "Spieler 2";

                if (vsCom == true)
                {


                    gameOvervsCom = false;
                    gameOver2 = false;

                    zaehlerWinsX = 0;
                    zaehlerWinsO = 0;

                }
                if (gameOver2 == true)
                {
                    zaehlerWinsO++;

                }
                if (gameOvervsCom == true)
                {
                    zaehlerWinsX++;
                }
                lab_ZaehlerX.Text = Convert.ToString(zaehlerWinsX);
                lab_ZaehlerO.Text = Convert.ToString(zaehlerWinsO);




                vsCom = false;
                vsPlayer = true;



                feld_1.IsEnabled = true;
                feld_1.Text = "";
                feld_2.IsEnabled = true;
                feld_2.Text = "";
                feld_3.IsEnabled = true;
                feld_3.Text = "";
                feld_4.IsEnabled = true;
                feld_4.Text = "";
                feld_5.IsEnabled = true;
                feld_5.Text = "";
                feld_6.IsEnabled = true;
                feld_6.Text = "";
                feld_7.IsEnabled = true;
                feld_7.Text = "";
                feld_8.IsEnabled = true;
                feld_8.Text = "";
                feld_9.IsEnabled = true;
                feld_9.Text = "";




                //Anzahl der Spieler auf 2 festlegen,lab_Spielerermitteln ist ein HilfsLabel um die Reihenfolge einzuhalten
                lab_Spielerermitteln.Text = "2";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                    lab_GameKoordinator.Text = "X fängt an!!!";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                    lab_GameKoordinator.Text = "X begins!!!";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                    lab_GameKoordinator.Text = "X begins !!!";

                if (gameOvervsCom == true || gameOver2 == true || itsDraw == true)
                {
                    aufrufeMethodeOFaengtAn++;
                    if (aufrufeMethodeOFaengtAn > 1)
                    {

                        aufrufeMethodeOFaengtAn = 0;
                    }
                    else
                    {
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                            lab_GameKoordinator.Text = "O ist am Zug";
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                            lab_GameKoordinator.Text = "O is your turn";
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                            lab_GameKoordinator.Text = "O is your turn";

                        lab_Spielerermitteln.Text = "1";
                    }
                }
            }
            //Ansonsten den Vs Com modus ausführen.
            else
            {

                lab_Com.Text = "Com";
                lab_GameKoordinator.IsVisible = false;





                //normalen Standard Modus ausführen.
                //Wenn vsPlayer true ist den Punktestand zuruecksetzen , dann erst vsPlayer auf false setzen
                if (vsPlayer == true)
                {
                    zaehlerWinsCom = 0;
                    zaehlerWinsXvsCom = 0;

                    gameOverCom = false;
                    gameOvervsCom = false;
                    itsDraw = false;

                }






                if (gameOverCom == true)
                {
                    zaehlerWinsCom++;

                }
                if (gameOvervsCom == true)
                {
                    zaehlerWinsXvsCom++;

                }
                lab_ZaehlerX.Text = Convert.ToString(zaehlerWinsXvsCom);
                lab_ZaehlerO.Text = Convert.ToString(zaehlerWinsCom);






                //Spielfelder freigeben
                feld_1.IsEnabled = true;
                feld_1.Text = "";
                feld_2.IsEnabled = true;
                feld_2.Text = "";
                feld_3.IsEnabled = true;
                feld_3.Text = "";
                feld_4.IsEnabled = true;
                feld_4.Text = "";
                feld_5.IsEnabled = true;
                feld_5.Text = "";
                feld_6.IsEnabled = true;
                feld_6.Text = "";
                feld_7.IsEnabled = true;
                feld_7.Text = "";
                feld_8.IsEnabled = true;
                feld_8.Text = "";
                feld_9.IsEnabled = true;
                feld_9.Text = "";


                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                    lab_GameKoordinator.Text = "X fängt an";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                    lab_GameKoordinator.Text = "X begins";
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                    lab_GameKoordinator.Text = "X begins";
                lab_Spielerermitteln.Text = "2";

                if (gameOverCom == true || gameOvervsCom == true || itsDraw == true)
                {
                    aufrufeMethodeOFaengtAn++;
                    if (aufrufeMethodeOFaengtAn > 1)
                    {

                        aufrufeMethodeOFaengtAn = 0;
                    }
                    else
                    {
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                            lab_GameKoordinator.Text = "X ist am Zug";
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                            lab_GameKoordinator.Text = "X is your turn";
                        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                            lab_GameKoordinator.Text = "X is your turn";

                        GameCom("O", "X");
                    }


                }

                gameOvervsCom = false;
                gameOverCom = false;
                itsDraw = false;
                PlayerWin = false;
                vsCom = true;
                vsPlayer = false;

            }


            
        }
        // Die Klick Ereignise der Felder
        private void feld_1_Click(object sender, EventArgs e)
        {

            FelderMethode(feld_1,"1");

            
        }


        private void feld_2_Click(object sender, EventArgs e)
        {

            FelderMethode(feld_2,"2");


        }

        private void feld_3_Click(object sender, EventArgs e)
        {
            FelderMethode(feld_3,"3");



        }

        private void feld_4_Click(object sender, EventArgs e)
        {
            FelderMethode(feld_4,"4");


        }

        private void feld_5_Click(object sender, EventArgs e)
        {

            FelderMethode(feld_5,"5");



        }

        private void feld_6_Click(object sender, EventArgs e)
        {

            FelderMethode(feld_6,"6");

        }

        private void feld_7_Click(object sender, EventArgs e)
        {
            FelderMethode(feld_7,"7");

        }

        private void feld_8_Click(object sender, EventArgs e)
        {
            FelderMethode(feld_8,"8");

        }

        private void feld_9_Click(object sender, EventArgs e)
        {
            FelderMethode(feld_9,"9");

        }

        void GameKoordinater(string O,string X,string feldNR,string spieler)
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                lab_GameKoordinator.Text = O + " ist am Zug";
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                lab_GameKoordinator.Text = O + " it's your turn";
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                lab_GameKoordinator.Text = O + " it's your turn";
            lab_Spielerermitteln.Text = spieler;
            string feld = "feld_" + feldNR;
            if (feld == "feld_1")
                feld_1.Text = X;
            if (feld == "feld_2")
                feld_2.Text = X;
            if (feld == "feld_3")
                feld_3.Text = X;
            if (feld == "feld_4")
                feld_4.Text = X;
            if (feld == "feld_5")
                feld_5.Text = X;
            if (feld == "feld_6")
                feld_6.Text = X;
            if (feld == "feld_7")
                feld_7.Text = X;
            if (feld == "feld_8")
                feld_8.Text = X;
            if (feld == "feld_9")
                feld_9.Text = X;
           
        }
        void GameKoordinaterComSet(string X,string spieler)
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "de")
                lab_GameKoordinator.Text = X + " ist am Zug";
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "en")
                lab_GameKoordinator.Text = X + " it's your turn";
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString() == "us")
                lab_GameKoordinator.Text = X + " it's your turn";
            lab_Spielerermitteln.Text = spieler;
            
        }

        
        
          
        void FelderMethode(Button feld,string feldNR)
        {
           
            //Spiel Modus vs Com
            if (vsCom == true & lab_Spielerermitteln.Text == "2")
            {
                feld.TextColor = Color.Cyan;
               
                //Spieler 1 setzt X
                GameKoordinater("O", "X", feldNR , "1");
                GameOverX();

                feld.IsEnabled = false;
                if (PlayerWin == true)
                    lab_Spielerermitteln.Text = "2";
            }

            if (vsCom == true & lab_Spielerermitteln.Text == "1" & PlayerWin == false)
            {

                //Com setzt O oder X
                GameKoordinaterComSet("X", "2");

                GameCom("O", "X");

                GameOverCom();

            }

            else
            //Spielmodus 1 vs 1.
        if (lab_Spielerermitteln.Text == "2")//Anzahl der Spieler
            {
                feld .TextColor = Color.Cyan;
                lab_GameKoordinator.BackgroundColor = Color.LawnGreen ;
                lab_GameKoordinator.TextColor = Color.Black;
                GameKoordinater("O", "X", feldNR, "1");
                GameOverX();
                feld .IsEnabled = false;
            }
            else

            // der nächste Spieler 
            if (lab_Spielerermitteln.Text == "1")
            {
                feld.TextColor = Color.LawnGreen;
                lab_GameKoordinator.BackgroundColor = Color.Cyan;
                lab_GameKoordinator.TextColor = Color.Black;
                GameKoordinater("X", "O", feldNR , "2");
                GameOverO();
                feld.IsEnabled = false;
            }

            Draw();
        }
        private void btn_Beenden_Click(object sender, EventArgs e)
        {
            lab_GameKoordinator.IsVisible = true;
            btn_SpielStarten.IsVisible = true;
            btn_SpielStarten.IsEnabled = true;
            PlayerWin = false;
            vsCom = false;
            zaehlerWinsCom = 0;
            zaehlerWinsO = 0;
            zaehlerWinsX = 0;
            zaehlerWinsXvsCom = 0;
            gameOvervsCom = false;
            gameOverCom = false;

            gameOver2 = false;
            lab_ZaehlerO.Text = "0";
            lab_ZaehlerX.Text = "0";
            // Die felder leeren und Sperren
            lab_GameKoordinator.Text = "";
            feld_1.IsEnabled  = false;
            feld_1.Text = "";
            feld_1.TextColor = Color.LawnGreen ;
            feld_2.IsEnabled = false;
            feld_2.Text = "";
            feld_2.TextColor = Color.LawnGreen;
            feld_3.IsEnabled = false;
            feld_3.Text = "";
            feld_3.TextColor = Color.LawnGreen;
            feld_4.IsEnabled  = false;
            feld_4.Text = "";
            feld_4.TextColor = Color.LawnGreen;
            feld_5.IsEnabled = false;
            feld_5.Text = "";
            feld_5.TextColor = Color.LawnGreen;
            feld_6.IsEnabled = false;
            feld_6.Text = "";
            feld_6.TextColor = Color.LawnGreen;
            feld_7.IsEnabled  = false;
            feld_7.Text = "";
            feld_7.TextColor = Color.LawnGreen;
            feld_8.IsEnabled  = false;
            feld_8.Text = "";
            feld_8.TextColor = Color.LawnGreen;
            feld_9.IsEnabled  = false;
            feld_9.Text = "";
            feld_9.TextColor = Color.LawnGreen;
            CloseApp();
        }  
    }
}
