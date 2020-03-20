using System.Collections.Generic;

public interface IHeaderPolicy
{
    IList<IPolicy> Headers { get; }
    void BuildPolicies();
}