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
using System.IO;
using Microsoft.Win32;
using FirstFloor.ModernUI.App.Classes;

namespace FirstFloor.ModernUI.App.Pages
{
    /// <summary>
    /// Interaction logic for Introduction.xaml
    /// </summary>
    public partial class Introduction : UserControl
    {
        public Introduction()
        {
            InitializeComponent();
        }

        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichier CSV (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                string adresse = saveFileDialog.FileName;
                Administration.SauvegarderFichier(adresse);
                Infos.Text = "Sauvegardé à l'adresse: " + adresse;
            }
        }

        private void ChargementCSV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichier CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string adresse = openFileDialog.FileName;
                try
                {
                    Administration.CSVToAdmin(Program.LectureFichier(adresse));
                    Infos.Text = "Fichier chargé: " + adresse;
                }
                catch
                {
                    MessageBoxResult result = MessageBox.Show("Veuillez verifier votre fichier", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
