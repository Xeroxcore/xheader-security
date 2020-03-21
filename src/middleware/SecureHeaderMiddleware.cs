using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using xheaderSecurity.Interface;

namespace xheaderSecurity
{
    public class SecureHeaderMiddleware
    {
        protected readonly RequestDelegate Next;
        protected IHeaderPolicy Policy { get; }
        protected bool StopOnException { get; }
        public SecureHeaderMiddleware(RequestDelegate next, IHeaderPolicy policy, bool stopOnException = true)
        {
            Next = next;
            if (Validation.ObjectIsNull(policy))
                throw new Exception("Error: The Constructor input parameter policy is null");
            Policy = policy;
            StopOnException = stopOnException;
        }

        protected void AddToHeader(string header, string value, IHeaderDictionary headerList)
        {
            if (!headerList.ContainsKey(header))
                headerList.Add(header, value);

        }

        protected void RemoveFromHeader(string header, IHeaderDictionary headerList)
            => headerList.Remove(header);

        protected void ImplementSecurityPolicy(IHeaderDictionary headers)
        {
            foreach (var policy in Policy.Headers)
            {
                if (!policy.Remove)
                    AddToHeader(policy.Header, policy.Value, headers);
                else
                    RemoveFromHeader(policy.Header, headers);
            }
        }

        protected void PolicyIsValid()
        {
            if (Validation.ObjectIsNull(Policy.Headers))
                throw new Exception("Error: Assigned list of header policies in your policy is null");
            if (!Validation.ListIsGreateThanValue(Policy.Headers, 0))
                throw new Exception("Warning: Assigned list of header policies in your policy is empty");
        }

        public virtual async Task Invoke(HttpContext context)
        {
            try
            {
                var headers = context.Response.Headers;
                Policy.BuildPolicies();
                PolicyIsValid();
                ImplementSecurityPolicy(headers);
                await Next(context);
            }
            catch
            {
                if (StopOnException)
                    throw;
            }
        }
    }
}
