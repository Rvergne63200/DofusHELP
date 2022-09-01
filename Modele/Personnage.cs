using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modele
{
    public class Personnage
    {
        public Classe ClassePers { get; private set; } // Variable contenant la classe choisie par l'utilisateur
        public Dictionary<NomCarac, Caracs> CaracsPers { get; private set; } // Dictionary contenant toutes les caractéristiques du personnage avec le nom de la caractéristique en clé
        public int Niveau { get; private set; } // Niveau du personnage

        /// <summary>
        /// Dictionary qui prend comme clée la position à laquelle il correspond (chapeau, Amulette, Anneau1, Anneau2), 
        /// cela indique donc également ce que l'on peut mettre comme équipement, l'équipement est stocké en valeur
        /// </summary>
        public Dictionary<PosInventaire, Equipement> Stuff { get; private set; }


        /// <summary>
        /// Constructeur de la classe Personnage (détermine sa classe, ses caractéristiques et lui crée son inventaire d'équipements)
        /// </summary>
        /// <param name="classe">Classe du personnage que l'on instancie</param>
        public Personnage (Classe classe) 
        {
            ClassePers = classe;
            CaracsPers = new Dictionary<NomCarac, Caracs>() {
                [NomCarac.Vitalite] = new Caracs(NomCarac.Vitalite, 50, "unknown"),
                [NomCarac.Agilite] = new Caracs(NomCarac.Agilite, 0, "unknown"),
                [NomCarac.Intelligence] = new Caracs(NomCarac.Intelligence, 0, "unknown"),
                [NomCarac.Chance] = new Caracs(NomCarac.Chance, 0, "unknown"),
                [NomCarac.Force] = new Caracs(NomCarac.Force, 0, "unknown"),
                [NomCarac.Sagesse] = new Caracs(NomCarac.Sagesse, 0, "unknown"),
                [NomCarac.PA] = new Caracs(NomCarac.PA, 6, "unknown"),
                [NomCarac.PM] = new Caracs(NomCarac.PM, 3, "unknown"),
                [NomCarac.Invocation] = new Caracs(NomCarac.Invocation, 0, "unknown"),
                [NomCarac.PO] = new Caracs(NomCarac.PO, 0, "unknown"),
            };
            Stuff = new Dictionary<PosInventaire, Equipement>();

            ActualiserInventaire();
        }


        /// <summary>
        /// Methode permettant d'ajouter une nouvelle caractéristique au personnage (inutile pour le moment, 
        /// peut être lors d'une mise a jour si une caractéristique est ajoutée et que l'utilisateur a sauvegardé un personnage avant)
        /// </summary>
        /// <param name="car"></param>
        public void AjouterCarac(Caracs car)
        {
            if(!CaracsPers.ContainsKey(car.NomCarac))
                CaracsPers.Add(car.NomCarac, car);
        }


        /// <summary>
        /// Methode permettant de supprimer une caractéristique du personnage
        /// </summary>
        /// <param name="name">Nom de la caratéristique que l'on veut supprimer</param>
        public void SupprimerCarac(NomCarac name)
        {
            if(CaracsPers.ContainsKey(name))
                CaracsPers.Remove(name);
        }

        /// <summary>
        ///  Methode qui regarde toutes les positions d'inventaire possible et qui ajoutes les positions possibles que le personnage n'a 
        ///  pas (exemple mise a jour ou l'on ajoute une position d'inventaire, permet d'actualiser un personnage sauvegardé
        /// </summary>
        public void ActualiserInventaire()
        {
            foreach (PosInventaire p in (PosInventaire[])Enum.GetValues(typeof(PosInventaire)))
            {
                if (!Stuff.ContainsKey(p))
                {
                    try
                    {
                        Stuff.Add(p, null);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter des points à une caractéristique 
        /// </summary>
        /// <param name="carac">Caractéristique qu'e l'on cherche à modifier</param>
        /// <param name="nbPoints">Nombre de point que l'on veut ajouter</param>
        public void AjouterPointsCaracteristiques(NomCarac carac, int nbPoints)
        {
            if(!CaracsPers.TryGetValue(carac, out Caracs truc))
            {
                return;
            }

            CaracsPers[carac].Value += nbPoints;
        }

        /// <summary>
        /// Methode qui permet de déséquiper un équipement sur un personnage
        /// </summary>
        /// <param name="pos">Position de l'inventaire que l'on veut vider</param>
        public void DeEquiper(PosInventaire pos)
        {
            if(Stuff[pos] == null)
            {
                return;  
            }

            foreach (Caracs c in CaracsPers.Values)
            {
                foreach (Caracs b in Stuff[pos].ListBonus)
                {
                    if (b.NomCarac == c.NomCarac)
                    {
                        c.Value -= b.Value;
                    }
                }
            }

            Stuff[pos] = null;
        }

        static Dictionary<TypeEquipement, Func<Personnage, PosInventaire>> SelectPosEquip = new Dictionary<TypeEquipement, Func<Personnage, PosInventaire>>()
        {
            [TypeEquipement.Amulette] = p => PosInventaire.Amulette,
            [TypeEquipement.Anneau] = pers =>
                                    {
                                        var pos = PosInventaire.Anneau1;
                                        foreach (PosInventaire p in (PosInventaire[])Enum.GetValues(typeof(PosInventaire)))
                                        {
                                            if (p == PosInventaire.Anneau1 || p == PosInventaire.Anneau2)
                                            {
                                                if (pers.Stuff[p] == null)
                                                {
                                                    pos = p;
                                                }
                                            }
                                        }
                                        return pos;
                                    },
            [TypeEquipement.Arme] = p => PosInventaire.Arme,
            [TypeEquipement.Bottes] = p => PosInventaire.Bottes,
            [TypeEquipement.Bouclier] = p => PosInventaire.Bouclier,
            [TypeEquipement.Cape] = p => PosInventaire.Cape,
            [TypeEquipement.Ceinture] = p => PosInventaire.Ceinture,
            [TypeEquipement.Chapeau] = p => PosInventaire.Chapeau,
            [TypeEquipement.Familier] = p => PosInventaire.Familier,
            [TypeEquipement.Trophee] = pers =>
                                     {
                                         var pos = PosInventaire.Trophee1;
                                         foreach (PosInventaire p in (PosInventaire[])Enum.GetValues(typeof(PosInventaire)))
                                         {
                                             if (p == PosInventaire.Trophee1 || p == PosInventaire.Trophee2 || p == PosInventaire.Trophee3 || p == PosInventaire.Trophee4 || p == PosInventaire.Trophee5 || p == PosInventaire.Trophee6)
                                             {
                                                 if (pers.Stuff[p] == null)
                                                 {
                                                     pos = p;
                                                 }
                                             }
                                         }
                                         return pos;
                                     },
        };
        /// <summary>
        /// Cette méthode sélectionne un emplacement en fonction de l'équipement des des emplacements déjà pris, puis équipe l'équipement
        /// </summary>
        /// <param name="e">Equipement que l'on veut équiper</param>
        public void Equiper(Equipement e)
        {
            PosInventaire pos = SelectPosEquip[e.TypeEquip](this);

            if (Stuff[pos] != null)
            {
                DeEquiper(pos);
            }

            Stuff[pos] = e;

            try
            {
                foreach (Caracs c in CaracsPers.Values)
                {
                    foreach (Caracs b in Stuff[pos].ListBonus)
                    {
                        if (b.NomCarac == c.NomCarac)
                        {
                            c.Value += b.Value;
                        }
                    }
                }

            }catch(Exception err)
            {
                Debug.WriteLine(err.Message);
            }
                

        }

        /// <summary>
        /// Methode qui permet de lister le stuff du personnage DANS LA CONSOLE
        /// </summary>
        public void AffichStuff() 
        {
            foreach (KeyValuePair<PosInventaire, Equipement> e in Stuff)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Methode permettant d'afficher toutes les caractéristiques d'un personnage DANS LA CONSOLE
        /// </summary>
        public void ListerCarac()
        {
            foreach (Caracs c in CaracsPers.Values)
            {
                Console.WriteLine(c.ToString());
            }
        }

        /// <summary>
        /// Méthode qui convertis le détail d'un personnage en String
        /// </summary>
        /// <returns>Détail du personnage</returns>
        public override string ToString()
        {
            return $"Personnage : {ClassePers}";
        }
    }
}