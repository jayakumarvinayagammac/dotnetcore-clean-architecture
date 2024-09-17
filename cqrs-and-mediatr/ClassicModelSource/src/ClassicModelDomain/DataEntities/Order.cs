
namespace ClassicModelDomain.DataEntities;

public partial class Order
{
    public int OrderNumber { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public int CustomerNumber { get; set; }

    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
