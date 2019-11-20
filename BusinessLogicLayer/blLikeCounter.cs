using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlLikeCounter;

namespace BusinessLogicLayer
{
    public class blLikeCounter
    {
        private enLikeCounter _enLikeCounter = null;
        private DAL _objDAL = null;

        public enLikeCounter GetEntityReference { get { return _enLikeCounter; } }

        public blLikeCounter(enLikeCounter enLikeCounter_)
        {
            this._enLikeCounter = enLikeCounter_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enLikeCounter> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            return GetDALReference().ReadAll(startRowIndex_, endRowIndex_);
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enLikeCounter);
            }
            return _objDAL;
        }
    }
}
