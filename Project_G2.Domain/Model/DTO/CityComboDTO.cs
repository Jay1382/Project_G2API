using Project_G2.DomainLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DomainLayer.Model.DTO
{
    public class CityComboDTO
    {
        public PaginationResponse? paginationResponse { get; set; }
        public List<CityComboResponse>? cityComboResponse { get; set; }
    }
}
