using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using GrupoADyD.Models;
using System;
using GrupoADyD.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GrupoADyD.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientViewModel ClientViewModel)
        {
            var client = new Client
            {
                ClientId = 1,
                FirstName = ClientViewModel.FirstName,
                LastName = ClientViewModel.LastName,
                Phone = ClientViewModel.Phone,
                Discount = ClientViewModel.Discount,
                ToCost = ClientViewModel.ToCost,
                Direction = ClientViewModel.Direction,
                CreatedBy = HttpContext.User.Identity.Name.ToString(),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            if (ModelState.IsValid)
            {

                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "No se puede crear.");
            return View(client);
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = await db.Clients.FindAsync(id);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        
        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClientViewModel ClientViewModel)
        {
            var client = new Client
            {
                //ClientId = 1,
                FirstName = ClientViewModel.FirstName,
                LastName = ClientViewModel.LastName,
                Phone = ClientViewModel.Phone,
                Discount = ClientViewModel.Discount,
                ToCost = ClientViewModel.ToCost,
                Direction = ClientViewModel.Direction,
                CreatedBy = HttpContext.User.Identity.Name.ToString(),
                ModificationDate = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = await db.Clients.FindAsync(id);


            var ClientViewModel = new ClientViewModel
            {
                //ClientId = 1,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Discount = client.Discount,
                ToCost = client.ToCost,
                Direction = client.Direction
            };

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(ClientViewModel);
        }
        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
