using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class dlQuery : DataAccessBridge
    {
        private enQuery _enQuery = null;
        public dlQuery(enQuery enQuery_)
            : base("Query")
        {
            this._enQuery = enQuery_;
        }

        public int Create()
        {
            return base.Create(_enQuery.Name, _enQuery.E_Mail, _enQuery.Contact, _enQuery.Subject, _enQuery.Topic_Type, _enQuery.Message, _enQuery.File_Name, _enQuery.Type, _enQuery.User_ID, DateTime.Now);
        }

        public int Create(SqlTransaction objSqlTransaction_)
        {
            return base.Create(objSqlTransaction_,_enQuery.Name, _enQuery.E_Mail, _enQuery.Contact, _enQuery.Subject, _enQuery.Topic_Type, _enQuery.Message, _enQuery.File_Name, _enQuery.Type, _enQuery.User_ID, DateTime.Now);
        }
        public void Read()
        {
            using (IDataReader idr = base.Read(_enQuery.ID, _enQuery.Type, _enQuery.User_ID, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enQuery);
                    _enQuery.IsGetSuccess = true;
                }
            }
        }

        public List<enQuery> ReadAll()
        {
            var listOfQueries = new List<enQuery>();
            using (IDataReader idr = base.Read(_enQuery.ID, _enQuery.Type, _enQuery.User_ID, null, null))
            {
                while (idr.Read())
                {
                    var objENQuery = new enQuery();
                    ConstructObject(idr, objENQuery);
                    listOfQueries.Add(objENQuery);
                    _enQuery.IsGetSuccess = true;
                }
            }
            return listOfQueries;
        }

        public int Delete()
        {
            return base.Delete(_enQuery.ID);
        }

        private void ConstructObject(IDataReader dr_, enQuery enQuery_)
        {
            enQuery_.ID = Convert.ToInt32(dr_["ID"]);
            enQuery_.Name = dr_["Name"].ToString();
            enQuery_.E_Mail = dr_["E_Mail"].ToString();
            enQuery_.Contact = dr_["Contact"].ToString();
            enQuery_.Subject = dr_["Subject"].ToString();
            enQuery_.Topic_Type = DBNull.Value == dr_["Topic_Type"] ? (int?)null : Convert.ToInt32(dr_["Topic_Type"]);
            enQuery_.Message = dr_["Message"].ToString();
            enQuery_.File_Name = dr_["File_Name"].ToString();
            enQuery_.Type = Convert.ToInt32(dr_["Type"]);
            enQuery_.User_ID = Convert.ToInt32(dr_["User_ID"]);
            enQuery_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enQuery_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
