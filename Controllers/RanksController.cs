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
    public class RanksController : Controller
    {
        private readonly IRankService _rankService;

        public RanksController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet("/api/ranks")]
        public async Task<IActionResult> Ranks(RankSearchModel searchModel)
        {
            var model = await _rankService.RankAsync(searchModel);
            return Ok(model);
        }

        // GET: Ranks
        public async Task<IActionResult> Index(RankSearchModel searchModel)
        {
            var model = await _rankService.ListAsync(searchModel);
            return View(model);
        }

        // GET: Ranks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ranks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ranks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]RankCreateModel createModel)
        {
            try
            {
                var isEffected = await _rankService.CreateAsync(createModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(createModel);
            }
        }

        // GET: Ranks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _rankService.GetAsync(id);
            return View(result);
        }

        // POST: Ranks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm]RankUpdateModel updateModel)
        {
            if (ModelState.IsValid)
            {
                var isEffected = await _rankService.UpdateAsync(id, updateModel);

                return RedirectToAction(nameof(Index));
            }

            return View(updateModel);
        }

        // GET: Ranks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _rankService.GetAsync(id);
            return View(result);
        }

        // POST: Ranks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [FromForm]RankDeleteModel deleteModel)
        {
            try
            {
                var isEffected = await _rankService.DeleteAsync(id, deleteModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}