using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Shportyuk;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string name = "Anastasia";
            Customer m = new Customer(name);

            Assert.IsTrue(m is Customer);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string name = "Anastasia";
            Customer m = new Customer(name);
            Assert.AreEqual(name, m.Name);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string name = "Anastasia";
            Customer m = new Customer(name);
            m.PrintBanner();
            Assert.AreEqual(0, m.GetAmount());

        }

        [TestMethod]
        public void TestMethod4()
        {
            string name = "Anastasia";
            Customer m = new Customer(name);
            Assert.AreEqual(5, m.GetTicketPrice(DateTime.Now,5));

        }
        [TestMethod]
        public void TestMethod5()
        {
            string name = "Anastasia";
            Customer m = new Customer(name);

            Assert.IsTrue(m.NotSummer(DateTime.Now));
        }
       
    }
}
