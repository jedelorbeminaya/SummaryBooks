using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBooks.Domain
{
    public class Summary
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
