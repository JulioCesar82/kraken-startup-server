using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.ParkingSchedules;
using KrakenStartup.ParkingTransactions;
using KrakenStartup.UsersProfile;
using KrakenStartup.UsersVouchers;

namespace KrakenStartup.RentParkings
{
    [Table("RENTPARKING")]
    public class RentParking : Entity, IHasCreationTime
    {
        public RentParking()
        {
            ParkingTransaction = new HashSet<ParkingTransaction>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RentParkingId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public RentParkingStatus Status { get; set; } = RentParkingStatus.Pending;

        [Required]
        public byte PercentageTime { get; set; }

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountMoney { get; set; }

        [Required]
        [ForeignKey(nameof(ParkingSchedule))]
        public int ParkingScheduleId { get; set; }

        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserVoucher))]
        public int? UserVoucherId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(ParkingSchedules.ParkingSchedule.RentParking))]
        public virtual ParkingSchedule ParkingSchedule { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.RentParking))]
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty(nameof(UsersVouchers.UserVoucher.RentParking))]
        public virtual UserVoucher UserVoucher { get; set; }

        [InverseProperty(nameof(ParkingTransactions.ParkingTransaction.RentParking))]
        public virtual ICollection<ParkingTransaction> ParkingTransaction { get; set; }
    }
}