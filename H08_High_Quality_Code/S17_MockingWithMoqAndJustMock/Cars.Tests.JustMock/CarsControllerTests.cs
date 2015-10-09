namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }                

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByInvalidParameterShouldThrowArgumentException()
        {
            this.controller.Sort("Trabant");
        }

        [TestMethod]
        public void SortByMakeShouldReturnView()
        {
            var sortedData = (IView)this.controller.Sort("make");
            var models = (List<Car>)sortedData.Model;

            Assert.AreEqual(1, models[0].Id);
            Assert.AreEqual("Audi", models[0].Make);
            Assert.AreEqual("A4", models[0].Model);
            Assert.AreEqual(2005, models[0].Year);                        

            Assert.AreEqual(3, models[2].Id);
            Assert.AreEqual("BMW", models[2].Make);
            Assert.AreEqual("330d", models[2].Model);
            Assert.AreEqual(2007, models[2].Year);

            
        }

        [TestMethod]
        public void SortByYearShouldReturnView()
        {
            var sortedData = (IView)this.controller.Sort("year");
            var models = (List<Car>)sortedData.Model;

            Assert.AreEqual(1, models[0].Id);
            Assert.AreEqual("Audi", models[0].Make);
            Assert.AreEqual("A4", models[0].Model);
            Assert.AreEqual(2005, models[0].Year);                      

            Assert.AreEqual(4, models[3].Id);
            Assert.AreEqual("Opel", models[3].Make);
            Assert.AreEqual("Astra", models[3].Model);
            Assert.AreEqual(2010, models[3].Year);
        }

        [TestMethod]
        public void CreateCarsControllerWithoutParameter()
        {
            new CarsController();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CotrollerDetailsCalledWithInvalidIdShouldThrowException()
        {
            this.controller.Details(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchByInvalidStringShouldThrowException()
        {
            this.controller.Search("Trabant");
        }
                
        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
