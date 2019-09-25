using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Vavatech.WebApi.Api.ActionResults
{
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            return Task.FromResult(response);

        }
    }
}