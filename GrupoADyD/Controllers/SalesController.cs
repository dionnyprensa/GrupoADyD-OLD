using GrupoADyD.Models;
using GrupoADyD.Models.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GrupoADyD.Controllers
{
    public class SalesController : Controller
    {
        private ClientRepository ClientRepository = new ClientRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        private ICollection<Product> ProductsTable = new List<Product>();
        private ICollection<Product> Duplicates = new List<Product>();
        private decimal TotalPV = 0;
        private decimal TotalBV = 0;
        private decimal TotalCost = 0;
        private decimal TotalPrice = 0;
        private decimal Total = 0;
        private short IndexProduct = 1;
        private decimal TotalPerProduct = 0;

        // GET: Sales
        public async Task<ActionResult> Index()
        {
            //var sales = db.Sales.Include(s => s.DetailedSale);
            return View(await db.Sales.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.Clients = new SelectList(db.Clients, "ClientId", "FirstName");

            //ViewBag.Products = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SaleId,Total,RowVersion,CreationDate,ModificationDate")] Sale sale)
        {
            ViewBag.SaleId = new SelectList(db.Clients, "ClientId", "FirstName"
                , sale.SaleId);

            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                await db.SaveChangesAsync();

                TotalPV = 0;
                TotalBV = 0;
                TotalCost = 0;
                TotalPrice = 0;
                Total = 0;

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(null, "Error");
                return View(sale);
            }
        }

        // GET: Sales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            ViewBag.SaleId = new SelectList(db.Clients, "ClientId", "FirstName"
                , sale.SaleId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SaleId,Total,RowVersion,CreationDate,ModificationDate")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SaleId = new SelectList(db.Clients, "ClientId", "FirstName"
                , sale.SaleId);

            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            db.Sales.Remove(sale);
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

        public ActionResult FindClientById(int Id)
        {
            return PartialView("_ClientSale", ClientRepository.FindById(Id));
        }

        public ActionResult FindProduct(string NameOrCode)
        {
            var productName = db.Products.FirstOrDefault(p => p.Name.Contains(NameOrCode));

            if (productName == null)
            {
                var productCode = db.Products.FirstOrDefault(p => p.Code == NameOrCode);

                return PartialView("_ProductSale", productCode);
            }
            else {
                return PartialView("_ProductSale", productName);
            }
        }

        public ActionResult AddProductToTable(string Code)
        {
            var product = db.Products.FirstOrDefault(p => p.Code == Code);

            ViewBag.HasProduct = (product.Code.ToString().Length > 1) ? true : false;

            if (ViewBag.HasProduct)
            {
                if (TempData["ProductsTable"] != null)
                {
                    ProductsTable = TempData["ProductsTable"] as List<Product>;

                    Total = Total + 1;
                }

                ProductsTable.Add(product);

                foreach (var e in Duplicates)
                {
                    var a = e.Code.ToString();
                }

                /*
                List<String> duplicates = lst.GroupBy(x => x)
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key)
                             .ToList();
                */

                TotalPV = product.PV;
                TotalBV = product.BV;
                TotalCost = product.Cost;
                TotalPrice = product.Price;

                //Total = product.Price;

                DataPersist();
            }

            return PartialView("_TableSale", ProductsTable);
        }

        void DataPersist()
        {
            if(TempData["TotalPV"] != null)
            {
                var tpv = TempData["TotalPV"];
                var tbv = TempData["TotalBV"];
                var tc = TempData["TotalCost"];
                var tp = TempData["TotalPrice"];
                var t = TempData["Total"];
                var tpr = TempData["TotalPerProduct"];

                TotalPV += (decimal)tpv;
                TotalBV += (decimal)tbv;
                TotalCost += (decimal)tc;
                TotalPrice += (decimal)tp;
                Total += (decimal)t;
                TotalPerProduct += (decimal)tpr;
            }

            TempData["TotalPV"] = TotalPV;
            TempData["TotalBV"] = TotalBV;
            TempData["TotalCost"] = TotalCost;
            TempData["TotalPrice"] = TotalPrice;
            TempData["Total"] = Total;
            TempData["TotalPerProduct"] = TotalPerProduct;
            TempData["IndexProduct"] = 1;
            TempData["ProductsTable"] = ProductsTable;
        }
    }
}