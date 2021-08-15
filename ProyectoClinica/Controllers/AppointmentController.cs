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
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Patients()
        {
            return View(await _context.Patients.ToListAsync());
        }

        public async Task<IActionResult> AllAppointments()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.IdAppointment == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAppointment,DateAppo,PacienteId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Appointment", new { @id = appointment.PacienteId.ToString() });
            }
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente", appointment.PacienteId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente", appointment.PacienteId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAppointment,DateAppo,PacienteId")] Appointment appointment)
        {
            if (id != appointment.IdAppointment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.IdAppointment))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Appointment", new { @id = appointment.PacienteId.ToString() });
            }
            ViewData["PacienteId"] = new SelectList(_context.Patients, "IdPaciente", "IdPaciente", appointment.PacienteId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.IdAppointment == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Appointment", new { @id = appointment.PacienteId.ToString() });
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.IdAppointment == id);
        }
    }
}
