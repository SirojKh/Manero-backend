using Manero_Backend.Models.Dtos.Tag;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Helpers.Factory;

public class TagFactory
{
    public static TagResponse CreateResponse(TagEntity tag)
    {
        return new()
        {
            Id = tag.Id,
            Name = tag.Name
        };
    }
    
    public static TagEntity CreateEntity(TagRequest tag)
    {
        return new()
        {
            Name = tag.Name
        };
    }
    
    public static TagEntity CreateEntity(TagResponse tag)
    {
        return new()
        {
            Id = tag.Id,
            Name = tag.Name
        };
    }

    public static TagEntity CreateEntity(string tag)
    {
        return new()
        {
            Name = tag
        };
    }

    public static TagRequest CreateRequest(string entityTag)
    {
        return new TagRequest()
        {
            Name = entityTag
        };
    }
}