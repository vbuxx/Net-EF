using DTS_EntityFrameworks.Context;
using DTS_EntityFrameworks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS_EntityFrameworks.Controllers
{
    public class DivisionController : Controller
    {
        MyContext myContext;

        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        //GET
        public IActionResult Index()
        {
            var data = myContext.Divisions.ToList();
            return View(data);
        }

        //READ BY ID
        //GET
        public IActionResult Detail(int Id)
        {
            var data = myContext.Divisions
                .Where(x => x.Id == Id);
            return View(data);
        }


        //CREATE
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisions.Add(division);
                if (myContext.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        //UPDATE
        //GET
        public IActionResult Edit(int Id)
        {
            var data = myContext.Divisions
               .Where(x => x.Id == Id);
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisions.Update(division);
                if (myContext.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        //DELETE
        //GET
        public IActionResult Delete(int Id)
        {
            var data = myContext.Divisions
               .Where(x => x.Id == Id);
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisions.Remove(division);
                if (myContext.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }


    }
}
