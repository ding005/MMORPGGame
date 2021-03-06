// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct RechargeShop : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static RechargeShop GetRootAsRechargeShop(ByteBuffer _bb) { return GetRootAsRechargeShop(_bb, new RechargeShop()); }
  public static RechargeShop GetRootAsRechargeShop(ByteBuffer _bb, RechargeShop obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public RechargeShop __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Type { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Price { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span(10); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(10); }
  public string SalesDesc { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSalesDescBytes() { return __p.__vector_as_span(12); }
#else
  public ArraySegment<byte>? GetSalesDescBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetSalesDescArray() { return __p.__vector_as_array<byte>(12); }
  public string ProductDesc { get { int o = __p.__offset(14); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetProductDescBytes() { return __p.__vector_as_span(14); }
#else
  public ArraySegment<byte>? GetProductDescBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public byte[] GetProductDescArray() { return __p.__vector_as_array<byte>(14); }
  public int Virtual { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Icon { get { int o = __p.__offset(18); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIconBytes() { return __p.__vector_as_span(18); }
#else
  public ArraySegment<byte>? GetIconBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public byte[] GetIconArray() { return __p.__vector_as_array<byte>(18); }

  public static Offset<RechargeShop> CreateRechargeShop(FlatBufferBuilder builder,
      int Id = 0,
      int Type = 0,
      int Price = 0,
      StringOffset NameOffset = default(StringOffset),
      StringOffset SalesDescOffset = default(StringOffset),
      StringOffset ProductDescOffset = default(StringOffset),
      int Virtual = 0,
      StringOffset IconOffset = default(StringOffset)) {
    builder.StartObject(8);
    RechargeShop.AddIcon(builder, IconOffset);
    RechargeShop.AddVirtual(builder, Virtual);
    RechargeShop.AddProductDesc(builder, ProductDescOffset);
    RechargeShop.AddSalesDesc(builder, SalesDescOffset);
    RechargeShop.AddName(builder, NameOffset);
    RechargeShop.AddPrice(builder, Price);
    RechargeShop.AddType(builder, Type);
    RechargeShop.AddId(builder, Id);
    return RechargeShop.EndRechargeShop(builder);
  }

  public static void StartRechargeShop(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddType(FlatBufferBuilder builder, int Type) { builder.AddInt(1, Type, 0); }
  public static void AddPrice(FlatBufferBuilder builder, int Price) { builder.AddInt(2, Price, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(3, NameOffset.Value, 0); }
  public static void AddSalesDesc(FlatBufferBuilder builder, StringOffset SalesDescOffset) { builder.AddOffset(4, SalesDescOffset.Value, 0); }
  public static void AddProductDesc(FlatBufferBuilder builder, StringOffset ProductDescOffset) { builder.AddOffset(5, ProductDescOffset.Value, 0); }
  public static void AddVirtual(FlatBufferBuilder builder, int Virtual) { builder.AddInt(6, Virtual, 0); }
  public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset) { builder.AddOffset(7, IconOffset.Value, 0); }
  public static Offset<RechargeShop> EndRechargeShop(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<RechargeShop>(o);
  }
};


}
