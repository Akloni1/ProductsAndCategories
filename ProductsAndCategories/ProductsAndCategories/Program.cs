// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

String connectionString = "Server=DESKTOP-JUI9V07;Database=ProductsAndCategories;Trusted_connection=True";
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();
using (connection)
{

    string sqlCommand = "SELECT Product.ProductName,Category.NameCategory FROM ProductCategory" +
                        " RIGHT JOIN Product ON Product.IdProduct = ProductCategory.IdProduct" +
                        " LEFT JOIN Category ON Category.IdCategory = ProductCategory.IdCategory"; 


    SqlCommand command = new SqlCommand(sqlCommand, connection);
    SqlDataReader reader = command.ExecuteReader();
    using (reader)
    {
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine(reader[i] + "\t");
            }

            Console.WriteLine();
        }
    }
}