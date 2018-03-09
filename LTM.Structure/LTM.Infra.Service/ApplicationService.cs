using LTM.Infra;
using LTM.Infra.Data.Base;
using System;

namespace LTM.Infra.Service
{
    public abstract class ApplicationService
    {
        protected readonly IUnitOfWork _uow;
        private NotificationResult result;

        public ApplicationService(IUnitOfWork uow)
        {
            this._uow = uow;
            result = new NotificationResult();
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }


        public NotificationResult Commit(NotificationResult result)
        {
            if (result.IsValid)
            {
                try
                {
                    _uow.Commit();
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    result.AddError(ex);
                }
            }
            else
            {
                _uow.Rollback();
            }
            return result;
        }
    }
}
