using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceTemplate.Domain.Entities
{
    public class StampEntity : Entity
    {
        [Column("created_date")]
        public DateTime? DateCreated { get; set; }

        [Column("modified_date")]
        public DateTime? DateModified { get; set; }
    }
}