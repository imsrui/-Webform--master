using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class NewsService
    {
        private readonly NewsManager dal = new NewsManager();

        public int Add(News model)
        {
            return dal.Add(model);
        }


        public int Edit(News model)
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

        public IList<News> GetAll()
        {
            return dal.GetAll();
        }

        public IList<News> GetNewsByTitle(string title)
        {
            return dal.GetNewsByTitle(title);
        }

        public News GetNewsById(Guid id)
        {
            return dal.GetNewsById(id);
        }

        public IList<News> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<News> GetNewsByTitleInTrash(string title)
        {
            return dal.GetNewsByTitleInTrash(title);
        }

        public IList<News> GetNewsTopFour()
        {
            return dal.GetNewsTopFour();
        }


        public News GetNewsPre(DateTime createTime)
        {
            return dal.GetNewsPre(createTime);
        }


        public News GetNewsNext(DateTime createTime)
        {
            return dal.GetNewsNext(createTime);
        }

    }
}