using Entity;
using System;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlContest;

namespace BusinessLogicLayer
{
    public class blContest
    {
        private enContest _enContest = null;
        private DAL _objDAL = null;

        public enContest GetEntityReference { get { return _enContest; } }

        public blContest(enContest enContest_)
        {
            this._enContest = enContest_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enContest> ReadAll()
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
                _objDAL = new DAL(this._enContest);
            }
            return _objDAL;
        }
    }
}
