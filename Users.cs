using System;
using System.Data.SqlClient;
namespace ConsoleApp
{
     class Users
    {
        public int Id{get;set;}
        public string UserType{get;set;}
        public string Phone{get;set;}
        public string LastName{get;set;}
        public string FirstName{get;set;}
        public string MidlleName{get;set;}
        public string Email{get;set;}
        public DateTime BirthDate{get;set;}
        public  string Adress{get;set;}
      public void Inser(SqlConnection connection,SqlTransaction transaction,Users users)
      {
        
   string sql="INSERT INTO Users(UserType,Phone,LastName,FirstName,MiddleName,BirthDate,Adress)";
    sql+="VALUES(@UserType,@Phone,@LastName,@FirstName,@MiddleName,@BirthDate,@Adress);";
      var cmd=connection.CreateCommand();
      cmd.Transaction=transaction;
     cmd.CommandText=sql;
     cmd.Parameters.AddWithValue("@UserType",users.UserType);
     cmd.Parameters.AddWithValue("@Phone",users.Phone);
     cmd.Parameters.AddWithValue("@LastName",users.LastName);
     cmd.Parameters.AddWithValue("@FirstName",users.FirstName);
     cmd.Parameters.AddWithValue("@MiddleName",users.MidlleName);
     cmd.Parameters.AddWithValue("@BirthDate",Convert.ToDateTime(users.BirthDate));
     cmd.Parameters.AddWithValue("@Adress",users.Adress);
     var result=cmd.ExecuteNonQuery();
      if(result>0)
     {
         Console.WriteLine("Users added successfully");
     }
   
      }
    }
  }