using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.ViewModels
{
    public class ModePayementViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string CodeSurDeclarationTVA { get; set; }
        public string Observation { get; set; }
    }
}
