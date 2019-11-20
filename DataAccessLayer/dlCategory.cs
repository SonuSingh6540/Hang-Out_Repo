using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
   public class dlCategory : DataAccessBridge
    {
        private enCategory _enCategory = null;

        public dlCategory(enCategory enCategory_)
            :base("Category")
        {
            this._enCategory = enCategory_;
        }

        public int Create()
        {
            return base.Create(_enCategory.Name,_enCategory.Image_Name,_enCategory.IsActive,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enCategory.ID))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enCategory);
                }
            }
        }

        public List<enCategory> ReadAll()
        {
            var listOfCategories = new List<enCategory>();
            using (IDataReader idr = base.Read(_enCategory.ID))
            {
                while (idr.Read())
                {
                    var objENCategory = new enCategory();
                    ConstructObject(idr, objENCategory);
                    listOfCategories.Add(objENCategory);
                }
            }
            return listOfCategories;
        }

        public int Update()
        {
            return base.Update(_enCategory.ID, _enCategory.Name, _enCategory.Image_Name, _enCategory.IsActive,_enCategory.InsertedOn, DateTime.Now);
        }

        public int Delete()
        {
            return base.Delete(_enCategory.ID);
        }

        private void ConstructObject(IDataReader dr_, enCategory enCategory_)
        {
            enCategory_.ID = Convert.ToInt32(dr_["ID"]);
            enCategory_.Name = dr_["Name"].ToString();
            enCategory_.Image_Name = dr_["Image_Name"].ToString();
            enCategory_.IsActive = Convert.ToBoolean(dr_["IsActive"]);
            enCategory_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enCategory_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
