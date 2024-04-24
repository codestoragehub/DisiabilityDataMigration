using System.Runtime.Serialization;

namespace DisabilityInPortal.Domain.Enums;

public enum PaymentIntentStatus
{
    None = 0,

    [EnumMember(Value = "requires_payment_method")]
    RequiresPaymentMethod = 1,

    [EnumMember(Value = "requires_confirmation")]
    RequiresConfirmation = 2,

    [EnumMember(Value = "requires_action")]
    RequiresAction = 3,

    [EnumMember(Value = "processing")]
    Processing = 4,

    [EnumMember(Value = "succeeded")]
    Succeeded = 5,

    [EnumMember(Value = "canceled")]
    Canceled = 6
}