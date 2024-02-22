using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Tag;

public class TagRequest
{
    public string Name { get; set; } = null!;
    
    public static implicit operator TagEntity(TagRequest tag)
    {
        return TagFactory.CreateEntity(tag);
    }
}