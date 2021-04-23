using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ExtMemoryStream : MemoryStream
{
    public short ReadShort()
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        return BitConverter.ToInt16(arr, 0);
    }

    public void WriteShort(short value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, 2);
    }

    public ushort ReadUShort()
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        return BitConverter.ToUInt16(arr, 0);
    }

    public void WriteUShort(ushort value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, 2);
    }

    public int ReadInt()
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        return BitConverter.ToInt32(arr, 0);
    }


    public void WriteInt(int value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, 4);
    }

    public bool ReadBool()
    {
        return base.ReadByte() == 1;
    }

    public void WriteBool(bool value)
    {
        base.WriteByte((byte)(value ? 1 : 0));
    }

    public void WriteUTF8String(string value)
    {
        byte[] arr = Encoding.UTF8.GetBytes(value);
        if (arr.Length > 65535)
        {
            throw new InvalidCastException("字符串长度超出范围");
        }
        WriteUShort((ushort)arr.Length);
        base.Write(arr, 0, arr.Length);
    }
    public string ReadUTF8String()
    {
        ushort len = this.ReadUShort();
        byte[] arr = new byte[len];
        base.Read(arr, 0, len);
        return Encoding.UTF8.GetString(arr, 0, len);
    }
}

