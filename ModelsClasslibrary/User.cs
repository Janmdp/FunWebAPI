using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsClasslibrary
{
    public class User : IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public int Active { get; set; }
    }
}
