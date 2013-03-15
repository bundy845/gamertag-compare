using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for FeedServiceTest and is intended
    ///to contain all FeedServiceTest Unit Tests
    ///</summary>
    [TestClass]
    public class FeedServiceTest
    {
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
        [TestMethod]
        public void GamesPlayedTest()
        {
            var target = new FeedService();
            const string gamertag = "Bundy"; 
            var gamesPlayed = target.GamesPlayed(gamertag);
            Assert.IsTrue(gamesPlayed.Games.Count > 0);
        }

        /// <summary>
        ///A test for GamerExists
        ///</summary>
        [TestMethod]
        public void GamerExistsTest()
        {
            var target = new FeedService();
            const string gamertag = "Bundy";
            var actual = target.GamerExists(gamertag);
            Assert.IsTrue(actual);            
        }

        [TestMethod]
        public void GamerDoesntExistTest()
        {
            var target = new FeedService();
            const string gamertag = "Bundyaaaaaaa";
            var actual = target.GamerExists(gamertag);
            Assert.IsFalse(actual);    
        }

    }
}
