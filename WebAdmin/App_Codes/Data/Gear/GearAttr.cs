using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GearAttr의 요약 설명입니다.
/// </summary>
public class GearAttr
{
	public int attrId;
	public int value;

	public GearAttr(int nAttrId, int nValue)
	{
		attrId = nAttrId;
		value = nValue;
	}
}