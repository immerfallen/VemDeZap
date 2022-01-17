using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable , IRequestHandler<AdicionarUsuarioRequest, AutenticarUsuarioResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositorioUsuario;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositorioUsuario, IMediator mediator)
        {
             _mediator = mediator;
             _repositorioUsuario = repositorioUsuario;
        }

        public async Task<AutenticarUsuarioResponse> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //Validar se request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new AutenticarUsuarioResponse(this);
            }
            // Verificar se o usuário já existe
            if (_repositorioUsuario.Existe(x=>x.Email==request.Email))
            {
                AddNotification("Email", "E-mail já cadastrado no sistema");
                return new AutenticarUsuarioResponse(this);
            }

            Entities.Usuario usuario = new Entities.Usuario(request.PrimeiroNome, request.UltimoNome, request.Email, request.Senha);

            AddNotifications(usuario);

            if (IsInvalid())
            {
                return new AutenticarUsuarioResponse(this);
            }

            usuario = _repositorioUsuario.Adicionar(usuario);

            //Crir objeto de resposta

            var response = new AutenticarUsuarioResponse(this, usuario);

            AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(response);
            
        }
    }
}
