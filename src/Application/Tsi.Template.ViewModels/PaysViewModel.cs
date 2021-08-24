using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tsi.Template.ViewModels
{
    public class PaysViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }    
        public string Nom { get; set; }   
        public string SymboleMonetaire { get; set; }      
        public int NbreDecimales { get; set; }
        public string Observation { get; set; }  
    }
}