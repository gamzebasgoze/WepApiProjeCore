using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class BankalarRepository : IBankalarRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<BankalarRepository> _logger;
        public BankalarRepository(IConfiguration configuration, ILogger<BankalarRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }

        public IEnumerable<Bankalar> GetAllBankalar()
        {
            List<Bankalar> bankalars = new List<Bankalar>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankalar]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Bankalar bankalar = new Bankalar();
                        bankalar.BankaID = Convert.ToInt32(rdr["BankaID"]);
                        bankalar.BankaAdi = rdr["BankaAdi"].ToString();
                        bankalar.BankaLogo = rdr["BankaLogo"].ToString();
                        bankalar.Aktif = rdr["Aktif"].ToString();
                        bankalars.Add(bankalar);


                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllBankalar methodunda");
                    bankalars = null;
                }
            }
            return bankalars;
        }

        public Bankalar GetBankalarById(int id)
        {
            Bankalar bankalar = new Bankalar();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectBankalarById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@BankaID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        bankalar.BankaID = id;
                        bankalar.BankaAdi = rdr["BankaAdi"].ToString();
                        bankalar.BankaLogo = rdr["BankaLogo"].ToString();
                        bankalar.Aktif = rdr["Aktif"].ToString();
                    }


                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetBankalarById() var");
                    bankalar = null;
                }
            }
            return bankalar;
        }

        public Bankalar AddBankalar(Bankalar bankalar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoBankalar]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaAdi", bankalar.BankaAdi);
                    cmd.Parameters.AddWithValue("@BankaLogo", bankalar.BankaLogo);
                    cmd.Parameters.AddWithValue("@Aktif", bankalar.Aktif);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addbankalar methodunda");
                    bankalar = null;
                }

            }

            return bankalar = null;
        }

        public Bankalar UpdateBankalar(Bankalar bankalar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateBankalar]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaID", bankalar.BankaID);
                    cmd.Parameters.AddWithValue("@BankaAdi", bankalar.BankaAdi);
                    cmd.Parameters.AddWithValue("@BankaLogo", bankalar.BankaLogo);
                    cmd.Parameters.AddWithValue("@Aktif", bankalar.Aktif);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    bankalar = null;
                }
            }

            return bankalar;
        }

        public void DeleteBankalar(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteBankalar]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@BankaID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteBankalar() methodunda");

                }

            }
        }
    }
}
