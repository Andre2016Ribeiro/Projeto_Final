using ClassBackendBotanica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotanicaFrontEnd.Controllers
{
    public class ArtigosController : Controller
    {// GET: ArtigosController
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");

            var result = await client.GetFromJsonAsync<List<Artigo>>("");

            return View(result);
        }

        // GET: ArtigosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");

            var result = await client.GetFromJsonAsync<Artigo>(id.ToString());


            return View(result);
        }

        // GET: ArtigosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtigosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artigo collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");

                await client.PostAsJsonAsync<Artigo>("", collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }


        // GET: ArtigosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");


            var result = await client.GetFromJsonAsync<Artigo>(id.ToString());
            return View(result);
        }

        // POST: ArtigosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artigo collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");

                await client.PutAsJsonAsync<Artigo>(id.ToString(), collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtigosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");


            var result = await client.GetFromJsonAsync<Artigo>(id.ToString());
            return View(result);
        }

        // POST: ArtigosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Artigo collection)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:5223/api/Artigos/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Artigos");
                await client.DeleteAsync(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
