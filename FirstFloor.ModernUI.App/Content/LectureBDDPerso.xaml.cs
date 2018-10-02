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
    public partial class LectureBDDPerso : UserControl, IContent
    {


        public LectureBDDPerso()
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
            command.CommandText = "SELECT * from personnel";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string matricule = "";
            string nom = "";
            string prenom = "";
            string sexe = "";
            string fonction = "";

            personnel.Text = "matricule | nom | prénom | sexe | fonction";
            while (reader.Read())
            {
                fonction = reader.GetString(0);
                matricule = reader.GetString(1);
                nom = reader.GetString(2);
                prenom = reader.GetString(3);
                sexe = reader.GetString(4);
                string texte = "\n" + matricule + " | " + nom + " | " + prenom + " | " + sexe + " | " + fonction;
                personnel.Text += texte;
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
            command.CommandText = "SELECT * from personnel";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string matricule = "";
            string nom = "";
            string prenom = "";
            string sexe = "";
            string fonction = "";

            personnel.Text = "matricule | nom | prénom | sexe | fonction";
            while (reader.Read())
            {
                fonction = reader.GetString(0);
                matricule = reader.GetString(1);
                nom = reader.GetString(2);
                prenom = reader.GetString(3);
                sexe = reader.GetString(4);
                string texte = "\n" + matricule + " | " + nom + " | " + prenom + " | " + sexe + " | " + fonction;
                personnel.Text += texte;
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
            
        }

        public void OnNavigatedTo(Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
        }
    }
}
