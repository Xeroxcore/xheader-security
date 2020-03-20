using System.Collections.Generic;
using xheaderSecurity.Interface;

namespace middleware.test
{
    public class DublicateTestHeaderPolicy : TestHeaderPolicy
    {
        public override void BuildPolicies()
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

            Headers.Add(new Policy()
            {
                Header = "TestHeader2",
                Remove = false,
                Value = "HeaderTestValue2"
            });
        }
    }
}