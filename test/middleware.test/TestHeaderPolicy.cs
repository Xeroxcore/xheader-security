using System.Collections.Generic;

namespace middleware.test
{
    public class TestHeaderPolicy : IHeaderPolicy
    {
        public IList<IPolicy> Headers { get; set; }

        public virtual void BuildPolicies()
        {
            Headers = new List<IPolicy>();
            Headers.Add(new Policy()
            {
                Header = "TestHeader",
                Remove = false,
                Value = "HeaderTestValue"
            });

            Headers.Add(new Policy()
            {
                Header = "TestHeader2",
                Remove = false,
                Value = "HeaderTestValue2"
            });
        }
    }
}