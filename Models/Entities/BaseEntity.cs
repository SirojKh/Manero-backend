using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_Backend.Models.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}