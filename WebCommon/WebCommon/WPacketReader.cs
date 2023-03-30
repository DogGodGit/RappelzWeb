using System;
using System.IO;
using System.Text;

namespace WebCommon;

public class WPacketReader : WBinReader
{
	public WPacketReader(Stream output)
		: base(output)
	{
	}

	public WPacketReader(Stream output, Encoding encoding)
		: base(output, encoding)
	{
	}

	public T ReadPDPacketData<T>() where T : WPDPacketData
	{
		if (!ReadBoolean())
		{
			return null;
		}
		T inst = Activator.CreateInstance<T>();
		inst.Deserialize(this);
		return inst;
	}

	public T[] ReadPDPacketDatas<T>() where T : WPDPacketData
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		T[] insts = new T[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadPDPacketData<T>();
		}
		return insts;
	}
}
