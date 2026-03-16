using lab3.DAL.Interfaces;

namespace lab3.BLL;

internal static class UnitOfWorkHelper {
	public static async Task<ActionResult> SaveAllChanges(IUnitOfWork uow) {
		try {
			await uow.SaveChangesAsync();
			return ActionResult.Successful;
		} catch (Exception e) {
			return ActionResult.Fail(e.Message);
		}
	}
}
