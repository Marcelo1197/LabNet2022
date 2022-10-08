using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Logic;
using Crud.NorthW.App.MVC.Models;

namespace Crud.NorthW.App.MVC.Controllers
{
    public class ShippersController : Controller
    {
        private ShippersLogic _logic = new ShippersLogic();

        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = _logic.GetAll().Select(s => new ShippersView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
            });
            if (TempData["ShipperAddedSuccessfully"] != null)
            {
                ViewBag.SuccessMessage = TempData["ShipperAddedSuccessfully"];
                TempData.Remove("ShipperAddedSuccessfully");
            }
            else if (TempData["ShipperUpdatedSuccessfully"] != null)
            {
                ViewBag.SuccessUpdatedMessage = TempData["ShipperUpdatedSuccessfully"];
                TempData.Remove("ShipperUpdatedSuccessfully");
            }
            else if (TempData["ShipperDeletedSuccessfully"] != null)
            {
                ViewBag.SuccessDeletedMessage = TempData["ShipperDeletedSuccessfully"];
                TempData.Remove("ShipperDeletedSuccessfully");
            }
            return View(shippers);
        }

        public ActionResult Find(int id)
        {
            var shipper = _logic.Get(id);
            return View(shipper);
        }

        // GET: Shippers/Add
        public ActionResult Add()
        {
            return View("AddUpdate");
        }

        // POST: Shippers/Add
        [HttpPost]
        public ActionResult Add(ShippersView shippersView)
        {
            try
            {
                var shippersEntity = new Shippers
                {
                    CompanyName = shippersView.CompanyName,
                };
                _logic.Add(shippersEntity);
                TempData["ShipperAddedSuccessfully"] = $"El shipper {shippersEntity.CompanyName} se creo con éxito!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Update(ShippersView shipperWithNewData)
        {
            try
            {
                var shipperUpdated = _logic.Get(shipperWithNewData.ShipperID);
                shipperUpdated.CompanyName = shipperWithNewData.CompanyName;
                _logic.Update(shipperUpdated);
                TempData["ShipperUpdatedSuccessfully"] = $"El Shipper #{shipperUpdated.ShipperID} se actualizó con éxito!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var shipperDeleted = _logic.Get(id);
                _logic.Delete(shipperDeleted);
                TempData["ShipperDeletedSuccessfully"] = $"El Shipper #{shipperDeleted.ShipperID} se eliminó con éxito!";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView { 
                    ErrorMessage = "No podemos eliminar este shipper porque tiene órdenes asociadas :(" 
                });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView { ErrorMessage = ex.Message });
            }
        }
    }
}