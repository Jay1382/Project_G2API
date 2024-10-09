using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DomainLayer.Model.RequestModel
{
    public class AddGroupRequest
    {
        public string? GroupName { get; set; }
        public bool? Status { get; set; }
    }
}
