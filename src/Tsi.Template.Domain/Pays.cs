using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Domain
{
    public class Pays : BaseEntity
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string SymboleMonetaire { get; set; }
        public int NbreDecimales { get; set; }
        public string Observation { get; set; }
        public ICollection<ExpertComptable> ExpertComptables { get; set; }
    }
}
