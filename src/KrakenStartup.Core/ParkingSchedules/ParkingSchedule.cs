using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Parkings;
using KrakenStartup.RentParkings;

namespace KrakenStartup.ParkingSchedules
{
    [Table("PARKINGSCHEDULE")]
    public class ParkingSchedule : Entity, IHasCreationTime
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ParkingScheduleId { get; set; }

        [Required]
        public DateTime Day { get; set; }
        
        [Required]
        public ParkingScheduleRepetition Repetition { get; set; }

        public DateTime? ValidTime { get; set; }

        [Required]
        [ForeignKey("Parking")]
        public int ParkingId { get; set; }

        [Required]
        [Range(0, 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Enable { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; }

        [InverseProperty("ParkingSchedule")]
        public virtual Parking Parking { get; set; }

        [InverseProperty("ParkingSchedule")]
        public virtual ICollection<RentParking> RentParking { get; set; }
    }
}