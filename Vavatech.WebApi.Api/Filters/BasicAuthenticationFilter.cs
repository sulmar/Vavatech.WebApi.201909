using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Vavatech.WebApi.Api.ActionResults;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.Api.Filters
{
    public class BasicAuthenticationFilter : IAuthenticationFilter
    {
        private ICustomerRepository customerRepository;

        public BasicAuthenticationFilter(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;

            if (authorization == null)
                return;

            if (authorization.Scheme != "Basic")
                return;

            string parameter = authorization.Parameter;

            byte[] credentialsBytes = Convert.FromBase64String(parameter);

            string[] credentials = Encoding.ASCII.GetString(credentialsBytes).Split(':');

            string username = credentials[0];
            string password = credentials[1];

            Customer customer = customerRepository.Authorize(username, password);


            if (customer==null)
            {
                context.ErrorResult = new AuthenticationFailureResult();
                return;
            }

            string[] roles = new string[] { "Developer" };

            IIdentity identity = new GenericIdentity(customer.FirstName);
            IPrincipal principal = new GenericPrincipal(identity, roles);

            context.Principal = principal;


            // sposób nie dokonczoną implementację
            // throw new NotImplementedException();

        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);

            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new System.Net.Http.Headers.AuthenticationHeaderValue("Basic"));
            }

            context.Result = new ResponseMessageResult(result);
        }
    }
}