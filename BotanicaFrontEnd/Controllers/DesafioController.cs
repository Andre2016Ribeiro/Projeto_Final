using Microsoft.AspNetCore.Mvc;
using BotanicaFrontEnd.MeusServicos;
using BotanicaFrontEnd.Models;
using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Authorization;

namespace BotanicaFrontEnd.Controllers
{
    [Authorize]
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
            string name = User.Identity.Name;
            

            ViewData["Enviadas"] = await _meuServico.ReceberrMensagemAsync(name);
            
            
            return View(await _meuServico.ReceberMensagemAsync(name));



        }

        
    }
}
