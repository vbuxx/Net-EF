using DTS_EntityFrameworks.Context;
using DTS_EntityFrameworks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS_EntityFrameworks.Controllers
{
    public class RegionController : Controller
    {
        MyContext myContext;



        public RegionController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        //GET
        public IActionResult Index()
        {
            var data = myContext.Regions.Include(x => x.Division).ToList();
            return View(data);
        }

        //READ BY ID
        //GET
        public IActionResult Details(int Id)
        {
            var data = myContext.Regions
                .Where(x => x.Id == Id)
                .Include(x => x.Division)
                .FirstOrDefault();
            return View(data);
        }


        //CREATE
        //GET
        public IActionResult Create()
        {
            SelectFromList createNew = new SelectFromList();
            createNew.Region = new Region();
            List<SelectListItem> divisions = myContext.Divisions
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();

            createNew.Divisions = divisions;
            return View(createNew);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                myContext.Regions.Add(region);
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

            SelectFromList editItem = new SelectFromList();
            editItem.Region = myContext.Regions.Where(x => x.Id == Id).FirstOrDefault();
            List<SelectListItem> divisions = myContext.Divisions
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();

            editItem.Divisions = divisions;
            return View(editItem);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Region region)
        {
            if (ModelState.IsValid)
            {
                myContext.Regions.Update(region);
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
            var data = myContext.Regions
               .Where(x => x.Id == Id)
               .Include(x => x.Division).FirstOrDefault();
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Region region)
        {
            if (ModelState.IsValid)
            {
                myContext.Regions.Remove(region);
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
