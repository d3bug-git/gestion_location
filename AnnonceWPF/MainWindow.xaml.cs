using AnnonceBDD;
using MahApps.Metro.IconPacks;
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

namespace AnnonceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BDDSingleton BDD = BDDSingleton.Instance;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            //Affichage d'un cadre par défaut.
            //Cadre.NavigationService.Navigate(new pgAdverts());
        }
        #region Méthodes liées au Menu du haut de la fenêtre
        //private void AfficherAnnonces(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgAdverts()); }
        private void SauvegarderModifications(object sender, RoutedEventArgs e)
        {
            //BDD.SauvegarderModifications();
            MessageBox.Show("Modifications sauvegardées dans la base de données.", "Sauvegarde des modifications", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Quitter(object sender, RoutedEventArgs e) { this.Close(); }
        private void BasculerState(object sender, RoutedEventArgs e)
        {
            if (this.WindowState.Equals(WindowState.Maximized))
            {     
                this.WindowState = WindowState.Normal;
                this.WindowStateIcon.Kind=PackIconModernKind.WindowMaximize;

            }
            else
            {
                this.WindowState = WindowState.Maximized;
                this.WindowStateIcon.Kind = PackIconModernKind.WindowMinimize;
            }
        }
        private void Normal(object sender, RoutedEventArgs e) { this.WindowState = WindowState.Normal; }
        private void Mininiser(object sender, RoutedEventArgs e) { this.WindowState = WindowState.Minimized; }
        #endregion

        private void NavServiceOnNavigated(object sender, NavigationEventArgs e) { while (Cadre.NavigationService.RemoveBackEntry() != null) ; }
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BDD.ModificationsEnAttente)
            {
                if (MessageBox.Show("Il y a des modifications en attente voulez vous les sauvegarder avant de quitter ?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    if (MessageBox.Show("La fermeture de l'application va entrainer la perte des modifications non sauvegardées dans la base de données. Etes-vous sûr de vouloir fermer l'application?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else { BDD.SauvegarderModifications(); }
        }
    }
}
}
