using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace HutInTheWoods.Data
{
    public class DataRepository
    {
        private const string ConnectionString = "server=127.0.0.1;uid=root;pwd=Mandark2;database=huts_in_the_woods";

        public IEnumerable<Hut> GetHutsForFirstPage()
        {
            var huts = new List<Hut>();

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.huts where huts_show_on_first_page = 1";
            command.CommandType = CommandType.Text;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    huts.Add(MapHut(reader));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return huts;
        }

        public IEnumerable<News> GetLatestNews(int count = 4)
        {
            var news = new List<News>();

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.news order by news_date desc limit @limit";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@limit", count);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    news.Add(MapNews(reader));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return news;
        }

        public Hut GetHutById(int id)
        {
            Hut hut = null;

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM huts_in_the_woods.huts where huts_id = @id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    hut = MapHut(reader);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return hut;
        }

        public News GetNewsById(int id)
        {
            News news = null;

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.news where news_id = @id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    news = MapNews(reader);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return news;
        }

        public IEnumerable<Hut> GetHuts()
        {
            var huts = new List<Hut>();

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.huts order by huts_name";
            command.CommandType = CommandType.Text;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    huts.Add(MapHut(reader));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return huts;
        }

        public IEnumerable<HutPicture> GetHutPicturesById(int hutId)
        {
            var pics = new List<HutPicture>();

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.huts_pictures where hp_huts_id = @id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", hutId);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pics.Add(MapHutPicture(reader));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return pics;
        }

        public IEnumerable<News> GetNews()
        {
            var news = new List<News>();

            var connection = new MySqlConnection(ConnectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from huts_in_the_woods.news order by news_date desc";
            command.CommandType = CommandType.Text;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    news.Add(MapNews(reader));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return news;
        }

        private Hut MapHut(MySqlDataReader reader)
        {
            return new Hut()
            {
                Id = reader.GetIntOrDefault("huts_id").Value,
                Name = reader.GetStringOrDefault("huts_name"),
                ShortDescription = reader.GetStringOrDefault("huts_short_description"),
                Description = reader.GetStringOrDefault("huts_description"),
                BigPicturePath = reader.GetStringOrDefault("huts_big_picture_path"),
            };
        }

        private News MapNews(MySqlDataReader reader)
        {
            return new News()
            {
                Id = reader.GetIntOrDefault("news_id").Value,
                Name = reader.GetStringOrDefault("news_name"),
                ShortDescription = reader.GetStringOrDefault("news_short_description"),
                Description = reader.GetStringOrDefault("news_description"),
                Path = reader.GetStringOrDefault("news_path"),
                Date = reader.GetDateTimeOrDefault("news_date").Value
            };
        }

        private HutPicture MapHutPicture(MySqlDataReader reader)
        {
            return new HutPicture()
            {
                Id = reader.GetIntOrDefault("hp_id").Value,
                Description = reader.GetStringOrDefault("hp_description"),
                Path = reader.GetStringOrDefault("hp_path"),
                HutId = reader.GetIntOrDefault("hp_huts_id").Value,
            };
        }
    }
}
