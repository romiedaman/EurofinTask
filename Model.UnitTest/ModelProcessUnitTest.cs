using Model.Registration;
using Moq;
using System;
using Task_1.Controllers;
using Xunit;

namespace Model.UnitTest
{
    public class ModelProcessUnitTest
    {
        [Fact]
        public void Test_ValidateModelDetail()
        {
            var modelRepository = new Mock<IModelRepository>();
            var modelProcessor = new ModelProcessor(modelRepository.Object);

            Assert.True(modelProcessor.ValidateModelDetail(new Task_1.ModelData
            {
                Id = 1,
                Title = "Romit",
                Description = "AXT",
                IsComplete = true
            }));
        }




        [Fact]
        public void Test_ModelDetailByID()
        {
            var modelRepository = new Mock<IModelRepository>();
            var modelProcessor = new ModelProcessor(modelRepository.Object);

            Assert.True(modelProcessor.ValidateModelDetailByID(1));
        }

        [Fact]
        public void Test_DeleteEmployeeId()
        {
            var modelRepository = new Mock<IModelRepository>();
            modelRepository.Setup(e => e.DeleteModelData(It.IsAny<int>())).Returns(true);
            var modelProcessor = new ModelProcessor(modelRepository.Object);

            Assert.True(modelProcessor.ValidateForModelDeleteID(1));
        }

        [Fact]
        public void Test_AddModelDetail()
        {
            var modelRepository = new Mock<IModelRepository>();
            var modelProcessor = new ModelProcessor(modelRepository.Object);

            Assert.True(modelProcessor.AddModelDetails(new Task_1.ModelData
            {
                Id = 1,
                Title = "Romit",
                Description = "AXT",
                IsComplete = true
            }));
        }

        [Fact]
        public void Test_ModifyModelDetail()
        {
            var modelRepository = new Mock<IModelRepository>();
            var modelProcessor = new ModelProcessor(modelRepository.Object);

            Assert.True(modelProcessor.ModifyModelDetails(new Task_1.ModelData
            {
                Id = 1,
                Title = "Romit",
                Description = "AXT",
                IsComplete = true
            }
             ));
        }
    }
}
