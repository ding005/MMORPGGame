#import "IAPMgr.h"
#import "SVProgressHUD.h"

@implementation IAPMgr

@synthesize proUpgradeProduct;

//取消HUD
-(void)CancelHUD
{
    [SVProgressHUD dismiss];
}

//添加苹果支付中心订单监听
-(void) AttachObserver
{
    [[SKPaymentQueue defaultQueue] addTransactionObserver:self];
}

//取消支付
-(BOOL) CanMakePayment
{
    return [SKPaymentQueue canMakePayments];
}

//请求充值产品信息
-(void) RequestProductData:(NSString *)productId
{
    NSLog(@"请求充值产品信息:%@",productId);
    NSArray *idArray = [productId componentsSeparatedByString:@"\t"];
    NSSet *idSet = [NSSet setWithArray:idArray];
    [self sendRequest:idSet];
}

//真正的向苹果支付中心发送请求
-(void)sendRequest:(NSSet *)idSet
{
    SKProductsRequest *request = [[SKProductsRequest alloc] initWithProductIdentifiers:idSet];
    request.delegate = self;
    [request start];
}

//定义产品列表 保存起来
NSArray *products;

//苹果支付中心返回请求结果
-(void)productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response
{
	//把有效的产品Id保存起来
    products = [response.products copy];
    
    for (SKProduct *productId in products) {
        NSLog(@"有效的产品Id:%@",productId);
    }
    
    for(NSString *invalidProductId in response.invalidProductIdentifiers){
        NSLog(@"无效的产品Id:%@",invalidProductId);
    }
}

//获取当前的产品编号
-(NSString *)GetCurrProductId
{
    return [[NSUserDefaults standardUserDefaults] objectForKey:@"m_CurrProductId"];
}

//设置当前的产品编号
-(void) SetCurrProductId:(NSString *)productId
{
    [[NSUserDefaults standardUserDefaults] setObject:productId forKey:@"m_CurrProductId"];
}

//查询是否存在未完成订单 购买的时候 先执行这个
-(void) SearchUnSuccessOrder
{
    [SVProgressHUD showWithStatus:@"正在查询交易数据"];
    [[SKPaymentQueue defaultQueue] restoreCompletedTransactions];//查询未完成交易
}

//请求购买充值产品
-(void)BuyRequest:(NSString *)productId
{
    [self SetCurrProductId:productId];
    NSLog(@"先查询是否存在未完成订单");
    [self SearchUnSuccessOrder];
}

//购买充值产品
-(void)BuyProductRequest:(NSString *)productId
{
    if(products == nil || products.count == 0)
    {
        return;
    }
    
    NSLog(@"正在购买的产品Id:%@",productId);
    [SVProgressHUD showWithStatus:@"加载中，请稍候。。。"];
    
    for (SKProduct *p in products) {
        if([p.productIdentifier isEqualToString:productId])
        {
            proUpgradeProduct=p;
            break;
        }
    }
    
    SKMutablePayment *payment = [SKMutablePayment paymentWithProduct:proUpgradeProduct];
    payment.quantity = 1;
    [[SKPaymentQueue defaultQueue] addPayment:payment];
}

//返回交易回执字符串
-(NSString *)transactionInfo:(SKPaymentTransaction *)transaction
{
    return [self encode:(uint8_t *)transaction.transactionReceipt.bytes length:transaction.transactionReceipt.length];
}

