
using Microsoft.AspNet.OData;
using ODataComlextype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ODataComlextype.Controllers
{
    public class DefaultController : ODataController
    {
        ProductsContext db = new ProductsContext();
        
        [HttpGet]
        public List<Product> Get()
        {
            var res = db.Products;
            return res.ToList();

        }
    }
}
