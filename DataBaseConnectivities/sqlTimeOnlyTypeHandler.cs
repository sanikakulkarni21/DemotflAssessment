using Dapper;
using System;
using System.Data;

namespace DataBaseConnectivities
{
    // Custom type handler for Dapper to manage TimeOnly data type.
    public class SqlTimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
    {
        // Converts TimeOnly to SQL Time (TimeSpan) when saving.
        public override void SetValue(IDbDataParameter parameter, TimeOnly value)
        {
            parameter.Value = value.ToTimeSpan();
        }

        // Converts SQL Time (TimeSpan) back to TimeOnly when reading.
        public override TimeOnly Parse(object value)
        {
            return TimeOnly.FromTimeSpan((TimeSpan)value);
        }
    }
}
