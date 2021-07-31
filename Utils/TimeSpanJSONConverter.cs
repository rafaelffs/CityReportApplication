using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.Utils
{
    public class TimeSpanJSONConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTime.Parse(reader.GetString()).TimeOfDay;

        public override void Write(
            Utf8JsonWriter writer,
            TimeSpan timeSpan,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(timeSpan.ToString(
                    "H:mm tt", CultureInfo.InvariantCulture));
    }
}
