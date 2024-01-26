using Microsoft.Data.Sqlite;
using Cupcakes.Models;


namespace Cupcakes.Data
{
    public static class DbContext
    {
        public static Cupcake GetCupcakeById(int cupcakeId)
        {
            Cupcake cupcake = new Cupcake();

            SqliteConnection connection = new SqliteConnection("Data Source = Data/cupcakes.db");

            connection.Open();

            string sql = "SELECT CupcakeId, Name, Description, Price, ImageFilename from Cupcakes WHERE CupcakeId = @CupcakeId";

            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@CupcakeId", cupcakeId);

            SqliteDataReader reader = cmd.ExecuteReader();

            reader.Read();
            cupcake.CupcakeId = reader.GetInt32(0);
            cupcake.Name = reader.GetString(1);
            cupcake.Description = reader.GetString(2);
            cupcake.Price = reader.GetDecimal(3);
            if (!reader.IsDBNull(4))
            {
                cupcake.ImageFilename = reader.GetString(4);
            }

            connection.Close();

            return cupcake;
        }

        public static List<Cupcake> GetAllCupcakes()
        {
            List<Cupcake> cupcakes = new List<Cupcake>();

            SqliteConnection connection = new SqliteConnection("Data Source= Data/cupcakes.db");

            connection.Open();

            string sql = "SELECT CupcakeId, Name, Description, Price, ImageFilename from Cupcakes ORDER BY Name";

            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            SqliteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cupcake cupcake = new Cupcake();
                cupcake.CupcakeId = reader.GetInt32(0);
                cupcake.Name = reader.GetString(1);
                cupcake.Description = reader.GetString(2);
                cupcake.Price = reader.GetInt32(3);
                if (!reader.IsDBNull(4))
                {
                    cupcake.ImageFilename = reader.GetString(4);
                }

                cupcakes.Add(cupcake);
            }
            connection.Close();
            return cupcakes;
        }

        public static void AddNewCupcake(Cupcake cupcake)
        {
            SqliteConnection connection = new SqliteConnection("Data Source= Data/cupcakes.db");

            connection.Open();

            string sql = "INSERT INTO Cupcakes(Name, ImageFilename, Description, Price) VALUES (@Name, @ImageFilename, @Description, @Price)";
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Name", cupcake.Name);
            cmd.Parameters.AddWithValue("@ImageFilename", cupcake.ImageFilename);
            cmd.Parameters.AddWithValue("@Description", cupcake.Description);
            cmd.Parameters.AddWithValue("@Price", cupcake.Price);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteCupcake(int cupcakeId)
        {
            SqliteConnection connection = new SqliteConnection("Data Source= Data/cupcakes.db");

            connection.Open();

            string sql = "DELETE FROM Cupcakes WHERE CupcakeId = @CupcakeId";
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@CupcakeId", cupcakeId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}
