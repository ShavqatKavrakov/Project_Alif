using System;
using System.Data.SqlClient;
namespace ConsoleApp
{
  class Forms
  {
      public int Id{get;set;}
      public string Gender{get;set;}
      public int Age{get;set;}
      public string Marital_Status{get;set;}
      public string Country{get;set;}
      public void Inser(SqlConnection connection,SqlTransaction transaction,Forms forms)
      {
 var sql="INSERT INTO Forms(Age,Marital_Status,Country,Gender)";
    sql+=$"VALUES(@age,@marital_status,@country,@gender);";
     var cmd=connection.CreateCommand();
     cmd.Transaction=transaction;
     cmd.CommandText=sql;
     cmd.Parameters.AddWithValue("@age",forms.Age);
     cmd.Parameters.AddWithValue("@marital_status",forms.Marital_Status);
     cmd.Parameters.AddWithValue("@country",forms.Country);
     cmd.Parameters.AddWithValue("@gender",forms.Gender);
     var result=cmd.ExecuteNonQuery();
      }
  }

}