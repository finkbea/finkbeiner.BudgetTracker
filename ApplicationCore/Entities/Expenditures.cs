using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities {
    [Table("Expenditures")]
    public class Expenditures {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpDate { get; set; }
        public string Remarks { get; set; }

        public Users User { get; set; }
    }
}
