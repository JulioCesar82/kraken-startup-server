using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.CreditCards;
using KrakenStartup.Enums;
using KrakenStartup.ParkingTransactions;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.UsersCreditCards
{
    [Table("USERCREDITCARD")]
    public class UserCreditCard : Entity, IHasCreationTime
    {
        public UserCreditCard()
        {
            ParkingTransaction = new HashSet<ParkingTransaction>();
        }

        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        public DocumentationStatus Status { get; set; }

        [Required]
        public DateTime ValidTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(CreditCard))]
        public int CreditCardId { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(CreditCards.CreditCard.UserCreditCard))]
        public virtual CreditCard CreditCard { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.UserCreditCard))]
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty(nameof(ParkingTransactions.ParkingTransaction.UserCreditCard))]
        public virtual ICollection<ParkingTransaction> ParkingTransaction { get; set; }
    }
}