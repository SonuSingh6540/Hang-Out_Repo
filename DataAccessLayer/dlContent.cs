using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class dlContent : DataAccessBridge
    {
        private enContent _enContent = null;
        public dlContent(enContent enContent_)
            : base("Content")
        {
            this._enContent = enContent_;
        }

        public int Create()
        {
            return base.Create(_enContent.Type, _enContent.Description, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enContent.ID,_enContent.Type))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enContent);
                    _enContent.IsGetSuccess = true;
                }
            }
        }

        public List<enContent> ReadAll()
        {
            var listOfContents = new List<enContent>();
            using (IDataReader idr = base.Read(null,null))
            {
                while (idr.Read())
                {
                    var objENContent = new enContent();
                    ConstructObject(idr, objENContent);
                    listOfContents.Add(objENContent);
                    _enContent.IsGetSuccess = true;
                }
            }
            return listOfContents;
        }

        public int Update()
        {
            return base.Update(_enContent.ID, _enContent.Type, _enContent.Description, _enContent.InsertedOn, DateTime.Now);
        }

        private void ConstructObject(IDataReader dr_, enContent enContent_)
        {
            enContent_.ID = Convert.ToInt32(dr_["ID"]);
            enContent_.Type = Convert.ToInt32(dr_["Type"]);
            enContent_.Description = dr_["Description"].ToString();
            enContent_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enContent_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
