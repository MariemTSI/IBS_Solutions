using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.ViewModels
{
    public class SocieteViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string IdentifiantFiscal { get; set; }
        public string Observation { get; set; }
        public int ExpertComptableId { get; set; }
        public SelectList ExpertComptable { get; set; }
    }
}
