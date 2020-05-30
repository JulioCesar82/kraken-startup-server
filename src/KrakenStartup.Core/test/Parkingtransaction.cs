﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrakenStartup.test
{
    [Table("PARKINGTRANSACTION")]
    public partial class Parkingtransaction
    {
        [Key]
        public int ParkingTransactionId { get; set; }
        public int RentParkingId { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [StringLength(255)]
        public string TransactionInfo { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountMoney { get; set; }
        public int? UserWalletId { get; set; }
        public int? UserCreditCardId { get; set; }
        public byte Enable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }

        [ForeignKey(nameof(RentParkingId))]
        [InverseProperty(nameof(Rentparking.Parkingtransaction))]
        public virtual Rentparking RentParking { get; set; }
        [ForeignKey(nameof(UserCreditCardId))]
        [InverseProperty(nameof(Usercreditcard.Parkingtransaction))]
        public virtual Usercreditcard UserCreditCard { get; set; }
        [ForeignKey(nameof(UserWalletId))]
        [InverseProperty(nameof(Userwallet.Parkingtransaction))]
        public virtual Userwallet UserWallet { get; set; }
    }
}