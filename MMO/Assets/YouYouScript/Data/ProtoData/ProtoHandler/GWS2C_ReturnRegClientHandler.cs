// <auto-generated>
//     Generated by the 悠游课堂 http://www.u3dol.com.  DO NOT EDIT!
// </auto-generated>
using YouYou;
using YouYou.Proto;

/// <summary>
/// 网关服务器返回注册客户端结果
/// </summary>
public class GWS2C_ReturnRegClientHandler
{
    public static void OnHandler(byte[] buffer)
    {
        GWS2C_ReturnRegClient proto = GWS2C_ReturnRegClient.Parser.ParseFrom(buffer);

#if DEBUG_LOG_PROTO && DEBUG_MODEL
        GameEntry.Log(LogCategory.Proto, "<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoId + "</color>");
        GameEntry.Log(LogCategory.Proto, "<color=#c5e1dc>==>>" + proto.ToString() + "</color>");
#endif
    }
}