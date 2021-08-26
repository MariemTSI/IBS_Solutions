using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.ViewModels
{
    public class ComptesComptablesViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Intitule { get; set; }
        public string NatureCompteComptable { get; set; }
        public string Observation { get; set; }
        public int SocieteId { get; set; }
    }
}
