using SkateShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkateShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sale()
        {
            List<Item> lista = new List<Item> { };
            _context.Accessories.Where(a => a.sale == true).ToList().ForEach(a=>lista.Add(new Item { Id=a.Id, img=a.img, name=a.name, price=a.price}));
            _context.Decks.Where(a => a.sale == true).ToList().ForEach(a => lista.Add(new Item { Id = a.Id, img = a.img, name = a.name, price = a.price }));
            _context.Trucks.Where(a => a.sale == true).ToList().ForEach(a => lista.Add(new Item { Id = a.Id, img = a.img, name = a.name, price = a.price }));
            _context.Wheels.Where(a => a.sale == true).ToList().ForEach(a => lista.Add(new Item { Id = a.Id, img = a.img, name = a.name, price = a.price }));
            return View(lista);
        }

        public ActionResult Completes()
        {
            var lista = _context.Completes.ToList();
            return View(lista);
        }

        public ActionResult Skateboard_Decks()
        {
            var lista = _context.Decks.ToList();   
            return View(lista);
        }

        public ActionResult Wheels()
        {
            var lista = _context.Wheels.ToList();
            return View(lista);
        }
        public ActionResult Trucks()
        {
            var lista = _context.Trucks.ToList();
            return View(lista);
        }
        public ActionResult Skate_Accessories()
        {
            var lista = _context.Accessories.ToList();
            return View(lista);

        }
        public ActionResult Redirect(string type)
        {
            return RedirectToAction("Index", type);
        }
        public ActionResult ShowItem(int id,string type)
        {
            switch (type)
            {
                case "Decks":
                    {
                        var x = _context.Decks.ToList().ElementAt(id-1);
                        Item tmp = new Item { Id = x.Id, name = x.name, price = x.price, img=x.img,info=x.info,sale=x.sale };
                        return View(tmp);
                    }
                case "Trucks":
                    {
                        var x = _context.Trucks.ToList().ElementAt(id-1);
                        Item tmp = new Item { Id = x.Id, name = x.name, price = x.price, img = x.img, info = x.info, sale = x.sale };
                        return View(tmp);
                    }
                case "Wheels":
                    {
                        var x = _context.Wheels.ToList().ElementAt(id-1);
                        Item tmp = new Item { Id = x.Id, name = x.name, price = x.price, img = x.img, info = x.info, sale = x.sale };
                        return View(tmp);
                    }
                case "Accessories":
                    {
                        var x = _context.Accessories.ToList().ElementAt(id-1);
                        Item tmp = new Item { Id = x.Id, name = x.name, price = x.price, img = x.img, info = x.info, sale = x.sale };
                        return View(tmp);
                    }
                case "Completes":
                    {
                        var x = _context.Completes.ToList().ElementAt(id - 1);
                        Item tmp = new Item { Id = x.Id, name = x.name, price = x.price, img = x.img, info = x.info};
                        return View(tmp);
                    }
                default:
                    {
                        return HttpNotFound();
                    }

            }
        }
    }
}