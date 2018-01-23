using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProAgenda.Web.Models
{
    public static class Banco
    {

        public static string ConectionString()
        {
            return @"Data Source=NBBV022006;Initial Catalog=FullCalendarMVC_Demo;Integrated Security=True";

          //  return @"Data Source=SYENX;Initial Catalog=FullCalendarMVC_Demo;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }

        public static List<AppointmentDiary> SelectAllList()
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[AppointmentDiary]", con);

            var result = new List<AppointmentDiary>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var foo = new AppointmentDiary
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        AppointmentLength = Convert.ToInt32(reader["AppointmentLength"]),
                        DateTimeScheduled = Convert.ToDateTime(reader["DateTimeScheduled"]),
                        SomeImportantKey = Convert.ToInt32(reader["SomeImportantKey"]),
                        StatusENUM = Convert.ToInt32(reader["StatusENUM"]),
                        Title = reader["Title"].ToString(),
                    };
                    result.Add(foo);
                }
            }
            return result;

        }
    

        public static List<AppointmentDiary> GetAgendas(double start, double end)
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppointmentDiary WHERE SomeImportantKey BETWEEN " + start + " AND " + end + "; ", con);
            
            var agends = new List<AppointmentDiary>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    agends.Add(new AppointmentDiary()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        AppointmentLength = Convert.ToInt32(reader["AppointmentLength"]),
                        DateTimeScheduled = Convert.ToDateTime(reader["DateTimeScheduled"]),
                        SomeImportantKey = Convert.ToInt32(reader["SomeImportantKey"]),
                        StatusENUM = Convert.ToInt32(reader["StatusENUM"]),
                        Title = reader["Title"].ToString(),
                    });
                }
            }
            return agends;
        }

        public static void UpdateAgenda(int id, string NewEventStart, string NewEventEnd)
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmmd = new SqlCommand("UPDATE [dbo].[AppointmentDiary]   ,[DateTimeScheduled] = "+ NewEventStart + "      ,[StatusENUM] = "+ NewEventStart + " WHERE ID = "+id+"", con);
            con.Close();
            cmmd.ExecuteNonQuery();
          
        }


        public static void CreateNewAgenda(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmmd = new SqlCommand("INSERT INTO [dbo].[AppointmentDiary] ([Title] ,[SomeImportantKey] ,[DateTimeScheduled]  ,[AppointmentLength] ,[StatusENUM]) VALUES   ("+Title+" , 1, "+ NewEventDate + ", "+ NewEventTime + ", "+ NewEventDuration + "   ", con);
            con.Close();
            cmmd.ExecuteNonQuery();

        }

    }
}