using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Parkings;
using KrakenStartup.ParkingTransactions;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.UsersWallets
{
    [Table("USERWALLET")]
    public class UserWallet : Entity, IHasCreationTime
    {
        public UserWallet()
        {
            Parking = new HashSet<Parking>();
            ParkingTransaction = new HashSet<ParkingTransaction>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserWalletId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountMoney { get; set; }

        [Required]
        public UserWalletCurrencyType CurrencyType { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool Enable { get; set; } = true;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UsersProfile.UserProfile.UserWallet))]
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty(nameof(Parkings.Parking.Wallet))]
        public virtual ICollection<Parking> Parking { get; set; }

        [InverseProperty(nameof(ParkingTransactions.ParkingTransaction.UserWallet))]
        public virtual ICollection<ParkingTransaction> ParkingTransaction { get; set; }
    }
}