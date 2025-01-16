using MicroserviceTemplate.Domain.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using MicroserviceTemplate.Managers.MicroserviceTemplate;

namespace MicroserviceTemplate.Managers.Tests.Managers
{
    [TestClass]
    public class MicroserviceTemplateTests
    {
        //The main manager class that will be tested
        MicroserviceTemplateManager microserviceTemplateManager;
        //Mock of managers/repositories that will not be tested but instead use predetermined mock data
        private Mock<IMicroserviceTemplateRepository> mockMicroserviceTemplateRepository;

        //Initializes the test class. Initialize the main class to be tested and set up mocks.
        [TestInitialize]
        public void TestInitialize()
        {
            //New mocked instance of repository
            this.mockMicroserviceTemplateRepository = new Mock<IMicroserviceTemplateRepository>();

            //Construct the main class. Note that from mocked repository we use the object of mock.
            this.microserviceTemplateManager = new MicroserviceTemplateManager(mockMicroserviceTemplateRepository.Object);
        }
        //TestMethod that will run the test
        //If the manager method is Async method, this test also needs to be async.
        [TestMethod]
        public void RunATestMethodSuccesfully()
        {
            int x = 10;
            int y = 20;

            int expectedResult = x * y + (x + y);
            //Setup each method that is going to be used 
            //When setting up async methods Returns have to be set .Returns(Task.FromResult(value))

            mockMicroserviceTemplateRepository.Setup(m => m.ThisMethodIsForTestingPurposes(x, y)).Returns(x + y);

            //If you have no way of knowing what some values are or should be you can use It.IsAny<int>() where T is the object type
            //For example above setup could be said with
            //mockMicroserviceTemplateRepository.Setup(m => m.ThisMethodIsForTestingPurposes(It.IsAny<int>(), It.IsAny<int>())).Returns(It.IsAny<int>());

            //You should always use real values if you have a way of knowing them.
            int result = microserviceTemplateManager.ThisMethodIsOnlyForTestingPurposes(x, y);

            mockMicroserviceTemplateRepository.Verify(m => m.ThisMethodIsForTestingPurposes(x, y), Times.Once);

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "y was 0, expected an exception")]
        public void RunATestMethodToFailuter()
        {
            int x = 10;
            int y = 0;
            mockMicroserviceTemplateRepository.Setup(m => m.ThisMethodIsForTestingPurposes(x, y)).Returns(x + y);

            int result = microserviceTemplateManager.ThisMethodIsOnlyForTestingPurposes(x, y);

        }
    }
}
