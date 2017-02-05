using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch(DbEntityValidationException dbValidEx)
            {
                foreach(var eve in dbValidEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" ");
                    foreach(var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"Property \"{ve.PropertyName}\" message \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(dbValidEx);
                response = request.CreateResponse(HttpStatusCode.BadRequest, dbValidEx.InnerException.Message);
            }
            catch(DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = request.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch(Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.Date = DateTime.Now;
                error.Message = ex.Message;
                error.TraceError = ex.StackTrace;
                _errorService.Add(error);
                _errorService.SaveChanges();
            }catch
            {

            }
        }
    }
}
