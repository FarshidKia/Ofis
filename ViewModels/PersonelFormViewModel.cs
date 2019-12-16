using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ofis_ISE309.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> departmanlar { get; set; }
        public Personel Personel { get; set; }
    }
}