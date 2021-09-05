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
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets from Description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(1000, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets from Description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Owner { get; set; }



        /// <summary>
        /// Gets or Sets from CreatedAt.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets from ModifiedAt.
        /// </summary>
        [Required]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets or Sets from CreatedBy.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets from UpdatedBy.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string? ModifiedBy { get; set; }
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

