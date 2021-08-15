using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoClinica.Data;
using ProyectoClinica.Models;

namespace ProyectoClinica.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiagnosisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diagnosis
        public async Task<IActionResult> Index()
        {


            var applicationDbContext = _context.Diagnoses.Include(d => d.Patient);
            return View(await applicationDbContext.ToListAsync());
        }
        

        // GET: Diagnosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.IdDiagnosis == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        public IActionResult MenuDoctor()
        {

            return View();
        }      

        public async Task<IActionResult> Patients(string search)
        {
            if (search == null)
            {
                return View(await _context.Patients.ToListAsync());
            }

            return View(await _context.Patients.Where(p => p.Name.Contains(search)).ToListAsync());

            return View(await _context.Patients.ToListAsync());
        }

        // GET: Diagnosis/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: Diagnosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiagnosis,Symptoms,Exams,Prescription,PacienteId")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Diagnosis", new { @id = diagnosis.PacienteId.ToString() });
            }

            ViewData[" PacienteId "] = new SelectList(_context.Patients, " IdPaciente ", " IdPaciente ", diagnosis.PacienteId);

            return View(diagnosis);
        }

        // GET: Diagnosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente", diagnosis.PacienteId);
            return View(diagnosis);
        }

        // POST: Diagnosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiagnosis,Symptoms,Exams,Prescription,PacienteId")] Diagnosis diagnosis )
        {
            if (id != diagnosis.IdDiagnosis)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisExists(diagnosis.IdDiagnosis))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Diagnosis",new {@id= diagnosis.PacienteId.ToString()});
            }
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente", diagnosis.PacienteId);
            return View(diagnosis);
        }

        // GET: Diagnosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.IdDiagnosis == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // POST: Diagnosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Diagnosis", new { @id = diagnosis.PacienteId.ToString() });
        }

        private bool DiagnosisExists(int id)
        {
            return _context.Diagnoses.Any(e => e.IdDiagnosis == id);
        }
    }
}
