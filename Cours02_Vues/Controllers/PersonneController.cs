using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cours02_Vues.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cours02_Vues.Controllers
{
    public class PersonneController : Controller
    {
        private static List<Personne> Donnnees = new List<Personne>();

        private static List<SelectListItem> listePays = new List<SelectListItem>();

        static PersonneController()
        {
            for (int i = 0; i<=10; i++)
            {
                Donnnees.Add(new Personne() { IdPersonne = i+1, Nom = "Nom"+i, Prenom="Prenom"+i, Age=i+30, Pays= RandomPays() });
            }
            listePays.Add(new SelectListItem() { Text = "France", Value = "1" });
            listePays.Add(new SelectListItem() { Text = "Brazil", Value = "2" });
            listePays.Add(new SelectListItem() { Text = "Canada", Value = "3" });
            listePays.Add(new SelectListItem() { Text = "Etat Unis", Value = "4" });


        }

        private static int RandomPays()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 5); // creates a number between 1 and 12
            return value;
        }
        
        

        // GET: Personne
        public ActionResult Index()
        {
            ViewData["Title"] = "Asp Mvc";
            return View(Donnnees);
        }

        // GET: Personne/Details/5
        public ActionResult Details(int id)
        {
            Personne personne = Donnnees.Where(p => p.IdPersonne == id).FirstOrDefault();
            return View(personne);
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            //Personne personne = new Personne();
            ViewBag.listesPays = listePays;
            return View();
        }

        // POST: Personne/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personne personne)
        {
            try
            {
                // TODO: Add insert logic here
                personne.IdPersonne = Donnnees.Count + 1;
                Donnnees.Add(personne);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(int id)
        {
            Personne  personne = Donnnees.Where(p => p.IdPersonne == id).FirstOrDefault();
            if(personne!= null)
            {
                SelectListItem selectListItem=  listePays.Where(p => int.Parse(p.Value.Trim()) == personne.Pays).First();
                selectListItem.Selected = true;
                ViewBag.listesPays = listePays;
                return View(personne);
            }
            return View(new Personne());
        }

        // POST: Personne/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Personne personne)
        {
            try
            {
                Personne lpersonne = Donnnees.Where(p => p.IdPersonne == id).FirstOrDefault();
                lpersonne.Age = personne.Age;
                lpersonne.Nom = personne.Nom;
                lpersonne.Prenom = personne.Prenom;
                lpersonne.Pays = personne.Pays;
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personne/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}