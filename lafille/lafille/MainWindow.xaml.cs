using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lafille
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int portedragon = 0;
        private int porteprincesse = 0;
        private int vie = 3;
        private int succes = 0;                                                                                                 //@ c'est pour identifier les  deux \  \

        private System.Media.SoundPlayer rire = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + @"\lessons\rire.wav"); //pour les sons ou musique qui sont en contenu
        private System.Media.SoundPlayer applaudissement = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory +@"\lessons\applaudissementrs.wav");
        public MainWindow()
        {

            InitializeComponent();

            Reset();
        }

        private void ResetPortes()
        {
            BitmapImage imgPorteferme = new BitmapImage(); //un objet qui pourra contenir mon image de porteferme
            imgPorteferme.BeginInit();// commence a editer,,recuper dans les ressources les images
            imgPorteferme.UriSource = new Uri("pack://application:,,,/lesimages/portes ferme.jpg ", UriKind.Absolute); // source de l'image en ressources
            imgPorteferme.EndInit(); // fini d'editer

            imagePorte1.Source = imgPorteferme;
            imagePorte2.Source = imgPorteferme;
            imagePorte3.Source = imgPorteferme;

            Random rnd = new Random();

            portedragon = rnd.Next(1, 4);
            porteprincesse = rnd.Next(1, 4);

            while(portedragon == porteprincesse)
            {
                porteprincesse = rnd.Next(1, 4);
            }
        }

        private void Reset()
        {
            ResetPortes();
            succes = 0;
            vie = 3;

            BitmapImage imagevie = new BitmapImage(); //un objet qui pourra contenir mon image de porteferme
            imagevie.BeginInit();// commence a editer
            imagevie.UriSource = new Uri("pack://application:,,,/lesimages/coeur.jpg ", UriKind.Absolute); // source de l'image en ressources
            imagevie.EndInit(); // fini d'editer

            imagevies1.Source = imagevie;
            imagevies2.Source = imagevie;
            imagevies3.Source = imagevie;
        }

        private void boutonReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();

        }
        private void OuvrirPorte(int nunporte)
        {
            Boolean trouve = false;

            BitmapImage imgPorteOuverte = new BitmapImage();

            imgPorteOuverte.BeginInit();
            imgPorteOuverte.UriSource = new Uri("pack://application:,,,/Lesimages/portes ouvertes.jpg", UriKind.Absolute);
            imgPorteOuverte.EndInit();

            rire.Stop();
            applaudissement.Stop();


            switch (nunporte)
            {
                case 1:
                    imagePorte1.Source = imgPorteOuverte;
                    break;

                case 2:
                    imagePorte2.Source = imgPorteOuverte;
                    break;

                case 3:
                    imagePorte3.Source = imgPorteOuverte;
                    break;
            }

            if (nunporte == portedragon)
            {
                trouve = true;


                switch (vie)
                {
                    case 1:
                        imagevies1.Source = null;

                        break;

                    case 2:
                        imagevies2.Source = null;

                        break;

                    case 3:
                        imagevies3.Source = null;

                        break;
                }

                vie = vie - 1;
                Window windragon = new windows.WindowDragon();  //instancier la nouvelle fenetre du nom de windragon cree dans le nouveau repertoire windows
                                                                // window devant =systeme windows 
                windragon.ShowDialog();  // showdialog signifie que la fenetre va etre independante on doit la fermer pourque lae programme prendre la main
            }
                        if(nunporte ==porteprincesse)
                {
                    trouve = true;
                    succes = succes + 1;

                    Window winPrincesse = new  windows.WindowPrincesse();
                    winPrincesse.ShowDialog();
                    

                }

                if (succes == 3) // le joueur a gagne


                {
                applaudissement.Play();


                    MessageBox.Show("vous avez gagne", "Gagne", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                if (vie == 0) // le joueur a perdu

                {
                rire.Play();

                    MessageBox.Show("vous avez perdu", "Perdu", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                if(succes<3 & vie>0 & trouve==true)
                {
                    ResetPortes();
                }

                    }

            

        private void imagePorte1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OuvrirPorte(1);

        }

        private void imagePorte2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OuvrirPorte(2);
        }

        private void imagePorte3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OuvrirPorte(3);

        }
    }

    }
        
          
 
    

