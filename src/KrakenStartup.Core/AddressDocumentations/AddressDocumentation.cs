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
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int AddressDocumentationId { get; set; }
        
        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        public AddressDocumentationType Type { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DocumentationStatus Status { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }

        [Required]
        [Range(1, 99999)]
        public int AddressNumber { get; set; }

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
        [Range(0, 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Enable { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(Parkings.Parking.AddressDocumentation))]
        public virtual ICollection<Parking> Parking { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.AddressDocumentation))]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}