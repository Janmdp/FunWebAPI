using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ModelsClasslibrary;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    
    public partial class EFRoster : IRoster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RosterId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        [NotMapped]
        public List<Shift> Shifts { get; set; }

        public EFRoster()
        {
            
        }

        public EFRoster(int userId, int shiftId, List<Shift> shifts)
        {
            UserId = userId;
            ShiftId = shiftId;
            Shifts = shifts;
        }
    }
}
