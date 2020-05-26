using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ModelsClasslibrary.Shifts;

namespace DataAccesLayer.EntityFramework
{
    public partial class EFShift : IShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

        public EFShift()
        {
            
        }

        public EFShift(int id, DateTime start, DateTime end)
        {
            ShiftId = id;
            Start = start;
            End = end;
        }
    }
}
