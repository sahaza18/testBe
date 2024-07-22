using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LogiCivilApp.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
        }

        public Utilisateur(string idUtilisateur, string nom, string prenom, DateOnly dateNaissance, int genre, string? telephone, string? adresse, string mail, string password, DateOnly dateInscription, int idProfil, int etat)
        {
            IdUtilisateur = idUtilisateur;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Genre = genre;
            Telephone = telephone;
            Adresse = adresse;
            Mail = mail;
            Password = password;
            DateInscription = dateInscription;
            IdProfil = idProfil;
            Etat = etat;
        }


        public static string? hashPassword(string password)
        {
            if (password == null)
            {
                return null;
            }
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }


        public Utilisateur authentification (LogicivilContext dbContext)
        {
            Utilisateur? result = null;
            result = dbContext.Utilisateurs.Where(u => u.Mail == this.Mail && u.Password == Utilisateur.hashPassword(this.Password)).FirstOrDefault();

            if (result == null)
            {
                throw new Exception(" Identifiant ou password incorrect !!! ");
            }
            if (result.Etat == 0)
            {
                throw new Exception(" Votre Compte est actuelemnt désactivée !!! ");
            }

            return result;
        }




    }
}
