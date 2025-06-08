using System.ComponentModel.DataAnnotations;

namespace InventarioProduto.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        private Guid _id { get; set; }

        public BaseEntity()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetGuid() { return _id; }
    }
}
