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
        public ParkingSchedule()
        {
            RentParking = new HashSet<RentParking>();
        }

        [Required]
        public DateTime Day { get; set; }
        
        [Required]
        public ParkingScheduleRepetition Repetition { get; set; }

        public DateTime? ValidTime { get; set; }

        [Required]
        [ForeignKey("Parking")]
        public int ParkingId { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty("ParkingSchedule")]
        public virtual Parking Parking { get; set; }

        [InverseProperty("ParkingSchedule")]
        public virtual ICollection<RentParking> RentParking { get; set; }
    }
}