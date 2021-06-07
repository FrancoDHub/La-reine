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
using System.Windows.Shapes;

namespace lafille.windows
{
    /// <summary>
    /// Logique d'interaction pour WindowDragon.xaml
    /// </summary>
    public partial class WindowDragon : Window
    {
        private System.Media.SoundPlayer monster = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + @"\lessons\monster.wav");

        public WindowDragon()
        {
            InitializeComponent();
            monster.Play();

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }
    }
}
