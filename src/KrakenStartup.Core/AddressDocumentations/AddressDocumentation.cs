using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Enums;
using KrakenStartup.Parkings;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.AddressDocumentations
{
    [Table("ADDRESSDOCUMENTATION")]
    public class AddressDocumentation : Entity, IHasCreationTime
    {
        public AddressDocumentation()
        {
            Parking = new HashSet<Parking>();
            UserProfile = new HashSet<UserProfile>();
        }

        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        public AddressDocumentationType Type { get; set; }

        [Required]
        public DocumentationStatus Status { get; set; }

        [Required]
        [StringLength(10)]
        public string Latitude { get; set; }

        [Required]
        [StringLength(10)]
        public string Longitude { get; set; }

        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(5)]
        public string AddressNumber { get; set; }

        [StringLength(50)]
        public string Complement { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        [Required]
        [StringLength(50)]
        public string NeighborhoodName { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(Parkings.Parking.AddressDocumentation))]
        public virtual ICollection<Parking> Parking { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.AddressDocumentation))]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}