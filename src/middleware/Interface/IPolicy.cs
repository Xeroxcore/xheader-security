namespace xheaderSecurity.Interface
{
    public interface IPolicy
    {
        string Header { get; set; }
        string Value { get; set; }
        bool Remove { get; set; }
    }
}
