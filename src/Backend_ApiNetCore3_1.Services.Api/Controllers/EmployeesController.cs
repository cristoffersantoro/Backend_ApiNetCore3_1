using Microsoft.AspNetCore.Mvc;
using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Controllers
{
    [Route("[controller]")]
    [Produces(contentType: "application/json")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeAppService _employeeAppService;
        public EmployeesController(
            IEmployeeAppService employeeAppService,
            INotificator notifications) : base(notifications)
        {
            _employeeAppService = employeeAppService;
        }

        #region Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _employeeAppService.GetAll();
            return await Response(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var employeeViewModel = _employeeAppService.GetById(id);

            return await Response(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeViewModelRequest viewModel)
        {
            _employeeAppService.Insert(viewModel);

            return await Response();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromBody]EmployeeViewModelRequest viewModel, int id)
        {
            _employeeAppService.Update(viewModel, id);

            return await Response();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _employeeAppService.Remove(id);

            return await Response();
        }


        #endregion

    } // fim da Classe
}
