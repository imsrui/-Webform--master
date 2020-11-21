using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class NewsManager
    {
        public int Add(News model)
        {
            string sql = "insert into News(News_Id,News_Title,News_Content,News_Image,News_DeleteId,News_CreateTime,News_UpdateTime) values(@News_Id,@News_Title,@News_Content,@News_Image,@News_DeleteId,@News_CreateTime,@News_UpdateTime)";
            return SqlHelper<News>.ExceuteNonQuery(sql,model);
        }


        public int Edit(News model)
        {
            string sql = "update News set News_Title=@News_Title,News_Content=@News_Content,News_Image=@News_Image,News_UpdateTime=@News_UpdateTime where News_Id = @News_Id";
            return SqlHelper<News>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from News where News_DeleteId = 0 and News_Id = @News_Id";
            return SqlHelper<News>.ExceuteNonQuery(sql, new News(){ News_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update News set News_DeleteId = 0 where  News_Id = @News_Id";
            return SqlHelper<News>.ExceuteNonQuery(sql, new News() { News_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update News set News_DeleteId = 1 where  News_Id = @News_Id";
            return SqlHelper<News>.ExceuteNonQuery(sql, new News() { News_Id = id });
        }

        public IList<News> GetAll()
        {
            string sql = "select * from News where News_DeleteId = 1 order by News_CreateTime desc";
            return SqlHelper<News>.Query(sql,null);
        }

        public IList<News> GetNewsByTitle(string title)
        {
            string sql = "select * from News where News_DeleteId = 1 and News_Title like @News_Title order by News_UpdateTime desc";
            return SqlHelper<News>.Query(sql, new News(){ News_Title = "%"+title+"%"});
        }

        public News GetNewsById(Guid id)
        {
            string sql = "select * from News where News_Id = @News_Id";
            return SqlHelper<News>.Query(sql,new News(){News_Id =  id}).FirstOrDefault();
        }

        public IList<News> GetAllInTrash()
        {
            string sql = "select * from News where News_DeleteId = 0 order by News_UpdateTime desc";
            return SqlHelper<News>.Query(sql, null);
        }

        public IList<News> GetNewsByTitleInTrash(string title)
        {
            string sql = "select * from News where News_DeleteId = 0 and News_Title like @News_Title order by News_UpdateTime desc";
            return SqlHelper<News>.Query(sql, new News() { News_Title = "%" + title + "%" });
        }

        public IList<News> GetNewsTopFour()
        {
            string sql = "select top 4 * from News where News_DeleteId = 1 order by News_UpdateTime desc";
            return  SqlHelper<News>.Query(sql, null); 
        }


        public News GetNewsPre(DateTime createTime)
        {
            string sql = "select top 1 * from News where News_CreateTime > @News_CreateTime order by News_CreateTime asc";
            return SqlHelper<News>.Query(sql, new News() {News_CreateTime = createTime}).FirstOrDefault();
        }


        public News GetNewsNext(DateTime createTime)
        {
            string sql = "select top 1 * from News where News_CreateTime < @News_CreateTime  order by News_CreateTime desc";
            return SqlHelper<News>.Query(sql, new News() { News_CreateTime = createTime }).FirstOrDefault();
        }

    }
}