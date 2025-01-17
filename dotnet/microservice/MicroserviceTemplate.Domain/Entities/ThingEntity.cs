using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceTemplate.Domain.Entities
{
    [Table("thing")]
    public class ThingEntity : StampEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("occupation")]
        public string Occupation { get; set; }

        [Column("age")]
        public int Age { get; set; }
    }
}