namespace Trilogy.ActivityReporter.DAL
{
    public interface IUnitOwner
    {
        DateTime UtcNow { get; }
        void Configure();
    }
}