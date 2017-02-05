using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

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

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if(ModelState.IsValid)
                {
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

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
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

        public HttpResponseMessage Delete(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
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
                    respone = request.CreateResponse(HttpStatusCode.OK, listCategory);
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
