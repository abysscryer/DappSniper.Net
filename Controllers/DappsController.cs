using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DappSniper.Net.Models;
using DappSniper.Net.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DappSniper.Net.Controllers
{
    public class DappsController : Controller
    {
        private readonly IDappService _dappService;

        public DappsController(IDappService dappService)
        {
            _dappService = dappService;
        }

        // GET: Dapps
        public async Task<IActionResult> Index(DappSearchModel searchModel)
        {
            var model = await _dappService.ListAsync(searchModel);
            return View(model);
        }
        
        // GET: Dapps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var model = await _dappService.GetAsync(id);
            return View(model);
        }

        // GET: Dapps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dapps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]DappCreateModel createModel)
        {

            if (ModelState.IsValid)
            {
                var isEffected = await _dappService.CreateAsync(createModel);

                return RedirectToAction(nameof(Index));
            }

            return View(createModel);
        }

        // GET: Dapps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _dappService.GetAsync(id);
            return View(result);
        }

        // POST: Dapps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm]DappUpdateModel updateModel)
        {
            if(ModelState.IsValid)
            {
                var isEffected = await _dappService.UpdateAsync(id, updateModel);

                return RedirectToAction(nameof(Index));
            }

                return View(updateModel);
        }

        // GET: Dapps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _dappService.GetAsync(id);
            return View(result);
        }

        // POST: Dapps/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [FromForm]DappDeleteModel deleteModel)
        {
            try
            {
                var isEffected = await _dappService.DeleteAsync(id, deleteModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}