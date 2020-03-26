using AgroVision.Api.Mappers;
using AgroVision.Common.Exceptions;
using AgroVision.Dal.Entities;
using AgroVision.Model;
using AgroVision.Web.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Api.Repositories
{
    public class AgroVisionDbRepository : IAgroVisionDbRepository
    {
        private readonly AgroVisionDbContext _dbContext;
        private readonly IMapper _mapper;

        public AgroVisionDbRepository(AgroVisionDbContext dbContext, IAgroVisionMapper<IMapper> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper.CreateMapper();
        }

        public async Task<UserCalculationModel> GetUserCalculation(int id)
        {
            var entity = await _dbContext.UserCalculations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new ResourceNotFoundException("UserCalculation");
            }

            var response = _mapper.Map<UserCalculationModel>(entity);
            return response;
        }

        public async Task<List<UserCalculationModel>> GetUserCalculationFilter(GetUserCalculationModel model)
        {
            var entity = await _dbContext.UserCalculations
                .Where(x =>
                    (model.UserId == null || x.UserId == model.UserId) &&
                    (model.CropType == null || x.CropType == model.CropType) &&
                    (model.SprayingAgent == null || x.SprayingAgent == model.SprayingAgent) &&
                    (model.Description == null || x.Description.Contains(model.Description))
                ).ToListAsync();
            var response = _mapper.Map<List<UserCalculationModel>>(entity);
            return response;
        }

        public async Task<UserCalculationModel> CreateUserCalculation(UserCalculationModel model)
        {
            var entity = _mapper.Map<UserCalculation>(model);

            _dbContext.UserCalculations.Add(entity);

            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<UserCalculationModel>(entity);
            return response;
        }

        public async Task<UserCalculationModel> UpdateUserCalculation(UserCalculationModel model)
        {

            var entity = await _dbContext.UserCalculations.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new ResourceNotFoundException("UserCalculation");
            }
            entity = _mapper.Map(model, entity);

            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<UserCalculationModel>(entity);
            return response;
        }

        public async Task DeleteUserCalculation(int id)
        {

            var entity = await _dbContext.UserCalculations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new ResourceNotFoundException("UserCalculation");
            }
            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
