namespace SafeVault
{
    using Microsoft.Data.SqlClient;
    using Microsoft.SqlServer;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;
    using System.Web;

    public class SecureCode
    {

        public static string SanitizeInput(string userInput)
        {
            return HttpUtility.HtmlEncode(userInput);
        }

        // Validazione input
        public static string ValidateInput(string userInput)
        {
            if (!Regex.IsMatch(userInput, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ArgumentException("Input non valido: consentiti solo caratteri alfanumerici e underscore.");
            }
            return userInput;
        }

        // Query SQL sicura
        public static void GetUserData(string username)
        {
            try
            {
                username = ValidateInput(username);

                string connectionString = "your_connection_string_here";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"User: {reader["Username"]}");
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Errore di validazione: {ex.Message}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore nel database: {ex.Message}");
            }
        }
    }
}
