using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Classe c = new Classe("Ecaflip", "UN CHAT !", new List<Sort> {
                new Sort("Coup de patte","DONNE UN COUP DE PATTE"),
                new Sort("sortInsfjsoj", "Hqhuej")
            }
            );

            Personnage p = new Personnage(c);
            Equipement e = new Equipement("Anneau de Boursoufle", TypeEquipement.Anneau,
                new Caracs(NomCarac.PA, 1),
                new Caracs(NomCarac.Vitalite, 100)
                );

            p.Equiper(e);

            e = new Equipement("Coiffe bleue", TypeEquipement.Chapeau,
                new Caracs(NomCarac.Chance, 100)
                );

            p.Equiper(e);

            e = new Equipement("Anneau de Bourse", TypeEquipement.Anneau,
                new Caracs(NomCarac.PA, 1),
                new Caracs(NomCarac.Vitalite, 100)
                );

            p.Equiper(e);

            e = new Equipement("Anneau de Truc", TypeEquipement.Anneau,
                new Caracs(NomCarac.PA, 1),
                new Caracs(NomCarac.Vitalite, 100)
                );

            p.Equiper(e);

            p.AffichStuff();

            p.AjouterPointsCaracteristiques(NomCarac.Vitalite, 50);

            p.ListerCarac();
            Console.WriteLine(p);
        }
    }
}
