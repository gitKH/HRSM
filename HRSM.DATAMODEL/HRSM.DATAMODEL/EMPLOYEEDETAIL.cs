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
    
    public partial class EMPLOYEEDETAIL
    {
        public System.Guid RGUID { get; set; }
        public string AT { get; set; }
        public string AFM { get; set; }
        public Nullable<Gender> GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<bool> MARITALSTATUS { get; set; }
        public Nullable<System.DateTime> SECLICEXPDATE { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
