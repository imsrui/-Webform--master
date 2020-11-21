using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class UsersService
    {
        private readonly UsersManager dal = new UsersManager();

        public int Add(Users users)
        {
            return dal.Add(users);
        }

        public int Edit(Users users)
        {
            return dal.Edit(users);
        }

        public int PutTrash(Guid id)
        {
            return dal.PutTrash(id);
        }

        public int Restore(Guid id)
        {
            return dal.Restore(id);
        }

        public int Delete(Guid id)
        {
            return dal.Delete(id);
        }

        public IList<Users> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Users> GetUsersByNickName(string nickname)
        {
            return dal.GetUsersByNickName(nickname);
        }

        public Users GetUsersById(Guid id)
        {
            return dal.GetUsersById(id);
        }


        public IList<Users> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Users> GetUsersByNickNameInTrash(string nickname)
        {
            return dal.GetUsersByNickNameInTrash(nickname);
        }

        public Users Login(string account, string password)
        {
            return dal.Login(account, password);
        }

        public int ChangePwd(string account, string password)
        {
            return dal.ChangePwd(account, password);
        }
    }
}