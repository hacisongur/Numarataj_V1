namespace Numarataj.Entity.Entities
{
    public class AdresTespit:BaseEntity,IEntity
    {
        public int? Id { get; set; }
        int IEntity.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
