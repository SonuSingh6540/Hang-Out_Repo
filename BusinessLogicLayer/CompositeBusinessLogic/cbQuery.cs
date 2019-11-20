using DAL = DataAccessLayer.CompositeRepositories.crQuery;
using Entity;

namespace BusinessLogicLayer.CompositeBusinessLogic
{
    public class cbQuery
    {
        private DAL _objDAL = null;

        public cbQuery() { }

        public void createCompleteSection(enQuery enQuery_)
        {
            var objBLQuery = new blQuery(enQuery_);
            GetDALReference().CreateQuery(enQuery_);
        }

        public DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL();
            }
            return _objDAL;
        }
    }
}
