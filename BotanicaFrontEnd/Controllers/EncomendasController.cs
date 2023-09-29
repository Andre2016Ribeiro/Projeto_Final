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
using System.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BotanicaFrontEnd.Controllers
{
    [Authorize]
    public class EncomendasController : Controller
    {
        private readonly HttpClient _context;
        public EncomendasController()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5223/api/Encomendas/");
            _context = client;
        }
        //string? name = User.Identity.Name;
        //User.Identity.GetUserId();
        // GET: EncomendasController
        public async Task<IActionResult> Index()
        {
            string? name = User.Identity.Name;


            return View(await _context.GetFromJsonAsync<List<Encomenda>>("GetByName/" + name));
        }

        // GET: EncomendasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var encomenda = await _context.GetFromJsonAsync<Encomenda>("GetBydetail/" + id.ToString());
            if (id == null || encomenda == null)
            {
                return NotFound();
            }



            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // GET: EncomendasController/Create
        public async Task<IActionResult> Create()
        {
            string? name = User.Identity.Name;


            
            return View( await _context.GetFromJsonAsync<Encomenda>("GetByNameCreate/" + name));
        }

        // POST: EncomendasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,DataEncomenda,UtilizadorId,ArtigoId")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                await _context.PostAsJsonAsync<Encomenda>("", encomenda);
                return RedirectToAction(nameof(Index));
            }
            return View(encomenda);
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
