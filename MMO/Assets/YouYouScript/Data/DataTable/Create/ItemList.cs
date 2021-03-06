// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct ItemList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ItemList GetRootAsItemList(ByteBuffer _bb) { return GetRootAsItemList(_bb, new ItemList()); }
  public static ItemList GetRootAsItemList(ByteBuffer _bb, ItemList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ItemList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Item? Items(int j) { int o = __p.__offset(4); return o != 0 ? (Item?)(new Item()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ItemsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<ItemList> CreateItemList(FlatBufferBuilder builder,
      VectorOffset ItemsOffset = default(VectorOffset)) {
    builder.StartObject(1);
    ItemList.AddItems(builder, ItemsOffset);
    return ItemList.EndItemList(builder);
  }

  public static void StartItemList(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddItems(FlatBufferBuilder builder, VectorOffset ItemsOffset) { builder.AddOffset(0, ItemsOffset.Value, 0); }
  public static VectorOffset CreateItemsVector(FlatBufferBuilder builder, Offset<Item>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateItemsVectorBlock(FlatBufferBuilder builder, Offset<Item>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartItemsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<ItemList> EndItemList(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ItemList>(o);
  }
};


}
