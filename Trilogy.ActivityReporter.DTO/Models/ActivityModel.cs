namespace Trilogy.ActivityReporter.DataModels.Models
{
    public class ActivityModel
    {
        /// <summary>
        /// Activity value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Time when value was added.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}