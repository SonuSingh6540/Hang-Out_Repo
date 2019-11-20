using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlUser;

namespace BusinessLogicLayer
{
   public class blUser
    {
        private enUser _enUser = null;
        private DAL _objDAL = null;

        public enUser GetEntityReference { get { return _enUser; } }

        public blUser(enUser enUser_)
        {
            this._enUser = enUser_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public int Update()
        {
            return GetDALReference().Update();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enUser> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            return GetDALReference().ReadAll(startRowIndex_, endRowIndex_);
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enUser);
            }
            return _objDAL;
        }
    }
}
