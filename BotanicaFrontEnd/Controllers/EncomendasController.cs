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
using System.Dynamic;

namespace BotanicaFrontEnd.Controllers
{
    [Authorize]
    public class EncomendasController : Controller
    {
        private IConfiguration _config;
        
        public EncomendasController(ILogger<EncomendasController> logger, IConfiguration config)
        { 
            
            _config = config;
           

           
        }

        
            

        
        
        //string? name = User.Identity.Name;
        //User.Identity.GetUserId();
        // GET: EncomendasController
        public async Task<IActionResult> Index()
        {
            string? name = User.Identity.Name;
            
            HttpClient encomenda = new HttpClient();

            encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");
            

            return View(await encomenda.GetFromJsonAsync<List<Encomenda>>("GetByName/" + name));
        }

        // GET: EncomendasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpClient encomenda = new HttpClient();

            encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");

            var encomendas = await encomenda.GetFromJsonAsync<Encomenda>("GetBydetail/" + id.ToString());
            if (id == null || encomendas == null)
            {
                return NotFound();
            }



            if (encomendas == null)
            {
                return NotFound();
            }

            return View(encomendas);
        }

        // GET: EncomendasController/Create
        public async Task<IActionResult> Create()
        {
            string? name = User.Identity.Name;
            HttpClient utilizador = new HttpClient();

            utilizador.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Utilizadores/");


            ViewData["Utilizador"] = await utilizador.GetFromJsonAsync<Utilizador>("GetByNames/" + name);
            
            return View();
        }

        // POST: EncomendasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,DataEncomenda,UtilizadorId,ArtigoId")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                HttpClient encomendas = new HttpClient();

                encomendas.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");

                await encomendas.PostAsJsonAsync<Encomenda>("", encomenda);
                return RedirectToAction(nameof(Index));
            }
            return View(encomenda);
        }


        // GET: EncomendasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient encomenda = new HttpClient();

            encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");


            var result = await encomenda.GetFromJsonAsync<Encomenda>("GetBydetail/" + id.ToString());
            return View(result);
        }

        // POST: EncomendasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Encomenda collection)
        {
            try
            {
                HttpClient encomenda = new HttpClient();

                encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");

                await encomenda.PutAsJsonAsync<Encomenda>(id.ToString(), collection);
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
            HttpClient encomenda = new HttpClient();

            encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");

            var result = await encomenda.GetFromJsonAsync<Encomenda>("GetBydetail/" + id.ToString());
            return View(result);
        }

        // POST: EncomendasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Encomenda collection)
        {
            try
            {
                HttpClient encomenda = new HttpClient();

                encomenda.BaseAddress = new Uri(_config.GetValue<string>("con") + "/Encomendas/");


                await encomenda.DeleteAsync(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
