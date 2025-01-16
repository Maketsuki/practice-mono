namespace MicroserviceTemplate.Domain.DTO
{
    public class IdentityReturnDTO
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }

        public IdentityReturnDTO()
        { }

        public IdentityReturnDTO(long id)
        { this.Id = id; }

        public IdentityReturnDTO(Guid guid)
        { this.Guid = guid; }

        public IdentityReturnDTO(long id, Guid guid)
        { this.Id = id; this.Guid = guid; }
    }
}