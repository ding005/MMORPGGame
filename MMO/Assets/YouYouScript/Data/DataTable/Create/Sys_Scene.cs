// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sys_Scene : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sys_Scene GetRootAsSys_Scene(ByteBuffer _bb) { return GetRootAsSys_Scene(_bb, new Sys_Scene()); }
  public static Sys_Scene GetRootAsSys_Scene(ByteBuffer _bb, Sys_Scene obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sys_Scene __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string SceneName { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSceneNameBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetSceneNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetSceneNameArray() { return __p.__vector_as_array<byte>(6); }
  public int BGMId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SceneType { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<Sys_Scene> CreateSys_Scene(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset SceneNameOffset = default(StringOffset),
      int BGMId = 0,
      int SceneType = 0) {
    builder.StartObject(4);
    Sys_Scene.AddSceneType(builder, SceneType);
    Sys_Scene.AddBGMId(builder, BGMId);
    Sys_Scene.AddSceneName(builder, SceneNameOffset);
    Sys_Scene.AddId(builder, Id);
    return Sys_Scene.EndSys_Scene(builder);
  }

  public static void StartSys_Scene(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddSceneName(FlatBufferBuilder builder, StringOffset SceneNameOffset) { builder.AddOffset(1, SceneNameOffset.Value, 0); }
  public static void AddBGMId(FlatBufferBuilder builder, int BGMId) { builder.AddInt(2, BGMId, 0); }
  public static void AddSceneType(FlatBufferBuilder builder, int SceneType) { builder.AddInt(3, SceneType, 0); }
  public static Offset<Sys_Scene> EndSys_Scene(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sys_Scene>(o);
  }
};


}
