using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands.Usuario.AdicionarUsuario;
using VemDeZap.Domain.Extensions;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AutenticarUsuarioRequest
{
    public class AutenticarUsuarioHandler : Notifiable, IRequestHandler<AutenticarUsuarioRequest, AutenticarUsuarioResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AutenticarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<AutenticarUsuarioResponse> Handle(AutenticarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                AddNotification("Request", "Request é obrigatorio");
                return null;
            }
            request.Senha = request.Senha.ConvertoToMD5();

            Entities.Usuario usuario = _repositoryUsuario.ObterPor(x => x.Email == request.Email && x.Senha == request.Senha);

            if(usuario == null)
            {
                AddNotification("Usuario", "Usuario nao encontrado");
                return new AutenticarUsuarioResponse()
                {
                    Autenticado = false
                };
            }

            var response = (AutenticarUsuarioResponse)usuario;

            return await Task.FromResult(response);

        }
    }
}
