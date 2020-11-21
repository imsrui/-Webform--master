using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DAL
{
    //SqlServer 2014 版本 与 SqlServer2012 不一致  EFCore  SqlServer2012以下 与Sqlserver2014以上的内容是不同
    //server=.;database=数据库名;uid=sa;pwd=11  2012版本以下默认是数据库池连接
    //2014版本需要我们需要手动设定
    //Dapper  ---> Mybaties 半自动化的框架(因为我们需要手写T-SQL语句) --> 用于操作与数据库相关的内容
    //EntityFramework   --->   hibernate  自动化框架(不需要我们手写T-SQL语句的,已经封装完成了)
    //C#当中用的最多的框架就是EF,到了EFCore变了
    public static class SqlHelper<T> where T : class,new()
    {
       private static readonly string constr = ConfigurationManager.ConnectionStrings["DapperCon"].ConnectionString;
      
        public static int ExceuteNonQuery(string sql, T model)
        {
            using (IDbConnection con = new SqlConnection(constr)) // 面向接口开发,降低耦合度
            {
                con.Open();
                return con.Execute(sql,model);
            }
        }

        public static IList<T> Query(string sql, T model)
        {
            using (IDbConnection con = new SqlConnection(constr))
            {
                con.Open();
                if (model == null)
                {
                    return con.Query<T>(sql).ToList();
                }

                return con.Query<T>(sql, model).ToList();
            }
        }

    }
}