//进行编码
-(NSString *)encode:(const uint8_t *)input length:(NSInteger) length
{
    static char table[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    
    NSMutableData *data = [NSMutableData dataWithLength:((length+2)/3)*4];
    uint8_t *output = (uint8_t *)data.mutableBytes;
    
    for(NSInteger i=0; i<length; i+=3){
        NSInteger value = 0;
        for (NSInteger j= i; j<(i+3); j++) {
            value<<=8;
            
            if(j<length){
                value |=(0xff & input[j]);
            }
        }
        
        NSInteger index = (i/3)*4;
        output[index + 0] = table[(value>>18) & 0x3f];
        output[index + 1] = table[(value>>12) & 0x3f];
        output[index + 2] = (i+1)<length ? table[(value>>6) & 0x3f] : '=';
        output[index + 3] = (i+2)<length ? table[(value>>0) & 0x3f] : '=';
    }
    
    return [[NSString alloc] initWithData:data encoding:NSASCIIStringEncoding];
}

-(void) provideContent:(SKPaymentTransaction *)transaction
{
    NSLog(@"youyou 发送回执 %@", [self transactionInfo:transaction]);
    UnitySendMessage("AppleStoreInterface", "ProvideContent", [[self transactionInfo:transaction] UTF8String]);
}

-(void) BuyProductOK:(NSString *)productId
{
    SKPaymentTransaction* t = [self searchTransaction:productId];
    [[SKPaymentQueue defaultQueue] finishTransaction:t];
    [SVProgressHUD dismiss];
}

-(void) BuyProductFail
{
    [SVProgressHUD dismiss];
}

//查询交易
-(SKPaymentTransaction*)searchTransaction:(NSString *)productId
{
    NSArray* array = [SKPaymentQueue defaultQueue].transactions;
    if([array count] <= 0){
        return nil;
    }
    
    for (SKPaymentTransaction *transaction in array) {
        return transaction;
    }
    
    return nil;
}

//苹果支付中心返回交易更新
-(void)paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray *)transactions{
    for (SKPaymentTransaction *transaction in transactions) {
        
        NSLog(@"transactionState: %ld",transaction.transactionState);
        
        switch (transaction.transactionState) {
            case SKPaymentTransactionStatePurchasing:
                NSLog(@"SKPaymentTransactionStatePurchasing");
                break;
            case SKPaymentTransactionStatePurchased:
                NSLog(@"SKPaymentTransactionStatePurchased");
                [self completeTransaction:transaction];
                break;
            case SKPaymentTransactionStateFailed:
                NSLog(@"SKPaymentTransactionStateFailed");
                [self failedTransaction:transaction];
                break;
            case SKPaymentTransactionStateRestored:
                NSLog(@"SKPaymentTransactionStateRestored");
                [self restoreTransaction:transaction];
                break;
            default:
                break;
        }
    }
}

//启动完成交易流程
-(void) completeTransaction:(SKPaymentTransaction *)transaction
{
    //NSLog(@"Comblete transaction : %@",transaction.transactionIdentifier);
    [self provideContent:transaction];
}

-(void) failedTransaction:(SKPaymentTransaction *)transaction{
    [SVProgressHUD dismiss];
    NSLog(@"youyou 交易失败: %ld",transaction.error.code);
    
    if (transaction.error.code == SKErrorPaymentCancelled || transaction.error.code == SKErrorUnknown) {
        UnitySendMessage("AppleStoreInterface", "CancelPay", "");
    }
    
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

-(void) restoreTransaction:(SKPaymentTransaction *)transaction{
    [SVProgressHUD dismiss];
    NSLog(@"youyou Restore transaction : %@",transaction.transactionIdentifier);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

//
- (void)paymentQueue:(SKPaymentQueue *)queue restoreCompletedTransactionsFailedWithError:(NSError *)error
{
    NSLog(@"查询未完成订单失败");
    [SVProgressHUD dismiss];
}

- (void)paymentQueueRestoreCompletedTransactionsFinished:(SKPaymentQueue *)queue
{
    NSLog(@"未完成交易订单数量=%lu",(unsigned long)[queue.transactions count]);
    if ([queue.transactions count] > 0)
    {
        //如果存在未完成订单 则恢复交易
        NSLog(@"如果存在未完成订单 则恢复交易");
        [SVProgressHUD showWithStatus:@"正在恢复交易。。。"];
        for (SKPaymentTransaction *transaction in queue.transactions) {
            [self completeTransaction:transaction];
            break;
        }
    }
    else
    {
        //如果不存在未完成订单 则继续购买
        NSLog(@"如果不存在未完成订单 则继续购买");
        [self BuyProductRequest:[self GetCurrProductId]];
    }
}

@end
