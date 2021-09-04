// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{   
    using global::BlogEngine.Utils.Resources;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entity BlogEngine.
    /// </summary>
    [Table("BlogEngine")]
    public class BlogEngine
    {

        /// <summary>
        /// Gets or Sets from Id.
        /// </summary>
        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets from Name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets from Description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(4000, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets from ProfileId.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int ProfileId { get; set; }

        /// <summary>
        /// Gets or Sets from BehaviourTypeId.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int BehaviourTypeId { get; set; }

        /// <summary>
        /// Gets or Sets from CreatedAt.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets from UpdatedAt.
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; set; }       
    }
}

/**
 * Examples of Regular Expressions:
 *
 * To Range:
 * [Range(1,long.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
 *
 * To Letters and Numbers:
 * [RegularExpression(@"^[a-zA-Z]{1,40}|[0-9]{1,40}$", ErrorMessageResourceName = "modelCharactersMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
 *
 **/

