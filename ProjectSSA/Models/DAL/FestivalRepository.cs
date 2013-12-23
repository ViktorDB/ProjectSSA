using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper;
using System.Data.Common;

namespace ProjectSSA.Models.DAL
{
    public class FestivalRepository
    {
        public static Festival GetFestival()
        {
            Festival f = new Festival();
            string sSQL = "SELECT * FROM Festival";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                f.Name = reader["Naam"].ToString();
                f.Place = reader["Plaats"].ToString();
                DateTime date1 = Convert.ToDateTime(reader["StartDate"].ToString());
                f.StartDate = date1.ToString("dd-MM-yyyy");
                DateTime date2 = Convert.ToDateTime(reader["EndDate"].ToString());
                f.EndDate = date2.ToString("dd-MM-yyyy");
            }
            reader.Close();

            return (f);
        }
    }
}