namespace Manero_Backend.Models.Entities
{
    public class OrderStatusEntity : BaseEntity
    {
        public long CompletedUnix { get; set; }
        public long EstimatedTimeUnix { get; set; }
        public bool Completed { get; set; }

        public Guid OrderStatusTypeId { get; set; }
        public OrderStatusTypeEntity OrderStatusType { get; set; }
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
