using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Enums;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.Identifications
{
    [Table("IDENTIFICATION")]
    public class Identification : Entity, IHasCreationTime
    {
        [Required]
        public IdentificationType Type { get; set; }

        [Required]
        public DocumentationStatus Status { get; set; }

        [Required]
        public DateTime ValidTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        [StringLength(255)]
        public string StorageId { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.Identification))]
        public virtual UserProfile UserProfile { get; set; }
    }
}