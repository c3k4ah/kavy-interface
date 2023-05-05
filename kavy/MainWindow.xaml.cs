using System.Data;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;


namespace kavy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TextBlock> textBlocks = new List<TextBlock>();
        public MainWindow()
        {
            InitializeComponent();
            AddTextBlocks();
            textList.ItemsSource = textBlocks;
            FindallClients();
        }
        private void AddTextBlocks()
        {
            for (int i = 0; i < 5; i++)
            {
                textBlocks.Add(new TextBlock { Text = $"TextBlock {i + 1}" });
            }
        }

        // ========================= BACKEND IMPLEMENTATIONS ========================
        // ********** clients **********
        private int clientId {get; set;}
        private string nomClient {get; set;}


        private void Message_txtChange(object sender, TextChangedEventArgs e)
        {
            nomClient = SendEventMessage.Text;
        }
        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            // Création de la nouvelle fenêtre
            var loginPage = new LoginWindow();

            // Affichage de la nouvelle fenêtre
            loginPage.Show();

            // Fermeture de la fenêtre actuelle
            this.Close();

        }
        public void CreateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Create(this.nomClient);
            SendEventMessage.Clear();
            FindallClients();
        }

        public void FindallClients() {
            Clients clients = new Clients();
            messageList.ItemsSource = clients.Findall();
            
        }

        public Dictionary<string, object> FindoneClients() {
            Clients clients = new Clients();
            return clients.Findone(this.clientId);
        }

        public void UpdateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Update(this.nomClient, this.clientId);
        }

        public void DeleteClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Delete(this.clientId);
        }

        // ******************** archives ********************
        private int archiveId {get; set;}
        private string titreArchive {get; set;}
        private string descriptionArchive {get; set;}
        private int listeIdArchive {get; set;}
        private string searchArchive {get; set;}

        public void CreateArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Create(this.titreArchive, this.descriptionArchive, this.listeIdArchive);
        }

        public List<Dictionary<string, object>> FindallArchives() {
            Archives archives = new Archives();
            return archives.Findall();
        }

        public Dictionary<string, object> FindoneArchives() {
            Archives archives = new Archives();
            return archives.Findone(this.archiveId);
        }

        public List<Dictionary<string, object>> FindByListeIdArchives() {
            Archives archives = new Archives();
            return archives.FindByListeId(this.listeIdArchive);
        }

        public List<Dictionary<string, object>> FindByClientIdArchives() {
            Archives archives = new Archives();
            return archives.FindByClientId(this.clientId);
        }

        public List<Dictionary<string, object>> FiltreArchives() {
            Archives archives = new Archives();
            return archives.Filtre(this.searchArchive);
        }

        public void UpdateArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Update(this.titreArchive, this.descriptionArchive, this.archiveId);
        }

        public void DeleteArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Delete(this.archiveId);
        }
        // ***********************************
    }
}
