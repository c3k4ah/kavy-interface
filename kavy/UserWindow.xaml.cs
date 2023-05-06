using kavy.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kavy
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {

            InitializeComponent();
            FindallListes();
        }
        // ******************** ARCHIVES ********************
        private int archiveId { get; set; }
        private string contentArchive { get; set; }
        private int listeIdArchive { get; set; }
        private int clientId { get; set; }
        private int adminIdArchive { get; set; }
        private string searchArchive { get; set; }


      
        public void LogOut(object sender, RoutedEventArgs e)
        {
            // Création de la nouvelle fenêtre
            var loginPage = new LoginWindow();

            // Affichage de la nouvelle fenêtre
            loginPage.Show();

            // Fermeture de la fenêtre actuelle
            this.Close();
        }
        public void FindallArchives()
        {
            Archives archives = new Archives();
            archives.Find();
        }


        private void UpdateArchiveClick(object sender, RoutedEventArgs e)
        {

            ListeModel selectedArchive = eventListe.SelectedItem as ListeModel;
            Console.WriteLine("atooo ah!!");
            if (selectedArchive != null)
            {
                this.archiveId = selectedArchive.id;
             
                this.FindByListeIdArchives();

            }
        }

        public void FindByListeIdArchives()
        {
            MemoryCache cache = MemoryCache.Default;
            this.adminIdArchive = int.Parse(cache.Get("adminId") as string ?? "1");
            Archives archives = new Archives();
            messageList.ItemsSource = archives.FindByListeId(this.archiveId);
        }

        public void FindByClientIdArchives()
        {

            Archives archives = new Archives();
            archives.FindByClientId(this.clientId);
        }

       

        // ************** LISTES **************
        private int listeId { get; set; }
        private string nomListe { get; set; }

       

        public void FindallListes()
        {
            Listes listes = new Listes();
            eventListe.ItemsSource = listes.Find();
        }

        public void FindoneListes()
        {
            Listes listes = new Listes();
            listes.Find(this.listeId);
        }

    }
}
