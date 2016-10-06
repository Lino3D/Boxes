using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorytmy_Zaawansowane.Classes;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoad()
        {
            string filename = @"C:\Users\Mike\Desktop\t.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            string line = file.ReadToEnd();


            var BoxesTmp = InputOutput.InitializeList(line);
            var Boxes = new BoxList();
            Boxes.CzyscListe();
            Boxes.DodajPudelka(BoxesTmp);
            Boxes.UstawPionowo();

            foreach (var item in Boxes.ListBox)
            {
                Assert.IsTrue(item.Width <= item.Height);
            }



            BoxList A = new BoxList();
            BoxList B = new BoxList();

            A.DodajPudelka(Boxes.GetBoxList());
            B.DodajPudelka(Boxes.GetBoxList());

            A.SortujPudelka(true);
            B.SortujPudelka(false);


            for (int i = 0; i < A.ListBox.Count - 2; i++)
                Assert.IsTrue(A.ListBox[i].Height <= A.ListBox[i + 1].Height);

            for (int i = 0; i < B.ListBox.Count - 2; i++)
                Assert.IsTrue(B.ListBox[i].Width <= B.ListBox[i + 1].Width);
        }

        [TestMethod]
        public void Algorithm()
        {

        }
    }
}
