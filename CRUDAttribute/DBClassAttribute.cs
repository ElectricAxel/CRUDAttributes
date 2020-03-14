using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAttribute {
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DBClassAttribute : Attribute {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string tableName;

        // This is a positional argument
        public DBClassAttribute(string table) {
            this.tableName = table;
        }

        public string TableName {
            get { return tableName; }
        }
    }
}
