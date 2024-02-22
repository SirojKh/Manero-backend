using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Tag;

public class TagResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    public static implicit operator TagResponse(TagEntity tag)
    {
        return TagFactory.CreateResponse(tag);
    }
    
    public static implicit operator TagEntity(TagResponse tag)
    {
        return TagFactory.CreateEntity(tag);
    }
}