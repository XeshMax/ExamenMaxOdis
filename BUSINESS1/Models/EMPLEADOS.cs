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
    
    public partial class EMPLEADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADOS()
        {
            this.NOMINA = new HashSet<NOMINA>();
        }
    
        public int IdEmpleado { get; set; }
        public int IdDepartamento { get; set; }
        public string NomEmpleado { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOMINA> NOMINA { get; set; }
    }
}
