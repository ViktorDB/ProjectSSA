using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using DBHelper;

namespace ProjectSSA.Models.DAL
{
    public class BandRepository
    {
        public static List<Band> GetBands()
        {
            List<Band> bands = new List<Band>();
            string sSQL = "SELECT * FROM Band";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                Band b = new Band();

                b.ID = int.Parse(reader["IDBand"].ToString());
                b.Name = reader["BandName"].ToString();
                b.Picture = reader["Picture"].ToString();
                b.Description = reader["Description"].ToString();
                b.Twitter = reader["Twitter"].ToString();
                b.Facebook = reader["Facebook"].ToString();
                b.Genres = int.Parse(reader["Genres"].ToString());

                bands.Add(b);
            }

            return (bands);
        }

        public static Band GetBandDetails(int BandID)
        {
            //List<Band> bands = new List<Band>();
            Band b = new Band();
            
            string sSQL = string.Format("SELECT * FROM Band WHERE IDBand = {0}", BandID);

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                b.ID = int.Parse(reader["IDBand"].ToString());
                b.Name = reader["BandName"].ToString();
                b.Picture = reader["Picture"].ToString();
                b.Description = reader["Description"].ToString();
                b.Twitter = reader["Twitter"].ToString();
                b.Facebook = reader["Facebook"].ToString();
                b.Genres = int.Parse(reader["Genres"].ToString());

                //bands.Add(b);
            }

            return (b);
        }


    }
}