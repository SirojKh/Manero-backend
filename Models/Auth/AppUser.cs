using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Manero_Backend.Models.Auth;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Otp { get; set; } = "000000";
    public string? Location { get; set; }
   
    public ICollection<AddressEntity> Addresses { get; set; } //M:1
    public ICollection<UserPromoCodeEntity> UserPromoCodes { get; set; } //M:M
    public ICollection<PaymentDetailEntity> PaymentDetails { get; set; } //M:1
    public ICollection<OrderEntity> Orders { get; set; } //M:1
    public ICollection<ReviewEntity> Reviews { get; set; } //M:M
    public ICollection<WishEntity> WishList { get; set; } //M:M


}