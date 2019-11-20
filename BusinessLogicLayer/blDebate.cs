using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL = DataAccessLayer.dlDebate;

namespace BusinessLogicLayer
{
    public class blDebate
    {
        private enDebate _enDebate = null;
        private DAL _objDAL = null;

        public enDebate GetEntityReference { get { return _enDebate; } }

        public blDebate(enDebate enDebate_)
        {
            this._enDebate = enDebate_;
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

        public List<enDebate> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            return GetDALReference().ReadAll(startRowIndex_, endRowIndex_);
        }


        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();

            //if (!_enComment.IsGetSuccess)
            //    return;

            Aggregate(entitiesToAggregate_);
        }

        public List<enDebate> ReadAllAndAggregate(int? startRowNumber_ = null, int? endRowNumber_ = null, params Type[] entitiesToAggregate_)
        {
            List<enDebate> listOfDebates = ReadAll(startRowNumber_, endRowNumber_);

            foreach (var item in listOfDebates)
            {
                var objBLComment = new blDebate(item);
                objBLComment.Aggregate(entitiesToAggregate_);
            }

            return listOfDebates;
        }

        private void Aggregate(params Type[] entitiesToAggregate_)
        {
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enCategory)) != null)
            {
                _enDebate.Category_ = new enCategory { ID = _enDebate.Category_ID };
                var objBLCategory = new blCategory(_enDebate.Category_);
                objBLCategory.Read();
            }
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enUser)) != null)
            {
                if(_enDebate.User_ID != null)
                {
                    _enDebate.User_ = new enUser { ID = _enDebate.User_ID.Value };
                    var objBLUser = new blUser(_enDebate.User_);
                    objBLUser.Read();
                }
            }
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }
        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enDebate);
            }
            return _objDAL;

        }
    }
}