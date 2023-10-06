using Microsoft.AspNetCore.Mvc;
using BotanicaFrontEnd.MeusServicos;
using BotanicaFrontEnd.Models;


namespace BotanicaFrontEnd.Controllers
{
    public class partilhaController : Controller
    {
        private readonly MeuServicoAzure _servico;

        public partilhaController(MeuServicoAzure servico)
        {
            _servico = servico;
        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            //Vista com um form com um elemento de input de tipo "file":
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile files)
        {
           
            await _servico.UploadBlobAsync(files);

            
            /*if () {*/

              
                return View("Sucesso");
            /*}
            return Content("Não foi recebido nenhum ficheiro!");*/
        }
    }
}
