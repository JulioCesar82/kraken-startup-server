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

        [Required]
        public UserVoucherStatus Status { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AmountMoney { get; set; }

        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Voucher))]
        public int VoucherId { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.UserVoucher))]
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty(nameof(Vouchers.Voucher.UserVoucher))]
        public virtual Voucher Voucher { get; set; }

        [InverseProperty(nameof(RentParkings.RentParking.UserVoucher))]
        public virtual ICollection<RentParking> RentParking { get; set; }
    }
}