using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageFacilitet : IManage<Facilitet>
    {
        private const String GET_ALL = "select * from Faciliteter";
        private const String GET_ONE = "select * from Faciliteter WHERE Facilitet_Id = @ID";
        private const String DELETE = "delete from Faciliteter WHERE Facilitet_Id = @ID";
        private const String INSERT = "insert into Faciliteter values (@ID, @NAME)";
        private const String UPDATE = "update Faciliteter " +
                                      "SET Facilitet_Id = @ID, Name = @NAME " +
                                      "WHERE Facilitet_Id = @ID";

        protected Facilitet ReadNextElement(SqlDataReader reader)
        {
            Facilitet facilitet = new Facilitet();

            facilitet.Facilitetnr = reader.GetInt32(0);
            facilitet.Name = reader.GetString(1);

            return facilitet;
        }


        public IEnumerable<Facilitet> Get()
        {
            List<Facilitet> liste = new List<Facilitet>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Facilitet booking = ReadNextElement(reader);
                liste.Add(booking);
            }
            reader.Close();

            return liste;
        }

        public Facilitet Get(int id)
        {
            Facilitet facilitet = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                facilitet = ReadNextElement(reader);
            }
            reader.Close();

            return facilitet;
        }

        public bool Post(Facilitet f)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", f.Facilitetnr);
            cmd.Parameters.AddWithValue("@NAME", f.Name);

            int noOfRows = 0;
            try
            {
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            

            return noOfRows == 1;
        }

        public bool Put(int id, Facilitet b)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@NAME", b.Name);
            cmd.Parameters.AddWithValue("@ID", id); //id == b.Facilitetnr

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }
    }
}