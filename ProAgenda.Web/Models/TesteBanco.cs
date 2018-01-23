using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProAgenda.Web.Models
{
    public static class TesteBanco
    {

        public static string ConectionString()
        {
            return @"Data Source=SYENX;Initial Catalog=FullCalendarMVC_Demo;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }

        public static SqlDataReader SelectDataReaderAgenda()
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmmd = new SqlCommand("SELECT * FROM [dbo].[AppointmentDiary]", con);
            var retorno = cmmd.ExecuteReader();
            

            return retorno;
        }
        

        public static List<AppointmentDiary> GetToListAgenda()
        {
            var agends = new List<AppointmentDiary>();
            var reader = SelectDataReaderAgenda();

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
            return agends;
        }

        public static List<AppointmentDiary> GetAgendas(double start, double end)
        {
            SqlConnection con = new SqlConnection(ConectionString());
            con.Open();
            SqlCommand cmmd = new SqlCommand("SELECT Title ,SomeImportantKey,DateTimeScheduled,AppointmentLength,StatusENUM FROM[FullCalendarMVC_Demo].[dbo].[AppointmentDiary] WHERE[DateTimeScheduled] BETWEEN " + start + " AND " + end + "; ", con);
            con.Close();
            var agends = new List<AppointmentDiary>();
            var reader = SelectDataReaderAgenda();

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