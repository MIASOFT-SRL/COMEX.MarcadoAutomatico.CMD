//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMEX.MaracadoAutomatico.CMD3.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACGroup
    {
        public short GroupID { get; set; }
        public string Name { get; set; }
        public Nullable<short> TimeZone1 { get; set; }
        public Nullable<short> TimeZone2 { get; set; }
        public Nullable<short> TimeZone3 { get; set; }
        public Nullable<bool> holidayvaild { get; set; }
        public Nullable<int> verifystyle { get; set; }
    }
}
