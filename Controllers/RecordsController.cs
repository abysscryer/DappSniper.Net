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
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        // GET: Records
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize = 10)
        {
            var model = await _recordService.ListAsync(pageNumber, pageSize);
            return View(model);
        }

        // GET: Records/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]RecordCreateModel createModel)
        {
            try
            {
                var isEffected = await _recordService.CreateAsync(createModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(createModel);
            }
        }

        // GET: Records/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _recordService.GetAsync(id);
            return View(result);
        }

        // POST: Records/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm]RecordUpdateModel updateModel)
        {
            try
            {
                var isEffected = await _recordService.UpdateAsync(id, updateModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _recordService.GetAsync(id);
            return View(result);
        }

        // POST: Records/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [FromForm]RecordDeleteModel deleteModel)
        {
            try
            {
                var isEffected = await _recordService.DeleteAsync(id, deleteModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}