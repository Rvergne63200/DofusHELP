using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vue
{
    public class ClasseView
    {
        public Classe Model { get; set; }
        public string Image { get; set; }
        public List<SortView> Sorts { get; set; }

        public ClasseView(string nom, string desc, string image, params SortView[] sorts)
        {
            List<Sort> mSorts = new List<Sort>();
            Sorts = new List<SortView>();
            foreach (SortView sort in sorts)
            {
                mSorts.Add(sort.Model);
                Sorts.Add(sort);
            }
            Model = new Classe(nom, desc, mSorts);
            Image = image;
        }
    }
}
