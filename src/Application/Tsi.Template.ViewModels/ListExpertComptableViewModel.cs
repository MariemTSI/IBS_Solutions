using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.ViewModels
{
    public class ListExpertComptableViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }

        public string Pays { get; set; }
    }
}
