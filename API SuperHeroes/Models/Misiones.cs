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
    
    public partial class Misiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Misiones()
        {
            this.Agrupaciones = new HashSet<Agrupaciones>();
            this.Superheroes_Misiones = new HashSet<Superheroes_Misiones>();
        }
    
        public int Codigo_Mision { get; set; }
        public string Descripcion { get; set; }
        public int TipoID { get; set; }
        public string Estado_Mision { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agrupaciones> Agrupaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Superheroes_Misiones> Superheroes_Misiones { get; set; }
        public virtual TipoMision TipoMision { get; set; }
    }
}
