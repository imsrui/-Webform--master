using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class FriendShipsManager
    {
        public int Add(FriendShips model)
        {
            string sql = "insert into FriendShips(FriendShips_Id,FriendShips_Title,FriendShips_Link,FriendShips_DeleteId,FriendShips_CreateTime,FriendShips_UpdateTime) values(@FriendShips_Id,@FriendShips_Title,@FriendShips_Link,@FriendShips_DeleteId,@FriendShips_CreateTime,@FriendShips_UpdateTime)";
            return SqlHelper<FriendShips>.ExceuteNonQuery(sql,model);
        }

        public int Edit(FriendShips model)
        {
            string sql = "update FriendShips set FriendShips_Title = @FriendShips_Title,FriendShips_Link = @FriendShips_Link,FriendShips_UpdateTime = @FriendShips_UpdateTime where FriendShips_Id = @FriendShips_Id";
            return SqlHelper<FriendShips>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from FriendShips where FriendShips_DeleteId = 0 and FriendShips_Id = @FriendShips_Id ";
            return SqlHelper<FriendShips>.ExceuteNonQuery(sql, new FriendShips(){ FriendShips_Id = id });
        }

        public int PutTrash(Guid id)
        {
            string sql = "update FriendShips set FriendShips_DeleteId = 0 where FriendShips_Id = @FriendShips_Id";
            return SqlHelper<FriendShips>.ExceuteNonQuery(sql, new FriendShips() { FriendShips_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update FriendShips set FriendShips_DeleteId = 1 where FriendShips_Id = @FriendShips_Id";
            return SqlHelper<FriendShips>.ExceuteNonQuery(sql, new FriendShips() { FriendShips_Id = id });
        }

        public IList<FriendShips> GetAll()
        {
            string sql = "select * from FriendShips where FriendShips_DeleteId = 1  order by FriendShips_UpdateTime desc ";
            return SqlHelper<FriendShips>.Query(sql, null);
        }

        public IList<FriendShips> GetFriendShipsByTitle(string title)
        {
            string sql = "select * from FriendShips where FriendShips_DeleteId = 1 and FriendShips_Title like @FriendShips_Title   order by FriendShips_UpdateTime desc ";
            return SqlHelper<FriendShips>.Query(sql, new FriendShips(){ FriendShips_Title = "%"+title+"%"});
        }

        public FriendShips GetFriendShipsById(Guid id)
        {
            string sql = "select * from FriendShips where FriendShips_Id = @FriendShips_Id";
            return SqlHelper<FriendShips>.Query(sql, new FriendShips() { FriendShips_Id = id }).FirstOrDefault();
        }

        public IList<FriendShips> GetAllInTrash()
        {
            string sql = "select * from FriendShips where FriendShips_DeleteId = 0  order by FriendShips_UpdateTime desc ";
            return SqlHelper<FriendShips>.Query(sql, null);
        }

        public IList<FriendShips> GetFriendShipsByTitleInTrash(string title)
        {
            string sql = "select * from FriendShips where FriendShips_DeleteId = 0 and FriendShips_Title like @FriendShips_Title   order by FriendShips_UpdateTime desc ";
            return SqlHelper<FriendShips>.Query(sql, new FriendShips() { FriendShips_Title = "%" + title + "%" });
        }

    }
}