using Microsoft.Data.SqlClient;
public class ProductCRUD
{
    private string connectionString = "Server = localhost; database = MyDB; User Id = SA ; Password = YourStrong@Password1 ; TrustServerCertificate = TRUE";
    // --- IGNORE ---
    public void CreateProduct(){
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("INSERT INTO Products (Name, Price) VALUES ('Sample Product', 9.99)", connection);
        command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine("Product Created");
    }

}

