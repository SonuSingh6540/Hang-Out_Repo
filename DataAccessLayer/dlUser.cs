using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlUser :DataAccessBridge
    {
        private enUser _enUser = null;
        public dlUser(enUser enUser_)
            : base("User")
        {
            this._enUser = enUser_;
        }

        public int Create()
        {
            return base.Create(_enUser.Name,_enUser.E_Mail,_enUser.Password,_enUser.Country,_enUser.Contact,_enUser.Reference_Code,_enUser.Sponsor_ID,_enUser.VerificationCode,_enUser.Verified,DateTime.Now);
        }

        public int Update()
        {
            return base.Update(_enUser.ID, _enUser.Name, _enUser.E_Mail, _enUser.Password, _enUser.Country, _enUser.Contact, _enUser.Reference_Code, _enUser.Sponsor_ID, _enUser.VerificationCode, _enUser.Verified, _enUser.InsertedOn, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enUser.ID,_enUser.Reference_Code,_enUser.Sponsor_ID,_enUser.E_Mail,_enUser.Password,_enUser.VerificationCode, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enUser);
                    _enUser.IsGetSuccess = true;
                }
            }
        }

        public List<enUser> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            var listOfUsers = new List<enUser>();
            using (IDataReader idr = base.Read(_enUser.ID,_enUser.Reference_Code, _enUser.Sponsor_ID, _enUser.E_Mail, _enUser.Password,_enUser.VerificationCode, startRowIndex_, endRowIndex_))
            {
                while (idr.Read())
                {
                    var objENUser = new enUser();
                    ConstructObject(idr, objENUser);
                    listOfUsers.Add(objENUser);
                    _enUser.IsGetSuccess = true;
                }

                if (idr.NextResult())
                {
                    idr.Read();
                    _enUser.RecordsCount = Convert.ToInt32(idr["RecordsCount"]);
                }
            }
            return listOfUsers;
        }

        private void ConstructObject(IDataReader dr_, enUser enUser_)
        {
            enUser_.ID = Convert.ToInt32(dr_["ID"]);
            enUser_.Name = dr_["Name"].ToString();
            enUser_.E_Mail = dr_["E_Mail"].ToString();
            enUser_.Password = dr_["Password"].ToString();
            enUser_.Country = Convert.ToInt32(dr_["Country"]);
            enUser_.Contact = dr_["Contact"].ToString();
            enUser_.Reference_Code = dr_["Reference_Code"].ToString();
            enUser_.Sponsor_ID = dr_["Sponsor_ID"].ToString();
            enUser_.VerificationCode = dr_["VerificationCode"].ToString();
            enUser_.Verified =  Convert.ToBoolean(dr_["Verified"]);
            enUser_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enUser_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
