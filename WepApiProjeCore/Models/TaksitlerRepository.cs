using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class TaksitlerRepository : ITaksitlerRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<TaksitlerRepository> _logger;
        public TaksitlerRepository(IConfiguration configuration, ILogger<TaksitlerRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public Taksitler AddTaksitler(Taksitler taksitler)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoTaksitler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaID", taksitler.BankaID);
                    cmd.Parameters.AddWithValue("@Taksit", taksitler.Taksit);
                    cmd.Parameters.AddWithValue("@EkTaksit", taksitler.EkTaksit);
                    cmd.Parameters.AddWithValue("@VadeFarki", taksitler.VadeFarki);
                    cmd.Parameters.AddWithValue("@Aciklama", taksitler.Aciklama);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addtaksitler methodunda");
                    taksitler = null;
                }

            }

            return taksitler = null;
        }

        public void DeleteTaksitler(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteTaksitler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@TaksitID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteTaksitler() methodunda");

                }

            }
        }

        public IEnumerable<Taksitler> GetAllTaksitler()
        {
            List<Taksitler> taksitlers = new List<Taksitler>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectTaksitler]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Taksitler taksitler = new Taksitler();
                        taksitler.TaksitID = Convert.ToInt32(rdr["TaksitID"]);
                        taksitler.BankaID = Convert.ToInt32(rdr["BankaID"]);
                        taksitler.Taksit = Convert.ToInt32(rdr["Taksit"]);
                        taksitler.EkTaksit = Convert.ToInt32(rdr["EkTaksit"]);
                        taksitler.VadeFarki = Convert.ToInt32(rdr["VadeFarki"]);
                        taksitler.Aciklama = rdr["Aciklama"].ToString();
                        taksitlers.Add(taksitler);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllTaksitler methodunda");
                    taksitlers = null;
                }
            }
            return taksitlers;
        }

        public Taksitler GetTaksitlerById(int id)
        {
            Taksitler taksitler = new Taksitler();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectTaksitlerById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@TaksitID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        taksitler.TaksitID = id;
                        taksitler.BankaID = Convert.ToInt32(rdr["BankaID"]);
                        taksitler.Taksit = Convert.ToInt32(rdr["Taksit"]);
                        taksitler.EkTaksit = Convert.ToInt32(rdr["EkTaksit"]);
                        taksitler.VadeFarki = Convert.ToInt32(rdr["VadeFarki"]);
                        taksitler.Aciklama = rdr["Aciklama"].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetTaksitlerById() var");
                    taksitler = null;
                }
            }
            return taksitler;
        }

        public Taksitler UpdateTaksitler(Taksitler taksitler)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateTaksitler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@TaksitID", taksitler.TaksitID);
                    cmd.Parameters.AddWithValue("@BankaID", taksitler.BankaID);
                    cmd.Parameters.AddWithValue("@Taksit", taksitler.Taksit);
                    cmd.Parameters.AddWithValue("@EkTaksit", taksitler.EkTaksit);
                    cmd.Parameters.AddWithValue("@VadeFarki", taksitler.VadeFarki);
                    cmd.Parameters.AddWithValue("@Aciklama", taksitler.Aciklama);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    taksitler = null;
                }
            }

            return taksitler;
        }
    }
}
