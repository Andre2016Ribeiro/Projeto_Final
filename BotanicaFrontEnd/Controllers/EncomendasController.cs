using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassBackendBotanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace BotanicaFrontEnd.Controllers
{
    public class EncomendasController : Controller
    {
        // GET: EncomendasController
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");

            var result = await client.GetFromJsonAsync<List<Encomenda>>("");

            return View(result);
        }

        // GET: EncomendasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");

            var result = await client.GetFromJsonAsync<Encomenda>(id.ToString());


            return View(result);
        }

        // GET: EncomendasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncomendasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Encomenda collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");

                await client.PostAsJsonAsync<Encomenda>("", collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }


        // GET: EncomendasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");


            var result = await client.GetFromJsonAsync<Encomenda>(id.ToString());
            return View(result);
        }

        // POST: EncomendasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Encomenda collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/" + id.ToString());
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");

                await client.PutAsJsonAsync<Encomenda>(id.ToString(), collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EncomendasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");


            var result = await client.GetFromJsonAsync<Encomenda>(id.ToString());
            return View(result);
        }

        // POST: EncomendasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Encomenda collection)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/encomendas");
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
