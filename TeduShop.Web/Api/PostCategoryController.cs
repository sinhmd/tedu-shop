using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
using TeduShop.Web.Infrastructure.Extensions;
using AutoMapper;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService)
            : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if(ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanges();
                    respone = request.CreateResponse(HttpStatusCode.Created, category);
                }
                else
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return respone;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    var category = _postCategoryService.Update(postCategory);
                    _postCategoryService.SaveChanges();
                    respone = request.CreateResponse(HttpStatusCode.OK, category);
                }
                else
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return respone;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    var category = _postCategoryService.Delete(postCategory);
                    _postCategoryService.SaveChanges();
                    respone = request.CreateResponse(HttpStatusCode.OK, category);
                }
                else
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return respone;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
                    var listCategory = _postCategoryService.GetAll();
                    var listCategoryViewModel = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                    respone = request.CreateResponse(HttpStatusCode.OK, listCategoryViewModel);
                }
                else
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return respone;
            });
        }
    }
}
