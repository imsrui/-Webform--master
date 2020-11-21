using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class ContactService
    {
        private  readonly ContactManager dal = new ContactManager();
        public int Add(Contact model)
        {
            return dal.Add(model);
        }


        public int Edit(Contact model)
        {
            return dal.Edit(model);
        }

        public Contact GetAll()
        {
            return dal.GetAll();
        }
    }
}