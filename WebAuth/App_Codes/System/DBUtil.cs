using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

/// <summary>
/// DBUtil'的摘要描述.
/// </summary>
public static class DBUtil
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Static member functions

    public static void Close(ref SqlConnection conn)
    {
        if (conn == null)
            return;

        conn.Close();
        conn = null;
    }

    public static void Commit(ref SqlTransaction trans)
    {
        if (trans == null)
            return;

        trans.Commit();
        trans = null;
    }

    public static SqlConnection GetConnection(ConnectionStringSettings settings)
    {
        if (settings == null)
            return null;

        return new SqlConnection(settings.ConnectionString);
    }

    public static SqlConnection GetUserConnection()
    {
        return GetConnection(Config.rappelzUserConnectionString);
    }

    public static SqlConnection GetGameDBConn(string sConnectionString)
    {
        return new SqlConnection(sConnectionString);
    }

    public static void Rollback(ref SqlTransaction trans)
    {
        if (trans == null)
            return;

        trans.Rollback();
        trans = null;
    }

    public static string EscapeSingleQuote(string sValue)
    {
        return sValue == null ? null : sValue.Replace("'", "''");
    }

    public static object NullToDBNull(object value)
    {
        return value == null ? DBNull.Value : value;
    }

    //
    // DB 데이터 캐스팅 함수
    // DBNull인 경우 기본값을 반환한다.
    //

    public static T Convert<T>(object value)
    {
        return Convert<T>(value, default(T));
    }

    public static T Convert<T>(object value, T valueForDBNull)
    {
        return value == DBNull.Value ? valueForDBNull : (T)value;
    }

    public static DataTable ObjectToTable(object obj)
    {
        try
        {
            Type t;
            if (obj.GetType().IsGenericType)
            {
                t = obj.GetType().GetGenericTypeDefinition();
            }
            else
            {
                t = obj.GetType();
            }

            const BindingFlags InstanceBindFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

            if (t == typeof(List<>) || obj is Array ||
                t == typeof(IEnumerable<>))
            {
                DataTable dt = new DataTable();
                IEnumerable<object> lstenum = obj as IEnumerable<object>;
                if (lstenum.Count() > 0)
                {
                    var ob1 = lstenum.GetEnumerator();
                    ob1.MoveNext();
                    foreach (var item in ob1.Current.GetType().GetFields())
                    {
                        dt.Columns.Add(new DataColumn() { ColumnName = item.Name });
                    }
                    //数据
                    foreach (var item in lstenum)
                    {
                        DataRow row = dt.NewRow();
                        Type type = ob1.Current.GetType();
                        foreach (var sub in type.GetFields())
                        {
                            FieldInfo property = type.GetField(sub.Name, InstanceBindFlags);
                            if (property != null)
                            {
                                row[sub.Name] = property.GetValue(item);
                            }
                        }
                        dt.Rows.Add(row);
                    }
                    return dt;
                }
            }
            else if (t == typeof(DataTable))
            {
                return (DataTable)obj;
            }
            else   //(t==typeof(Object))
            {
                DataTable dt = new DataTable();
                DataRow row = dt.NewRow();

                Type type = obj.GetType();
                foreach (var item in type.GetFields())
                {
                    dt.Columns.Add(new DataColumn() { ColumnName = item.Name });

                    FieldInfo property = type.GetField(item.Name, InstanceBindFlags);
                    if (property != null)
                    {
                        row[item.Name] = property.GetValue(obj);
                    }
                }
                dt.Rows.Add(row);

                return dt;
            }
        }
        catch (Exception ex)
        {
        }
        return null;
    }

    public static string DataTableToJson(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    public static string DataTableToCsv(DataTable vContent)
    {
        StringBuilder sCsvContent;

        sCsvContent = new StringBuilder();

        for (int i = 0; i < vContent.Columns.Count; i++)
        {
            sCsvContent.Append(vContent.Columns[i].ColumnName);
            sCsvContent.Append(i == vContent.Columns.Count - 1 ? "\r\n" : ",");
        }

        foreach (DataRow row in vContent.Rows)
        {
            for (int i = 0; i < vContent.Columns.Count; i++)
            {
                sCsvContent.Append(row[i].ToString().Trim());
                sCsvContent.Append(i == vContent.Columns.Count - 1 ? "\r\n" : ",");
            }
        }
        return sCsvContent.ToString();
    }
}