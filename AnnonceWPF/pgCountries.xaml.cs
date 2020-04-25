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
using System.Collections.ObjectModel;
using AnnonceBDD;

namespace AnnonceWPF
{
    /// <summary>
    /// Logique d'interaction pour pgCountries.xaml
    /// </summary>
    public partial class pgCountries : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;

        public pgCountries()
        {
            InitializeComponent();
            grpListePays.DataContext = BDD.countries;
        }

        private void AjouterPays(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvPays.SelectedItem = BDD.AddCountry("Nouveau pays", "Préfixe", "+32"); }, nameof(AjouterPays));
        }

        private void SupprimerPays(object sender, RoutedEventArgs e)
        {
            Country selection = (Country)lvPays.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer {selection.NameCountry} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveCountry(selection); }, nameof(SupprimerPays));
                }
            }
        }
    }
}
