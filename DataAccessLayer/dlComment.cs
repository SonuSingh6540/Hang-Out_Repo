using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DataAccessLayer
{
    public class dlComment : DataAccessBridge
    {
        private enComment _enComment = null;

        public dlComment(enComment enComment_) : base("Comment")
        {
            this._enComment = enComment_;
        }

        public int Create()
        {
            return base.Create(_enComment.Message,_enComment.Type,_enComment.Debate_ID,_enComment.User_ID,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enComment.ID,_enComment.Debate_ID,_enComment.User_ID, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enComment);
                    _enComment.IsGetSuccess = true;
                }
            }
        }

        public List<enComment> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            var listOfComments = new List<enComment>();
            using (IDataReader idr = base.Read(_enComment.ID, _enComment.Debate_ID, _enComment.User_ID, startRowIndex_, endRowIndex_))
            {
                while (idr.Read())
                {
                    var objENComment = new enComment();
                    ConstructObject(idr, objENComment);
                    listOfComments.Add(objENComment);
                    _enComment.IsGetSuccess = true;
                }

                if (idr.NextResult())
                {
                    idr.Read();
                    _enComment.RecordsCount = Convert.ToInt32(idr["RecordsCount"]);
                }
            }
            return listOfComments;
        }

        private void ConstructObject(IDataReader dr_, enComment enComment_)
        {
            enComment_.ID = Convert.ToInt32(dr_["ID"]);
            enComment_.Message = dr_["Message"].ToString();
            enComment_.Type = Convert.ToInt32(dr_["Type"]);
            enComment_.Debate_ID = Convert.ToInt32(dr_["Debate_ID"]);
            enComment_.User_ID = Convert.ToInt32(dr_["User_ID"]);
            enComment_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enComment_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
