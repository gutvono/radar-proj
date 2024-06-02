using Model;
using MVC;
using DBConfig;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class RadarRepository : GenericMvcClass<Radar>
    {
        SqlConnection connection;
        private readonly Config _config;

        public RadarRepository()
        {
            connection = new(_config.Sql.ConnectionString);
            connection.Open();
        }

        public override bool Delete(int id)
        {
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
            Radar radar = null;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Get, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        radar = new Radar();
                        radar.Id = reader.GetInt32(0);
                        radar.Concessionaria = reader.GetString(1);
                        radar.Rodovia = reader.GetString(2);
                        radar.Uf = reader.GetString(3);
                        radar.Km_m = reader.GetString(4);
                        radar.Municipio = reader.GetString(5);
                        radar.TipoPista = reader.GetString(6);
                        radar.Sentido = reader.GetString(7);
                        radar.DataDaInativacao = reader.GetDateTime(8);
                        radar.Latitude = reader.GetString(9);
                        radar.Longitude = reader.GetString(10);
                        radar.VelocidadeLeve = reader.GetString(11);
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
                        radar.Rodovia = reader.GetString(2);
                        radar.Uf = reader.GetString(3);
                        radar.Km_m = reader.GetString(4);
                        radar.Municipio = reader.GetString(5);
                        radar.TipoPista = reader.GetString(6);
                        radar.Sentido = reader.GetString(7);
                        radar.DataDaInativacao = reader.GetDateTime(8);
                        radar.Latitude = reader.GetString(9);
                        radar.Longitude = reader.GetString(10);
                        radar.VelocidadeLeve = reader.GetString(11);

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
            bool result = false;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Insert, connection))
                {
                    cmd.Parameters.AddWithValue($"@Concessionaria", entity.Concessionaria);
                    cmd.Parameters.AddWithValue($"@AnoDoPnvSnv", entity.AnoDoPnvSnv);
                    cmd.Parameters.AddWithValue($"@Rodovia", entity.Rodovia);
                    cmd.Parameters.AddWithValue($"@Uf", entity.Uf);
                    cmd.Parameters.AddWithValue($"@Km_m", entity.Km_m);
                    cmd.Parameters.AddWithValue($"@Municipio", entity.Municipio);
                    cmd.Parameters.AddWithValue($"@TipoPista", entity.TipoPista);
                    cmd.Parameters.AddWithValue($"@Sentido", entity.Sentido);
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
            bool result = false;

            try
            {
                for (int i = 0; i <= (int)Math.Floor((double)entities.Count / 1000); i++)
                {
                    using (SqlCommand cmd = new())
                    {
                        StringBuilder insertQuery = new();
                        insertQuery.Append(_config.Sql.Query.InsertMany);

                        int paramIndex = 0;

                        foreach (var entity in entities.Skip(1000 * i).Take(1000))
                        {
                            if (entity.Concessionaria != null)
                            {
                                if (paramIndex > 0) insertQuery.Append(", ");

                                insertQuery.Append($"(@Concessionaria{paramIndex}, " +
                                    $"@AnoDoPnvSnv{paramIndex}, " +
                                    $"@Rodovia{paramIndex}, " +
                                    $"@Uf{paramIndex}, " +
                                    $"@Km_m{paramIndex}, " +
                                    $"@Municipio{paramIndex}, " +
                                    $"@TipoPista{paramIndex}, " +
                                    $"@Sentido{paramIndex}, " +
                                    $"@DataDaInativacao{paramIndex}, " +
                                    $"@Latitude{paramIndex}, " +
                                    $"@Longitude{paramIndex}, " +
                                    $"@VelocidadeLeve{paramIndex})");

                                cmd.Parameters.AddWithValue($"@Concessionaria{paramIndex}", entity.Concessionaria);
                                cmd.Parameters.AddWithValue($"@AnoDoPnvSnv{paramIndex}", entity.AnoDoPnvSnv);
                                cmd.Parameters.AddWithValue($"@Rodovia{paramIndex}", entity.Rodovia);
                                cmd.Parameters.AddWithValue($"@Uf{paramIndex}", entity.Uf);
                                cmd.Parameters.AddWithValue($"@Km_m{paramIndex}", entity.Km_m);
                                cmd.Parameters.AddWithValue($"@Municipio{paramIndex}", entity.Municipio);
                                cmd.Parameters.AddWithValue($"@TipoPista{paramIndex}", entity.TipoPista);
                                cmd.Parameters.AddWithValue($"@Sentido{paramIndex}", entity.Sentido);
                                cmd.Parameters.AddWithValue($"@DataDaInativacao{paramIndex}", entity.DataDaInativacao);
                                cmd.Parameters.AddWithValue($"@Latitude{paramIndex}", entity.Latitude);
                                cmd.Parameters.AddWithValue($"@Longitude{paramIndex}", entity.Longitude);
                                cmd.Parameters.AddWithValue($"@VelocidadeLeve{paramIndex}", entity.VelocidadeLeve);

                                paramIndex++;
                            }
                        }

                        if (paramIndex > 0)
                        {
                            cmd.CommandText = insertQuery.ToString();
                            cmd.Connection = connection;

                            try
                            {
                                connection.Open();
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
                    };
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
            bool result = false;

            try
            {
                using (SqlCommand cmd = new(_config.Sql.Query.Update, connection))
                {
                    cmd.Parameters.AddWithValue($"@Concessionaria", entity.Concessionaria);
                    cmd.Parameters.AddWithValue($"@AnoDoPnvSnv", entity.AnoDoPnvSnv);
                    cmd.Parameters.AddWithValue($"@Rodovia", entity.Rodovia);
                    cmd.Parameters.AddWithValue($"@Uf", entity.Uf);
                    cmd.Parameters.AddWithValue($"@Km_m", entity.Km_m);
                    cmd.Parameters.AddWithValue($"@Municipio", entity.Municipio);
                    cmd.Parameters.AddWithValue($"@TipoPista", entity.TipoPista);
                    cmd.Parameters.AddWithValue($"@Sentido", entity.Sentido);
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
