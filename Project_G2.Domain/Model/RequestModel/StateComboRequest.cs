using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DomainLayer.Model.RequestModel
{
    public class StateComboRequest
    {
        public int? CountryID { get; set; }
        public int? PageSize { get; set; }
        public int? CurrentPage { get; set; }
    }
}
