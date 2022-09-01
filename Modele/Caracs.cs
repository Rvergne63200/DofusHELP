using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Caracs
    {
        public NomCarac NomCarac { get; set; }
        public int Value { get; set; }
        public string Details { get; set; }

        /// <summary>
        /// Constructeur à 2 paramètre d'un Caractéristique définissant son nom et sa valeur
        /// </summary>
        /// <param name="n">Nom de la caractéristique</param>
        /// <param name="val">Valeur de la caractéristique</param>
        public Caracs(NomCarac n, int val)
        {
            NomCarac = n;
            Value = val;
        }

        /// <summary>
        /// Constructeur à 3 paramètre d'un Caractéristique définissant son nom, sa valeur et son detail
        /// </summary>
        /// <param name="n">Nom de la caractéristiue</param>
        /// <param name="val">Valeur de la caractéristique</param>
        /// <param name="det">Detail sur la caractéristique</param>
        public Caracs(NomCarac n, int val,  string det)
        {
            NomCarac = n;
            Value = val;
            Details = det;
        }


        /// <summary>
        /// Methode qui permet de convertire en String les informations sur une caractéristique
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{NomCarac}: {Value}";
        }
    }
}
