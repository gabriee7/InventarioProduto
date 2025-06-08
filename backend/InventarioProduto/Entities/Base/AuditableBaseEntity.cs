namespace InventarioProduto.Entities.Base
{
    public class AuditableBaseEntity : BaseEntity
    {
        private DateTime _creationTime { get; set; }
        private DateTime? _LastModifiedTime { get; set; }

        public AuditableBaseEntity() : base()
        {
            _creationTime = DateTime.UtcNow;
        }

        public void SetModifiedTime()
        {
            _LastModifiedTime = DateTime.UtcNow;
        }

        public DateTime GetCreationTime() { return _creationTime; }
        public DateTime? GetLastModifiedTime() { return _LastModifiedTime; }
    }
}
