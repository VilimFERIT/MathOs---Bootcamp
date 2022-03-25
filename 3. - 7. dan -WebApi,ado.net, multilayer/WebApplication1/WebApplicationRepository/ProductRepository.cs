using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class ProductRepository
    {
      
        public static string connectionString = @"Data Source=DESKTOP-KKL4FN6\SQLEXPRESS;Initial Catalog = vjezba; Integrated Security = True";


        public List<ProductModel> GetProductById(Guid id)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Product WHERE Id ='{id}'", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<ProductModel> products = new List<ProductModel>();

                while (reader.Read())
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

        public void AddNewProduct(ProductModel newProduct)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                connection.Open();
                string newProductCommand = $"INSERT INTO Product(Title, Stock, CountryOfOrigin) VALUES('{newProduct.Name}', { newProduct.Stock}, '{newProduct.CountryOfOrigin}');";
                adapter.InsertCommand= new SqlCommand(newProductCommand, connection);
               adapter.InsertCommand.ExecuteNonQuery();
               
            }

        }
    }
}
