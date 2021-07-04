using PerfectChannel.Infrastructure.Repositories;
using Moq;
using PerfectChannel.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace PerfectChannel.WebApi.Test.Controllers
{
    [TestClass]
    public class TaskControllerTests
    {
        [TestMethod]
        public void GetTasks_ReturnsOk()
        {
            // arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetTasks()).Returns(GetTestTasks());
            var controller = new TaskController(mockRepo.Object);
            
            // act
            var result = controller.GetTasks();
            var okResult = result as OkObjectResult;
            var listValues = okResult.Value as List<Domain.Task>;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, listValues.Count);
        }

        [TestMethod]
        public void AddTask_BadRequest()
        {
            // arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetTasks()).Returns(GetTestTasks());
            var controller = new TaskController(mockRepo.Object);

            var result = controller.AddTask(null);
            var badRequestResult = result as BadRequestObjectResult;

            // assert
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid task value", badRequestResult.Value);
        }

        [TestMethod]
        public void AddTask_ReturnsOk()
        {
            // arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetTasks()).Returns(GetTestTasks());
            var controller = new TaskController(mockRepo.Object);

            // act
            var task = new Domain.Task()
            {
                Id = Guid.NewGuid(),
                Text = "Task3",
                Pending = true
            };
            
            var result = controller.AddTask(task);
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("The task was added sucessfully", okResult.Value);
        }

        [TestMethod]
        public void UpdateTask_ReturnsOk()
        {
            // arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetTasks()).Returns(GetTestTasks());
            var controller = new TaskController(mockRepo.Object);

            // act
            var task = new Domain.Task()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Text = "Task 1",
                Pending = false
            };
            var result = controller.UpdateTask(task);
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("The task was updated sucessfully", okResult.Value);
        }

        [TestMethod]
        public void UpdateTask_BadRequest()
        {
            // arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetTasks()).Returns(GetTestTasks());
            var controller = new TaskController(mockRepo.Object);

            var result = controller.UpdateTask(null);
            var badRequestResult = result as BadRequestObjectResult;

            // assert
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid task value", badRequestResult.Value);
        }

        private List<Domain.Task> GetTestTasks()
        {
            var tasks = new List<Domain.Task>();
            tasks.Add(new Domain.Task()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Text = "Task 1",
                Pending = true
            });
            tasks.Add(new Domain.Task()
            {
                Id = Guid.NewGuid(),
                Text = "Task 2",
                Pending = false
            });
            return tasks;
        }
    }
}
