namespace OnlineStore.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }= true;
        public bool IsDeleted { get; set; }= false;
    }
}
