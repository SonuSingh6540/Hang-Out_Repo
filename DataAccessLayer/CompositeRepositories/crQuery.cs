using System;
using System.Collections.Generic;
using Entity;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace DataAccessLayer.CompositeRepositories
{
    public class crQuery
    {
        private HttpContextBase context { get; set; }

        public void CreateQuery (enQuery enQuery_)
        {
            var objSqlHelper = new SqlHelper();
            SqlConnection objSqlConnection = null;
            SqlTransaction objSqlTransaction = null;
            try
            {
                using (objSqlConnection = objSqlHelper.GetConnection())
                {
                    objSqlConnection.Open();
                    using (objSqlTransaction = objSqlConnection.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        var objDLQuery = new dlQuery(enQuery_);
                        var AdvertisementImageID = objDLQuery.Create(objSqlTransaction);

                        foreach(var item in enQuery_.ListOfAdvertisementImages)
                        {
                            item.Advertisement_ID = AdvertisementImageID;
                            var objDLAdvertisementImage = new dlAdvertisementImage(item);
                            objDLAdvertisementImage.Create();
                        }
                        objSqlTransaction.Commit();
                    }
                }
            }
            catch
            {
                if (objSqlTransaction != null)
                    objSqlTransaction.Rollback();
                throw;
            }
        }
    }
}
