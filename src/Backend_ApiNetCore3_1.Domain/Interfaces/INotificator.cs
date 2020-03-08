using Backend_ApiNetCore3_1.Domain.Notifications;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Domain.Interfaces
{
    public interface INotificator
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
