// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sys_CommonEventId : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sys_CommonEventId GetRootAsSys_CommonEventId(ByteBuffer _bb) { return GetRootAsSys_CommonEventId(_bb, new Sys_CommonEventId()); }
  public static Sys_CommonEventId GetRootAsSys_CommonEventId(ByteBuffer _bb, Sys_CommonEventId obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sys_CommonEventId __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(6); }
  public string Name { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(8); }

  public static Offset<Sys_CommonEventId> CreateSys_CommonEventId(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset NameOffset = default(StringOffset)) {
    builder.StartObject(3);
    Sys_CommonEventId.AddName(builder, NameOffset);
    Sys_CommonEventId.AddDesc(builder, DescOffset);
    Sys_CommonEventId.AddId(builder, Id);
    return Sys_CommonEventId.EndSys_CommonEventId(builder);
  }

  public static void StartSys_CommonEventId(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static Offset<Sys_CommonEventId> EndSys_CommonEventId(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sys_CommonEventId>(o);
  }
};


}
