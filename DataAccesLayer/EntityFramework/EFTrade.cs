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
    public partial class EFTrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TradeId { get; set; }

        [Required]
        public int ShiftId { get; set; }
        public EFShift Shift { get; set; }

        [Required]
        public int ReworkShiftId { get; set; }
        public EFShift ReworkShift { get; set; }

        [Required]
        public int RequestUserId { get; set; }
        public EFUser RequestUser { get; set; }

        public int? AcceptUserId { get; set; }
        public EFUser AcceptUser { get; set; }

        public EFTrade()
        {
            
        }

        public EFTrade(int id, Shift shift, Shift reworkShift, User requestUser, User acceptUser)
        {
            TradeId = id;
            Shift = Converter.ToEfShift(shift);
            ReworkShift = Converter.ToEfShift(reworkShift);
            RequestUser = Converter.ToEfUser(requestUser);
            AcceptUser = Converter.ToEfUser(acceptUser);
        }
    }
}
