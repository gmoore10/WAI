using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAI
{
    /// <summary>
    /// Our Settings Database Table Model
    /// </summary>
    public abstract class TableExtensions 
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }
        public DateTime? DateLastModified { get; set; }
        [Required]
        public int AddedBy { get; set; }
        public int? LastModifiedBy { get; set; }
        [Timestamp]
        public byte[] ts { get; set; }

    }
}
