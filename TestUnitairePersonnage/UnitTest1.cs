using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele;

namespace TestUnitairePersonnage
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow (0, NomCarac.Agilite)]
        [DataTestMethod]
        public void TestAjouterPointCarac(int i, NomCarac c)
        {
            Personnage p = new Personnage(new Classe("Nom", "Desc", null));

            p.AjouterPointsCaracteristiques(c, i);
            Assert.AreEqual(p.CaracsPers.ContainsKey(c), true);
            // A finir
        }

        [TestMethod]
        public void TestDeEquiper()
        {
        }

        [TestMethod]
        public void TestEquiper()
        {
        }
    }
}
