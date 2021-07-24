using Newtonsoft.Json.Converters;

namespace Base.Repository.Utils
{
    public class DateTimeFormatConverter : IsoDateTimeConverter
    {
        public DateTimeFormatConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }
}