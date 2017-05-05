namespace Shop.Models
{
    public enum UserTypeEnum
    {
        admin,
        vendor,
        distributor,//should be default
        agent,
        salesmanager,
        shopkeeper,        
        wholesaler,
        retailer
    }

    public enum AddressTypeEnum
    {
        Business,
        Residential,
        Office,
        Shipping,
        Billing//should be default
    }

    public enum QuantityTypeEnum
    {
        Number,//should be default
        Weight,
        Volume,
        Length    
    }
        //Custom,
        //Single =1,        
        //Dozen =12,
        //Carton=24        

    public enum OrderStatusEnum
    {
        UnVerified,
        Verified,
        Cancelled,
        Processing,
        Paid,//top priority        
        Shipping,
        Delivery,
        Delivered,
         // cancel
    }

    public enum DeliveryStatusEnum : byte
    {
        UnPack,
        Packed,
        Agent,
        Ready,
        OntheWay,
        Delivered
    }
}