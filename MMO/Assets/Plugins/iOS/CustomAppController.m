#import "UnityAppController.h"
#import "WXApi.h"

//微信开发者ID
#define URL_APPID @"wx86e63d040cbc2340"

@interface CustomAppController : UnityAppController <WXApiDelegate>
@end

IMPL_APP_CONTROLLER_SUBCLASS (CustomAppController)

@implementation CustomAppController


- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    
    //向微信注册
    NSLog(@"向微信注册");
    //[WXApi registerApp:URL_APPID];
    
    //坑1enableMTA 一定要是no
    //添加libc++.tbd
    //添加libsqlite3.tbd
    //添加CoreTelephony.framework
    [WXApi registerApp:URL_APPID enableMTA:NO];
    
    return YES;
}

-(BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<NSString *,id> *)options
{
    //必须有这个 相当于注册回调
    return [WXApi handleOpenURL:url delegate:self];
}

//是微信终端向第三方程序发起请求，要求第三方程序响应。第三方程序响应完后必须调用sendRsp返回。在调用sendRsp返回时，会切回到微信终端程序界面。
-(void) onReq:(BaseReq*)reqonReq
{
    
    
}

//如果第三方程序向微信发送了sendReq的请求，那么onResp会被回调。sendReq请求调用后，会切到微信终端程序界面。
-(void) onResp:(BaseResp*)resp
{
    if([resp isKindOfClass:[SendAuthResp class]])
    {
        SendAuthResp* authResp = (SendAuthResp*)resp;
        NSLog(@"errCode==%d",authResp.errCode);
        if (authResp.errCode == 0)
        {
            //int errCode, string code, string state, string lang, string country
            UnitySendMessage("AppleStoreInterface", "OnWeixinReturnCode", [[NSString stringWithFormat:@"%d\t%@\t%@\t%@\t%@",authResp.errCode,authResp.code,authResp.state,authResp.lang,authResp.country] UTF8String]);
        }
        else
        {
            UnitySendMessage("AppleStoreInterface", "OnWeixinReturnCode", [[NSString stringWithFormat:@"%d",authResp.errCode] UTF8String]);
        }
    }
    else if([resp isKindOfClass:[PayResp class]])
    {
        //支付结果
        PayResp* payResp = (PayResp*)resp;
        int errCode = payResp.errCode;
        UnitySendMessage("AppleStoreInterface", "OnWeixinReturnCode", [[NSString stringWithFormat:@"%d",errCode] UTF8String]);
        //0    成功    展示成功页面
        //-1    错误    可能的原因：签名错误、未注册APPID、项目设置APPID不正确、注册的APPID与设置的不匹配、其他异常等。
        //-2    用户取消    无需处理。发生场景：用户不支付了，点击取消，返回APP。
    }
}

@end
