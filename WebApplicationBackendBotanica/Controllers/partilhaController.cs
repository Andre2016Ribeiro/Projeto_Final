using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBackendBotanica.MeusServicos;

namespace WebApplicationBackendBotanica.Controllers
{
    public class partilhaController : Controller
    {
        private readonly MeuServicoAzure _blobStorage;
        public partilhaController(MeuServicoAzure blobStorage)
        {
            _blobStorage = blobStorage;
        }
        // GET: partilhaController
        public async Task<IActionResult> Index()
        {
            return View(await _blobStorage.GetAllBlobFiles());
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile files)
        {
            await _blobStorage.UploadBlobFileAsync(files);
            return RedirectToAction("Index", "partilha");
        }

        public async Task<IActionResult> Delete(string blobName)
        {
            await _blobStorage.DeleteDocumentAsync(blobName);
            return RedirectToAction("Index", "partilha");
        }
    }
}
