//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sajt.DataSloj
{
    using System;
    using System.Collections.Generic;
    
    public partial class slider
    {
        public int slider_id { get; set; }
        public string text { get; set; }
        public int picture_id { get; set; }
    
        public virtual picture picture { get; set; }
    }
}
