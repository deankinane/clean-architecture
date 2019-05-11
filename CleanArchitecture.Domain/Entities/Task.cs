using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Notes { get; set; }
        public bool SoftDeleted { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
