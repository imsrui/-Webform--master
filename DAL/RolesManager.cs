using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class RolesManager
    {
        public int Add(Roles roles)
        {
            string sql = "insert into Roles(Roles_Id,Roles_Title,Roles_DeleteId,Roles_CreateTime,Roles_UpdateTime) " +
                         "values(@Roles_Id,@Roles_Title,@Roles_DeleteId,@Roles_CreateTime,@Roles_UpdateTime)";

            return SqlHelper<Roles>.ExceuteNonQuery(sql, roles);
        }

        public int Edit(Roles roles)
        {
            string sql = "update Roles set Roles_Title = @Roles_Title , Roles_UpdateTime = @Roles_UpdateTime where Roles_Id = @Roles_Id";
            return SqlHelper<Roles>.ExceuteNonQuery(sql, roles);
        }
        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int PutTrash(Guid id)
        {
            string sql = "update Roles set Roles_DeleteId = 0 where Roles_Id = @Roles_Id";
            return SqlHelper<Roles>.ExceuteNonQuery(sql, new Roles(){ Roles_Id = id});
        }
        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Restore(Guid id)
        {
            string sql = "update Roles set Roles_DeleteId = 1 where Roles_Id = @Roles_Id";
            return SqlHelper<Roles>.ExceuteNonQuery(sql, new Roles() { Roles_Id = id });
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Roles where Roles_DeleteId = 0 and Roles_Id = @Roles_Id";
            return SqlHelper<Roles>.ExceuteNonQuery(sql, new Roles() { Roles_Id = id });
        }

        public IList<Roles> GetAll()
        {
            string sql = "select * from Roles where Roles_DeleteId = 1";
            return SqlHelper<Roles>.Query(sql, null);
        }

        public IList<Roles> GetRolesByTitle(string title)
        {
            string sql = "select * from Roles where Roles_DeleteId = 1 and Roles_Title like @roles_Title";
            return SqlHelper<Roles>.Query(sql, new Roles { Roles_Title = "%"+title+"%" });
        }


        public Roles GetRolesById(Guid id)
        {
            string sql = "select * from Roles where Roles_Id = @Roles_Id";
            return SqlHelper<Roles>.Query(sql, new Roles() { Roles_Id = id}).FirstOrDefault();
        }

        public IList<Roles> GetAllInTrash()
        {
            string sql = "select * from Roles where Roles_DeleteId = 0";
            return SqlHelper<Roles>.Query(sql, null);
        }

        public IList<Roles> GetRolesByTitleInTrash(string title)
        {
            string sql = "select * from Roles where Roles_DeleteId = 0 and Roles_Title like @roles_Title";
            return SqlHelper<Roles>.Query(sql, new Roles { Roles_Title = "%" + title + "%" });
        }

    }
}