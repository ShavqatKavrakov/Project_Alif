using System;
using System.Data.SqlClient;
namespace ConsoleApp
{
class CreditApps 
{
 public int id{get;set;}
 public int UserId{get;set;}
public DateTime Date{get;set;}  
public double Summ{get;set;}
public string Target{get;set;}
public int Period{get;set;}
public void Inser(SqlConnection connection,SqlTransaction transaction,CreditApps creditApps)
      {
 var sql="INSERT INTO CreditApps(UserId,Date,Summ,Target,Period)";
   sql+= $"VALUES(@userid,@date,@summ,@target,@period);";
     var command=connection.CreateCommand();
     command.Transaction=transaction;
     command.CommandText=sql;
     command.Parameters.AddWithValue("@userid",creditApps.UserId);
     command.Parameters.AddWithValue("@date",Convert.ToDateTime(creditApps.Date));
     command.Parameters.AddWithValue("@summ",creditApps.Summ);
     command.Parameters.AddWithValue("@target",creditApps.Target);
     command.Parameters.AddWithValue("@period",creditApps.Period);
     var result=command.ExecuteNonQuery();
     if(result>0)
     {
         Console.WriteLine("CreditApps added successfully");
     }
      }
      public void Select(SqlConnection connection,SqlTransaction transaction)
      {
       var sql="select c.id,Cast(c.Date AS date),c.Summ, c.Target,c.Period  From CreditApps AS c";
       var command=connection.CreateCommand();
       command.Transaction=transaction;
       command.CommandText=sql;
       var result=command.ExecuteReader();
       Console.WriteLine("ИСТОРИЯ ЗАЯВКА");
       Console.WriteLine("| ID |       Дата        |  Сумма |       Цель    | Срок ");
       Console.WriteLine("|----|-------------------|--------|---------------|-----");
       while(result.Read())
       {
 Console.WriteLine($"|{result.GetValue(0)}   | {result.GetValue(1)}| {result.GetValue(2)}|{result.GetValue(3)}| {result.GetValue(4)} ");
       }
       result.Close();
      }
}
}
