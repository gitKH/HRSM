//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRSM.DATAMODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHIFT
    {
        public System.Guid RGUID { get; set; }
        public System.DateTime FROM { get; set; }
        public System.DateTime TO { get; set; }
        public System.Guid EMPLOYEERGUID { get; set; }
        public System.Guid GUARDSITERGUID { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual GUARDSITE GUARDSITE { get; set; }
    }
}
