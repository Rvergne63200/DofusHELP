using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Classe
    {
        public string NomClasse
        {
            get
            {
                return nomClasse;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Ne peut pas être null");
                }

                nomClasse = value;
            }
        }
        private string nomClasse;

        public string DescriptionClasse
        {
            get
            {
                return descriptionClasse;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Ne peut pas être null");
                }

                descriptionClasse = value;
            }
        }
        private string descriptionClasse;

        public List<Sort> ListSort { get; private set; }

        /// <summary>
        /// Contient le chemin vers l'icone de classe
        /// </summary>
        public string IconeClasse { get; private set; }

        /// <summary>
        /// Contient le chemin vers l'image perso de la classe
        /// </summary>
        public string ImagePersoClasse { get; private set; }

        /// <summary>
        /// Constructeur de la classe Classe (Détermine son nom, sa description et crée sa liste de sorts)
        /// </summary>
        /// <param name="nom">Nom voulu pour la classe</param>
        /// <param name="description">Description voulue pour la classe</param>
        /// <param name="sort">Liste des sorts que la classe contient</param>
        public Classe(string nom, string description, List<Sort> sort)
        {
            NomClasse = nom;
            DescriptionClasse = description;
            ListSort = new List<Sort>();

            if (sort != null)
            {
                foreach (Sort s in sort)
                {
                    try
                    {
                        AjouterSort(s);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }

        }


        /// <summary>
        /// Constructeur de la classe Classe (Détermine son nom, sa description et crée sa liste de sorts)
        /// </summary>
        /// <param name="nom">Nom voulu pour la classe</param>
        /// <param name="description">Description voulue pour la classe</param>
        /// <param name="sort">Liste des sorts que la classe contient</param>
        public Classe(string nom, string description, List<Sort> sort, string icone, string image)
        {
            NomClasse = nom;
            DescriptionClasse = description;
            ListSort = new List<Sort>();

            IconeClasse = icone;
            ImagePersoClasse = image;

            if(sort != null)
            {
                foreach (Sort s in sort)
                {
                    try
                    {
                        AjouterSort(s);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }

        }

        /// <summary>
        /// Permet d'ajouter un sort à la liste de sorts de la classe (a condition que le nom soit différent des autres sorts)
        /// </summary>
        /// <param name="ajSort">Sort que l'on veut ajouter</param>
        public void AjouterSort(Sort ajSort)
        {
            if (ListSort.Contains(ajSort))
            {
                return;
            }

            ListSort.Add(ajSort);
        }

        /// <summary>
        /// Permet de traduire la classe sous une forme textuel en String
        /// </summary>
        /// <returns>Détail d'une classe</returns>
        public override string ToString()
        {
            return $"{NomClasse} : {DescriptionClasse}";
        }
    }
}
