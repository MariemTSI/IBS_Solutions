using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Domain
{
    public class Tiers : BaseEntity
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Intitule { get; set; }
        public string Adresse { get; set; }
        public string ComplementAdresse { get; set; }
        public string CP { get; set; }
        public string Ville { get; set; }
        public string Observation { get; set; }

        public int SecteursActivitesId { get; set; }
        public SecteursActivites SecteursAcivites { get; set; }
        public int NatureParDefaut { get; set; }
        public Nature Nature { get; set; }
        public int PaysId { get; set; }
        public Pays Pays { get; set; }



    }
}
