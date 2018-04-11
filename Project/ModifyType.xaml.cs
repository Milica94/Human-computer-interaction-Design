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
    /// Interaction logic for ModifyType.xaml
    /// </summary>
    public partial class ModifyType : Window
    {
        private Type _type { get; set; }
        private string Slika { get; set; }
        public ModifyType()
        {
            InitializeComponent();
        }
            public ModifyType(Type par1)
        {
            
            InitializeComponent();

            _type = par1;
            
            textBox1.Text =String.Format("{0}", par1.ID);
            
            textBox2.Text = String.Format("{0}", par1.ime);
            textBox3.Text = String.Format("{0}", par1.max_br);

                 BitmapImage nesto1 = new BitmapImage();
                 nesto1.BeginInit();
                 nesto1.UriSource = new Uri(par1.Slika);
                 nesto1.EndInit();
                 image1.Source = nesto1;
                 Slika = nesto1.UriSource.ToString();

        }
      
      
        private void zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sacuvaj(object sender, RoutedEventArgs e)
        {

            if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals(""))
            {

                _type.ime = textBox2.Text.Trim();
                _type.max_br = Int32.Parse(textBox3.Text.Trim());
                _type.Slika = image1.Source.ToString();

                Serialization.types.Remove(_type);
                Serialization.types.Add(_type);

                this.Close();
            }
         

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
      
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                BitmapImage nesto = new BitmapImage();
                nesto.BeginInit();
                nesto.UriSource = new Uri(filename);
                nesto.EndInit();
                image1.Source = nesto;
            }
        }
        
      
    }
}
