using System.Linq;
using Model;

namespace DAL
{
    public class CopyrightsManager
    {
        public int Add(Copyrights model)
        {
            string sql = "insert into Copyrights(Copyrights_Id,Copyrights_Title,Copyrights_Details,Copyrights_Tel,Copyrights_Mobile,Copyrights_QQ,Copyrights_QQ2,Copyrights_Email,Copyrights_Logo,Copyrights_Image,Copyrights_Address) values(@Copyrights_Id,@Copyrights_Title,@Copyrights_Details,@Copyrights_Tel,@Copyrights_Mobile,@Copyrights_QQ,@Copyrights_QQ2,@Copyrights_Email,@Copyrights_Logo,@Copyrights_Image,@Copyrights_Address)";
            return SqlHelper<Copyrights>.ExceuteNonQuery(sql,model);
        }

        public int Edit(Copyrights model)
        {
            string sql = "update Copyrights set Copyrights_Title=@Copyrights_Title,Copyrights_Details=@Copyrights_Details,Copyrights_Tel=@Copyrights_Tel,Copyrights_Mobile=@Copyrights_Mobile,Copyrights_QQ=@Copyrights_QQ,Copyrights_QQ2=@Copyrights_QQ2,Copyrights_Email=@Copyrights_Email,Copyrights_Logo=@Copyrights_Logo,Copyrights_Image=@Copyrights_Image,Copyrights_Address=@Copyrights_Address where Copyrights_Id=@Copyrights_Id";
            return SqlHelper<Copyrights>.ExceuteNonQuery(sql, model);
        }

        public Copyrights GetCopyrights()
        {
            string sql = "select * from Copyrights";
            return SqlHelper<Copyrights>.Query(sql,null).FirstOrDefault();
        }
    }
}