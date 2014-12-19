using ACM.BL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLCSharpTest
{
    [TestClass()]
    public class CustomerTest
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

        [TestMethod()]
        [TestCategory("Valid")]
        public void CreateTest()
        {
            // Set up
            // Perform the operation
            Customer actual = Customer.Create();

            // Validate
            Customer expected = new Customer
            {
                CustomerId = 0,
                LastName = null,
                FirstName = null
            };

            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
        }

        [TestMethod()]
        [Owner("DJK")]
        [Priority(1)]
        [TestProperty("TestType","Valid")]
        public void ToStringTestValid()
        {
            // Set up
            Customer customerInstance = Customer.Create();
            customerInstance.LastName = "Baggins";
            customerInstance.FirstName = "Bilbo";
            String actual = customerInstance.ToString();

            // Perform the operation
            String expected = "Baggins, Bilbo (0)";

            // Validate
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [Owner("Joe")]
        [Priority(2)]
        [TestProperty("TestType", "Null")]
        public void ToStringTestNull()
        {
            // Set up
            Customer customerInstance = Customer.Create();
            String actual = customerInstance.ToString();

            // Perform the operation
            String expected = " (0)";

            // Validate
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [Owner("Joe")]
        [Priority(1)]
        [TestProperty("TestType", "Missing Value")]
        public void ToStringTestNoFirstName()
        {
            // Set up
            Customer customerInstance = Customer.Create();
            customerInstance.LastName = "Baggins";
            String actual = customerInstance.ToString();

            // Perform the operation
            String expected = "Baggins (0)";

            // Validate
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestProperty("TestType", "Missing Value")]
        public void ToStringTestNoLastName()
        {
            // Set up
            Customer customerInstance = Customer.Create();
            customerInstance.FirstName = "Bilbo";
            String actual = customerInstance.ToString();

            // Perform the operation
            String expected = "Bilbo (0)";

            // Validate
            Assert.AreEqual(expected, actual);
        }
    }
}
