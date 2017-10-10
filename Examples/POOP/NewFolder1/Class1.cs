//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace POOP.NewFolder1
//{
//    public class Product
//    {
//        public Product(int id, string name, decimal price)
//        {
//            Id = id;
//            Name = name;
//            Price = price;
//        }
//        public int Id { get; }
//        public string Name { get; }
//        public decimal Price { get; }
//    }
//    public class DbProduct
//    {
//        private readonly int _productId;
//        private readonly SqlConnection _sqlConnection;

//        public DbProduct(int productId)
//            : this(productId, "MyDbConnectionString")
//        {
//        }
//        public DbProduct(int productId, string connectionString)
//            : this(productId, new SqlConnection(connectionString))
//        {
            
//        }
//        public DbProduct(int productId, SqlConnection sqlConnection)
//        {
//            _productId = productId;
//            _sqlConnection = sqlConnection;
//        }

//        public Product Content()
//        {
//                string query = $"SELECT * FROM {nameof(Product)} WHERE {nameof(Product.Id)} = @{nameof(Product.Id)}";
//                new SqlCommand(query, _sqlConnection)
                    
//                using (SqlCommand cmd =)
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Parameters.AddWithValue(nameof(Product.Id), _productId);  
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            return new Product(reader);
//                        }
//                        else
//                        {
//                            return null;
//                        }
//                    }
//                }
//        }
//    }

//    public class SelectCommand<T>
//    {
//        private readonly SqlConnection _sqlConnection;

//        public SelectCommand(SqlConnection sqlConnection)
//        {
//            _sqlConnection = sqlConnection;
//        }
//    }
//}
