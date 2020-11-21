using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class UsersManager
    {
        public int Add(Users users)
        {
            string sql = "insert into Users(Users_Id,Users_Account,Users_Password,Users_NickName,Users_Photo,Users_RolesId,Users_DeleteId,Users_CreateTime,Users_UpdateTime)"
                         + " values(@Users_Id,@Users_Account,@Users_Password,@Users_NickName,@Users_Photo,@Users_RolesId,@Users_DeleteId,@Users_CreateTime,@Users_UpdateTime)";
            return SqlHelper<Users>.ExceuteNonQuery(sql, users);
        }

        public int Edit(Users users)
        {
            string sql = "update Users set Users_Password=@Users_Password , Users_NickName=@Users_NickName , Users_RolesId=@Users_RolesId , Users_UpdateTime = @Users_UpdateTime where Users_Id = @Users_Id";
            return SqlHelper<Users>.ExceuteNonQuery(sql, users);
        }

        public int PutTrash(Guid id)
        {
            string sql = "update Users set Users_DeleteId = 0 where Users_Id = @Users_Id";
            return SqlHelper<Users>.ExceuteNonQuery(sql, new Users() {Users_Id = id});
        }

        public int Restore(Guid id)
        {
            string sql = "update Users set Users_DeleteId = 0 where Users_Id = @Users_Id";
            return SqlHelper<Users>.ExceuteNonQuery(sql, new Users() { Users_Id = id });
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Users where Users_DeleteId = 0 and Users_Id = @Users_Id";
            return SqlHelper<Users>.ExceuteNonQuery(sql, new Users() { Users_Id = id });
        }

        public IList<Users> GetAll()
        {
            string sql = "select * from Users where Users_DeleteId = 1 ";
            return SqlHelper<Users>.Query(sql, null);
        }

        public IList<Users> GetUsersByNickName(string nickname)
        {
            string sql = "select * from Users where Users_DeleteId = 1 and Users_NickName like @Users_NickName";
            return SqlHelper<Users>.Query(sql, new Users(){ Users_NickName = "%"+nickname+"%" });
        }

        public Users GetUsersById(Guid id)
        {
            string sql = "select * from Users where Users_Id = @Users_Id";
            return SqlHelper<Users>.Query(sql, new Users() {Users_Id = id}).FirstOrDefault();
        }


        public IList<Users> GetAllInTrash()
        {
            string sql = "select * from Users where Users_DeleteId = 0";
            return SqlHelper<Users>.Query(sql, null);
        }

        public IList<Users> GetUsersByNickNameInTrash(string nickname)
        {
            string sql = "select * from Users where Users_DeleteId = 0 and Users_NickName like @Users_NickName";
            return SqlHelper<Users>.Query(sql, new Users() { Users_NickName = "%" + nickname + "%" });
        }

        public Users Login(string account, string password)
        {
            string sql = "select * from Users where Users_Account = @Users_Account and Users_Password = @Users_Password";
            return SqlHelper<Users>.Query(sql, new Users() {Users_Account = account, Users_Password = password}).FirstOrDefault();
        }


        public int ChangePwd(string account, string password)
        {
            string sql = "update Users set Users_Password = @Users_Password where Users_Account = @Users_Account";
            return SqlHelper<Users>.ExceuteNonQuery(sql,
                new Users() {Users_Account = account, Users_Password = password});
        }
    }
}