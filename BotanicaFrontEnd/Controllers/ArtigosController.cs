using ClassBackendBotanica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotanicaFrontEnd.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly HttpClient _context;

        public ArtigosController()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
            _context = client;
        }

        // GET: ArtigosController
        public async Task<IActionResult> Index()
        {
            

            return View(await _context.GetFromJsonAsync<List<Artigo>>(""));
        }

        // GET: ArtigosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var artigo = await _context.GetFromJsonAsync<Artigo>(id.ToString());
            if (id == null || artigo == null)
            {
                return NotFound();
            }



            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        
    }
}
