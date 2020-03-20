using System.Collections.Generic;

namespace xheaderSecurity.Interface
{
    public interface IHeaderPolicy
    {
        IList<IPolicy> Headers { get; }
        void BuildPolicies();
    }
}
