// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sys_StorySoundList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sys_StorySoundList GetRootAsSys_StorySoundList(ByteBuffer _bb) { return GetRootAsSys_StorySoundList(_bb, new Sys_StorySoundList()); }
  public static Sys_StorySoundList GetRootAsSys_StorySoundList(ByteBuffer _bb, Sys_StorySoundList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sys_StorySoundList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Sys_StorySound? SysStorySounds(int j) { int o = __p.__offset(4); return o != 0 ? (Sys_StorySound?)(new Sys_StorySound()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int SysStorySoundsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Sys_StorySoundList> CreateSys_StorySoundList(FlatBufferBuilder builder,
      VectorOffset Sys_StorySoundsOffset = default(VectorOffset)) {
    builder.StartObject(1);
    Sys_StorySoundList.AddSysStorySounds(builder, Sys_StorySoundsOffset);
    return Sys_StorySoundList.EndSys_StorySoundList(builder);
  }

  public static void StartSys_StorySoundList(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddSysStorySounds(FlatBufferBuilder builder, VectorOffset SysStorySoundsOffset) { builder.AddOffset(0, SysStorySoundsOffset.Value, 0); }
  public static VectorOffset CreateSysStorySoundsVector(FlatBufferBuilder builder, Offset<Sys_StorySound>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateSysStorySoundsVectorBlock(FlatBufferBuilder builder, Offset<Sys_StorySound>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartSysStorySoundsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Sys_StorySoundList> EndSys_StorySoundList(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sys_StorySoundList>(o);
  }
};


}
