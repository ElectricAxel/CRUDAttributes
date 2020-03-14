using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CRUDAttribute {
    public static class BDBuilder {

        public static string BuildInsert(object o) {
            Type t = o.GetType();
            DBClassAttribute tableAttribute = (DBClassAttribute)Attribute.GetCustomAttribute(t, typeof(DBClassAttribute));
            if (tableAttribute == null) {
                return "";
            }

            bool first = true;
            PropertyInfo[] properties = t.GetProperties();
            DBPropertyAttribute columnAttribute;

            if (properties == null || properties.Length == 0) {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append(tableAttribute.TableName);
            sb.Append("(");
            foreach (PropertyInfo pi in properties) {
                columnAttribute = (DBPropertyAttribute)Attribute.GetCustomAttribute(pi, typeof(DBPropertyAttribute));
                if (columnAttribute != null) {
                    if (!first) {
                        sb.Append(",");
                    }
                    sb.Append(columnAttribute.ColumnName);
                    first = false;
                }
            }
            sb.Append(") VALUES(");
            first = true;
            foreach (PropertyInfo pi in properties) {
                columnAttribute = (DBPropertyAttribute)Attribute.GetCustomAttribute(pi, typeof(DBPropertyAttribute));
                if (columnAttribute != null) {
                    if (!first) {
                        sb.Append(",");
                    }
                    sb.Append("'");
                    sb.Append(pi.GetValue(o, null));
                    sb.Append("'");
                    first = false;
                }
            }
            sb.Append("); SELECT SCOPE_IDENTITY()");
            return sb.ToString();
        }
    }
}
