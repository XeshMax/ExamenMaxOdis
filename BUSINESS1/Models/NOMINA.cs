//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BUSINESS1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NOMINA
    {
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public System.DateTime Fecha { get; set; }
        public double SueldoDia { get; set; }
        public int Dias { get; set; }
        public double SueldoQuincenal { get; set; }
    
        public virtual EMPLEADOS EMPLEADOS { get; set; }
    }
}