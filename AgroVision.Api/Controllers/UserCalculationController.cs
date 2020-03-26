using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroVision.Api.Repositories;
using AgroVision.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgroVision.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    public class UserCalculationController : ControllerBase
    {
        private readonly ILogger<UserCalculationController> _logger;
        private readonly IAgroVisionDbRepository _agroVisionDbRepository;

        public UserCalculationController(ILogger<UserCalculationController> logger, IAgroVisionDbRepository agroVisionDbRepository)
        {
            _logger = logger;
            _agroVisionDbRepository = agroVisionDbRepository;
        }

        [HttpGet("{id}")]
        public async Task<UserCalculationModel> Get(int id)
        {
            return await _agroVisionDbRepository.GetUserCalculation(id);
        }


        [HttpPost]
        public async Task<List<UserCalculationModel>> GetUserCalculationFilter(GetUserCalculationModel model)
        {
            return await _agroVisionDbRepository.GetUserCalculationFilter(model);
        }

        [HttpPut]
        public async Task<UserCalculationModel> Update(UserCalculationModel model)
        {
            return await _agroVisionDbRepository.UpdateUserCalculation(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _agroVisionDbRepository.DeleteUserCalculation(id);
        }

        [HttpPost]
        public async Task<UserCalculationModel> Create(UserCalculationModel model)
        {
            return await _agroVisionDbRepository.CreateUserCalculation(model);
        }
    }
}
