﻿using ClassBackendBotanica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotanicaFrontEnd.Controllers
{
    public class UtilizadoresController : Controller
    {
        // GET: UtilizadoresController
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");

            var result = await client.GetFromJsonAsync<List<Utilizador>>("");

            return View(result);
        }

        // GET: UtilizadoresController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");

            var result = await client.GetFromJsonAsync<Utilizador>(id.ToString());


            return View(result);
        }

        // GET: UtilizadoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilizadoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizador collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");

                await client.PostAsJsonAsync<Utilizador>("", collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }


        // GET: UtilizadoresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");


            var result = await client.GetFromJsonAsync<Utilizador>(id.ToString());
            return View(result);
        }

        // POST: UtilizadoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Utilizador collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");

                await client.PutAsJsonAsync<Utilizador>(id.ToString(), collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilizadoresController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
            //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");


            var result = await client.GetFromJsonAsync<Utilizador>(id.ToString());
            return View(result);
        }

        // POST: UtilizadoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Utilizador collection)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:5223/api/Utilizadores/");
                //client.BaseAddress = new Uri("https://populacaoapi.azurewebsites.net/api/Utilizadores");
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
