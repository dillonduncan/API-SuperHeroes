//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_SuperHeroes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agrupaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agrupaciones()
        {
            this.Acompanantes = new HashSet<Acompanantes>();
        }
    
        public int AgrupacionesID { get; set; }
        public string Nombre { get; set; }
        public string Nombre_integrantes { get; set; }
        public Nullable<int> MisionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acompanantes> Acompanantes { get; set; }
        public virtual Misiones Misiones { get; set; }
    }
}
