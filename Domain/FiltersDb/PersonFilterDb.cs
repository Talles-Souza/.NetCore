using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FiltersDb
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string Name { get; set; }
    }
}
