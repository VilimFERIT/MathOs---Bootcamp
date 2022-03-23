using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ProductController : ApiController
    {
        static List<Product> products = new List<Product>();
        // GET: api/Product
        [HttpGet]

        [Route("webapi/getproduct")]
        public HttpResponseMessage FindProductInfo( Guid productId)
        {
            Product foundProduct = products.Find(product => product.Id == productId);
            if (productId == foundProduct.Id)
            {
                return Request.CreateResponse(HttpStatusCode.Found, foundProduct);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"The item with the id{productId} is not in our stock!");
            }
        }

        //test

        // GET: api/Product/5
        [HttpGet]

        [Route("products/under50")]
        public HttpResponseMessage FindProductsUnder50Euro()
        {
            List<Product> cheapProducts = new List<Product>();
            foreach(Product product in products)
            {
                if(product.Price<50)
                {
                    cheapProducts.Add(product);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, cheapProducts);
        }

        // POST: api/Product

        [HttpPost]

        [Route("product/addproduct")]
        public HttpResponseMessage AddNewProduct(Product newProduct)
        {
            if(newProduct!=null)
            {
                products.Add(newProduct);
                return Request.CreateResponse(HttpStatusCode.OK, $"A new product {newProduct.Name} has been added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"You haven't entered anything!");
            }


        }

        // PUT: api/Product/5

        [HttpPut]

        [Route("product/updateprice")]
        public HttpResponseMessage UpdateProductPrice(Guid productId, double newPrice)
        {
            Product updatedProduct = products.Find(product => product.Id == productId);
            if (productId==updatedProduct.Id)
            {
                double oldPrice=updatedProduct.Price;
                updatedProduct.Price = newPrice;
                return Request.CreateResponse(HttpStatusCode.OK, $"The product price has been updated from {oldPrice} to {newPrice}");
               
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The product that you're looking for isn't here!");

            }
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(Guid productId)
        {
            Product soonToBeDeletedProduct = products.Find(product => product.Id == productId);
            if (productId == soonToBeDeletedProduct.Id)
            {
                products.Remove(soonToBeDeletedProduct);
                return Request.CreateResponse(HttpStatusCode.OK, $"The product with the id {productId} has been deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"The item with the id{productId} is not in our stock!");
            }
        }
    }
}
