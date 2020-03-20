using System.Collections.Generic;
using xheaderSecurity.Interface;

namespace middleware.test
{
    public class EmptyTestHeaderPolicy : TestHeaderPolicy
    {
        public override void BuildPolicies()
        {
            Headers = new List<IPolicy>();
        }
    }
}