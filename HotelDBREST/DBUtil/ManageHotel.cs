using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    

    public class ManageHotel : IManage<Hotel>
    {
        private const String GET_ALL = "select * from DemoHotel";
        private const String GET_ONE = "select * from DemoHotel WHERE Hotel_No = @ID";
        private const String DELETE = "delete from DemoHotel WHERE Hotel_No = @ID";
        private const String INSERT = "insert into DemoHotel values (@ID, @Name, @Address)";
        private const String UPDATE = "update DemoHotel " +
                                      "SET Hotel_no = @HotelId, Name = @Name, Address = @Address, Facilitet_Id = @FacilitetID  " +
                                      "WHERE Hotel_No = @ID";


        // GET: api/Hotels
        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            reader.Close();

            return liste;
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
            }
            reader.Close();

            return hotel;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }


        // POST: api/Hotels
        public bool Post(Hotel hotel)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            cmd.Parameters.AddWithValue("@FacilitetID", hotel.FaciliteterID);

            int rowsAffected;
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            return rowsAffected == 1;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Hotel hotel)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@HotelId", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            cmd.Parameters.AddWithValue("@FacilitetID", hotel.FaciliteterID);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

     
        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;

        }

    }
}