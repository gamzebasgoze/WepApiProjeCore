using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class BankaDetayRepository : IBankaDetayRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<BankaDetayRepository> _logger;
        public BankaDetayRepository(IConfiguration configuration, ILogger<BankaDetayRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public BankaDetay AddBankaDetay(BankaDetay bankadetay)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoBankaDetay]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaID", bankadetay.BankaID);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", bankadetay.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", bankadetay.Sifre);
                    cmd.Parameters.AddWithValue("@MagazaNo", bankadetay.MagazaNo);
                    cmd.Parameters.AddWithValue("@Host", bankadetay.Host);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addbankadetay methodunda");
                    bankadetay = null;
                }

            }

            return bankadetay = null;
        }

        public void DeleteBankaDetay(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteBankaDetay]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaDetayID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteBankaDetay() methodunda");

                }

            }
        }

        public IEnumerable<BankaDetay> GetAllBankaDetay()
        {
            List<BankaDetay> bankadetays = new List<BankaDetay>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankaDetay]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BankaDetay bankadetay = new BankaDetay();
                        bankadetay.BankaDetayID = Convert.ToInt32(rdr["BankaDetayID"]);
                        bankadetay.BankaID = Convert.ToInt32(rdr["BankaID"]);
                        bankadetay.KullaniciAdi = rdr["KullaniciAdi"].ToString();
                        bankadetay.Sifre = rdr["Sifre"].ToString();
                        bankadetay.MagazaNo = rdr["MagazaNo"].ToString();
                        bankadetay.Host = rdr["Host"].ToString();
                        bankadetays.Add(bankadetay);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllBankaDetay methodunda");
                    bankadetays = null;
                }
            }
            return bankadetays;
        }

        public BankaDetay GetBankaDetayById(int id)
        {
            BankaDetay bankadetay = new BankaDetay();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankaDetayById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BankaDetayID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        bankadetay.BankaDetayID = id;
                        bankadetay.BankaID = id;
                        bankadetay.KullaniciAdi = rdr["KullaniciAdi"].ToString();
                        bankadetay.Sifre = rdr["Sifre"].ToString();
                        bankadetay.MagazaNo = rdr["MagazaNo"].ToString();
                        bankadetay.Host = rdr["Host"].ToString();
                    }


                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetBankaDetayById() var");
                    bankadetay = null;
                }
            }
            return bankadetay;
        }

        public BankaDetay UpdateBankaDetay(BankaDetay bankadetay)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateBankaDetay]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaDetayID", bankadetay.BankaDetayID);
                    cmd.Parameters.AddWithValue("@BankaID", bankadetay.BankaID);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", bankadetay.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", bankadetay.Sifre);
                    cmd.Parameters.AddWithValue("@MagazaNo", bankadetay.MagazaNo);
                    cmd.Parameters.AddWithValue("@Host", bankadetay.Host);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    bankadetay = null;
                }
            }

            return bankadetay;
        }
    }
}
