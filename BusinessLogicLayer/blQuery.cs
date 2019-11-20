using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlQuery;

namespace BusinessLogicLayer
{
   public class blQuery
    {
        private enQuery _enQuery = null;
        private DAL _objDAL = null;

        public enQuery GetEntityReference { get { return _enQuery; } }

        public blQuery(enQuery enQuery_)
        {
            this._enQuery = enQuery_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }

        public List<enQuery> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enQuery);
            }
            return _objDAL;
        }
    }
}
