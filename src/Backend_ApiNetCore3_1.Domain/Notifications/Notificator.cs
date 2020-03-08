using Backend_ApiNetCore3_1.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Backend_ApiNetCore3_1.Domain.Notifications
{
    public class Notificator : INotificator
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificator()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}

