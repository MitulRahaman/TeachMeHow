//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace teachme.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string InstructorImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
