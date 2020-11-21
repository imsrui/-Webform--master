using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class CopyrightsService
    {
        private readonly CopyrightsManager dal = new CopyrightsManager();

        public int Add(Copyrights model)
        {
            return dal.Add(model);
        }

        public int Edit(Copyrights model)
        {
            return dal.Edit(model);
        }

        public Copyrights GetCopyrights()
        {
            return dal.GetCopyrights();
        }
    }
}