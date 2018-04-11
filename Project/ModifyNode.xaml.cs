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
    /// Interaction logic for ModifyNode.xaml
    /// </summary>
    public partial class ModifyNode : Window
    {
        private Node node { get; set; }
        public ModifyNode()
        {
            InitializeComponent();
        }
        
        public ModifyNode(Node par2)
        {

            InitializeComponent();

            node = par2;

            textBox1.Text = par2.ID;

            textBox2.Text =par2.ime;
            textBox3.Text = par2.opis;

        }

        //Funkcija koja zatvara ovaj prozor
        private void zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sacuvaj1(object sender, RoutedEventArgs e)
        {

            if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals(""))
            {
                node.ime = textBox2.Text.Trim();
                node.opis = textBox3.Text.Trim();
                this.Close();
            }
          
        }

     

     
    }
}
