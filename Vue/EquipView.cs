using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;

namespace Vue
{ 
    class EquipView
    {
        public Equipement Modele { get; set; }
        public string Image { get; set; }

        public EquipView(Equipement e)
        {
            Modele = e;
            Image = e.Image;
        }

    }
}
