using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models {
    public class UserDetailsResponseModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }

        //navigational properties
        public List<SubExpenditureResponseModel> Expenditures { get; set; }
        public List<SubIncomeResponseModel> Incomes { get; set; }
    }
    public class SubExpenditureResponseModel {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpDate { get; set; }
        public string Remarks { get; set; }
    }
    public class SubIncomeResponseModel {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Remarks { get; set; }
    }

}
