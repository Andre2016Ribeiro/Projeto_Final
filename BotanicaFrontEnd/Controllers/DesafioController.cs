using Microsoft.AspNetCore.Mvc;
using BotanicaFrontEnd.MeusServicos;

namespace BotanicaFrontEnd.Controllers
{
    public class DesafioController : Controller
    {
        private readonly MeuServicoAzure _meuServico;

        public DesafioController(MeuServicoAzure meuServico)
        {
            _meuServico = meuServico;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string mensagem)
        {
            //Exemplo de texto de teste:
            string? name = User.Identity.Name;
           string mensagens = mensagem + " do utilizador " + name;
            //Enviar uma mensagem:
            await _meuServico.EnviarMensagemAsync(mensagens);
            
            ViewBag.Mensagem = "Foi enviada a Resposta: " + mensagem;

            return View();
        }

        public async Task<IActionResult> Receber()
        {
            //Receber uma mensagem:
            string Resposta = await _meuServico.ReceberrMensagemAsync();
            string userr = Resposta;
            var userrs = userr.Split(' ');
            string utilizadorr = userrs.Last();
            if (utilizadorr == User.Identity.Name)
                ViewBag.Resposta = "A sua resposta Está " + Resposta;
            else
                ViewBag.Resposta = "a sua resposta ainda não foi corrigida ";

            string mensagem = await _meuServico.ReceberMensagemAsync();
            string user = mensagem;
            var users = user.Split(' ');
            string utilizador = users.Last();
            if (utilizador==User.Identity.Name)
                ViewBag.Mensagem = "A sua resposta Foi: " + mensagem;
            else
                ViewBag.Mensagem = "Não há mensagens a receber";

            return View();

            

        }
    }
}
