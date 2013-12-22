using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper;
using System.Data.Common;

namespace ProjectSSA.Models.DAL
{
    public class LineUpRepository
    {
        public static List<LineUp> GetLineUps()
        {
            List<LineUp> lineups = new List<LineUp>();
            string sSQL = "SELECT Band.*, LineUp.*, Stage.* FROM Band INNER JOIN LineUp ON Band.IDBand = LineUp.Band INNER JOIN Stage ON LineUp.Stage = Stage.StageID";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                LineUp l = new LineUp();

                l.BandID = int.Parse(reader["IDBand"].ToString());
                l.Band = reader["BandName"].ToString();
                l.Stage = reader["StageName"].ToString();
                l.StageID = int.Parse(reader["StageID"].ToString());
                DateTime date = Convert.ToDateTime(reader["Date"].ToString());
                l.Date = date.ToString("dd-MM-yyyy");
                l.From = reader["From"].ToString();
                l.Until = reader["Until"].ToString();
                l.Facebook = reader["Facebook"].ToString();
                l.Twitter = reader["Twitter"].ToString();
                l.Description = reader["Description"].ToString();

                lineups.Add(l);
            }
            reader.Close();

            return (lineups);
        }

        public static List<LineUp> GetAllDays()
        {
            List<LineUp> lineups = new List<LineUp>();
            string sSQL = "SELECT DISTINCT Date FROM LineUp";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                LineUp l = new LineUp();

                DateTime date = Convert.ToDateTime(reader["Date"].ToString());
                l.Date = date.ToString("dd-MM-yyyy");

                lineups.Add(l);
            }
            reader.Close();

            return (lineups);
        }

        public static List<LineUp> GetLineUpsByDay(string datetime)
        {
            List<LineUp> lineups = new List<LineUp>();
            string sSQL = string.Format("SELECT Band.*, LineUp.*, Stage.* FROM Band INNER JOIN LineUp ON Band.IDBand = LineUp.Band INNER JOIN Stage ON LineUp.Stage = Stage.StageID WHERE Date = '{0}'", datetime);

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                LineUp l = new LineUp();

                l.BandID = int.Parse(reader["IDBand"].ToString());
                l.Band = reader["BandName"].ToString();
                l.Stage = reader["StageName"].ToString();
                l.StageID = int.Parse(reader["StageID"].ToString());
                DateTime date = Convert.ToDateTime(reader["Date"].ToString());
                l.Date = date.ToString("dd-MM-yyyy");
                l.From = reader["From"].ToString();
                l.Until = reader["Until"].ToString();
                l.Facebook = reader["Facebook"].ToString();
                l.Twitter = reader["Twitter"].ToString();
                l.Description = reader["Description"].ToString();

                lineups.Add(l);
            }
            reader.Close();

            return (lineups);
        }
    }
}