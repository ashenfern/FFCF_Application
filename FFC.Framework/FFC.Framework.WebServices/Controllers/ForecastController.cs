using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FFC.Framework.Data;
using FFC.Framework.WebServicesManager;

namespace FFC.Framework.WebServices.Controllers
{
    public class ForecastController : ApiController
    {
        private FFCEntities db = new FFCEntities();
        private ForecastManager fm = new ForecastManager();
        //private RManager rm = new RManager();

        // GET 
        //[Route("Forecast/{customerId}/orders/{orderId}")]
        [ActionName("ByProductDayTime")]
        public List<sp_Forecast_GetDailyTimeSpecificAvereageProductTransactions_Result> GetProducts(int day, int productId, int start, int end)
        {
            var result = fm.GetDailyTimeSpecificAvereageProductTransactions().Where( r => r.Day == day).ToList();
            return result;
        }

        [ActionName("TestForecast")]
        [System.Web.Http.HttpGet]
        public ForecastResult ForecastTest(int id)
        {
            var result = RManager.Fcast1();
            return result;
        }


        //    // GET api/Forecast
        //public IQueryable<Product> GetProducts()
        //{
        //    return db.Products;
        //}

        //                // GET api/Forecast/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult GetProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

        //// PUT api/Forecast/5
        //public IHttpActionResult PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.ProductID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Forecast
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        //}

        //// DELETE api/Forecast/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ProductID == id) > 0;
        //}
    }
}