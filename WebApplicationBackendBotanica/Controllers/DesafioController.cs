using Microsoft.AspNetCore.JsonPatch.Internal;
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

            ViewData["Enviadas"] = await _meuServico.ReceberrMensagemAsync();



            return View(await _meuServico.ReceberMensagemAsync());


            
        }

       

        [HttpGet]
        public async Task<IActionResult> Update(string Message)
        {
            await _meuServico.EnviarMensagemAsync(Message);

            ViewBag.Mensagem = "Foi enviada a Resposta: " + Message;
            return RedirectToAction("Index", "Desafio");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _meuServico.DeleteMenssagemAsync(id);
            return RedirectToAction("Index", "Desafio");
        }

        public async Task<IActionResult> Delete1(string id)
        {
            await _meuServico.DeleteMenssagemAsync1(id);
            return RedirectToAction("Index", "Desafio");
        }
    }
}
