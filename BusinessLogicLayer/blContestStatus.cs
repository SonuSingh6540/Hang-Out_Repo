using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL = DataAccessLayer.dlContestStatus;

namespace BusinessLogicLayer
{
    public class blContestStatus
    {
        private enContestStatus _enContestStatus = null;
        private DAL _objDAL = null;

        public enContestStatus GetEntityReference { get { return _enContestStatus; } }

        public blContestStatus(enContestStatus enContestStatus_)
        {
            this._enContestStatus = enContestStatus_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enContestStatus> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();
            Aggregate(entitiesToAggregate_);
        }

        public List<enContestStatus> ReadAllAndAggregate(params Type[] entitiesToAggregate_)
        {
            List<enContestStatus> listOfContestStatus = ReadAll();

            foreach (var item in listOfContestStatus)
            {
                var objBLContestStatus = new blContestStatus(item);
                objBLContestStatus.Aggregate(entitiesToAggregate_);
            }
            return listOfContestStatus;
        }

        private void Aggregate(params Type[] entitiesToAggregate_)
        {
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enContest)) != null)
            {
                _enContestStatus.Contest_ = new enContest { ID = _enContestStatus.ContestID};
                var objBLContest = new blContest(_enContestStatus.Contest_);
                objBLContest.Read();
            }
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enUser)) != null)
            {
                _enContestStatus.User_ = new enUser { ID = _enContestStatus.UserID };
                var objBLUser = new blUser(_enContestStatus.User_);
                objBLUser.Read();
            }
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
                _objDAL = new DAL(this._enContestStatus);
            }
            return _objDAL;
        }
    }
}

