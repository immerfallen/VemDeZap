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
    public class AdicionarUsuarioHandler : Notifiable , IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IRepositoryUsuario _repositorioUsuario;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //Validar se request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new Response(this);
            }
            // Verificar se o usuário já existe
            if (_repositorioUsuario.Existe(x=>x.Email==request.Email))
            {
                AddNotification("Email", "E-mail já cadastrado no sistema");
                return new Response(this);
            }

            Entities.Usuario usuario = new Entities.Usuario();

            usuario.PrimeiroNome = request.PrimeiroNome;
            usuario.UltimoNome = request.UltimoNome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            _repositorioUsuario.Adicionar(usuario);
        }
    }
}
