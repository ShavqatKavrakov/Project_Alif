using System;
using System.Data.SqlClient;
namespace ConsoleApp
{
class Credits
{
public int id{get;set;}
public int SalaryCompareCredit{get;set;}
public int OverdueCredit{get;set;}
public int CreditHistory{get;set;}
public DateTime Update{get;set;}
public double Balance{get;set;}
public void Inser(SqlConnection connection,SqlTransaction transaction,Credits credits)
      {
 var sql="INSERT INTO Credits(SalaryCompareCredit,CreditHistory,OverdueCredit,[Update],Balance)";
  sql+= $"VALUES(@salary,@history,@overdue,@update,@balance);";
     var cmd=connection.CreateCommand();
     cmd.Transaction=transaction;
     cmd.CommandText=sql;
     cmd.Parameters.AddWithValue("@salary",credits.SalaryCompareCredit);
     cmd.Parameters.AddWithValue("@history",credits.CreditHistory);
     cmd.Parameters.AddWithValue("@overdue",credits.OverdueCredit);
     cmd.Parameters.AddWithValue("@update",Convert.ToDateTime(credits.Update));
     cmd.Parameters.AddWithValue("@balance",credits.OverdueCredit);
     
     var result=cmd.ExecuteNonQuery();
   
      }
}

}