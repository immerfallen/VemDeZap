using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace VemDeZap.Domain.Commands
{
    public class AutenticarUsuarioResponse
    {
        public AutenticarUsuarioResponse(INotifiable notifiable)
        {
            this.Success = notifiable.IsValid();
            this.Notifications = notifiable.Notifications;
        }
        public AutenticarUsuarioResponse(INotifiable notifiable, object data)
        {
            this.Success = notifiable.IsValid();
            this.Data = data;
            this.Notifications = notifiable.Notifications;
        }
        public IEnumerable<Notification> Notifications { get; }
        public bool Success { get; private set; }
        public object Data { get; private set; }


    }
}
