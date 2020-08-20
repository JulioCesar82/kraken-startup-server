﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KrakenStartup.Enums;
using KrakenStartup.UsersProfile;

namespace KrakenStartup.DriverDocumentations
{
    [Table("DRIVERDOCUMENTATION")]
    public class DriverDocumentation : Entity, IHasCreationTime
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DriverDocumentationId { get; set; }

        [Required]
        public DriverDocumentationType Type { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DocumentationStatus Status { get; set; }

        [Required]
        public DateTime ValidTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        [StringLength(255)]
        public string StorageId { get; set; }

        [Required]
        [Range(0, 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Enable { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedTime { get; set; }

        [InverseProperty(nameof(UsersProfile.UserProfile.DriverDocumentation))]
        public virtual UserProfile UserProfile { get; set; }
    }
}