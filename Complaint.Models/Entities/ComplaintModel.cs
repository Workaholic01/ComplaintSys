using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Models.Entities
{
    public class ComplaintModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ComplaintDate { get; set; }
    }
}
