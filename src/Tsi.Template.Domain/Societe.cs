using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Domain
{
    public class Societe : BaseEntity
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string IdentifiantFiscal { get; set; }
        public string Observation { get; set; }
        public int ExpertComptableId { get; set; }
        public ExpertComptable ExpertComptable { get; set; }
    }
}
