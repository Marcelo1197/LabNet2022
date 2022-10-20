using Crud.NorthW.App.Common.Exceptions.WebApiExceptions;
using Crud.NorthW.App.Entities;
using Crud.NorthW.App.Logic;
using Crud.NorthW.App.WebAPI.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Crud.NorthW.App.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShippersController : ApiController
    {
        private ShippersLogic _logic = new ShippersLogic();

        // GET: api/Shippers
        public IHttpActionResult GetShippers() 
        {
            try
            {
                var shippers = _logic.GetAll().Select(s => new ShippersResponse
                {
                    ShipperID = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone
                });
                return Ok(shippers);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        // GET: api/Shippers/{id}
        public IHttpActionResult GetShipper(int id)
        {
            try
            {
                var shipperFinded = _logic.Get(id);
                if (shipperFinded == null)
                {
                    throw new ShipperNotExistsException();
                }
                var shipperFindedView = new ShippersResponse
                {
                    ShipperID = shipperFinded.ShipperID,
                    CompanyName = shipperFinded.CompanyName,
                    Phone = shipperFinded.Phone
                };
                return Ok(shipperFindedView);
            }
            catch (ShipperNotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        // POST: api/Shippers
        public IHttpActionResult AddShipper([FromBody] ShippersRequest shipper)
        {
            try
            {
                Shippers newShipper = new Shippers
                {
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                };
                _logic.Add(newShipper);
                return Content(HttpStatusCode.Created, newShipper);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        [System.Web.Http.HttpPut, EnableCors(origins: "*", headers: "*", methods: "*")]
        // PUT: api/Shippers
        public IHttpActionResult Edit([FromBody] ShippersRequest shipper)
        {
            try
            {
                var shipperUpdated = _logic.Get(shipper.ShipperID);
                if (shipperUpdated == null)
                {
                    throw new ShipperNotExistsException();
                }
                shipperUpdated.CompanyName = shipper.CompanyName;
                shipperUpdated.Phone = shipper.Phone;
                _logic.Update(shipperUpdated);
                return Content(HttpStatusCode.OK, shipperUpdated);
            }
            catch (ShipperNotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        // DELETE: api/Shippers/{id}

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var shipperDeleted = _logic.Get(id);
                if (shipperDeleted == null)
                {
                    throw new ShipperNotExistsException();
                }
                _logic.RemoveOrderRelated(id);
                _logic.Delete(shipperDeleted);
                return Content(HttpStatusCode.OK, shipperDeleted);
            }
            catch (ShipperNotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message});
            }
            catch (DbUpdateException ex)
            {
                var error = "Para eliminar este shipper debes eliminar sus órdenes primero.";
                return Content(HttpStatusCode.Conflict, new { ErrorMessage = error });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

    }
}