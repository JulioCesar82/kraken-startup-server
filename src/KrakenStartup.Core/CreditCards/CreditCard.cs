using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.UsersCreditCards;

namespace KrakenStartup.CreditCards
{
    [Table("CREDITCARD")]
    public class CreditCard : Entity, IHasCreationTime
    {
        public CreditCard()
        {
            UserCreditCard = new HashSet<UserCreditCard>();
        }

        [Required]
        public CreditCardType Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Credential { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(UsersCreditCards.UserCreditCard.CreditCard))]
        public virtual ICollection<UserCreditCard> UserCreditCard { get; set; }
    }
}