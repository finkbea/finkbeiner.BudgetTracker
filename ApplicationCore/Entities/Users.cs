using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities {
    [Table("Users")]
    public class Users {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime JoinedOn { get; set; }

        //navigational properties
        public ICollection<Expenditures> Expenditures { get; set; }
        public ICollection<Incomes> Incomes { get; set; }
    }
}
