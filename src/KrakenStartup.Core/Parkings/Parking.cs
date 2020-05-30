using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.AddressDocumentations;
using KrakenStartup.ParkingSchedules;
using KrakenStartup.UsersWallets;

namespace KrakenStartup.Parkings
{
    [Table("PARKING")]
    public class Parking : Entity, IHasCreationTime
    {
        public Parking()
        {
            ParkingSchedule = new HashSet<ParkingSchedule>();
        }

        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountMoney { get; set; }

        [Required]
        [ForeignKey(nameof(Wallet))]
        public int WalletId { get; set; }

        [Required]
        [ForeignKey(nameof(AddressDocumentation))]
        public int AddressDocumentId { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(AddressDocumentations.AddressDocumentation.Parking))]
        public virtual AddressDocumentation AddressDocumentation { get; set; }

        [InverseProperty(nameof(UsersWallets.UserWallet.Parking))]
        public virtual UserWallet Wallet { get; set; }

        [InverseProperty(nameof(ParkingSchedules.ParkingSchedule.Parking))]
        public virtual ICollection<ParkingSchedule> ParkingSchedule { get; set; }
    }
}