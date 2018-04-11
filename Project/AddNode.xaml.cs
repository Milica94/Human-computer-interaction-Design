using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for AddNode.xaml
    /// </summary>
    public partial class AddNode : Window
    {
        
        public AddNode()
        {
            InitializeComponent();
            foreach (Type tp in Serialization.types)
            {
                comboBox1.Items.Add(tp);
            }
        }
        private void zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void spremi(object sender, RoutedEventArgs e)
        {

            bool result = true;
            //id
            if (textBox1.Text.Trim().Equals(""))
            {
                result = false;
                textBox1.BorderBrush = Brushes.Red;
                textBox1.BorderThickness = new Thickness(1);
            }

            //ime 
            if (textBox2.Text.Trim().Equals(""))
            {
                result = false;
                textBox2.BorderBrush = Brushes.Red;
                textBox2.BorderThickness = new Thickness(1);
            }
            //opis
            if (textBox3.Text.Trim().Equals(""))
            {
                result = false;
                textBox3.BorderBrush = Brushes.Red;
                textBox3.BorderThickness = new Thickness(1);
            }



            if (result)
            {
                Node b = new Node(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), comboBox1.SelectedItem as Type); //ovo sam dodala
                Serialization.nodes.Add(b);
                MainWindow.nodes.Add(b);
                this.Close();
              
            }
            else
            {
                MediaPlayer mplayer = new MediaPlayer();

                mplayer.Open(new Uri(@"../../sound/Lisa - D'oh!.wav", UriKind.Relative));

                mplayer.Play();
                MessageBox.Show("Podaci nisu dobro uneseni.", "Greska", MessageBoxButton.OK);
            }
        }

        private void removeBorder(object sender, RoutedEventArgs e)
        {
            textBox1.BorderThickness = new Thickness(0);
        }

        private void removeBorder2(object sender, RoutedEventArgs e)
        {
            textBox2.BorderThickness = new Thickness(0);
        }
        private void removeBorder3(object sender, RoutedEventArgs e)
        {
            textBox3.BorderThickness = new Thickness(0);
        }

    }
}
/*unos, izmena, brisanje i tabelarni prikaz objekta pod monitoringom*/