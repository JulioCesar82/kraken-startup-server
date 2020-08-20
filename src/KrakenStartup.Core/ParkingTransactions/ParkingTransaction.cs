using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.RentParkings;
using KrakenStartup.UsersCreditCards;
using KrakenStartup.UsersWallets;

namespace KrakenStartup.ParkingTransactions
{
    [Table("PARKINGTRANSACTION")]
    public class ParkingTransaction : Entity, IHasCreationTime
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ParkingTransactionId { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ParkingTransactionStatus Status { get; set; }

        [StringLength(255)]
        public string TransactionInfo { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountMoney { get; set; }

        [Required]
        [ForeignKey(nameof(RentParking))]
        public int RentParkingId { get; set; }

        [ForeignKey(nameof(UserWallet))]
        public int? UserWalletId { get; set; }

        [ForeignKey(nameof(UserCreditCard))]
        public int? UserCreditCardId { get; set; }

        [Required]
        [Range(0, 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Enable { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(RentParkings.RentParking.ParkingTransaction))]
        public virtual RentParking RentParking { get; set; }

        [InverseProperty(nameof(UsersCreditCards.UserCreditCard.ParkingTransaction))]
        public virtual UserCreditCard UserCreditCard { get; set; }

        [InverseProperty(nameof(UsersWallets.UserWallet.ParkingTransaction))]
        public virtual UserWallet UserWallet { get; set; }
    }
}