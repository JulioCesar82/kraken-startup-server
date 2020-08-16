using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.UsersCreditCards;

namespace KrakenStartup.CreditCards
{
    [Table("CREDITCARD")]
    public class CreditCard : AuditedEntity, IHasCreationTime
    {
        public CreditCard()
        {
            UserCreditCard = new HashSet<UserCreditCard>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CreditCardId { get; set; }

        [Required]
        public CreditCardType Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Credential { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool Enable { get; set; } = true;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UsersCreditCards.UserCreditCard.CreditCard))]
        public virtual ICollection<UserCreditCard> UserCreditCard { get; set; }
    }
}