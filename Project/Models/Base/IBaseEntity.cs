namespace Project.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? LastModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
