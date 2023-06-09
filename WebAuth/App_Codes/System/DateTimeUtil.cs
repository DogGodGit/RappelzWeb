﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DateTimeUtil'的摘要描述.
/// </summary>
public static class DateTimeUtil
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const string kFormat_Date = "yyyy-MM-dd";
	public const string kFormat_Time = "HH:mm:ss";
	public const string kFormat_Offset = "zzz";

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
}