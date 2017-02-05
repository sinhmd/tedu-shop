using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IErrorService
    {
        Error Add(Error error);
        void SaveChanges();
    }

    public class ErrorService : IErrorService
    {
        IErrorRepository _repository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public Error Add(Error error)
        {
            return _repository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
