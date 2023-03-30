using System.IO;
using System.Text;

namespace WebCommon;

public class WPacketWriter : WBinWriter
{
	public WPacketWriter()
	{
	}

	public WPacketWriter(Stream output)
		: base(output)
	{
	}

	public WPacketWriter(Stream output, Encoding encoding)
		: base(output, encoding)
	{
	}

	public void Write(WPDPacketData value)
	{
		if (value == null)
		{
			Write(value: false);
			return;
		}
		Write(value: true);
		value.Serialize(this);
	}

	public void Write(WPDPacketData[] values)
	{
		if (values == null)
		{
			Write(value: false);
			return;
		}
		Write(value: true);
		Write(values.Length);
		foreach (WPDPacketData value in values)
		{
			Write(value);
		}
	}
}
