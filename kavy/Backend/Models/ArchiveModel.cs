using System;

namespace kavy.Backend.Models {
    public class ArchiveModel {
        public int id {get; set;}
        public string content {get; set;}
        public int listeId {get; set;}
        public string nomListe {get; set;}
        public int adminId {get; set;}
        public string nomAdmin {get; set;} 
        public DateTime createdAt {get; set;}
    }
}