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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;



namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int numCnt { get; set; }
        public static List<Type> mojaLista = new List<Type>();
        public static   List<Node> mojaLista1 = new List<Node>();
        public static BindingList<Type> types { get; set; }
        public static BindingList<Node> nodes { get; set; }


        private Serialization serializer = new Serialization();

        public MainWindow()
        {
            MediaPlayer mplayer = new MediaPlayer();

            mplayer.Open(new Uri(@"../../sound/ide zmija.mp3", UriKind.Relative));

            mplayer.Play();

            InitializeComponent();

           numCnt = 0;
           
           types = serializer.DeSerializeObject<BindingList<Type>>("tipovibind.xml");
           DataContext = this;
           Serialization.types = serializer.DeSerializeObject<List<Type>>("tipovilist.xml");
           if (Serialization.types == null)
               Serialization.types = new List<Type>();
           if (types == null)
               types = new BindingList<Type>();

           nodes = serializer.DeSerializeObject<BindingList<Node>>("cvorovibind.xml");
           DataContext = this;
           Serialization.nodes = serializer.DeSerializeObject<List<Node>>("cvorovilist.xml");
           if (Serialization.nodes == null)
               Serialization.nodes = new List<Node>();
           if (nodes == null)
               nodes = new BindingList<Node>();

           
        }

        //TABELA TIP----------------------------------------------------------------------------------------------

        private void addNew(object sender, RoutedEventArgs e)
        {
            numCnt++;
            AddType win = new AddType();
            win.Owner = this;
            win.ShowDialog();

        }


        private void removeSelected(object sender, RoutedEventArgs e)
        {

            if (dataGrid1.SelectedItem != null)
            {
               
                Type row = (Type)dataGrid1.SelectedItems[0];
                string type_id=row.ID;

              
                int sel1 = 0;
                sel1 = dataGrid1.SelectedIndex;

                Serialization.types.RemoveAt(sel1);

                types.RemoveAt(sel1);

                foreach(Node c1 in nodes)
                {
                    mojaLista1.Add(c1);
                }
                foreach (Node c2 in mojaLista1)
                {
                    if (type_id == c2.type.ID)
                    {
                        dataGrid2.SelectedItem = c2;
                        sel1 = dataGrid2.SelectedIndex;
                        nodes.RemoveAt(sel1);
                        Serialization.nodes.RemoveAt(sel1);
                    }
                }
                
            
            MediaPlayer mplayer = new MediaPlayer();

            mplayer.Open(new Uri(@"../../sound/Nooooo.mp3", UriKind.Relative));

            mplayer.Play();
        }
    }
        private void izmeni(object sender, RoutedEventArgs e)
        {

            if (dataGrid1.SelectedItem != null)
            {

                ModifyType win1 = new ModifyType(dataGrid1.SelectedItem as Type);

                win1.ShowDialog();
                dataGrid1.Items.Refresh();

                dataGrid1.SelectedItem = null;
            }
         
        }

        // TABELA cvor ------------------------------------------------------------------------------------------------------
        
        private void addNew1(object sender, RoutedEventArgs e)
        {
            numCnt++;
            AddNode win3 = new AddNode();
            win3.Owner = this;
            win3.ShowDialog();


        }

       /* private void generiseColumn1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            //Podesavanje sirine poslednje kolone, kako se ne bi pojavila prazna kolona
            if (colNum == 3)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }*/

        //brisanje za drugu tabelu
        private void removeSelected1(object sender, RoutedEventArgs e)
        {
            
                if (dataGrid2.SelectedItem != null)
                {
                    int sel = 0;
                    sel = dataGrid2.SelectedIndex;

                    Serialization.nodes.RemoveAt(sel);
                    nodes.RemoveAt(sel);



                 /*   int sel1 = 0;
                    sel1 = dataGrid1.SelectedIndex;

                    S.types.RemoveAt(sel1);
                    types.RemoveAt(sel1);(*/
                }
                MediaPlayer mplayer = new MediaPlayer();

                mplayer.Open(new Uri(@"../../sound/Nooooo.mp3", UriKind.Relative));

                mplayer.Play();
                
            
          
        }
        private void izmeni1(object sender, RoutedEventArgs e)
        {

            if (dataGrid2.SelectedItem != null)
            {

                ModifyNode win4 = new ModifyNode(dataGrid2.SelectedItem as Node);

                win4.ShowDialog();
                dataGrid2.Items.Refresh();

                dataGrid2.SelectedItem = null;
            }

        }

    
            private void sacuvaj(object sender, EventArgs e)
        {
            serializer.SerializeObject<BindingList<Type>>(types, "tipovibind.xml");
            serializer.SerializeObject<BindingList<Node>>(nodes, "cvorovibind.xml");
            serializer.SerializeObject<List<Type>>(Serialization.types, "tipovilist.xml");
            serializer.SerializeObject<List<Node>>(Serialization.nodes, "cvorovilist.xml");
        }
      


    }

}