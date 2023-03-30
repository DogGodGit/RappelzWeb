using System;
using System.IO;
using System.Text;

namespace WebCommon;

public class WBinReader : BinaryReader
{
	public WBinReader(Stream output)
		: base(output)
	{
	}

	public WBinReader(Stream output, Encoding encoding)
		: base(output, encoding)
	{
	}

	public virtual T ReadEnumByte<T>()
	{
		return (T)Enum.ToObject(typeof(T), ReadByte());
	}

	public virtual T[] ReadEnumBytes<T>()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		T[] insts = new T[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadEnumByte<T>();
		}
		return insts;
	}

	public virtual T ReadEnumInt<T>()
	{
		return (T)Enum.ToObject(typeof(T), ReadInt32());
	}

	public virtual T[] ReadEnumInts<T>()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		T[] insts = new T[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadEnumInt<T>();
		}
		return insts;
	}

	public override string ReadString()
	{
		return ReadBoolean() ? base.ReadString() : null;
	}

	public virtual string[] ReadStrings()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		string[] insts = new string[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadString();
		}
		return insts;
	}

	public virtual byte[] ReadBytes()
	{
		return ReadBoolean() ? ReadBytes(ReadInt32()) : null;
	}

	public virtual short[] ReadShorts()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		short[] insts = new short[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadInt16();
		}
		return insts;
	}

	public virtual int[] ReadInts()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		int[] insts = new int[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadInt32();
		}
		return insts;
	}

	public virtual long[] ReadLongs()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		long[] insts = new long[nCount];
		for (int i = 0; i < nCount; i++)
		{
			insts[i] = ReadInt64();
		}
		return insts;
	}

	public virtual TimeSpan ReadTimeSpan()
	{
		return TimeSpan.FromTicks(ReadInt64());
	}

	public virtual TimeSpan? ReadNullableTimeSpan()
	{
		long? value = ReadNullableLong();
		return (!value.HasValue) ? null : new TimeSpan?(TimeSpan.FromTicks(value.Value));
	}

	public virtual DateTime ReadDateTime()
	{
		return DateTime.FromBinary(ReadInt64());
	}

	public virtual DateTime? ReadNullableDateTime()
	{
		long? value = ReadNullableLong();
		return (!value.HasValue) ? null : new DateTime?(DateTime.FromBinary(value.Value));
	}

	public virtual DateTimeOffset ReadDateTimeOffset()
	{
		return new DateTimeOffset(ReadDateTime(), ReadTimeSpan());
	}

	public virtual DateTimeOffset? ReadNullableDateTimeOffset()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		return ReadDateTimeOffset();
	}

	public virtual Guid ReadGuid()
	{
		return new Guid(ReadBytes());
	}

	public virtual Guid? ReadNullableGuid()
	{
		byte[] bytes = ReadBytes();
		return (bytes == null) ? null : new Guid?(new Guid(bytes));
	}

	public virtual Guid[] ReadGuids()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		int nCount = ReadInt32();
		Guid[] insts = new Guid[nCount];
		for (int i = 0; i < nCount; i++)
		{
			ref Guid reference = ref insts[i];
			reference = ReadGuid();
		}
		return insts;
	}

	public virtual byte? ReadNullableByte()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		return base.ReadByte();
	}

	public virtual short? ReadNullableShort()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		return base.ReadInt16();
	}

	public virtual int? ReadNullableInt()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		return base.ReadInt32();
	}

	public virtual long? ReadNullableLong()
	{
		if (!ReadBoolean())
		{
			return null;
		}
		return base.ReadInt64();
	}
}
