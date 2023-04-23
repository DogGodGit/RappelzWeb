using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DateTimeUtil의 요약 설명입니다.
/// </summary>
public static class DateTimeUtil
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Constants

    public const string kFormat_Date = "yyyy-MM-dd";
    public const string kFormat_Time = "HH:mm:ss";
    public const string kFormat_Offset = "zzz";

	public const string kFormat_SearchDateTime = "yyyy-MM-dd HH:mm";

    public const string kFormat_DateTime = kFormat_Date + " " + kFormat_Time;
    public const string kFormat_DateTime_Offset = kFormat_Date + " " + kFormat_Time + " " + kFormat_Offset;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Static member functions

    public static string ToDateString(DateTime dt)
    {
        return dt.ToString(kFormat_Date);
    }

    public static string ToDateTimeString(DateTime dt)
    {
        return dt.ToString(kFormat_DateTime);
    }

    public static string ToDateTimeOffsetString(DateTimeOffset dt)
    {
        return dt.ToString(kFormat_DateTime_Offset);
    }

	public static string ToDateTimeOffsetSearchString(DateTimeOffset dt)
	{
		return dt.ToString(kFormat_SearchDateTime);
	}

	public static DateTimeOffset ToValidDateTimeOffset(string sDate, DateTimeOffset dto)
	{
		try
		{
			dto = DateTimeOffset.Parse(sDate);
		}
		catch { }

		return dto;
	}
}
