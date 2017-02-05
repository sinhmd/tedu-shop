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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);
        PostCategory Update(PostCategory postCategory);
        PostCategory Delete(PostCategory postCategory);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        PostCategory GetById(int id);
        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _repository.Add(postCategory);
        }

        public PostCategory Delete(PostCategory postCategory)
        {
            return _repository.Delete(postCategory);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _repository.GetAll(new string[] { "Posts"});
        }

        public IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _repository.GetMultiPaging(x=>x.Status, out totalRow, page, pageSize,new string[] { "Posts"});
        }

        public PostCategory GetById(int id)
        {
            return _repository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public PostCategory Update(PostCategory postCategory)
        {
            return _repository.Update(postCategory);
        }
    }
}
