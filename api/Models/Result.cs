//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud_Api_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Result
    {
        public int id { get; set; }
        public string Status { get; set; }
        public string RepositoryName { get; set; }
        public string QueuedAt { get; set; }
        public string ScanningAt { get; set; }
        public string FinishedAt { get; set; }
    }
}