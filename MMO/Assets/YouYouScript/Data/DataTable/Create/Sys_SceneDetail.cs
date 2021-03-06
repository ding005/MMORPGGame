// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sys_SceneDetail : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sys_SceneDetail GetRootAsSys_SceneDetail(ByteBuffer _bb) { return GetRootAsSys_SceneDetail(_bb, new Sys_SceneDetail()); }
  public static Sys_SceneDetail GetRootAsSys_SceneDetail(ByteBuffer _bb, Sys_SceneDetail obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sys_SceneDetail __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SceneId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string ScenePath { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetScenePathBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetScenePathBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetScenePathArray() { return __p.__vector_as_array<byte>(8); }
  public int SceneGrade { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<Sys_SceneDetail> CreateSys_SceneDetail(FlatBufferBuilder builder,
      int Id = 0,
      int SceneId = 0,
      StringOffset ScenePathOffset = default(StringOffset),
      int SceneGrade = 0) {
    builder.StartObject(4);
    Sys_SceneDetail.AddSceneGrade(builder, SceneGrade);
    Sys_SceneDetail.AddScenePath(builder, ScenePathOffset);
    Sys_SceneDetail.AddSceneId(builder, SceneId);
    Sys_SceneDetail.AddId(builder, Id);
    return Sys_SceneDetail.EndSys_SceneDetail(builder);
  }

  public static void StartSys_SceneDetail(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddSceneId(FlatBufferBuilder builder, int SceneId) { builder.AddInt(1, SceneId, 0); }
  public static void AddScenePath(FlatBufferBuilder builder, StringOffset ScenePathOffset) { builder.AddOffset(2, ScenePathOffset.Value, 0); }
  public static void AddSceneGrade(FlatBufferBuilder builder, int SceneGrade) { builder.AddInt(3, SceneGrade, 0); }
  public static Offset<Sys_SceneDetail> EndSys_SceneDetail(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sys_SceneDetail>(o);
  }
};


}
