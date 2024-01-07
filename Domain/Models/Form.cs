namespace Domain.Models;

public class Form
{
    public Guid FormId { get; set; } = Guid.NewGuid();

    public string ReceiverName { get; set; } = default!;
    public int VechicleNumber { get; set; }
    public DateTime PickUpTime { get; set; }
    public DateTime DeliveryTime { get; set; }
    public string ImageBase64 { get; set; } = default!;
    public string ImageName { get; set; } = default!;
    public string ReasonForReceipt { get; set; } = default!;
    public string SignatureUponReceipt { get; set; } = default!;
    public string SignatureUponDelivery { get; set; } = default!;
}