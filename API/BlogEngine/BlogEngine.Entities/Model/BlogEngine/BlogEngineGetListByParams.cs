// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{   
    using global::BlogEngine.Utils.Resources;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity BlogEngineGetListByParams.
    /// </summary>
    public class BlogEngineGetListByParams
    {

        /// <summary>
        /// Gets or Sets from Id.
        /// </summary>

        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets from Name.
        /// </summary>
        [StringLength(150, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]/*[RegularExpression(@"^[a-zA-Z]{1,}|[0-9]{1,}$", ErrorMessageResourceName = "modelCharactersMessage", ErrorMessageResourceType = typeof(ResourceMessage))]*/
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets from Description.
        /// </summary>
        [StringLength(4000, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]/*[RegularExpression(@"^[a-zA-Z]{1,}|[0-9]{1,}$", ErrorMessageResourceName = "modelCharactersMessage", ErrorMessageResourceType = typeof(ResourceMessage))]*/
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets from ProfileId.
        /// </summary>

        public int? ProfileId { get; set; }

        /// <summary>
        /// Gets or Sets from BehaviourTypeId.
        /// </summary>
       
        public int? BehaviourTypeId { get; set; }

        /// <summary>
        /// Gets or Sets from CreatedAt.
        /// </summary>      
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets from UpdatedAt.
        /// </summary>      
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets from CreatedBy.
        /// </summary> 
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets from UpdatedBy.
        /// </summary>
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets from OrderBy.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        ///[RegularExpression(@"^[a-zA-Z]{1,40}|[0-9]{1,40}$", ErrorMessageResourceName = "modelCharactersMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or set from Ascendent.
        /// </summary>
        [Required]
        public bool Ascendent { get; set; }

        /// <summary>
        /// Gets or set from PageNumber.
        /// </summary>
        [Range(1, long.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets from ResultsPerPage.
        /// </summary>
        [Range(1, long.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int ResultsPerPage { get; set; }

    }
}
