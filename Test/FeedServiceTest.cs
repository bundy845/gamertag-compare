using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for FeedServiceTest and is intended
    ///to contain all FeedServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FeedServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GamesPlayed
        ///</summary>
        [TestMethod()]
        public void GamesPlayedTest()
        {
            FeedService target = new FeedService();
            string gamertag = "Bundy"; 
            target.GamesPlayed(gamertag);
            target.GamesPlayed(gamertag);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GamerExists
        ///</summary>
        [TestMethod()]
        public void GamerExistsTest()
        {
            FeedService target = new FeedService();
            string gamertag = "Bundy";
            bool expected = true;
            bool actual;
            actual = target.GamerExists(gamertag);
            Assert.AreEqual(expected, actual);            
        }

        [TestMethod()]
        public void GamerDoesntExistTest()
        {
            FeedService target = new FeedService();
            string gamertag = "Bundyaaaaaaa";
            bool expected = false;
            bool actual;
            actual = target.GamerExists(gamertag);
            Assert.AreEqual(expected, actual);    
        }

        /// <summary>
        ///A test for FeedService Constructor
        ///</summary>
        [TestMethod()]
        public void FeedServiceConstructorTest()
        {
            FeedService target = new FeedService();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetFeed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void GetFeedTest()
        {
            FeedService_Accessor target = new FeedService_Accessor(); // TODO: Initialize to an appropriate value
            string url = string.Empty; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.GetFeed(url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
