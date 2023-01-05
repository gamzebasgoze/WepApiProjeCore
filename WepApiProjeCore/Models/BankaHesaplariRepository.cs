using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class BankaHesaplariRepository : IBankaHesaplariRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private object bankahesaplaris;
        private readonly ILogger<BankaHesaplariRepository> _logger;
        public BankaHesaplariRepository(IConfiguration configuration, ILogger<BankaHesaplariRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public BankaHesaplari AddBankaHesaplari(BankaHesaplari bankahesaplari)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoBankaHesaplari]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaID", bankahesaplari.BankaID);
                    cmd.Parameters.AddWithValue("@HesapSahibi", bankahesaplari.HesapSahibi);
                    cmd.Parameters.AddWithValue("@HesapKurTip", bankahesaplari.HesapKurTip);
                    cmd.Parameters.AddWithValue("@HesapNo", bankahesaplari.HesapNo);
                    cmd.Parameters.AddWithValue("@IbanNo", bankahesaplari.IbanNo);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addbankahesaplari methodunda");
                    bankahesaplari = null;
                }

            }

            return bankahesaplari = null;
        }

        public void DeleteBankaHesaplari(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteBankaHesaplari]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaHesapID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteBankaHesaplari() methodunda");

                }

            }
        }

        public IEnumerable<BankaHesaplari> GetAllBankaHesaplari()
        {
            List<BankaHesaplari> bankahesaplaris = new List<BankaHesaplari>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankaHesaplari]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BankaHesaplari bankahesaplari = new BankaHesaplari();
                        bankahesaplari.BankaHesapID = Convert.ToInt32(rdr["BankaHesapID"]);
                        bankahesaplari.BankaID = (int)rdr["BankaID"];
                        bankahesaplari.HesapSahibi = rdr["HesapSahibi"].ToString();
                        bankahesaplari.HesapKurTip = rdr["HesapKurTip"].ToString();
                        bankahesaplari.HesapNo = rdr["HesapNo"].ToString();
                        bankahesaplari.IbanNo = rdr["IbanNo"].ToString();
                        bankahesaplaris.Add(bankahesaplari);

                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllBankaHesaplari methodunda");
                    bankahesaplaris = null;
                }
            }
            return bankahesaplaris;
        }

        public BankaHesaplari GetBankaHesaplariById(int id)
        {
            BankaHesaplari bankahesaplari = new BankaHesaplari();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankaHesaplariById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BankaHesapID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        bankahesaplari.BankaHesapID = Convert.ToInt32(rdr["BankaHesapID"]);
                        bankahesaplari.BankaID = (int)rdr["BankaID"];
                        bankahesaplari.HesapSahibi = rdr["HesapSahibi"].ToString();
                        bankahesaplari.HesapKurTip = rdr["HesapKurTip"].ToString();
                        bankahesaplari.HesapNo = rdr["HesapNo"].ToString();
                        bankahesaplari.IbanNo = rdr["IbanNo"].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetBankaHesaplariById() var");
                    bankahesaplari = null;
                }
            }
            return bankahesaplari;
        }

        public BankaHesaplari UpdateBankaHesaplari(BankaHesaplari bankahesaplari)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateBankaHesaplari]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaHesapID", bankahesaplari.BankaHesapID);
                    cmd.Parameters.AddWithValue("@BankaID", bankahesaplari.BankaID);
                    cmd.Parameters.AddWithValue("@HesapSahibi", bankahesaplari.HesapSahibi);
                    cmd.Parameters.AddWithValue("@HesapKurTip", bankahesaplari.HesapKurTip);
                    cmd.Parameters.AddWithValue("@HesapNo", bankahesaplari.HesapNo);
                    cmd.Parameters.AddWithValue("@IbanNo", bankahesaplari.IbanNo);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    bankahesaplari = null;
                }
            }

            return bankahesaplari;
        }
    }
}
