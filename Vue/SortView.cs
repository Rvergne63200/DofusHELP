using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue
{
    public class SortView
    {
        public Sort Model { get; set; }
        public string Image { get; set; }

        public SortView(string nom, string desc, string image)
        {
            Model = new Sort(nom, desc, null);
            Image = image;
        }
    }
}
