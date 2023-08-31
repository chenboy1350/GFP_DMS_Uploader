using System;
using System.Data;

namespace DMSUpload_Helper.Library
{
    public class ClassParamsAdd : IDbDataParameter
    {
        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable => throw new NotImplementedException();
        public string ParameterName { get; set; }
        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; }
        public object Value { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public int Size { get; set; }

        public ClassParamsAdd(string parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
        }
        public ClassParamsAdd(string parameterName, object value, DbType dbType)
        {
            ParameterName = parameterName;
            Value = value;
            DbType = dbType;
        }
    }
}
