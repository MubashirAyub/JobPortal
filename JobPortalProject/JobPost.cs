//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobPost
    {
        public long ID_JobPost { get; set; }
        public string ApplyEmail { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string JobCategory { get; set; }
        public string Job_Description { get; set; }
        public string Company_Name { get; set; }
        public string Salary { get; set; }
        public string MinimumExperience { get; set; }
        public string MinimumQualification { get; set; }
        public string Required_Skills { get; set; }
        public string Website_Company { get; set; }
        public string Facebook__Company { get; set; }
        public string Google_USERNAME { get; set; }
        public string LINKEDIN_USERNAME { get; set; }
        public string TWITTER_USERNAME { get; set; }
        public System.DateTime Job_ExpiryDate { get; set; }
        public System.DateTime Job_DatePosted { get; set; }
        public Nullable<bool> Available { get; set; }
    }
}