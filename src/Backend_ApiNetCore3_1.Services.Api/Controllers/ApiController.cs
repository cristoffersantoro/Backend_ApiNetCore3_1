using Microsoft.AspNetCore.Mvc;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly INotificator _notifications;

        protected ApiController(INotificator notifications)
        {
            _notifications = notifications;
        }

        protected List<Notificacao> Notifications => _notifications.ObterNotificacoes();

        protected bool IsValidOperation()
        {
            return (!_notifications.TemNotificacao());
        }

        protected async new Task<IActionResult> Response(object result = null)
        {

            if (IsValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                success = false,
                errors = await Task.Run(() => _notifications.ObterNotificacoes().Select(n => n.Mensagem))
            });
        }

    }
}
