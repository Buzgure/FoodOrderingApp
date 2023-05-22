using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Restaurant.Repository
{
    public class UserRepository : Repository<User>
    {
        
        private string connString = "Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;";
        
        
        public User save(User entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand(
                            "INSERT INTO Users(username, pass, actual_name) VALUES (@username, @password, @name)", connection);
                   // command.Parameters.AddWithValue("@id", entity.UserId);
                    command.Parameters.AddWithValue("@username", entity.Username);
                    command.Parameters.AddWithValue("@password", entity.Password);
                    command.Parameters.AddWithValue("@name", entity.ActualName);
                    command.ExecuteNonQuery();
                    return entity;
                    
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public User delete(User entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                    connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE users_id = @id");
                command.Parameters.AddWithValue("@id", entity.UserId);
                command.ExecuteNonQuery();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public User update(User entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand(
                            "UPDATE Users SET username = @username, pass = @password, actual_name = @name WHERE users_id = @id ", connection);
                    command.Parameters.AddWithValue("@username", entity.Username);
                    command.Parameters.AddWithValue("@password", entity.Password);
                    command.Parameters.AddWithValue("@name", entity.ActualName);
                    command.Parameters.AddWithValue("@id", entity.UserId);
                    command.ExecuteNonQuery();
                    return entity;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public ICollection<User> findAll()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["users_id"]);
                        user.Username = Convert.ToString(reader["username"]);
                        user.Password = Convert.ToString(reader["pass"]);
                        user.ActualName = Convert.ToString(reader["actual_name"]);
                        users.Add(user);

                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return users;
        }

        public User findOne(int ID)
        {
            throw new NotImplementedException();
        }

        public User findUserByUserAndPass(string username, string password)
        {
            List<User> users = findAll().ToList();
            foreach (User u in users)
            {
                if(u.Username == username)
                    if (u.Password == password)
                    {
                        return u;
                    }
                    else
                    {
                       //todo 
                    }
                
            }

            return null;

        }
    }
}