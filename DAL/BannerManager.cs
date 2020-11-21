using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class BannerManager
    {
        public int Add(Banner model)
        {
            string sql = "insert into Banner(Banner_Id,Banner_Img,Banner_Title,Banner_Link,Banner_DeleteId,Banner_WebMenuId,Banner_CreateTime,Banner_UpdateTime) values(@Banner_Id,@Banner_Img,@Banner_Title,@Banner_Link,@Banner_DeleteId,@Banner_WebMenuId,@Banner_CreateTime,@Banner_UpdateTime)";
            return SqlHelper<Banner>.ExceuteNonQuery(sql,model);
        }


        public int Edit(Banner model)
        {
            string sql = "update Banner set Banner_Title=@Banner_Title,Banner_Img=@Banner_Img,Banner_Link=@Banner_Link,Banner_WebMenuId=@Banner_WebMenuId,Banner_UpdateTime=@Banner_UpdateTime where Banner_Id=@Banner_Id";
            return SqlHelper<Banner>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Banner where Banner_DeleteId = 0 and Banner_Id = @Banner_Id";
            return SqlHelper<Banner>.ExceuteNonQuery(sql, new Banner(){ Banner_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update Banner set Banner_DeleteId = 0 where Banner_Id = @Banner_Id";
            return SqlHelper<Banner>.ExceuteNonQuery(sql, new Banner() { Banner_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update Banner set Banner_DeleteId = 1 where Banner_Id = @Banner_Id";
            return SqlHelper<Banner>.ExceuteNonQuery(sql, new Banner() { Banner_Id = id });
        }

        public IList<Banner> GetAll()
        {
            string sql = "select * from Banner where Banner_DeleteId = 1 order by Banner_UpdateTime desc";
            return SqlHelper<Banner>.Query(sql,null);
        }

        public IList<Banner> GetBannerByTitle(string title)
        {
            string sql = "select * from Banner where Banner_DeleteId = 1 and Banner_Title = @Banner_Title order by Banner_UpdateTime desc";
            return SqlHelper<Banner>.Query(sql, new Banner(){ Banner_Title =  "%"+title+"%"});
        }

        public IList<Banner> GetBannerByWebMenuId(Guid webMenuId)
        {
            string sql =
                "select * from Banner where Banner_DeleteId = 1 and Banner_WebMenuId = @Banner_WebMenuId order by Banner_UpdateTime desc";
            return SqlHelper<Banner>.Query(sql, new Banner() { Banner_WebMenuId =  webMenuId});
        }

        public Banner GetBannerById(Guid id)
        {
            string sql = "select * from Banner where Banner_Id = @Banner_Id";
            return SqlHelper<Banner>.Query(sql,new Banner(){ Banner_Id =  id}).FirstOrDefault();
        }

        public IList<Banner> GetAllInTrash()
        {
            string sql = "select * from Banner where Banner_DeleteId = 0 order by Banner_UpdateTime desc";
            return SqlHelper<Banner>.Query(sql, null);
        }

        public IList<Banner> GetBannerByTitleInTrash(string title)
        {
            string sql = "select * from Banner where Banner_DeleteId = 0 and Banner_Title = @Banner_Title order by Banner_UpdateTime desc";
            return SqlHelper<Banner>.Query(sql, new Banner() { Banner_Title = "%" + title + "%" });
        }

    }
}