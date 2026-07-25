using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace YAHALLO.Common
{
    public class StrictDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        private static readonly Regex IsoWithOffset = new Regex(
             @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{1,7})?(Z|[+-]\d{2}:?\d{2})$",
             RegexOptions.Compiled);


        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();

            if (str is null || !IsoWithOffset.IsMatch(str))
                throw new JsonException("Timestamp phải là ISO 8601 kèm offset, VD: 2026-07-20T09:30:00+07:00 hoặc ...Z");

            return DateTimeOffset.Parse(str, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.UtcDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ", CultureInfo.InvariantCulture));
        }
    }
}
