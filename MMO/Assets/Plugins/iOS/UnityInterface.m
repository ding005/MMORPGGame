#import "UnityInterface.h"
#import "IAPMgr.h"
#import "WXApi.h"


@implementation UnityInterface

//=================================

IAPMgr *iapMgr = nil;

//初始化付费管理器
void InitIAPMgr()
{
    iapMgr = [[IAPMgr alloc] init];
    [iapMgr AttachObserver]; //添加苹果支付中心订单监听
}

//请求充值产品信息
void RequstProductInfo(void *p)
{
    NSString *list = [NSString stringWithUTF8String:p];
    //NSLog(@"productKey:%@",list);
    [iapMgr RequestProductData:list];
}

//购买充值产品
void BuyProduct(void *p)
{
    [iapMgr BuyRequest:[NSString stringWithUTF8String:p]];
}

//发了元宝后 告诉iOS充值成功
void BuyProductOK(void *p)
{
	[iapMgr BuyProductOK:[NSString stringWithUTF8String:p]];
}

//购买失败
void BuyProductFail()
{
	[iapMgr BuyProductFail];
}

//取消HUD
void CancelHUD()
{
    [iapMgr CancelHUD];
}

//=========weixin==========



//初始化微信
void Initweixin()
{
    //如果安装了微信 发1
    if([WXApi isWXAppInstalled])
    {
        UnitySendMessage("AppleStoreInterface", "OnCheckWeixin", "1");
    }
    else
    {
        UnitySendMessage("AppleStoreInterface", "OnCheckWeixin", "0");
    }
}

void WeixinLogOn(char *state)
{
    //第一步：请求CODE
    
    //构造SendAuthReq结构体
    SendAuthReq* req =[[SendAuthReq alloc] init];
    req.scope = @"snsapi_userinfo";
    req.state = [NSString stringWithUTF8String:state]; //透传参数
    //第三方向微信终端发送一个SendAuthReq消息结构
    [WXApi sendReq:req];
}

//微信支付
void WeixinPay(char *partnerId, char *prepayId, char *nonceStr, char *timeStamp, char *package, char *sign)
{
    PayReq* req = [[PayReq alloc] init];
    
    //转换时间戳格式
    NSString *timeSp = [NSString stringWithUTF8String:timeStamp];
    int timesta=[timeSp intValue];
    UInt32 utimestamp = (UInt32)timesta;
    
    req.partnerId = [NSString stringWithUTF8String:partnerId];
    req.prepayId = [NSString stringWithUTF8String:prepayId];
    req.nonceStr = [NSString stringWithUTF8String:nonceStr];
    req.timeStamp = utimestamp;
    req.package = [NSString stringWithUTF8String:package];
    req.sign = [NSString stringWithUTF8String:sign];
    
    [WXApi sendReq:req];
}
//=========weixin==========

@end
