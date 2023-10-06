using System.ComponentModel.DataAnnotations;
namespace BotanicaFrontEnd.Models
{
    public class Desafio
    {
        [Display(Name = "Contentor")]
        public string Contentor
        {
            get;
            set;
        }
        [Display(Name = "Id")]
        public string Id
        {
            get;
            set;
        }
        public string Mensagem
        {
            get;
            set;
        }

        public string Autor
        {
            get;
            set;
        }

        public string Modified
        {
            get;
            set;
        }
    }
}
