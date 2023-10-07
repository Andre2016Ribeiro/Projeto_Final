using Microsoft.AspNetCore.Mvc;
using BotanicaFrontEnd.MeusServicos;
using BotanicaFrontEnd.Models;
using Microsoft.AspNetCore.Authorization;

namespace BotanicaFrontEnd.Controllers
{
    [Authorize]
    public class BlobStorageController : Controller
    {
        private readonly MeuServicoAzure _servico;

        public BlobStorageController(MeuServicoAzure servico)
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
            return View(await _servico.GetAllBlobFiles());
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile files)
        {
            await _servico.UploadBlobAsync(files);
            ViewData["sucesso"] = await _servico.GetAllBlobFiles();

            
            

              
                return View("Sucesso");
            
        }
    }
}
