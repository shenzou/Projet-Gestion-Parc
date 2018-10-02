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
using MySql.Data.MySqlClient;
using FirstFloor.ModernUI.Windows;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for LoremIpsum.xaml
    /// </summary>
    public partial class LectureBDDAttract : UserControl, IContent
    {
        

        public LectureBDDAttract()
        {
            InitializeComponent();
            string connectionString = "SERVER=35.195.241.250; PORT=3306; DATABASE=zombillenium; UID=root; PASSWORD=abcd1234;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Base de données inaccessible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * from attraction";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string besoinSpecifique = "";
            string dureeMaintenance = "";
            string ID = "";
            string maintenance = "";
            string natureMaintenance = "";
            string nbMinMonstre = "";
            string nom = "";
            string ouvert = "";
            string typeDeBesoin = "";

            attraction.Text = "Nom | ID | Ouvert | Besoin Spécifique | Maintenance | Durée de maintenance | Nature maintenance | Min Monstres | Type de besoin";
            while (reader.Read())
            {
                try { besoinSpecifique = reader.GetString(0); } catch { }
                try { dureeMaintenance = reader.GetString(1); } catch { }
                try { ID = reader.GetString(2); } catch { }
                try { maintenance = reader.GetString(3); } catch { }
                try { natureMaintenance = reader.GetString(4); } catch { }
                try { nbMinMonstre = reader.GetString(5); } catch { }
                try { nom = reader.GetString(6); } catch { }
                try { ouvert = reader.GetString(7); } catch { }
                try { typeDeBesoin = reader.GetString(8); } catch { }
                string texte = "\n" + nom + " | " + ID + " | " + ouvert + " | " + besoinSpecifique + " | " + maintenance + " | " + dureeMaintenance + " | " + natureMaintenance + " | " + nbMinMonstre + " | " + typeDeBesoin;
                attraction.Text += texte;
                //Console.WriteLine(texte);
            }
            connection.Close();
            progbar.Visibility = Visibility.Hidden;

        }

        public void Refresh()
        {
            progbar.Visibility = Visibility.Visible;
            string connectionString = "SERVER=35.195.241.250; PORT=3306; DATABASE=zombillenium; UID=root; PASSWORD=abcd1234;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Base de données inaccessible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * from attraction";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string besoinSpecifique = "";
            string dureeMaintenance = "";
            string ID = "";
            string maintenance = "";
            string natureMaintenance = "";
            string nbMinMonstre = "";
            string nom = "";
            string ouvert = "";
            string typeDeBesoin = "";

            attraction.Text = "Nom | ID | Ouvert | Besoin Spécifique | Maintenance | Durée de maintenance | Nature maintenance | Min Monstres | Type de besoin";
            while (reader.Read())
            {
                try { besoinSpecifique = reader.GetString(0); } catch { }
                try { dureeMaintenance = reader.GetString(1); } catch { }
                try { ID = reader.GetString(2); } catch { }
                try { maintenance = reader.GetString(3); } catch { }
                try { natureMaintenance = reader.GetString(4); } catch { }
                try { nbMinMonstre = reader.GetString(5); } catch { }
                try { nom = reader.GetString(6); } catch { }
                try { ouvert = reader.GetString(7); } catch { }
                try { typeDeBesoin = reader.GetString(8); } catch { }

                string texte = "\n" + nom + " | " + ID + " | " + ouvert + " | " + besoinSpecifique + " | " + maintenance + " | " + dureeMaintenance + " | " + natureMaintenance + " | " + nbMinMonstre + " | " + typeDeBesoin;
                attraction.Text += texte;
                //Console.WriteLine(texte);
            }
            connection.Close();
            progbar.Visibility = Visibility.Hidden;
        }
        public void OnFragmentNavigation(Windows.Navigation.FragmentNavigationEventArgs e)
        {
            
        }

        public void OnNavigatedFrom(Windows.Navigation.NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(Windows.Navigation.NavigationEventArgs e)
        {
           
        }

        public void OnNavigatingFrom(Windows.Navigation.NavigatingCancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
