//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hikaya.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SavedStory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> StoryId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Story Story { get; set; }
    }
}
