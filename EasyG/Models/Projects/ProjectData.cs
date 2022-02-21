using System;
using EasyG.Models.Libraries;

namespace EasyG.Models.Projects
{
    public class ProjectData
    {
        public int Id { get; set; }

        public DateTimeOffset DeliveryDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public string? Name { get; set; }

        public string? ShortName { get; set; }

        public string? State { get; set; }

        public string? Address { get; set; }

        public string? Region { get; set; }

        public CompanyData? Company { get; set; }

        public string? Description { get; set; }
    }
}
