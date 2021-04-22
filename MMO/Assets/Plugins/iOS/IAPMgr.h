#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

@interface IAPMgr : NSObject<SKProductsRequestDelegate, SKPaymentTransactionObserver>
{
	SKProduct *proUpgradeProduct;
	SKProductsRequest *productsRequest;
}

@property (nonatomic, retain) SKProduct *proUpgradeProduct;

-(void)CancelHUD;
-(void)AttachObserver;
-(BOOL)CanMakePayment;
-(void)RequestProductData:(NSString *)productIdentifiers;
-(void)BuyRequest:(NSString *)productIdentifier;
-(void)SearchUnSuccessOrder;
-(void)BuyProductOK:(NSString *)productIdentifier;
-(void)BuyProductFail;
@end
