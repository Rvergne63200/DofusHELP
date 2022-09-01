using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Modele;

namespace TestUnitairePersonnage
{
    [TestClass]
    public class TestPersonnage
    {
        [DataRow(NomCarac.Intelligence, 20, 20)]
        [DataRow(NomCarac.Intelligence, -20, -20)]
        [DataRow(NomCarac.Intelligence, 0, 0)]
        [DataTestMethod]
        public void TestAjouterPointCarac(NomCarac c, int i, int n)
        {
            Personnage p = new Personnage(new Classe("Test", "Test", null));

            p.AjouterPointsCaracteristiques(c, i);
            Assert.AreEqual(p.CaracsPers[c].Value, n);
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
