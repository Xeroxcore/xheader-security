using System.Collections.Generic;

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