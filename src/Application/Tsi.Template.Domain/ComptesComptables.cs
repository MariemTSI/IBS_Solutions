using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Domain
{
    public class ComptesComptables : BaseEntity
    {
        public string Numero { get; set; }

        public string Intitule { get; set; }
        public string NatureCompteComptable { get; set; }
        public string Observation { get; set; }
        public int SocieteId  { get; set; }
        public Societe Societe { get; set; }

       
    }
}
