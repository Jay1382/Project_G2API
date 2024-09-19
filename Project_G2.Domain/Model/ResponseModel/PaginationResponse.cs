using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DomainLayer.Model.ResponseModel
{
    public class PaginationResponse
    {
        public int? success { get; set; }
        public int? current_page { get; set; }
        public int? total_count { get; set; }
        public bool has_more { get; set; }
        public int? page_size { get; set; }
        public int? total_page { get; set; }
    }
}
