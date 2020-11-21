using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class SeoManager
    {
        public int Add(Seos model)
        {
            string sql = "insert into Seos(Seos_Id,Seos_Title,Seos_Keyword,Seos_Description,Seos_WebMenuId,Seos_DeleteId,Seos_CreateTime,Seos_UpdateTime) values(@Seos_Id,@Seos_Title,@Seos_Keyword,@Seos_Description,@Seos_WebMenuId,@Seos_DeleteId,@Seos_CreateTime,@Seos_UpdateTime)";
            return SqlHelper<Seos>.ExceuteNonQuery(sql, model);
        }

        public int Edit(Seos model)
        {
            string sql = "update Seos set Seos_Title=@Seos_Title,Seos_Keyword=@Seos_Keyword,Seos_Description=@Seos_Description,Seos_WebMenuId=@Seos_WebMenuId,Seos_UpdateTime=@Seos_UpdateTime where Seots_Id=@Seos_Id";
            return SqlHelper<Seos>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Seos where Seos_DeleteId = 0 and Seos_Id=@Seos_Id";
            return SqlHelper<Seos>.ExceuteNonQuery(sql, new Seos(){ Seos_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update Seos set Seos_DeleteId = 0 where Seos_Id = @Seos_Id";
            return SqlHelper<Seos>.ExceuteNonQuery(sql, new Seos() { Seos_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update Seos set Seos_DeleteId = 1 where Seos_Id = @Seos_Id";
            return SqlHelper<Seos>.ExceuteNonQuery(sql, new Seos() { Seos_Id = id });
        }

        public IList<Seos> GetAll()
        {
            string sql = "select * from Seos where Seos_DeleteId = 1 order by Seos_UpdateTime desc";
            return SqlHelper<Seos>.Query(sql,null);
        }

        public IList<Seos> GetSeosByTitle(string title)
        {
            string sql = "select * from Seos where Seos_DeleteId = 1 and Seos_Title like @Seos_Title order by Seos_UpdateTime desc";
            return SqlHelper<Seos>.Query(sql, new Seos(){ Seos_Title = "%"+title+"%"});
        }


        public IList<Seos> GetAllInTrash()
        {
            string sql = "select * from Seos where Seos_DeleteId = 0 order by Seos_UpdateTime desc";
            return SqlHelper<Seos>.Query(sql, null);
        }

        public IList<Seos> GetSeosByTitleInTrash(string title)
        {
            string sql = "select * from Seos where Seos_DeleteId = 0 and Seos_Title like @Seos_Title order by Seos_UpdateTime desc";
            return SqlHelper<Seos>.Query(sql, new Seos() { Seos_Title = "%" + title + "%" });
        }

        public Seos GetSeosById(Guid id)
        {
            string sql = "select * from Seos where Seos_Id = @Seos_Id";
            return SqlHelper<Seos>.Query(sql, new Seos() {Seos_Id = id}).FirstOrDefault();
        }

        public Seos GetSeos(string title)
        {
            string sql = "select * from Seos where Seos_Title = @Seos_Title";
            return SqlHelper<Seos>.Query(sql, new Seos() {Seos_Title = title}).FirstOrDefault();
        }


        public Seos GetSeosByWebMenuId(Guid id)
        {
            string sql = "select * from Seos where Seos_WebMenuId = @Seos_WebMenuId order by Seos_CreateTime desc ";
            return SqlHelper<Seos>.Query(sql, new Seos() {Seos_WebMenuId = id}).FirstOrDefault();
        }
    }
}