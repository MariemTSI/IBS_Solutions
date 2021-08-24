using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.ViewModels
{
    public class ExpertComptableViewModel
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string ComplementAdresse { get; set; }
        public string CP { get; set; }
        public string Ville { get; set; }
        public string Observation { get; set; }
        public int PaysId { get; set; }

        public SelectList Pays { get; set; }

    }
}
