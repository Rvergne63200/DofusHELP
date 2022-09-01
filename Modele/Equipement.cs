using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Equipement
    {
        public string NomEquip { get; private set; }
        public TypeEquipement TypeEquip { get; private set; }
        public List<Caracs> ListBonus { get; private set; }

        /// <summary>
        /// Contient le chemin vers l'image de l'equipement
        /// </summary>
        public string ImageEquip { get; private set; }

        /// <summary>
        /// Constructeur de la classe Equipement ( détermine son nom, son type, 
        /// ainsi que l'ensemble des caracs qu'il donne a son porteur
        /// </summary>
        /// <param name="nom">Nom de l'Equipement</param>
        /// <param name="type">Type d'Equipement</param>
        /// <param name="listBon">Liste de Caracs correspondant aux bonus qu'il donne</param>
        public Equipement(string nom, TypeEquipement type, string image,params Caracs[] listBon)
        {
            NomEquip = nom;
            TypeEquip = type;

            ListBonus = new List<Caracs>();

            ImageEquip = image;
            
            if(listBon != null)
                foreach(Caracs b in listBon)
                {
                    try
                    {
                        AjouterBonus(b);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
        }


        public Equipement(string nom, TypeEquipement type, params Caracs[] listBon)
        {
            NomEquip = nom;
            TypeEquip = type;

            ListBonus = new List<Caracs>();

            if (listBon != null)
                foreach (Caracs b in listBon)
                {
                    try
                    {
                        AjouterBonus(b);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
        }


        /// <summary>
        /// Permet d'ajouter des bonus supplémentaire à l'Equipement en question (ce qui permet à l'utilisateur d'ajouter
        /// des stats supplémentaires à l'Equipement, correspond à la forgemagie en jeu)
        /// </summary>
        /// <param name="c">Caractéristique que l'on veut ajouter</param>
        public void AjouterBonus(Caracs c)
        {

            if (c.Value == 0 || c.Value > 10000 || c.Value < -10000)
            {
                return;
            }

            ListBonus.Add(c);
        }


        /// <summary>
        /// Fonction qui retourne le détail de l'Equipement sous forme d'un String
        /// </summary>
        /// <returns>Detail de l'Equipement</returns>
        public override string ToString()
        {
            return $"{NomEquip} : {TypeEquip} ({ListBonus})";
        }

    }
}
