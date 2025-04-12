using System.ComponentModel.DataAnnotations;

namespace ASOS.DAL
{
	public class VerificationCode
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[Required]
		[MaxLength(6)]
		public string Code { get; set; }

		public DateTime Expiration { get; set; }
	}
}
