-- Active: 1683225659831@@localhost@3137@KAVY
CREATE DATABASE KAVY;

USE KAVY;

CREATE TABLE IF NOT EXISTS clients(
    id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS listes(
    id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS abonnements(
    id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    client_id INT NOT NULL,
    liste_id INT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL,
    CONSTRAINT fk_client_id_abonnements FOREIGN KEY(client_id)
        REFERENCES clients(id),
    CONSTRAINT fk_liste_id_abonnements FOREIGN KEY(liste_id)
        REFERENCES listes(id)
);

CREATE TABLE IF NOT EXISTS archives(
    id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    titre VARCHAR(255),
    description TEXT,
    liste_id INT NOT NULL,
    CONSTRAINT fk_liste_id_archives FOREIGN KEY(liste_id)
        REFERENCES listes(id)
);