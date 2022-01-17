using prmToolkit.NotificationPattern;
using System;
using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Extensions;

namespace VemDeZap.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario()
        {

        }
        public Usuario(string primeiroNome, string ultimoNome, string email, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 150, "O nome deve conter entre 3 e 150 caracteres.")
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 150)
                .IfNotEmail(x => x.Email, "Não é e-mail válido.")
                .IfNullOrInvalidLength(x => x.Senha, 3, 32);

            if (!string.IsNullOrEmpty(this.Senha))
            {
                this.Senha = Senha.ConvertoToMD5();
            }

            DataCadastro = DateTime.Now;
            Ativo = false;
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

    }
}
