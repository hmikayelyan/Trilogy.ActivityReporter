namespace Trilogy.ActivityReporter.DAL.Impl
{
    /// <summary>
    /// This class is a simple representation of the big idea to have a unit owner for every request. 
    /// If we evaluate the program further, we can configure unit owner in authorization block and have its basic parameters everywhere in our code. 
    /// In this case, we just set request time, so when we compare 2 dates, those would be captured in the same place, and no issues can happen there.
    /// </summary>
    public class UnitOwner : IUnitOwner
    {
        public DateTime UtcNow { get; private set; }
        public bool IsConfigured { get; private set; }

        public void Configure()
        {
            if (!IsConfigured)
            {
                IsConfigured = true;
                UtcNow = DateTime.UtcNow;
            }
            else
            {
                throw new InvalidOperationException("Unit Owner is already configured");
            }
        }
    }
}