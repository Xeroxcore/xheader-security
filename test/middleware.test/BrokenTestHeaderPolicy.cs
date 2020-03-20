namespace middleware.test
{
    public class BrokenTestHeaderPolicy : TestHeaderPolicy
    {
        public override void BuildPolicies()
        {
            Headers = null;
        }
    }
}