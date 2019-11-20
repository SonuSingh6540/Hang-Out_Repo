using Entity;
using System;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlContent;

namespace BusinessLogicLayer
{
   public class blContent
    {
        private enContent _enContent = null;
        private DAL _objDAL = null;

        public enContent GetEntityReference { get { return _enContent; } }

        public blContent(enContent enContent_)
        {
            this._enContent = enContent_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enContent> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public void Update()
        {
            GetDALReference().Update();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enContent);
            }
            return _objDAL;
        }
    }
}
