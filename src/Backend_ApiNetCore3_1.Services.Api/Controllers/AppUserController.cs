using Microsoft.AspNetCore.Mvc;
using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Controllers
{
    [Route("[controller]")]
    public class AppUsersController : ApiController
    {
        private readonly IAppUserAppService _appUserAppService;


        public AppUsersController(
            INotificator notifications,
            IAppUserAppService appUserAppService


        ) : base(notifications)
        {

            _appUserAppService = appUserAppService;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _appUserAppService.GetAll();
            return await Response(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _appUserAppService.GetById(id);
            return await Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AppUserViewModelRequest viewModel)
        {
            _appUserAppService.Insert(viewModel);
            return await Response();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromBody]AppUserViewModelRequest viewModel, int id)
        {

            _appUserAppService.Update(viewModel, id);
            return await Response();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _appUserAppService.Remove(id);
            return await Response();
        }
    }
}