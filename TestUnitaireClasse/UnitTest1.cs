using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele;

namespace TestUnitaireClasse
{
    [TestClass]
    public class UnitTest1
    {
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
        public void TestAjoutSort(int i, string Nom, string Desc) // Test que l'on ne puisses pas ajouter des sorts nulls ou avec une valeur à 0 caractères 
        {
            Classe test = new Classe("TEST", "NoDesc", new List<Sort>());

            try
            {
                test.AjouterSort(new Sort(Nom, Desc));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            Assert.AreEqual(test.ListSort.Count, i);
        }

        [TestMethod]
        public void TestAjoutSortsEgaux() // Test que l'on ne puisses pas ajouter deux sorts avec le meme nom dans une classe 
        {
            Classe test = new Classe("TEST", "NoDesc", new List<Sort>());

            test.AjouterSort(new Sort("Sort1", "test"));
            Assert.AreEqual(test.ListSort.Count, 1);

            test.AjouterSort(new Sort("Sort1", "test"));
            Assert.AreEqual(test.ListSort.Count, 1);

            test.AjouterSort(new Sort("Sort3", "test"));
            Assert.AreEqual(test.ListSort.Count, 2);
        }
    }
}
