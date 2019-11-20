using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlCategory;

namespace BusinessLogicLayer
{
   public class blCategory
    {
        private enCategory _enCategory = null;
        private DAL _objDAL = null;

        public blCategory(enCategory enCategory_)
        {
            this._enCategory = enCategory_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enCategory> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public int Update()
        {
            return GetDALReference().Update();
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enCategory);
            }
            return _objDAL;
        }
    }
}
