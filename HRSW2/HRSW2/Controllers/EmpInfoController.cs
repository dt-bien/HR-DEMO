using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRSW2.Entities;
using HRSW2.Models;
using Newtonsoft.Json;
using System.IO;
using HRSW2.DatabaseContext;
using Microsoft.AspNetCore.Cors;

namespace HRSW2.Controllers
{
    public class EmpInfoController : Controller
    {
        private readonly HrDbContext _context;

        public EmpInfoController(HrDbContext context)
        {
            _context = context;
        }

        // GET: EmpInfo
        public IActionResult Index()
        {
            //var hrDbContext = _context.EmpInfo.Include(e => e.Position);
            return View();
        }
        [EnableCors("MyPolicy")]
        public JsonResult GetAllEmployee()
        {
            var hrDbContext = _context.EmpInfo.Include(e => e.Position);
            return Json(hrDbContext);
        }

        // GET: EmpInfo/Details/5

        public IActionResult Details(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        [EnableCors("MyPolicy")]
        public JsonResult EmpDetails(int? id)
        {
            if (id == null)
            {
                return Json(new { Error = "Id Null" });
            }

            var empInfo =  _context.EmpInfo
                .Include(e => e.Position)
                .FirstOrDefault(m => m.Id == id);
            if (empInfo == null)
            {
                return Json(new { Error = "Not Found" });
            }
            else
            {
               
            }

            return Json(empInfo);
        }

        private byte[] GetImage(string base64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(base64String))
            {
                bytes = Convert.FromBase64String(base64String);
            }
            return bytes;
        }

        // GET: EmpInfo/Create
        public IActionResult Create()
        {
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "NamePos");
            return View();
        }

        // POST: EmpInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        public string Create( FileUpload empInfoFile )
        {
            EmpInfo oEmpInfo = JsonConvert.DeserializeObject<EmpInfo>(empInfoFile.empInfo);
            if ( empInfoFile.file != null)
            {
                using (var ms = new MemoryStream())
                {
                    empInfoFile.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oEmpInfo.Photo = fileBytes;
                    _context.EmpInfo.Add(oEmpInfo);
                   int result =  _context.SaveChanges();
                    if (result > 0)
                    {
                        return "Saved";
                    }
                    
                }
            }

            return "Failed";
        }

        // GET: EmpInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfo.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "Id", empInfo.PosId);
            return View(empInfo);
        }

        // POST: EmpInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmp,SocialNumber,Name,Age,Address,Photo,Updated,JoinDay,LeaveDay,PosId")] EmpInfo empInfo)
        {
            if (id != empInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpInfoExists(empInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "Id", empInfo.PosId);
            return View(empInfo);
        }

        // GET: EmpInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfo
                .Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // POST: EmpInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empInfo = await _context.EmpInfo.FindAsync(id);
            _context.EmpInfo.Remove(empInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpInfoExists(int id)
        {
            return _context.EmpInfo.Any(e => e.Id == id);
        }
    }
}
