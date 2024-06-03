using Model;
using MVC;
using DBConfig;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RadarRepository
{
    public class RadarRepositoryClass : GenericMvcClass<Radar>
    {
        private SqlConnection connection;
        private Config _config;

        public RadarRepositoryClass()
        {
            string JsonFilePath = @"C:\5by5\radar-proj\MVC\DBConfig\query.json";

            try { _config = JsonLoader.LoadConfig(JsonFilePath); }
            catch (Exception e) { Console.WriteLine($"Falha ao sincronizar arquivo JSON {JsonFilePath}"); }

            connection = new SqlConnection("Data Source = 127.0.0.1; Initial Catalog=RadarDB; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True");
        }

        public override bool Delete(int id)
        {
            connection.Open();
            bool result = false;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Delete, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return (cmd.ExecuteNonQuery() > 0);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"-- ERRO AO DELETAR RADAR COM ID: {id}\n" +
                    $"{e.Message}");
            }
            finally { connection.Close(); }

            return result;
        }

        public override Radar? Get(int id)
        {
            connection.Open();
            Radar radar = null;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Get, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        radar.Id = reader.GetInt32(0);
                        radar.Concessionaria = reader.GetString(1);
                        radar.AnoDoPnvSnv = reader.GetString(2);
                        radar.TipoDeRadar = reader.GetString(3);
                        radar.Rodovia = reader.GetString(4);
                        radar.Uf = reader.GetString(5);
                        radar.Km_m = reader.GetString(6);
                        radar.Municipio = reader.GetString(7);
                        radar.TipoPista = reader.GetString(8);
                        radar.Sentido = reader.GetString(9);
                        radar.Situacao = reader.GetString(10);
                        radar.DataDaInativacao = reader.GetDateTime(11);
                        radar.Latitude = reader.GetString(12);
                        radar.Longitude = reader.GetString(13);
                        radar.VelocidadeLeve = reader.GetString(14);
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"-- ERRO AO BUSCAR RADAR COM ID: {id}\n" +
                    $"{e.Message}");
            }
            finally { connection.Close(); }

            return radar;
        }

        public override List<Radar> GetAll()
        {
            connection.Open();
            List<Radar> radarList = new();

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.GetAll, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Radar radar = new();
                        radar.Id = reader.GetInt32(0);
                        radar.Concessionaria = reader.GetString(1);
                        radar.AnoDoPnvSnv = reader.GetString(2);
                        radar.TipoDeRadar = reader.GetString(3);
                        radar.Rodovia = reader.GetString(4);
                        radar.Uf = reader.GetString(5);
                        radar.Km_m = reader.GetString(6);
                        radar.Municipio = reader.GetString(7);
                        radar.TipoPista = reader.GetString(8);
                        radar.Sentido = reader.GetString(9);
                        radar.Situacao = reader.GetString(10);
                        radar.DataDaInativacao = reader.GetDateTime(11);
                        radar.Latitude = reader.GetString(12);
                        radar.Longitude = reader.GetString(13);
                        radar.VelocidadeLeve = reader.GetString(14);

                        radarList.Add(radar);
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("-- ERRO DURANTE A BUSCA:" +
                    $"{e.Message}");
            }
            finally { connection.Close(); }

            return radarList;
        }

        public override bool Insert(Radar entity)
        {
            connection.Open();
            bool result = false;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Insert, connection))
                {
                    cmd.Parameters.AddWithValue($"@Concessionaria", entity.Concessionaria);
                    cmd.Parameters.AddWithValue($"@AnoDoPnvSnv", entity.AnoDoPnvSnv);
                    cmd.Parameters.AddWithValue($"@TipoDeRadar", entity.TipoDeRadar);
                    cmd.Parameters.AddWithValue($"@Rodovia", entity.Rodovia);
                    cmd.Parameters.AddWithValue($"@Uf", entity.Uf);
                    cmd.Parameters.AddWithValue($"@Km_m", entity.Km_m);
                    cmd.Parameters.AddWithValue($"@Municipio", entity.Municipio);
                    cmd.Parameters.AddWithValue($"@TipoPista", entity.TipoPista);
                    cmd.Parameters.AddWithValue($"@Sentido", entity.Sentido);
                    cmd.Parameters.AddWithValue($"@Situacao", entity.Situacao);
                    cmd.Parameters.AddWithValue($"@DataDaInativacao", entity.DataDaInativacao);
                    cmd.Parameters.AddWithValue($"@Latitude", entity.Latitude);
                    cmd.Parameters.AddWithValue($"@Longitude", entity.Longitude);
                    cmd.Parameters.AddWithValue($"@VelocidadeLeve", entity.VelocidadeLeve);

                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine("-- ERRO AO INSERIR RADAR:" +
                    $"{e.Message}");
            }
            finally { connection.Close(); }

            return result;
        }

        public override bool InsertMany(List<Radar> entities)
        {
            connection.Open();
            bool result = false;

            try
            {
                for (int i = 0; i <= (int)Math.Floor((double)entities.Count / 1000); i++)
                {
                    using (SqlCommand cmd = new())
                    {
                        string insertQuery = _config.Sql.Query.InsertMany;

                        int paramIndex = 0;

                        foreach (var entity in entities.Skip(1000 * i).Take(1000))
                        {
                            if (entity.Concessionaria != null)
                            {
                                insertQuery += $"\n('{entity.Concessionaria}', " +
                                    $"'{entity.AnoDoPnvSnv}', " +
                                    $"'{entity.TipoDeRadar}'," +
                                    $"'{entity.Rodovia}', " +
                                    $"'{entity.Uf}', " +
                                    $"'{entity.Km_m}', " +
                                    $"'{entity.Municipio}', " +
                                    $"'{entity.TipoPista}', " +
                                    $"'{entity.Sentido}', " +
                                    $"'{entity.Situacao}'," +
                                    $"'{entity.DataDaInativacao}', " +
                                    $"'{entity.Latitude}', " +
                                    $"'{entity.Longitude}', " +
                                    $"'{entity.VelocidadeLeve}'),";
                            }
                        }

                        cmd.CommandText = insertQuery.Substring(0, insertQuery.Length - 1);
                        cmd.Connection = connection;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine($"--ERRO AO INSERIR QUERY SQL:\n" +
                                              $"cod.: {e.ErrorCode}\n" +
                                              $"msg: {e.Message}\n");
                        }
                        finally { cmd.Parameters.Clear(); }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"--ERRO AO PROCESSAR INSERÇÃO EM MASSA:\n" +
                                  $"msg: {e.Message}\n");
            }
            finally { connection.Close(); }

            return result;
        }

        public override bool Update(Radar entity)
        {
            connection.Open();
            bool result = false;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Update, connection))
                {
                    cmd.Parameters.AddWithValue($"@Concessionaria", entity.Concessionaria);
                    cmd.Parameters.AddWithValue($"@AnoDoPnvSnv", entity.AnoDoPnvSnv);
                    cmd.Parameters.AddWithValue($"@TipoDeRadar", entity.TipoDeRadar);
                    cmd.Parameters.AddWithValue($"@Rodovia", entity.Rodovia);
                    cmd.Parameters.AddWithValue($"@Uf", entity.Uf);
                    cmd.Parameters.AddWithValue($"@Km_m", entity.Km_m);
                    cmd.Parameters.AddWithValue($"@Municipio", entity.Municipio);
                    cmd.Parameters.AddWithValue($"@TipoPista", entity.TipoPista);
                    cmd.Parameters.AddWithValue($"@Sentido", entity.Sentido);
                    cmd.Parameters.AddWithValue($"@Situacao", entity.Situacao);
                    cmd.Parameters.AddWithValue($"@DataDaInativacao", entity.DataDaInativacao);
                    cmd.Parameters.AddWithValue($"@Latitude", entity.Latitude);
                    cmd.Parameters.AddWithValue($"@Longitude", entity.Longitude);
                    cmd.Parameters.AddWithValue($"@VelocidadeLeve", entity.VelocidadeLeve);

                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-- ERRO AO ATUALIZAR RADAR:" +
                    $"{e.Message}");
            }
            finally { connection.Close(); }

            return result;
        }
    }
}
