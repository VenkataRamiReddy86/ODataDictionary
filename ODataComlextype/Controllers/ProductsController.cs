using Microsoft.AspNet.OData;
using ODataComlextype.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace ODataComlextype.Controllers
{
    public class ProductsController : ODataController
    {
        ProductsContext db = new ProductsContext();
        public ProductsController()
        {
            Product product = new Product()
            {
                Id = 1,
                Name="name",
                Price=9,
                Category="a"
            };
            db.Products.Add(product);
            db.SaveChanges();
        }
        private bool ProductExists(int key)
        {
            return db.Products.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var res= db.Products;
            return res;

        }
        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = db.Products.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
       
    }
}
