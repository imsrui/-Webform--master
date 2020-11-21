using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class SystemMenuManager
    {

        public int Add(SystemMenus model) 
        {
            string sql = "insert into SystemMenus(SystemMenus_Id,SystemMenus_Title,SystemMenus_Link,SystemMenus_Icon,SystemMenus_DeleteId,SystemMenus_ParentId,SystemMenus_CreateTime,SystemMenus_UpdateTime) "
                + "values(@SystemMenus_Id,@SystemMenus_Title,@SystemMenus_Link,@SystemMenus_Icon,@SystemMenus_DeleteId,@SystemMenus_ParentId,@SystemMenus_CreateTime,@SystemMenus_UpdateTime)";
            return SqlHelper<SystemMenus>.ExceuteNonQuery(sql,model);
        }

        public int Edit(SystemMenus model)
        {
            string sql = "update SystemMenus set SystemMenus_Title = @SystemMenus_Title ,SystemMenus_Link = @SystemMenus_Link,SystemMenus_Icon = @SystemMenus_Icon,SystemMenus_ParentId = @SystemMenus_ParentId,SystemMenus_UpdateTime = @SystemMenus_UpdateTime where SystemMenus_Id = @SystemMenus_Id";
            return SqlHelper<SystemMenus>.ExceuteNonQuery(sql,model);
        }

        public int PutTrash(Guid id)
        {
            string sql = "update SystemMenus set SystemMenus_DeleteId = 0 where SystemMenus_Id = @SystemMenus_Id";
            return SqlHelper<SystemMenus>.ExceuteNonQuery(sql,new SystemMenus { SystemMenus_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update SystemMenus set SystemMenus_DeleteId = 1 where SystemMenus_Id = @SystemMenus_Id";
            return SqlHelper<SystemMenus>.ExceuteNonQuery(sql, new SystemMenus { SystemMenus_Id = id });
        }

        public int Delete(Guid id)
        {
            string sql = "delete from SystemMenus where SystemMenus_DeleteId = 0 and SystemMenus_Id = @SystemMenus_Id";
            return SqlHelper<SystemMenus>.ExceuteNonQuery(sql, new SystemMenus { SystemMenus_Id = id });
        }


        public IList<SystemMenus> GetAll() 
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 1";
            return SqlHelper<SystemMenus>.Query(sql,null);
        }

        public IList<SystemMenus> GetSystemMenuByTitle(string title)
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 1 and SystemMenus_Title like @SystemMenus_Title";
            return  SqlHelper<SystemMenus>.Query(sql, new SystemMenus { SystemMenus_Title = "%"+title+"%" }); 
        }

        public SystemMenus GetSystemMenus(Guid id) 
        {
            string sql = "select * from SystemMenus where SystemMenus_Id = @SystemMenus_Id";
            return SqlHelper<SystemMenus>.Query(sql, new SystemMenus { SystemMenus_Id = id }).FirstOrDefault(); 
        }

        public IList<SystemMenus> GetAllInTrash()
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 0";
            return SqlHelper<SystemMenus>.Query(sql, null);
        }

        public IList<SystemMenus> GetSystemMenuByTitleInTrash(string title)
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 0 and SystemMenus_Title like @SystemMenus_Title";
            return SqlHelper<SystemMenus>.Query(sql, new SystemMenus { SystemMenus_Title = "%" + title + "%" });
        }

        public IList<SystemMenus> GetSystemMenusByParentId(Guid parentId) 
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 1 and SystemMenus_ParentId = @SystemMenus_ParentId ";
            return SqlHelper<SystemMenus>.Query(sql, new SystemMenus { SystemMenus_ParentId = parentId });
        }


        public IList<SystemMenus> GetSystemMenusesByIdList(string idList) 
        {
            string sql = "select * from SystemMenus where SystemMenus_DeleteId = 1 and SystemMenus_Id not in("+idList+")";
            return SqlHelper<SystemMenus>.Query(sql, null);
        }


        public IList<SystemMenus> GetSystemMenusByRolesIdAndParnetId(Guid rid, Guid parentId)
        {
            string sql = "select * from SystemMenus where SystemMenus_ParentId = '"+parentId+ 
                         "' and SystemMenus_Id in(select UsersPermissions_SystemMenuId from UsersPermissions where UsersPermissions_RolesId = '" +rid+"' )";
            return SqlHelper<SystemMenus>.Query(sql, null);
        }


    }
}
