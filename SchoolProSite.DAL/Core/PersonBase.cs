

namespace SchoolProSite.DAL.Core
{
    public abstract class PersonBase : BaseEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
    }
}
