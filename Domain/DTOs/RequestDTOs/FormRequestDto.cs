using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.RequestDTOs;

public class FormRequestDto
{
    [Required]
    public string ReceiverName { get; set; } = default!;
    [Required]
    public int VechicleNumber { get; set; }
    [Required]
    public string PickUpTime { get; set; } = default!;
    [Required]
    public string DeliveryTime { get; set; } = default!;
    [Required]
    public string ImageBase64 { get; set; } = default!;
    [Required]
    public string ImageName { get; set; } = default!;
    [Required]
    public string ReasonForReceipt { get; set; } = default!;
    [Required]
    public string SignatureUponReceipt { get; set; } = default!;
    [Required]
    public string SignatureUponDelivery { get; set; } = default!;
}