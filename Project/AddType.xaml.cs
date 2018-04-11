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
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        public string Slika { get; set; }
        public AddType()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save(object sender, RoutedEventArgs e)
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
            //broj max
            if (textBox3.Text.Trim().Equals(""))
            {
                result = false;
                textBox3.BorderBrush = Brushes.Red;
                textBox3.BorderThickness = new Thickness(1);
            }
            int max_br = -1;
            try
            {
                max_br = Int32.Parse(textBox3.Text.Trim());
            }
            catch (Exception exc)
            {
                result = false;
                textBox3.BorderBrush = Brushes.Red;
                textBox3.BorderThickness = new Thickness(1);
            }

            if (result)
            {
                Type a = new Type(textBox1.Text.Trim(), textBox2.Text.Trim(), max_br, Slika);
                MainWindow.types.Add(a);
                Serialization.types.Add(a);
               // MainWindow.types.Add(a);
                //((MainWindow)this.Owner).dataGrid1.Items.Refresh();
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {
              
            
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

             
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // 
            if (result == true)
            {
                
                string filename = dlg.FileName;

                BitmapImage nesto = new BitmapImage();
                
                nesto.BeginInit();
                nesto.UriSource = new Uri(filename);
                nesto.EndInit();
                image1.Source = nesto;
                Slika = nesto.UriSource.ToString();
            }
        
        }



     

     
    }
}
