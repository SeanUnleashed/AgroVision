using AgroVision.Api.Mappers;
using AgroVision.Api.Repositories;
using AgroVision.Common.Exceptions;
using AgroVision.Web.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Api.Tests.Integration
{
    [TestClass]
    public class AgroVisionDbRepositoryTests
    {
        private readonly IAgroVisionDbRepository _agroVisionDbRepository;
        private readonly IAgroVisionMapper<IMapper> _mapper;
        private readonly AgroVisionDbContext dbContext;
        public AgroVisionDbRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AgroVisionDbContext>()
            .UseInMemoryDatabase(databaseName: "SprayingDosageCalculator")
            .Options;

            dbContext = new AgroVisionDbContext(options);
            _mapper = new AgroVisionMapper();
            _agroVisionDbRepository = new AgroVisionDbRepository(dbContext, _mapper);
        }

        [TestMethod]
        public async Task Test_GetUserCalculation_Success()
        {
            var createModel = await _agroVisionDbRepository.CreateUserCalculation(new Model.UserCalculationModel
            {
                AgentAmount = 1,
                CropType = "test",
                Description = "Test",
                Hectares = 7,
                LitersPerHectare = 90,
                MinimimSprayRate = 20,
                WaterAmount = 50,
                SprayingAgent = "Test",
                UserId = Guid.NewGuid().ToString("N")
            });
            var response = await _agroVisionDbRepository.GetUserCalculation(createModel.Id);

            Assert.AreEqual(response.Id, createModel.Id);
            Assert.AreEqual(response.AgentAmount, createModel.AgentAmount);
            Assert.AreEqual(response.CropType, createModel.CropType);
            Assert.AreEqual(response.Description, createModel.Description);
            Assert.AreEqual(response.Hectares, createModel.Hectares);
            Assert.AreEqual(response.LitersPerHectare, createModel.LitersPerHectare);
            Assert.AreEqual(response.MinimimSprayRate, createModel.MinimimSprayRate);
            Assert.AreEqual(response.SprayingAgent, createModel.SprayingAgent);
            Assert.AreEqual(response.UserId, createModel.UserId);
            Assert.AreEqual(response.WaterAmount, createModel.WaterAmount);


            await _agroVisionDbRepository.DeleteUserCalculation(response.Id);
        }

        [TestMethod]
        public async Task Test_GetUserCalculationFilter_Success()
        {
            var createModel1 = await _agroVisionDbRepository.CreateUserCalculation(new Model.UserCalculationModel
            {
                AgentAmount = 1,
                CropType = "Test",
                Description = "Test",
                Hectares = 7,
                LitersPerHectare = 90,
                MinimimSprayRate = 20,
                WaterAmount = 50,
                SprayingAgent = "Test",
                UserId = Guid.NewGuid().ToString("N")
            });
            var response = await _agroVisionDbRepository.GetUserCalculationFilter(new Model.GetUserCalculationModel { 
            UserId = createModel1.UserId
            });

            Assert.AreEqual(response.First().Id, createModel1.Id);
            Assert.AreEqual(response.First().AgentAmount, createModel1.AgentAmount);
            Assert.AreEqual(response.First().CropType, createModel1.CropType);
            Assert.AreEqual(response.First().Description, createModel1.Description);
            Assert.AreEqual(response.First().Hectares, createModel1.Hectares);
            Assert.AreEqual(response.First().LitersPerHectare, createModel1.LitersPerHectare);
            Assert.AreEqual(response.First().MinimimSprayRate, createModel1.MinimimSprayRate);
            Assert.AreEqual(response.First().SprayingAgent, createModel1.SprayingAgent);
            Assert.AreEqual(response.First().UserId, createModel1.UserId);
            Assert.AreEqual(response.First().WaterAmount, createModel1.WaterAmount);


            await _agroVisionDbRepository.DeleteUserCalculation(response.First().Id);
        }


        [TestMethod]
        public async Task Test_UpdateUserCalculation_Success()
        {
            var createModel = await _agroVisionDbRepository.CreateUserCalculation(new Model.UserCalculationModel
            {
                AgentAmount = 1,
                CropType = "Test",
                Description = "Test",
                Hectares = 7,
                LitersPerHectare = 90,
                MinimimSprayRate = 20,
                WaterAmount = 50,
                SprayingAgent = "Test",
                UserId = Guid.NewGuid().ToString("N")
            });
            var createResponse = await _agroVisionDbRepository.GetUserCalculation(createModel.Id);

            createResponse.Hectares = 999;
            createResponse.Description = "Test Update";

            var response = await _agroVisionDbRepository.UpdateUserCalculation(createResponse);

            Assert.AreEqual(response.Id, createResponse.Id);
            Assert.AreEqual(response.AgentAmount, createResponse.AgentAmount);
            Assert.AreEqual(response.CropType, createResponse.CropType);
            Assert.AreEqual(response.Description, createResponse.Description);
            Assert.AreEqual(response.Hectares, createResponse.Hectares);
            Assert.AreEqual(response.LitersPerHectare, createResponse.LitersPerHectare);
            Assert.AreEqual(response.MinimimSprayRate, createResponse.MinimimSprayRate);
            Assert.AreEqual(response.SprayingAgent, createResponse.SprayingAgent);
            Assert.AreEqual(response.UserId, createResponse.UserId);
            Assert.AreEqual(response.WaterAmount, createResponse.WaterAmount);


            await _agroVisionDbRepository.DeleteUserCalculation(response.Id);
        }


        [TestMethod]
        public async Task Test_DeleteUserCalculation_Success()
        {
            var createModel = await _agroVisionDbRepository.CreateUserCalculation(new Model.UserCalculationModel
            {
                AgentAmount = 1,
                CropType = "Test",
                Description = "Test",
                Hectares = 7,
                LitersPerHectare = 90,
                MinimimSprayRate = 20,
                WaterAmount = 50,
                SprayingAgent = "Test",
                UserId = Guid.NewGuid().ToString("N")
            });

            await _agroVisionDbRepository.DeleteUserCalculation(createModel.Id);

            try
            {
                await _agroVisionDbRepository.GetUserCalculation(createModel.Id);
                throw new Exception("User calculation not deleted");
            }
            catch (ResourceNotFoundException ex)
            {

            }
        }
    }
}
