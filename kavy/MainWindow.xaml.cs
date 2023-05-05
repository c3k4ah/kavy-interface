using System;
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
            FindallArchives();
            FindallListes();
            FindallAbonnments();
        }
        private void AddTextBlocks()
        {
            for (int i = 0; i < 5; i++)
            {
                textBlocks.Add(new TextBlock { Text = $"TextBlock {i + 1}" });
            }
        }

        // ========================= BACKEND IMPLEMENTATIONS ========================
        // ************* CLIENTS *************
        private int clientId {get; set;}
        private string nomClient {get; set;}
        private string passwordClient {get; set;}


        private void Message_txtChange(object sender, TextChangedEventArgs e)
        {
            nomClient = SendEventMessage.Text;
        }
        
        public void CreateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Create(this.nomClient);
            this.FindallClients();
            SendEventMessage.Clear();
        }

        public void FindallClients() {
            Clients clients = new Clients();
            clients.Find();
        }

        public void FindoneClients() {
            Clients clients = new Clients();
            clients.Find(this.clientId);
        }

        public void UpdateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Update(this.nomClient, this.clientId);
            this.FindallClients();
        }

        public void UpdatePasswordClients() {
            Clients clients = new Clients();
            clients.UpdatePassword(this.passwordClient, this.clientId);
        }

        public void DeleteClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.Delete(this.clientId);
            this.FindallClients();
        }

        // ******************** ARCHIVES ********************
        private int archiveId {get; set;}
        private string contentArchive {get; set;}
        private int listeIdArchive {get; set;}
        private int adminIdAdmin {get; set;}
        private string searchArchive {get; set;}

        public void CreateArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Create(this.contentArchive, this.listeIdArchive, this.adminIdAdmin);
            this.FindallArchives();
        }

        public void FindallArchives() {
            Archives archives = new Archives();
            archives.Find();
        }

        public void FindoneArchives() {
            Archives archives = new Archives();
            archives.Find(this.archiveId);
        }

        public void FindByListeIdArchives() {
            Archives archives = new Archives();
            archives.FindByListeId(this.listeIdArchive);
        }

        public void FindByClientIdArchives() {
            Archives archives = new Archives();
            archives.FindByClientId(this.clientId);
        }

        public void FiltreArchives() {
            Archives archives = new Archives();
            archives.Filtre(this.searchArchive);
        }

        public void UpdateArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Update(this.contentArchive, this.archiveId);
            this.FindallArchives();
        }

        public void DeleteArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.Delete(this.archiveId);
            this.FindallArchives();
        }

        // ************** LISTES **************
        private int listeId {get; set;}
        private string nomListe {get; set;}

        public void CreateListes() {
            Listes listes = new Archives();
            listes.Create(this.nomListe);
            this.FindallListes();
        }

        public void FindallListes() {
            Listes listes = new Listes();
            listes.Find();
        }

        public void FindoneListes() {
            Listes listes = new Listes();
            listes.Find(this.listeId);
        }

        // **************** ABONNEMENTS ****************
        private int abonnementId {get; set;}
        private int listeIdAbonnement {get; set;}
        private int clientIdAbonnement {get; set;}

        public void createAbonnements() {
            Abonnements abonnements = new Abonnements();
            abonnements.Create(this.clientIdAbonnement, this.listeIdAbonnement);
            this.FindallAbonnments();
        }

        public void FindallAbonnments() {
            Abonnements abonnements = new Abonnements();
            abonnements.Find();
        }

        public void UpdateAbonnements() {
            Abonnements abonnements = new Abonnements();
            abonnements.Update(this.listeIdAbonnement, this.abonnementId);
            this.FindallAbonnments();
        }

        public void DeleteAbonnements() {
            Abonnements abonnements = new Abonnements();
            abonnements.Delete(this.abonnementId);
            this.FindallAbonnments();
        }

        // ************** ADMIN *************
        private int adminId {get; set;}
        private string nomAdmin {get; set;}
        private string passwordAdmin {get; set;}

        public void createAdmin() {
            Admin admin = new Admin();
            admin.Create(this.nomAdmin);
            this.FindallAdmin();
        }

        public void FindallAdmin() {
             Admin admin = new Admin();
            admin.Find();
        }

        public void FindoneAdmin() {
            Admin admin = new Admin();
            admin.Find(this.adminId);
        }

        public void UpdateAdmin() {
            Admin admin = new Admin();
            admin.Update(this.nomAdmin, this.adminId);
            this.FindallAdmin();
        }

        public void UpdatePasswordAdmin() {
            Admin admin = new Admin();
            admin.UpdatePassword(this.passwordAdmin, this.adminId);
            this.FindallAdmin();
        }

        public void DeleteAdmin() {
            Admin admin = new Admin();
            admin.Delete(this.adminId);
            this.FindallAdmin();
        }

        // **************** AUTH **************
        private string nomAuth;
        private string passwordAuth;

        public void AuthAdmin() {
            Auth auth = new Auth();
            int response = auth.Admin(this.nomAuth, this.passwordAuth);
            if(response > 0){
                Console.WriteLine("Correct !");
                this.adminId = response;
            }
            else Console.WriteLine("Incorrect !");
        }

        public void AuthClient() {
            Auth auth = new Auth();
            int response = auth.Client(this.nomAuth, this.passwordAuth);
            if(response > 0){
                Console.WriteLine("Correct !");
                this.clientId = response;
            }
            else Console.WriteLine("Incorrect !");
        }
    }
}
