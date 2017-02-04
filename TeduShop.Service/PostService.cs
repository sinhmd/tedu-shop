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
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPostByCategory(int id, int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllTagByPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }

    public class PostService : IPostService
    {
        IPostRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _repository.Add(post);
        }

        public void Delete(Post post)
        {
            _repository.Delete(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _repository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _repository.GetMultiPaging(x => x.Status, out totalRow, pageSize, page);
        }

        public IEnumerable<Post> GetAllTagByPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _repository.GetMultiPaging(x => x.Status && IsPostContainTag(tag,x), out totalRow, pageSize, page);
        }

        private bool IsPostContainTag(string tag, Post post)
        {
            foreach (PostTag postTag in post.PostTags)
            {
                if(postTag.TagId == tag)
                {
                    return true;
                }
            }
            return false;
        }

        public Post GetById(int id)
        {
           return _repository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _repository.Update(post);
        }

        public IEnumerable<Post> GetAllPostByCategory(int id, int page, int pageSize, out int totalRow)
        {
            return _repository.GetMultiPaging(x => x.Status && x.CategoryId == id, out totalRow, page, pageSize);
        }
    }
}
