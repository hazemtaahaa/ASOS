using ASOS.DAL.Context;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL
{
	public class VerificationCodeRepository : GenericRepository<VerificationCode>, IVerificationCodeRepository
	{
		public VerificationCodeRepository(StoreContext context) : base(context)
		{
		}
	}
}
