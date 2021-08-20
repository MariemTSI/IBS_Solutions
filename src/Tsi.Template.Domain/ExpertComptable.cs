using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Domain
{
    public class ExpertComptable : BaseEntity
    {
        public int PaysId { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string ComplementAdresse { get; set; }
        public string CP { get; set; }
        public string Ville { get; set; }
        public string Observation { get; set; }
        public Pays Pays { get; set; }
        public ICollection<Societe> Societes { get; set; }

    }
}
