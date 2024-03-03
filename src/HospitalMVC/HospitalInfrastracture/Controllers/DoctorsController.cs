using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalDomain.Model;
using HospitalInfrastracture;

namespace HospitalInfrastracture.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DbhospitalContext _context;

        public DoctorsController(DbhospitalContext context)
        {
            _context = context;
        }

        /*public async Task<IActionResult> Index()
        {
            var dbhospitalContext = _context.Doctors.Include(d => d.Hospital).Include(d => d.Specialization);
            return View(await dbhospitalContext.ToListAsync());
        }*/

        // GET: Doctors
   /*     public async Task<IActionResult> Index()
        {
            *//*var dbhospitalContext = _context.Doctors.Include(d => d.Hospital).Include(d => d.Specialization);
            return View(await dbhospitalContext.ToListAsync());*/
            /*if (id == null)
            {*//*
                var dbhospitalContext = _context.Doctors.Include(d => d.Hospital).Include(d => d.Specialization);
            return View(await dbhospitalContext.ToListAsync());
                //return RedirectToAction("Hospitals", "Index");
           *//* }
            ViewBag.HospitalId = id;
            ViewBag.HospitalName = name;
            var doctorsByHospital = _context.Doctors.Where(x => x.HospitalId == id).Include(x => x.Hospital);
            return View(await doctorsByHospital.ToListAsync());*//*
        }*/

        public async Task<IActionResult> Index(int? id, string? name)
        {
            /*var dbhospitalContext = _context.Doctors.Include(d => d.Hospital).Include(d => d.Specialization);
            return View(await dbhospitalContext.ToListAsync());*/
            if (id == null)
            {
                var dbhospitalContext = _context.Doctors.Include(d => d.Hospital).Include(d => d.Specialization);
                return View(await dbhospitalContext.ToListAsync());
                //return RedirectToAction("Hospitals", "Index");
            }
            ViewBag.HospitalId = id;
            ViewBag.HospitalName = name;
            var doctorsByHospital = _context.Doctors.Where(x => x.HospitalId == id).Include(x => x.Hospital);
            return View(await doctorsByHospital.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Hospital)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "Adress");
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Experience,SpecializationId,HospitalId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "Adress", doctor.HospitalId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id", doctor.SpecializationId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "Adress", doctor.HospitalId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id", doctor.SpecializationId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Experience,SpecializationId,HospitalId")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "Adress", doctor.HospitalId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id", doctor.SpecializationId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Hospital)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
