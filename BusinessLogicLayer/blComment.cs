using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL = DataAccessLayer.dlComment;

namespace BusinessLogicLayer
{
    public class blComment
    {
        private enComment _enComment = null;
        private DAL _objDAL = null;

        public enComment GetEntityReference { get { return _enComment; } }

        public blComment(enComment enComment_)
        {
            this._enComment = enComment_;
        }
        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enComment> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            return GetDALReference().ReadAll(startRowIndex_, endRowIndex_);
        }

        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();

            if (!_enComment.IsGetSuccess)
                return;

            Aggregate(entitiesToAggregate_);
        }

        public List<enComment> ReadAllAndAggregate(int? startRowNumber_ = null, int? endRowNumber_ = null, params Type[] entitiesToAggregate_)
        {
            List<enComment> listOfComments = ReadAll(startRowNumber_, endRowNumber_);

            foreach (var item in listOfComments)
            {
                var objBLComment = new blComment(item);
                objBLComment.Aggregate(entitiesToAggregate_);
            }

            return listOfComments;
        }

        private void Aggregate(params Type[] entitiesToAggregate_)
        {
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enDebate)) != null)
            {
                _enComment.Debate_ = new enDebate { ID = _enComment.Debate_ID };
                var objBLDebate = new blDebate(_enComment.Debate_);
                objBLDebate.Read();
            }
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enUser)) != null)
            {
                _enComment.User_ = new enUser { ID = _enComment.User_ID };
                var objBLUser = new blUser(_enComment.User_);
                objBLUser.Read();
            }
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enLikeCounter)) != null)
            {
                var objENLikeCounter = new enLikeCounter() { Debate_ID = _enComment.Debate_ID, User_ID = _enComment.User_ID };
                var objBlLikeCounter = new blLikeCounter(objENLikeCounter);
                _enComment.listOfLikeCounter = objBlLikeCounter.ReadAll().Where(x => x.Comment_ID == _enComment.ID).ToList();
                _enComment.LikesCount = _enComment.listOfLikeCounter.Count;
            }
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enComment);
            }
            return _objDAL;
        }
    }
}
