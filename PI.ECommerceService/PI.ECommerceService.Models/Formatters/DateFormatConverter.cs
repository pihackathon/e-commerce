using Newtonsoft.Json.Converters;

namespace PI.ECommerceService.Models.Formatters
{
    /// <summary>
    /// Date formatter.
    /// </summary>
    public class DateFormatConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateFormatConverter"/> class.
        /// </summary>
        /// <param name="format">format of the date.</param>
        public DateFormatConverter(string format)
        {
            this.DateTimeFormat = format;
        }
    }
}
