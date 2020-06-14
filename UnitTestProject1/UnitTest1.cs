using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using UnitTestTools;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod01()
        {
            TestTools.StartTest("01", "Stellen Sie sicher, dass das git command von der Eingabeaufforderung ausführbar ist.");
            Assert.IsTrue(TestTools.GitAvail);
            TestTools.EndTest();
        }
        [TestMethod]
        public void TestMethod02()
        {
            TestTools.StartTest("02", "Ihr Programm soll die Datei INPUT.txt aus dem aktuellen Verzeichnis öffnen und den Input auf der Konsole ausgeben.");
            string expected = "“Lorem ipsum dolor sit amet, consectetur adipisici elit," + Environment.NewLine + 
                "sed eiusmod tempor incidunt ut labore et dolore magna aliqua."+ Environment.NewLine +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco" + Environment.NewLine +
                "laboris nisi ut aliquid ex ea commodi consequat. Quis" + Environment.NewLine +
                "aute iure reprehenderit in voluptate velit esse cillum" + Environment.NewLine +
                "dolore eu fugiat nulla pariatur.Excepteur sint obcaecat" + Environment.NewLine +
                "cupiditat non proident, sunt in culpa qui officia deserunt" + Environment.NewLine +
                "mollit anim id est laborum.”" + Environment.NewLine;
            StringWriter sw = new StringWriter();
            var tmp_out = Console.Out;
            Console.SetOut(sw);
            var old_dir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory("..");
            Directory.SetCurrentDirectory("..");
            SmallSteps015.Program.Main(null);
            Console.SetOut(tmp_out);
            Assert.AreEqual(expected, sw.ToString());
            Directory.SetCurrentDirectory(old_dir);
            Console.WriteLine("> {0}", sw.ToString().Replace(Environment.NewLine, string.Format(Environment.NewLine + "> ")));
            TestTools.EndTest();
        }
        [TestMethod]
        public void TestMethod99()
        {
            Assert.IsTrue(TestTools.AllTests());
        }
    }
}
