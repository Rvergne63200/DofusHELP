using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Sort : IEquatable<Sort>
    {
        public string NomSort
        {
            get
            {
                return nomSort;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Ne peut pas être null");
                }

                nomSort = value;
            }
        }
        private string nomSort;

        public string DescriptionSort
        {
            get
            {
                return descriptionSort;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                   throw new Exception("Ne peut pas être null");
                }

                descriptionSort = value;
            }
        }
        private string descriptionSort;


        /// <summary>
        /// Contient le chemin vers l'icone du sort
        /// </summary>
        public string IconeSort { get; private set; }

        /// <summary>
        /// Constructeur de la classe Sort, permet de définir le nom et la description du sort
        /// </summary>
        /// <param name="s">Nom du sort</param>
        /// <param name="des">Description du sort</param>
        public Sort(string s, string des, string icone)
        {
            NomSort = s;
            DescriptionSort = des;
            IconeSort = icone;
        }

        public Sort(string s, string des)
        {
            NomSort = s;
            DescriptionSort = des;
        }

        /// <summary>
        /// Protocole d'égalité permettant de définir deux sorts Egaux à partir du moment ou leur nom est identique
        /// </summary>
        /// <param name="right"></param>
        /// <returns>Resultat de l'Egalité</returns>
        public override bool Equals(object right)
        {
            if(object.ReferenceEquals(right, null))
            {
                return false;
            }

            if(object.ReferenceEquals(this, right))
            {
                return true;
            }

            if(this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Sort);
        }

        public bool Equals(Sort other)
        {
            return (this.NomSort.Equals(other.NomSort));
        }

        /// <summary>
        /// Fonction qui permet de connaitre le HashCode de l'objet
        /// </summary>
        /// <returns>HashCode de l'objet en question</returns>
        public override int GetHashCode()
        {
            return NomSort.GetHashCode();
        }

        /// <summary>
        /// Permet de convertir un sort en une chaine de caractère contenant les details sur le sort
        /// </summary>
        /// <returns>Details du sort en String</returns>
        public override string ToString()
        {
            return $"{NomSort} : {DescriptionSort}";
        }
    }
}
