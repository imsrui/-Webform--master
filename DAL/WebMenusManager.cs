using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class WebMenusManager
    {
        public int Add(WebMenus model)
        {
            string sql = "insert into WebMenus(WebMenus_Id,WebMenus_Title,WebMenus_Link,WebMenus_Icon,WebMenus_DeleteId,WebMenus_ParentId,WebMenus_CreateTime,WebMenus_UpdateTime) "
                         + "values(@WebMenus_Id,@WebMenus_Title,@WebMenus_Link,@WebMenus_Icon,@WebMenus_DeleteId,@WebMenus_ParentId,@WebMenus_CreateTime,@WebMenus_UpdateTime)";
            return SqlHelper<WebMenus>.ExceuteNonQuery(sql, model);
        }

        public int Edit(WebMenus model)
        {
            string sql = "update WebMenus set WebMenus_Title = @WebMenus_Title ,WebMenus_Link = @WebMenus_Link,WebMenus_Icon = @WebMenus_Icon,WebMenus_ParentId = @WebMenus_ParentId,WebMenus_UpdateTime = @WebMenus_UpdateTime where WebMenus_Id = @WebMenus_Id";
            return SqlHelper<WebMenus>.ExceuteNonQuery(sql, model);
        }


        public int PutTrash(Guid id)
        {
            string sql = "update WebMenus set WebMenus_DeleteId = 0 where WebMenus_Id = @WebMenus_Id";
            return SqlHelper<WebMenus>.ExceuteNonQuery(sql, new WebMenus { WebMenus_Id = id });
        }


        public int Restore(Guid id)
        {
            string sql = "update WebMenus set WebMenus_DeleteId = 1 where WebMenus_Id = @WebMenus_Id";
            return SqlHelper<WebMenus>.ExceuteNonQuery(sql, new WebMenus { WebMenus_Id = id });
        }


        public int Delete(Guid id)
        {
            string sql = "delete from WebMenus where WebMenus_DeleteId = 0 and WebMenus_Id = @WebMenus_Id";
            return SqlHelper<WebMenus>.ExceuteNonQuery(sql, new WebMenus { WebMenus_Id = id });
        }

        public IList<WebMenus> GetAll()
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 1  order by WebMenus_CreateTime";
            return SqlHelper<WebMenus>.Query(sql, null);
        }

        public IList<WebMenus> GetAllWhatIsShow()
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 1 and WebMenus_IsShow = 1 order by WebMenus_CreateTime";
            return SqlHelper<WebMenus>.Query(sql, null);
        }

        public IList<WebMenus> GetWebMenusByTitle(string title)
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 1 and WebMenus_Title like @WebMenus_Title";
            return SqlHelper<WebMenus>.Query(sql, new WebMenus { WebMenus_Title = "%" + title + "%" });
        }

        public WebMenus GetWebMenus(Guid id)
        {
            string sql = "select * from WebMenus where WebMenus_Id = @WebMenus_Id";
            return SqlHelper<WebMenus>.Query(sql, new WebMenus { WebMenus_Id = id }).FirstOrDefault();
        }


        public IList<WebMenus> GetWebMenusByParentId(Guid parentId)
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 1 and WebMenus_ParentId = @WebMenus_ParentId ";
            return SqlHelper<WebMenus>.Query(sql, new WebMenus { WebMenus_ParentId = parentId });
        }


        public IList<WebMenus> GetAllInTrash()
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 0";
            return SqlHelper<WebMenus>.Query(sql, null);
        }

        public IList<WebMenus> GetWebMenusByTitleInTrash(string title)
        {
            string sql = "select * from WebMenus where WebMenus_DeleteId = 0 and WebMenus_Title like @WebMenus_Title";
            return SqlHelper<WebMenus>.Query(sql, new WebMenus { WebMenus_Title = "%" + title + "%" });
        }

    }
}