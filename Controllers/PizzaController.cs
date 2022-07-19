using la_mia_pizzeria.DataBase;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        // GET: PizzasController
        public ActionResult Index()
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {

                List<Pizza> listPizzas = context.Pizzas.Include(p => p.Category).ToList();

                return View(listPizzas);
            }

        }

        // GET: PizzasController/Details/5
        public ActionResult Details(int id)
        {
            using(PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizza = context.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                return View(pizza);
            }
        }

        // GET: PizzasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza newPizza)
        {
            if (!ModelState.IsValid) return View(newPizza);

            using (PizzeriaContext context = new PizzeriaContext())
            {

                context.Pizzas.Add(newPizza);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }

        }

        // GET: PizzasController/Edit/5
        public ActionResult Edit(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizza = context.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizza == null) return NotFound();

                return View(pizza);
            }

        }

        // POST: PizzasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            if (!ModelState.IsValid) return View(pizza);

            using(PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizzaEdited = context.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizzaEdited == null) return NotFound();

                pizzaEdited.Name = pizza.Name;
                pizzaEdited.Description = pizza.Description;
                pizzaEdited.Image = pizza.Image;
                pizzaEdited.Price = pizza.Price;

                context.Update(pizzaEdited);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        //// GET: PizzasController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: PizzasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return NotFound();

            using (PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizza = context.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizza == null) return NotFound();

                context.Pizzas.Remove(pizza);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
