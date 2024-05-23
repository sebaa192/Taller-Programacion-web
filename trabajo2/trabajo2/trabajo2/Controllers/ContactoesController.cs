using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trabajo2.Models;

namespace trabajo2.Controllers
{
    public class ContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contactoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contactos.Include(c => c.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactoes/Create
        public IActionResult Create(int id)
        {
            ViewData["Cliente"] =  _context.Clientes.FirstOrDefault(m => m.ClienteId == id);
            return View();
        }


        [HttpPost]   
        
        public async Task<IActionResult> guardarContacto(int ContactoId, int ClienteId, string nombre, string telefono, string email)
        {
        
            Contacto contacto = new Contacto();
            contacto.ContactoId = ContactoId;
            contacto.ClienteId = ClienteId;
            contacto.Nombre = nombre;
            contacto.Telefono= telefono; ;
            contacto.Email = email;

            var cliente = await _context.Clientes.Include(c => c.Contactos).FirstOrDefaultAsync(m => m.ClienteId == ClienteId);
            contacto.Cliente = cliente;
            cliente.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = ContactoId });

         }










            // POST: Contactoes/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Contacto contacto)
        {
            ModelState.Remove("Cliente.Email");
            ModelState.Remove("Cliente.Nombre");
            ModelState.Remove("Cliente.Apellido");
            contacto.Cliente = _context.Clientes.FirstOrDefault(m => m.ClienteId == contacto.ClienteId);
         
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Clientes", new { id = contacto.ClienteId });
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", contacto.ClienteId);
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", contacto.ClienteId);
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoId,Nombre,Telefono,Email,ClienteId")] Contacto contacto)
        {
            if (id != contacto.ContactoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.ContactoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", contacto.ClienteId);
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.ContactoId == id);
        }
    }
}
