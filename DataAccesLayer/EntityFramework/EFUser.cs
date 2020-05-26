using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ModelsClasslibrary;
using ModelsClasslibrary.Rosters;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Trades;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFUser : IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
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

        public EFUser()
        {

        }

        public EFUser(int id, string username, string password, string email, int active)
        {
            UserId = id;
            Username = username;
            Password = password;
            Email = email;
            Active = active;
        }
    }
}
