//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentroMedico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecetaMedica
    {
        public int id_receta { get; set; }
        public string nombre_medicamento { get; set; }
        public string dosis_medicamento { get; set; }
        public string instrucciones_medicamento { get; set; }
        public Nullable<int> id_anexo { get; set; }
    
        public virtual AnexosConsulta AnexosConsulta { get; set; }
    }
}
