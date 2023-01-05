using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class SiparislerRepository : ISiparislerRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<SiparislerRepository> _logger;
        public SiparislerRepository(IConfiguration configuration, ILogger<SiparislerRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public Siparisler AddSiparisler(Siparisler siparisler)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoSiparisler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@UyeID", siparisler.UyeID);
                    cmd.Parameters.AddWithValue("@SiparisTipi", siparisler.SiparisTipi);
                    cmd.Parameters.AddWithValue("@SiparisTarih", siparisler.SiparisTarih);
                    cmd.Parameters.AddWithValue("@Adet", siparisler.Adet);
                    cmd.Parameters.AddWithValue("@Tutar", siparisler.Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", siparisler.Aciklama);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addsiparisler methodunda");
                    siparisler = null;
                }

            }

            return siparisler = null;
        }

        public void DeleteSiparisler(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteSiparisler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@SiparislerID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteSiparisler() methodunda");

                }

            }
        }

        public IEnumerable<Siparisler> GetAllSiparisler()
        {
            List<Siparisler> siparislers = new List<Siparisler>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectSiparisler]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Siparisler siparisler = new Siparisler();
                        siparisler.SiparislerID = Convert.ToInt32(rdr["SiparislerID"]);
                        siparisler.UyeID = Convert.ToInt32(rdr["UyeID"]);
                        siparisler.SiparisTipi = rdr["SiparisTipi"].ToString();
                        siparisler.SiparisTarih = rdr["SiparisTarih"].ToString();
                        siparisler.Adet = Convert.ToInt32(rdr["Adet"]);
                        siparisler.Tutar = Convert.ToInt32(rdr["Tutar"]);
                        siparisler.Aciklama = rdr["Aciklama"].ToString();
                        siparislers.Add(siparisler);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllSiparisler methodunda");
                    siparislers = null;
                }
            }
            return siparislers;
        }

        public Siparisler GetSiparislerById(int id)
        {
            Siparisler siparisler = new Siparisler();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectSiparislerById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@SiparislerID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        siparisler.UyeID = Convert.ToInt32(rdr["UyeID"]);
                        siparisler.SiparisTipi = rdr["SiparisTipi"].ToString();
                        siparisler.SiparisTarih = rdr["SiparisTarih"].ToString();
                        siparisler.Adet = Convert.ToInt32(rdr["Adet"]);
                        siparisler.Tutar = Convert.ToInt32(rdr["Tutar"]);
                        siparisler.Aciklama = rdr["Aciklama"].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetSiparislerById() var");
                    siparisler = null;
                }
            }
            return siparisler;
        }

        public Siparisler UpdateSiparisler(Siparisler siparisler)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateSiparisler]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@SiparislerID", siparisler.SiparislerID);
                    cmd.Parameters.AddWithValue("@UyeID", siparisler.UyeID);
                    cmd.Parameters.AddWithValue("@SiparisTipi", siparisler.SiparisTipi);
                    cmd.Parameters.AddWithValue("@SiparisTarih", siparisler.SiparisTarih);
                    cmd.Parameters.AddWithValue("@Adet", siparisler.Adet);
                    cmd.Parameters.AddWithValue("@Tutar", siparisler.Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", siparisler.Aciklama);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    siparisler = null;
                }
            }

            return siparisler;
        }
    }
}
