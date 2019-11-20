using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL = DataAccessLayer.dlReward;

namespace BusinessLogicLayer
{
   public class blReward
    {
        private enReward _enReward = null;
        private DAL _objDAL = null;

        public enReward GetEntityReference { get { return _enReward; } }

        public blReward(enReward enReward_)
        {
            this._enReward = enReward_;
        }
        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enReward> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            return GetDALReference().ReadAll(startRowIndex_, endRowIndex_);
        }

        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();

            if (!_enReward.IsGetSuccess)
                return;
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enReward);
            }
            return _objDAL;
        }
    }
}
