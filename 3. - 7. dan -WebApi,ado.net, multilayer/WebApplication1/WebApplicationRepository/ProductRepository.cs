
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common;
using WebApplication.Model;
using WebApplication.Model.Common;
using WebApplication.Repository.Common;

namespace WebApplication.Repository
{
    public class ProductRepository : IProductRepository
    {

        public static string connectionString = @"Data Source=DESKTOP-KKL4FN6\SQLEXPRESS;Initial Catalog = vjezba; Integrated Security = True";

        //mla i async
        public async Task<List<IProductModel>> GetProductByIdAsync(Guid id)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Product WHERE Id ='{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IProductModel> products = new List<IProductModel>();

                while (await reader.ReadAsync())
                {
                    ProductModel product = new ProductModel();
                    product.Price = reader.GetDecimal(0);
                    product.Name = reader.GetString(1);
                    product.Id = reader.GetGuid(2);
                    product.Stock = reader.GetInt32(3);
                    product.CountryOfOrigin = reader.GetString(4);
                    products.Add(product);
                }
                return products;
            }

        }

        public async Task AddNewProductAsync(IProductModel newProduct)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                await connection.OpenAsync();
                string newProductCommand = $"INSERT INTO Product(Title, Stock, CountryOfOrigin) VALUES('{newProduct.Name}', { newProduct.Stock}, '{newProduct.CountryOfOrigin}');";
                adapter.InsertCommand = new SqlCommand(newProductCommand, connection);
                await adapter.InsertCommand.ExecuteNonQueryAsync();

            }

        }

        public async Task UpdateProductPriceAsync(Guid productId, decimal newPrice)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = connection.CreateCommand();

            using (connection)
            {
                await connection.OpenAsync();
                string updateProductPriceCommand = $"UPDATE Product SET Price = @NewPrice WHERE Id = '{productId}'";

                adapter.InsertCommand = new SqlCommand(updateProductPriceCommand, connection);
                adapter.InsertCommand.Parameters.Add("@NewPrice", System.Data.SqlDbType.Decimal).Value = newPrice;
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                //   
            }
        }

        public async Task<List<IProductModel>> GetAllProductsAsync()


        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand("SELECT * FROM Product", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<IProductModel> products = new List<IProductModel>();
                    while (await reader.ReadAsync())
                    {
                        ProductModel product = new ProductModel();
                        product.Price = reader.GetDecimal(0);
                        product.Name = reader.GetString(1);
                        product.Id = reader.GetGuid(2);
                        product.Stock = reader.GetInt32(3);
                        product.CountryOfOrigin = reader.GetString(4);
                        products.Add(product);
                    }
                    return products;
                
                
            }
        }

        public async Task DeleteProductAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"DELETE FROM Product WHERE	Id = '{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
        
            }

        }
    }
}
        


    

