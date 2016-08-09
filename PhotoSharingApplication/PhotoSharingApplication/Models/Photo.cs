using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PhotoSharingApplication.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        [Required]
        public string Title { get; set; }
        public String UserName { get; set; }
        public byte[] PhotoFile { get; set; }
        [DataType(DataType.MultilineText)]
        public string ImageMimeType { get; set; }
        [DataType(DataType.DateTime)][DisplayName("Created Date")][DisplayFormat(DataFormatString ="{0:MM/dd/yy}")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}