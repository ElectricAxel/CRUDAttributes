using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAttribute {
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DBPropertyAttribute : Attribute {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string columnName;

        // This is a positional argument
        public DBPropertyAttribute(string column) {
            this.columnName = column;
        }

        public string ColumnName {
            get { return columnName; }
        }
    }
}
