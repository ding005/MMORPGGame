// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sys_Localization : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sys_Localization GetRootAsSys_Localization(ByteBuffer _bb) { return GetRootAsSys_Localization(_bb, new Sys_Localization()); }
  public static Sys_Localization GetRootAsSys_Localization(ByteBuffer _bb, Sys_Localization obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sys_Localization __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Key { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKeyBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetKeyBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetKeyArray() { return __p.__vector_as_array<byte>(4); }
  public string Value { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetValueBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetValueBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetValueArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Sys_Localization> CreateSys_Localization(FlatBufferBuilder builder,
      StringOffset KeyOffset = default(StringOffset),
      StringOffset ValueOffset = default(StringOffset)) {
    builder.StartObject(2);
    Sys_Localization.AddValue(builder, ValueOffset);
    Sys_Localization.AddKey(builder, KeyOffset);
    return Sys_Localization.EndSys_Localization(builder);
  }

  public static void StartSys_Localization(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddKey(FlatBufferBuilder builder, StringOffset KeyOffset) { builder.AddOffset(0, KeyOffset.Value, 0); }
  public static void AddValue(FlatBufferBuilder builder, StringOffset ValueOffset) { builder.AddOffset(1, ValueOffset.Value, 0); }
  public static Offset<Sys_Localization> EndSys_Localization(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sys_Localization>(o);
  }
};


}
