using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ModelsClasslibrary.Shifts;
using ModelsClasslibrary.Trades;
using ModelsClasslibrary.Users;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFTrade : ITrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TradeId { get; set; }

        [Required]
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        [Required]
        public int ReworkShiftId { get; set; }
        public Shift ReworkShift { get; set; }

        [Required]
        public int RequestUserId { get; set; }
        public User RequestUser { get; set; }

        public int AcceptUserId { get; set; }
        public User AcceptUser { get; set; }

        public EFTrade()
        {
            
        }

        public EFTrade(int id, Shift shift, Shift reworkShift, User requestUser, User acceptUser)
        {
            TradeId = id;
            Shift = shift;
            ReworkShift = reworkShift;
            RequestUser = requestUser;
            AcceptUser = acceptUser;
        }
    }
}
