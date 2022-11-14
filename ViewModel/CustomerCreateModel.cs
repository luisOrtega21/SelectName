using Microsoft.AspNetCore.Mvc.Rendering;
using SelectExample.Models;
using System.Collections.Generic;

namespace SelectExample.ViewModel
{
    public class CustomerCreateModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
