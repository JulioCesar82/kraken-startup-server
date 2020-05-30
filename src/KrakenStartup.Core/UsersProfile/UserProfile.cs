﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.AddressDocumentations;
using KrakenStartup.CarDocumentations;
using KrakenStartup.DriverDocumentations;
using KrakenStartup.Identifications;
using KrakenStartup.RentParkings;
using KrakenStartup.UsersCreditCards;
using KrakenStartup.UsersVouchers;
using KrakenStartup.UsersWallets;

namespace KrakenStartup.UsersProfile
{
    [Table("USERPROFILE")]
    public class UserProfile : Entity, IHasCreationTime
    {
        public UserProfile()
        {
            RentParking = new HashSet<RentParking>();
            UserCreditCard = new HashSet<UserCreditCard>();
            UserVoucher = new HashSet<UserVoucher>();
        }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public UserProfileRegion PhoneRegion { get; set; }

        [Required]
        public UserProfileLanguage Language { get; set; }

        public bool MultiFactor { get; set; }

        public byte LastFailedLogin { get; set; }

        [StringLength(255)]
        public string FingerPrint { get; set; }

        [ForeignKey(nameof(Identification))]
        public int? IdentificationId { get; set; }

        [ForeignKey(nameof(DriverDocumentation))]
        public int? DriverDocumentationId { get; set; }

        [ForeignKey(nameof(AddressDocumentation))]
        public int? AddressDocumentationId { get; set; }

        [Required]
        [ForeignKey(nameof(UserWallet))]
        public int UserWalletId { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(AddressDocumentations.AddressDocumentation.UserProfile))]
        public virtual AddressDocumentation AddressDocumentation { get; set; }

        [InverseProperty(nameof(DriverDocumentations.DriverDocumentation.UserProfile))]
        public virtual DriverDocumentation DriverDocumentation { get; set; }

        [InverseProperty(nameof(Identifications.Identification.UserProfile))]
        public virtual Identification Identification { get; set; }

        [InverseProperty(nameof(UsersWallets.UserWallet.UserProfile))]
        public virtual UserWallet UserWallet { get; set; }

        [InverseProperty(nameof(CarDocumentations.CarDocumentation.UserProfile))]
        public virtual CarDocumentation CarDocumentation { get; set; }

        [InverseProperty(nameof(RentParkings.RentParking.UserProfile))]
        public virtual ICollection<RentParking> RentParking { get; set; }

        [InverseProperty(nameof(UsersCreditCards.UserCreditCard.UserProfile))]
        public virtual ICollection<UserCreditCard> UserCreditCard { get; set; }

        [InverseProperty(nameof(UsersVouchers.UserVoucher.UserProfile))]
        public virtual ICollection<UserVoucher> UserVoucher { get; set; }
    }
}