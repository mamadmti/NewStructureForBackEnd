using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Enums;

namespace MyProject.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid UserId { get; set; }

    }
}
