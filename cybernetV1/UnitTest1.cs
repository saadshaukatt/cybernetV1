using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace cybernetV1
{

    [TestClass]
    public class UnitTest1
    {
        BaseClass bc1 = new BaseClass();
        Pagefunctions p1 = new Pagefunctions();

        #region  Initializations and Cleanups

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {

            // MessageBox.Show("Assembly Initialization");
            // AutoClosingMessageBox.Show("Assembly Initialization", "Caption", 1000);

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // MessageBox.Show("Assembly CleanUp");
            //AutoClosingMessageBox.Show("Assembly Cleanup", "Caption", 1000);

        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // MessageBox.Show("Class Initialization");
            // AutoClosingMessageBox.Show("Class Initilization", "Caption", 1000);

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //MessageBox.Show("Class CleanUp");
            // AutoClosingMessageBox.Show("Class Cleanup", "Caption", 1000);


            /*Baseclass.dr.Close();
            Baseclass.dr.Quit();
            Baseclass.dr.Dispose();*/
        }


        [TestInitialize]
        public void TestInit()
        {

            // MessageBox.Show("Test Initialization");
            // AutoClosingMessageBox.Show("Test initialization", "Caption", 1000);

            bc1.SelniumDriver();
            p1.Gotourl("https://staging.cyber.net.pk/Pages/Login.aspx");


        }

        [TestCleanup]
        public void TestCleanup()
        {
            // MessageBox.Show("Test CleanUp");
            // AutoClosingMessageBox.Show("Test clean", "Caption", 1000);
           // bc1.Close();
        }





        #endregion



        [TestMethod]
        public void TestMethod1()
        {
            //
            //Thread.Sleep(4000);
            p1.Login("insiya.tejani@cyber.net.pk ", "1n5iy@MT.pplhub");
            p1.closepopup();

           // p1.Applcantlist("149", 2, 3, 2, 
             //   2, "TEST NEW MAIL" , "8332-3344432", "45210-1568978-2", "testnewemail@sybrid.com" );

            p1.Applcantlist("136", 0, 0, 0, 0, "", "", "", "");

            Thread.Sleep(2000);
            p1.Editsearch(jobtitle: 1, "final", "03333331372", "44543-2123156-4", "final@gmail.com", "abclinkedin", status: 1, abtus: 2, "aaaassssaaa" , 
                "C:\\NOOQI - Share Meal Plan to folks (ver 1.0).pdf",
                "C:\\try1.docx");
        }
    }
}
