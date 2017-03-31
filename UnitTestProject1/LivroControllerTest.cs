using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WEB_ASP_TP3.Repository;
using WEB_ASP_TP3.Domain;
using WEB_ASP_TP3.Controllers;
using System.Web;
using WEB_ASP_TP3.Models;
using System.Linq;
using System.Web.Mvc;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for LivroControllerTest
    /// </summary>
    [TestClass]
    public class LivroControllerTest
    {
        public LivroControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IndexTestMethod()
        {
            //Arrange
            var mockRepository = new Mock<ILivroRepository>();
            mockRepository.Setup(repository => repository.GetAllLivros()).Returns(new List<Livro> {

                new Livro() {Id = 100 , Titulo = "abssddf" , Editora = "asdas",Ano = 1234 ,Autor="asdsad"}
            });

            var controller = new LivroController(mockRepository.Object);



            //act
            var result = controller.index();


            // Assert

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<LivroViewModel>));

            var Livros = model as IEnumerable<LivroViewModel>;
            Assert.AreEqual(1, Livros.Count());
        }
    }
}
