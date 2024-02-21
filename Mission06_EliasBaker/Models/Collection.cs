using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mission06_EliasBaker.Models
{
	public class Collection
	{
        [Key]
        [Required]
        public int MovieId { get; set; }

        //[Required]
        //[ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        [Range(1888, 2024)]
        public int Year { get; set; } = 2000;
        
        //[Required]
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
		public bool Edited { get; set; }
		
		public string? LentTo { get; set; }

        [Required]
		public bool CopiedToPlex { get; set; }
		
		public string? Notes { get; set; }
	}
}

