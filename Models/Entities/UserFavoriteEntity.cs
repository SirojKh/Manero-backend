using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Entities;

public class UserFavoriteEntity
{
    public string UserId { get; set; } = null!;
    //[ForeignKey("User.Id")]
    public AppUser User { get; set; } = null!;

    public int ProductId { get; set; } 
    public ProductEntity Product { get; set; } = null!;
}