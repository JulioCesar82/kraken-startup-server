using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Enums;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.CarDocumentations
{
    [Table("CARDOCUMENTATION")]
    public class CarDocumentation : Entity, IHasCreationTime
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CarDocumentationId { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        public DriverDocumentationType Type { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DocumentationStatus Status { get; set; } = DocumentationStatus.Pending;

        [Required]
        public DateTime ValidTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        [StringLength(255)]
        public string StorageId { get; set; }

        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool Enable { get; set; } = true;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UsersProfile.UserProfile.CarDocumentation))]
        public virtual UserProfile UserProfile { get; set; }
    }
}