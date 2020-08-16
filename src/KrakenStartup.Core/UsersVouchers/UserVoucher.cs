using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.RentParkings;
using KrakenStartup.UsersProfile;
using KrakenStartup.Vouchers;

namespace KrakenStartup.UsersVouchers
{
    [Table("USERVOUCHER")]
    public class UserVoucher : Entity, IHasCreationTime
    {
        public UserVoucher()
        {
            RentParking = new HashSet<RentParking>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserVoucherId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UserVoucherStatus Status { get; set; } = UserVoucherStatus.Available;

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AmountMoney { get; set; }

        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Voucher))]
        public int VoucherId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UsersProfile.UserProfile.UserVoucher))]
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty(nameof(Vouchers.Voucher.UserVoucher))]
        public virtual Voucher Voucher { get; set; }

        [InverseProperty(nameof(RentParkings.RentParking.UserVoucher))]
        public virtual ICollection<RentParking> RentParking { get; set; }
    }
}