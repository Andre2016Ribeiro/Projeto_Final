using ClassBackendBotanica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotanicaFrontEnd.Controllers
{
    public class ArtigosController : Controller
    {
        private IConfiguration _config;

        public ArtigosController(ILogger<ArtigosController> logger, IConfiguration config)
        {

            _config = config;



        }

        // GET: ArtigosController
        public async Task<IActionResult> Index()
        {
            

            HttpClient artigo = new HttpClient();

            artigo.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Artigos/");
            HttpClient categoria = new HttpClient();

            categoria.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Categorias/");
            ViewData["categoria"] = await categoria.GetFromJsonAsync<List<Categoria>>("");
            return View(await artigo.GetFromJsonAsync<List<Artigo>>(""));
        }

        // GET: ArtigosController/Details/5
        
        public async Task<IActionResult> Details(int id)
        {
            HttpClient artigo = new HttpClient();

            artigo.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Artigos/");

            var artigos = await artigo.GetFromJsonAsync<Artigo>(id.ToString());
            HttpClient categoria = new HttpClient();

            categoria.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Categorias/");
            ViewData["categoria"] = await categoria.GetFromJsonAsync<Categoria>(artigos.CategoriaId.ToString());
            if (id == null || artigos == null)
            {
                return NotFound();
            }



            if (artigos == null)
            {
                return NotFound();
            }

            return View(artigos);
        }

        
    }
}
