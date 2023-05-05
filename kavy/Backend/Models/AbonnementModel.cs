using System;

namespace kavy.Backend.Models {
    public class AbonnementModel {
        public int id {get; set;}
        public int clientId {get; set;}
        public string nomClient {get; set;}
        public int listeId {get; set;}
        public string nomListe {get; set;}
        public DateTime createdAt { get; set; }
    }
}
