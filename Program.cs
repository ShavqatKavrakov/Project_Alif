using System;
using System.Data.SqlClient;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        string conString=@"Data Source=SHAVQAT\SQLEXPRESS; Initial Catalog=Project; Integrated Security=True";
        using (SqlConnection connection=new SqlConnection(conString))
        {
        connection.Open();
       SqlTransaction transaction =connection.BeginTransaction();
        SqlCommand command=connection.CreateCommand();
        try
        { 
            int bal=0;
            int sum=0;//сумма балов;
          CreditApps creditApps=new CreditApps();
          Credits credits=new Credits();
          Users users=new Users();
          Forms forms=new Forms();
         Console.ForegroundColor=ConsoleColor.Gray;
           Console.WriteLine("Вы administrator или client ?");
           users.UserType=Console.ReadLine();    
         Console.ForegroundColor=ConsoleColor.DarkGreen;
           Console.WriteLine("\nПАРАМЕТРЫ КРЕДИТА");        
            Console.WriteLine("Сумма кредита");
            creditApps.Summ=int.Parse(Console.ReadLine());
            Console.WriteLine("Cрок кредита(месяцев)");
            creditApps.Period=int.Parse(Console.ReadLine());
            Console.WriteLine("Годовая процентная ставка");
            double p=double.Parse(Console.ReadLine()); 
            sum+=1;
            Console.WriteLine(sum);
          Console.WriteLine("Цель получения кредита\n(1)-бытовая техника \n(2)-ремонт\n(3)-телефон\n(4)-прочее");
          switch(int.Parse(Console.ReadLine()))
          {
            case 1:
            {
              creditApps.Target="бытовая техника";
              bal=2;
            }break;
            case 2:
            {
              creditApps.Target="ремонт";
              bal=1;
            }break;
            case 3:
            {
              creditApps.Target="телефон";
              bal=0;
            }break;
            case 4:
            {
              creditApps.Target="прочее";
              bal=-1;
            }break;
          }
            sum+=bal;
            Console.WriteLine(sum);
            creditApps.Date=DateTime.Now;//дата получения кредита
            Console.WriteLine("Кредитная история(если есть сколько раз вы закрили кредит иначе(0))");
            credits.CreditHistory=int.Parse(Console.ReadLine());
              switch(credits.CreditHistory)
              {
                case>=3: bal=2; break;
                case>0: bal=1;break;
                case 0: bal=-1;break;
              }
            sum+=bal;
            Console.WriteLine(sum);
            Console.WriteLine("Просрока в кредитной истории(сколько раз)");
            credits.OverdueCredit=int.Parse(Console.ReadLine());
            if(credits.OverdueCredit>7)bal=-3;
           else if(credits.OverdueCredit>=5 && credits.OverdueCredit<=7)bal=-2;
           else if(credits.OverdueCredit==4)bal=-1;
           else bal=0;
            sum+=bal;
            Console.WriteLine(sum);
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.WriteLine("\nПЕРСОНАЛЬНАЯ ИНФОРМАЦИЯ");
            Console.WriteLine("ФИО(полностью)");
            string[] s=Console.ReadLine()?.Split(new[]{' '});
            users.LastName=s[0];
            users.FirstName=s[1];
            users.MidlleName=s[2];
           Console.WriteLine("Дата рождения");
           users.BirthDate=DateTime.Parse(Console.ReadLine());
           Console.WriteLine("Пол\n(1)-муж\n(2)-жен");
           switch(int.Parse(Console.ReadLine()))
           {
             case 1:
             {
               forms.Gender="муж";
               bal=1;
             }break;
             case 2:
             {
               forms.Gender="жен";
               bal=2;
             }break;
             
           }
           sum+=bal;
            Console.WriteLine(sum);
           Console.WriteLine("Индентификационный номер");
           creditApps.UserId=int.Parse(Console.ReadLine());
           Console.WriteLine("Гражданство");
           forms.Country=Console.ReadLine();
              if(forms.Country=="Таджикистан")bal=1;
              else
              {
              bal=0;
              }
           sum+=bal;
            Console.WriteLine(sum);
           forms.Age=creditApps.Date.Year-users.BirthDate.Year;//возрость(дата кредить-дата_рождения)
              if(forms.Age>=63)bal=1;
             else if(forms.Age>=36 && forms.Age<=62)bal=2;
             else if (forms.Age>=26 && forms.Age<=35)bal=1;
             else if( forms.Age <=25) bal=0;
           sum+=bal;
            Console.WriteLine(sum);
           Console.WriteLine("Адрес");
           users.Adress=Console.ReadLine();
           Console.WriteLine("Телефон");
           users.Phone=Console.ReadLine();
           Console.WriteLine("Семейное положение\n(1)-холость\n(2)-семеянин\n(3)-вразводе\n(4)-вдовец\n(5)-вдова");
           switch(int.Parse(Console.ReadLine()))
           {
             case 1:
             {
              forms.Marital_Status="холост";
              bal=1;
             }break;
             case 2:
             {
              forms.Marital_Status="семеянин";
              bal=1;
             }break;
             case 3:
             {
              forms.Marital_Status="вразводе";
              bal=1;
             }break;
               case 4:
             {
              forms.Marital_Status="вдовец";
              bal=1;
             }break;
              case 5:
             {
              forms.Marital_Status="вдова"; 
              bal=1;
             }break;
           }
            sum+=bal;
            Console.WriteLine(sum);
            Console.ForegroundColor=ConsoleColor.Green;
           Console.WriteLine("\nИНФОРМАЦИЯ О ТРУДОУСТОРЙСТВЕ");
            Console.WriteLine("Ваш доход в месяца");
            int t=Int16.Parse(Console.ReadLine());
            if(t*creditApps.Period/creditApps.Summ >=0.8)
            {   sum+=4;
             }
            else 
            {
                credits.SalaryCompareCredit=(int)(creditApps.Summ*100/(t*creditApps.Period));
                if(credits.SalaryCompareCredit<=80) bal=4;
                else if(credits.SalaryCompareCredit>80 && credits.SalaryCompareCredit<=150)bal=3;
                else if(credits.SalaryCompareCredit>150 &&credits.SalaryCompareCredit<=250)bal=2;
               else bal=1;  
                sum+=bal;
             }
            if(sum<=11)
            {
              Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine($" Вы не можете получить кредит");
            }
           else
            {
                 users.Inser(connection,transaction,users);
                 creditApps.Inser(connection,transaction,creditApps);
                 forms.Inser(connection,transaction,forms); 
                   Console.ForegroundColor=ConsoleColor.Blue;
           Console.WriteLine(" ГРАФИК ПОГОШЕНИЯ КРЕДИТА");
            double  m=p/1200;//месячный процент;
            double e=1-Math.Pow((1+m),(-1)*creditApps.Period);
             double pay=Math.Round((creditApps.Summ*m/e),2);
            Console.WriteLine("|    Дата    | Планируемые выплаты |  Баланс  ");
            Console.WriteLine("|------------|---------------------|----------");
            for(int i=0; i<creditApps.Period; ++i)
            {
              if(i==0)
              {
               Console.WriteLine($"|  {creditApps.Date.AddMonths(i).ToString("d")}|               {pay}|      {creditApps.Summ}");
               
              }
            else
             {
               Console.WriteLine($"|  {creditApps.Date.AddMonths(i).ToString("d")}|               {pay}|   {creditApps.Summ}");
             }
            double q=creditApps.Summ*m;
            creditApps.Summ=Math.Round((creditApps.Summ+q-pay),2);
           if(i==creditApps.Period-2) credits.Balance=creditApps.Summ;
            }
            credits.Update=creditApps.Date.AddMonths(creditApps.Period-1);
            Console.ForegroundColor=ConsoleColor.Green;
           credits.Inser(connection,transaction,credits);
              creditApps.Select(connection,transaction);   
            }
           
            transaction.Commit();
        }
        catch(Exception ex)
         {
      Console.WriteLine(ex.Message);
      transaction.Rollback();
         }
        }
    }  
  }  
}
