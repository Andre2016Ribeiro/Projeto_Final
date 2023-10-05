using Microsoft.AspNetCore.Mvc;
using WebApplicationBackendBotanica.MeusServicos;

namespace WebApplicationBackendBotanica.Controllers
{
    public class DesafioController : Controller
    {
        private readonly MeuServicoAzure _meuServico;

        public DesafioController(MeuServicoAzure meuServico)
        {
            _meuServico = meuServico;
        }

        public async Task<IActionResult> Index()
        {
            

            

            return View(await _meuServico.ReceberMensagemAsync());


            
        }

        [HttpPost]
        public async Task<IActionResult> Index(string mensagem)
        {
            //Exemplo de texto de teste:
            string? name = User.Identity.Name;
           string mensagens = mensagem + "do utilizador" + name;
            //Enviar uma mensagem:
            await _meuServico.EnviarMensagemAsync(mensagens);
            
            ViewBag.Mensagem = "Foi enviada a Resposta: " + mensagem;

            return View();
        }

        public async Task<IActionResult> Receber()
        {

            return View();
        }
    }
}
