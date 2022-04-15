using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using WebApplication.Service;
using WebApplication.Model;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using WebApplication.Common;
using WebApplication.Service.Common;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        static List<Product> products = new List<Product>();
        static List<Product> sqlProducts = new List<Product>();

        public static string connectionString = @"Data Source=DESKTOP-KKL4FN6\SQLEXPRESS;Initial Catalog = vjezba; Integrated Security = True";

        protected IProductService Service { get; private set; }
        public ProductController(IProductService service)
        {
            Service = service;

        }

        //GET naredbe 

        //get - multilayer - dependancy injection
        [HttpGet]
        [Route("webapi/getbyidmultilayer")]

        public async Task<HttpResponseMessage> GetProductAsync(Guid id)
        {
            //ProductService productService = new ProductService();
            
            var modelProducts = await Service.GetProductAsync(id);

            if (modelProducts == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, modelProducts);
            }


        }

        [HttpGet]
        [Route("webapi/getallmultilayer")]

        public async Task<HttpResponseMessage> GetAllProducts()
        {
            var products = await Service.GetAllProductsServiceAsync();
            if (products == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }

        }
   


        //get - webapi
        [HttpGet]
        [Route("webapi/getsqlproduct")]
        public async Task<HttpResponseMessage> GetTableContentAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Product", connection);

                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Product product = new Product();
                    product.Price = reader.GetDecimal(0);
                    product.Name = reader.GetString(1);
                    product.Id = reader.GetGuid(2);
                    product.Stock = reader.GetInt32(3);
                    product.CountryOfOrigin = reader.GetString(4);
                    sqlProducts.Add(product);

                }
            }
         //connection.Close();
         return Request.CreateResponse(HttpStatusCode.OK, sqlProducts);

        }

        //get - webapi

        [HttpGet]
        [Route("webapi/getsqlhaving")]

        public async Task<HttpResponseMessage> GetProductPriceOverXAsync(decimal price)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Product GROUP BY Price HAVING Price > {price}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
            }
            return Request.CreateResponse(HttpStatusCode.OK, sqlProducts);



        }

        //get - webapi
        [HttpGet]
        [Route("webapi/getsqlproductbyid")]

        public async Task<HttpResponseMessage> GetProductByIdAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Product WHERE Id ='{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();


                while (await reader.ReadAsync())
                {
                    Product product = new Product();
                    product.Price = reader.GetDecimal(0);
                    product.Name = reader.GetString(1);
                    product.Id = reader.GetGuid(2);
                    product.Stock = reader.GetInt32(3);
                    product.CountryOfOrigin = reader.GetString(4);
                    sqlProducts.Add(product);

                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, sqlProducts);
        }

        //get - webapi

        // GET: api/Product
        [HttpGet]

        [Route("webapi/getproduct")]
        public HttpResponseMessage FindProductInfo(Guid productId)
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

        //get - webapi
        // GET: api/Product/5
        [HttpGet]

        [Route("products/under50")]
        public HttpResponseMessage FindProductsUnderXEuro(decimal price)
        {
            List<Product> cheapProducts = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Price < price)
                {
                    cheapProducts.Add(product);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, cheapProducts);
        }

        // POST naredbe

        //post - multilayer - dependancy injection

        [HttpPost]
        [Route("webapi/insertproductmla")]

        //ovdje dobijem error da ne mogu pretvoriti varchar u numeric kada pokusam upisati cijenu(decimal)
        //inace uspije ubaciti novi product
        //rjeseno, pogledaj put tj. update price metodu
        
        public async Task<HttpResponseMessage> InsertProductMlaAsync (ProductModel product)
        {
           

            if (product != null)
            {
                await Service.InsertProductAsync(product);
                return Request.CreateResponse(HttpStatusCode.OK, $"A new product with the name {product.Name} has been inserted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        //post - data adapter
        [HttpPost]

        [Route("webapi/populatedataset")]
        public HttpResponseMessage PopulateDataset()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string adapterString = "SELECT * FROM Product";
                SqlDataAdapter myAdapter = new SqlDataAdapter(adapterString, connectionString);
                DataTable products = new DataTable();
                myAdapter.Fill(products);
                return Request.CreateResponse(HttpStatusCode.OK, products.Rows);
                // mozes returnat products.Rows
            }

        }

        //post - webapi

        [HttpPost]

        [Route("product/addproduct")]
        public HttpResponseMessage AddNewProduct(Product newProduct)
        {
            if (newProduct != null)
            {
                products.Add(newProduct);
                return Request.CreateResponse(HttpStatusCode.OK, $"A new product {newProduct.Name} has been added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"You haven't entered anything!");
            }


        }

        //post - webapi

        [HttpPost]

        [Route("webapi/insertproductsql")]

        public async Task<HttpResponseMessage> InsertProductAsync(Product product)

        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand($"INSERT INTO Product (Price, Title, Stock, CountryOfOrigin) VALUES ('{product.Price}','{product.Name}', {product.Stock}, '{product.CountryOfOrigin}');", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

            }
            return Request.CreateResponse(HttpStatusCode.OK, "Product has been added to the database!");
            }

        //post - adapter
        [HttpPost]
        [Route("webapi/insertproductadapter")]

        public async Task<HttpResponseMessage> InsertNewProductWithAdapterAsync(Product product)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection)
            { 
                await connection.OpenAsync();
                string newProductCommand = $"INSERT INTO Product (Price, Title, Stock, CountryOfOrigin) VALUES ('{product.Price}','{product.Name}', {product.Stock}, '{product.CountryOfOrigin}');";
            adapter.InsertCommand= new SqlCommand(newProductCommand, connection);

                await adapter.InsertCommand.ExecuteNonQueryAsync();
                connection.Close();

            }
            return Request.CreateResponse(HttpStatusCode.OK, "You have inserted a new product!");
        }



        //update - dependancy injection
        // PUT naredbe
  

        //put - multilayer
        [HttpPut]
        [Route("webapi/updatePriceMla")]

        public async Task<HttpResponseMessage> UpdatePriceMlaAsync ([FromUri]Guid productId, [FromUri]decimal newPrice)
        {
      
                
        await Service.UpdatePriceMlaAsync(productId, newPrice);

            return Request.CreateResponse(HttpStatusCode.OK, "The price has been updated!");

        }


        [HttpPut]
        [Route("product/sqlupdateprice")]

        public async Task<HttpResponseMessage> UpdatePriceAsync(Guid id, decimal newPrice)
        {

            string command = $"SELECT * FROM Product";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(command, connection);

            DataSet ds  = new DataSet();

            adapter.Fill(ds, "Product"); 

            DataTable dataTable = ds.Tables["Product"];

            dataTable.Rows[0]["Title"] = "Headphones";

            string sql = $"UPDATE Product SET Price='{newPrice}' WHERE Id ='{id}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            await connection.OpenAsync();
            SqlCommand cmd = new SqlCommand(sql, connection);
            sqlDataAdapter.UpdateCommand=cmd;
            adapter.Update(ds, "Product");
            return Request.CreateResponse(HttpStatusCode.OK, "The product has been updated!");



        }
        //webapi - webapi

        [HttpPut]
        [Route("product/updateprice")]
        public HttpResponseMessage UpdateProductPrice(Guid productId, decimal newPrice)
        {
            Product updatedProduct = products.Find(product => product.Id == productId);
            if (productId == updatedProduct.Id)
            {
                decimal oldPrice = updatedProduct.Price;
                updatedProduct.Price = newPrice;
                return Request.CreateResponse(HttpStatusCode.OK, $"The product price has been updated from {oldPrice} to {newPrice}");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The product that you're looking for isn't here!");

            }
        }

        
        // DELETE naredbe
        public Task<HttpResponseMessage> Delete(Guid productId)
        {
            Product soonToBeDeletedProduct = products.Find(product => product.Id == productId);
            if (productId == soonToBeDeletedProduct.Id)
            {
                products.Remove(soonToBeDeletedProduct);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, $"The product with the id {productId} has been deleted!"));
            }
            else
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound, $"The item with the id{productId} is not in our stock!"));
            }


        }

        [HttpDelete]

        [Route("webapi/deletesql")]

        //ne mozes obrisati tablice koje su povezane s drugom tablicom s foreign key osim sa cascadeom
        public async Task<HttpResponseMessage> DeleteSqlAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand($"DELETE FROM Product WHERE Id ='{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                    return Request.CreateResponse(HttpStatusCode.OK, "The item has been deleted!");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The item doesn't exist");
            }

            


        }



        //delete - dependancy injection
        [HttpDelete]

        [Route("webapi/deletesqlmla")]

        public async Task<HttpResponseMessage> DeleteAsyncDi(Guid id)
        {
            await Service.DeleteProductAsync(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Product has been deleted");
        }

    }
    public class ProductRest
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public int Stock { get; set; }
    }
}
