namespace Lila.DAL.Entities
{
    public class CustomersCity : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        
        public override string ToString()
        {
            return $"{Id}. ~~~ {CustomerId} ~~~ {CityId}";
        }
    }
}
