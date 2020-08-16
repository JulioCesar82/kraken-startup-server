using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.UsersVouchers;

namespace KrakenStartup.Vouchers
{
    [Table("VOUCHER")]
    public class Voucher : Entity, IHasCreationTime
    {
        public Voucher()
        {
            UserVoucher = new HashSet<UserVoucher>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int VoucherId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AmountMoney { get; set; }

        public int? PercentageValue { get; set; }

        public int? MinimumPurchaseValue { get; set; }

        public DateTime? ValidTime { get; set; }

        [Required]
        public bool SingleUse { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool Enable { get; set; } = true;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UsersVouchers.UserVoucher.Voucher))]
        public virtual ICollection<UserVoucher> UserVoucher { get; set; }
    }
}