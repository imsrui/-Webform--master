using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class FriendShipsService
    {
        private readonly FriendShipsManager dal = new FriendShipsManager();

        public int Add(FriendShips model)
        {
            return dal.Add(model);
        }

        public int Edit(FriendShips model)
        {
            return dal.Edit(model);
        }

        public int Delete(Guid id)
        {
            return dal.Delete(id);
        }

        public int PutTrash(Guid id)
        {
            return dal.PutTrash(id);
        }

        public int Restore(Guid id)
        {
            return dal.Restore(id);
        }

        public IList<FriendShips> GetAll()
        {
            return dal.GetAll();
        }

        public IList<FriendShips> GetFriendShipsByTitle(string title)
        {
            return dal.GetFriendShipsByTitle(title);
        }

        public FriendShips GetFriendShipsById(Guid id)
        {
            return dal.GetFriendShipsById(id);
        }

        public IList<FriendShips> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<FriendShips> GetFriendShipsByTitleInTrash(string title)
        {
            return dal.GetFriendShipsByTitleInTrash(title);
        }
    }
}