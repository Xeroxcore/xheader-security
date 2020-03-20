using System.Collections.Generic;

namespace middleware.test
{
    public class TestHeaderPolicy : IHeaderPolicy
    {
        public IList<IPolicy> Headers { get; }

        public TestHeaderPolicy()
        {
            Headers = new List<IPolicy>();
        }

        public void BuildPolicies()
        {
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