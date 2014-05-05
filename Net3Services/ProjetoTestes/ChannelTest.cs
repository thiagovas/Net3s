using Models.AtualizacaoEmDesuso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ChannelTest and is intended
    ///to contain all ChannelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ChannelTest
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
        ///A test for Channel Constructor
        ///</summary>
        [TestMethod()]
        public void ChannelConstructorTest()
        {
            Channel target = new Channel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Language
        ///</summary>
        [TestMethod()]
        public void LanguageTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Language = expected;
            actual = target.Language;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastBuildDate
        ///</summary>
        [TestMethod()]
        public void LastBuildDateTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.LastBuildDate = expected;
            actual = target.LastBuildDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Link
        ///</summary>
        [TestMethod()]
        public void LinkTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Link = expected;
            actual = target.Link;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LstItens
        ///</summary>
        [TestMethod()]
        public void LstItensTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            List<Item> expected = null; // TODO: Initialize to an appropriate value
            List<Item> actual;
            target.LstItens = expected;
            actual = target.LstItens;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ObjAtomLink
        ///</summary>
        [TestMethod()]
        public void ObjAtomLinkTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            AtomLink expected = null; // TODO: Initialize to an appropriate value
            AtomLink actual;
            target.ObjAtomLink = expected;
            actual = target.ObjAtomLink;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ObjImage
        ///</summary>
        [TestMethod()]
        public void ObjImageTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            target.ObjImage = expected;
            actual = target.ObjImage;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PubDate
        ///</summary>
        [TestMethod()]
        public void PubDateTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.PubDate = expected;
            actual = target.PubDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitleTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Title = expected;
            actual = target.Title;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WebMaster
        ///</summary>
        [TestMethod()]
        public void WebMasterTest()
        {
            Channel target = new Channel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.WebMaster = expected;
            actual = target.WebMaster;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
