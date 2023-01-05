using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WepApiProjeCore.Models
{
    public class OdemeTipRepository : IOdemeTipRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<OdemeTipRepository> _logger;
        public OdemeTipRepository(IConfiguration configuration, ILogger<OdemeTipRepository> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public OdemeTip AddOdemeTip(OdemeTip odemetip)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoOdemeTip]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@OdemeTipi", odemetip.OdemeTipi);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var addodemetip methodunda");
                    odemetip = null;
                }

            }

            return odemetip = null;
        }

        public void DeleteOdemeTip(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteOdemeTip]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@OdemeID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Hata var DeleteOdemeTip() methodunda");

                }

            }
        }

        public IEnumerable<OdemeTip> GetAllOdemeTip()
        {
            List<OdemeTip> odemetips = new List<OdemeTip>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectOdemeTip]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        OdemeTip odemetip = new OdemeTip();
                        odemetip.OdemeID = Convert.ToInt32(rdr["OdemeID"]);
                        odemetip.OdemeTipi = rdr["OdemeTipi"].ToString();
                        odemetips.Add(odemetip);


                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "hata var GetAllOdemeTip methodunda");
                    odemetips = null;
                }
            }
            return odemetips;
        }

        public OdemeTip GetOdemeTipById(int id)
        {
            OdemeTip odemetip = new OdemeTip();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SelectOdemeTipById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OdemeID", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        odemetip.OdemeID = id;
                        odemetip.OdemeTipi = rdr["OdemeTipi"].ToString();
                    }


                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "hata var GetOdemeTipById() var");
                    odemetip = null;
                }
            }
            return odemetip;
        }

        public OdemeTip UpdateOdemeTip(OdemeTip odemetip)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateOdemeTip]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@OdemeID", odemetip.OdemeID);
                    cmd.Parameters.AddWithValue("@OdemeTipi", odemetip.OdemeTipi);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    _logger.LogError(ex, "Error at UpdateCustomer() :(");
                    odemetip = null;
                }
            }

            return odemetip;
        }
    }
}
