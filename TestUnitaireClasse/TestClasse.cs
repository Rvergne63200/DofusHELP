using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele;

namespace TestUnitaireClasse
{
    [TestClass]
    public class TestClasse
    {
        /// <summary>
        /// Test que l'on ne puisses pas ajouter des sorts nulls ou avec une valeur à 0 caractères 
        /// </summary>
        /// <param name="i">Nombre de sort qu'il devrait y avoir dans la liste</param>
        /// <param name="Nom">Nom du sort</param>
        /// <param name="Desc">Description du sort</param>
        [DataRow(0, "", "Desc")]
        [DataRow(0, "", "")]
        [DataRow(0, "", null)]
        [DataRow(0, null, "Desc")]
        [DataRow(0, null, "")]
        [DataRow(0, null, null)]
        [DataRow(1, "Sort1", "Desc")]
        [DataRow(0, "Sort1", "")]
        [DataRow(0, "Sort1", null)]
        [DataTestMethod]
        public void TestAjoutSort(int i, string Nom, string Desc)
        {
            Classe test = new Classe("TEST", "NoDesc", new List<Sort>());

            try
            {
                test.AjouterSort(new Sort(Nom, Desc));
            }catch(Exception e) { }
                
            Assert.AreEqual(test.ListSort.Count, i);
        }


        /// <summary>
        /// Test que l'on ne puisses pas ajouter deux sorts avec le meme nom dans une classe
        /// </summary>
        [TestMethod]
        public void TestAjoutSortsEgaux()  
        {
            Classe test = new Classe("TEST", "NoDesc", new List<Sort>());

            test.AjouterSort(new Sort("Sort1", "test"));
            Assert.AreEqual(test.ListSort.Count, 1);

            test.AjouterSort(new Sort("Sort1", "test"));
            Assert.AreEqual(test.ListSort.Count, 1);

            test.AjouterSort(new Sort("Sort3", "test"));
            Assert.AreEqual(test.ListSort.Count, 2);
        }



        /// <summary>
        /// Test le constructeur de Classe afin que l'on ajoute pas un nom ou une description vide
        /// et que la liste de sort null est bien remplacée par une nouvelle liste de sort dans le constructeur
        /// </summary>
        /// <param name="name">nom de la classe</param>
        /// <param name="desc">description de la classe</param>
        /// <param name="test">valeur voulue du test qui indique si la classe a été créee ou pas</param>
        /// <param name="list">Liste de sort </param>
        [DataRow("nom", "desc", false, null)]
        [DataRow("", "desc", true ,null)]
        [DataRow("nom", "", true, null)]
        [DataRow("   ", "desc", true, null)]
        [DataRow("nom", "    ", true, null)]
        [DataRow("          ", "desc", true, null)]
        [DataRow("nom", "            ", true, null)]
        [DataRow(null, "desc", true, null)]
        [DataRow("nom", null, true, null)]
        [TestMethod]
        public void TestConstruct(string name, string desc, bool test, List<Sort> list)
        {
            Classe c = null;

            try
            {
                c = new Classe(name, desc, list);
            }catch(Exception e) { }
                
            Assert.AreEqual(c == null, test);

            if(c != null)
            {
                Assert.AreNotEqual(c.ListSort, null);
                Assert.AreEqual(String.IsNullOrWhiteSpace(c.NomClasse), false);
                Assert.AreEqual(String.IsNullOrWhiteSpace(c.DescriptionClasse), false);
            }
        }

    }
}
