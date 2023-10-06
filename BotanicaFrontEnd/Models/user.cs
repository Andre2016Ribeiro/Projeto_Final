using Microsoft.AspNetCore.Mvc;

namespace BotanicaFrontEnd.Models
{
    public class user
    {
        public string nome
        {
            get;
            set;
        }


        public user f(string nome)
        {
            this.nome = nome;
            return this;
        }
    }
}
