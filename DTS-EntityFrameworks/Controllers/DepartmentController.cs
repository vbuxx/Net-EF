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
    public class DepartmentController : Controller
    {
        MyContext myContext;

        

        public DepartmentController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        //GET
        public IActionResult Index()
        {
            var data = myContext.Departments.Include(x=>x.Division).ToList();
            return View(data);
        }

        //READ BY ID
        //GET
        public IActionResult Detail(int Id)
        {
            var data = myContext.Departments
                .Where(x=>x.Id==Id)
                .Include(x => x.Division);
            return View(data);
        }


        //CREATE
        //GET
        public IActionResult Create()
        {
            SelectFromList createNew = new SelectFromList();
            createNew.Department = new Department();
            List<SelectListItem> divisions = myContext.Divisions
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name}).ToList();

            createNew.Divisions = divisions;
            return View(createNew);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                myContext.Departments.Add(department);
                if (myContext.SaveChanges()>0)
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
            editItem.Department = myContext.Departments.Where(x=>x.Id == Id).FirstOrDefault();
            List<SelectListItem> divisions = myContext.Divisions
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();

            editItem.Divisions = divisions;
            return View(editItem);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                myContext.Departments.Update(department);
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
            var data = myContext.Departments
               .Where(x => x.Id == Id)
               .Include(x => x.Division).FirstOrDefault();
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            if (ModelState.IsValid)
            {
                myContext.Departments.Remove(department);
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
