namespace FreshVegCart.Api.Data.Entities;

public class OrderItem
{
    #region Primary Key

    public long OrderId { get; set; }
    public long ProductId { get; set; }

    #endregion


    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public string ProductImage { get; set; }
    public string Unit { get; set; }



    #region Navigation Properties

    public virtual Order Order { get; set; }
    //public virtual Product Product { get; set; }

    #endregion
}
