using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Controllers
{
    [Route("[controller]")]
    public class PositionsController : ApiController
    {
        private readonly IPositionAppService _positionAppService;

        private readonly IMapper _mapper;

        public PositionsController(
            IMapper mapper,
            IPositionAppService positionAppService,
            INotificator notifications

        ) : base(notifications)
        {
            _mapper = mapper;
            _positionAppService = positionAppService;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _positionAppService.GetAll();
            return await Response(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _positionAppService.GetById(id);

            return await Response(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PositionViewModelRequest viewModel)
        {
            _positionAppService.Insert(viewModel);

            return await Response();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromBody]PositionViewModelRequest viewModel, int id)
        {
            _positionAppService.Update(viewModel, id);

            return await Response();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _positionAppService.Remove(id);

            return await Response();
        }
    }
}