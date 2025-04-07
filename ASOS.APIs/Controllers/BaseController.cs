//using ASOS.DAL;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public abstract class BaseController<T> : ControllerBase where T : class
//    {
//        protected readonly IUnitOfWork _unitOfWork;

//        protected BaseController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        protected virtual async Task<IActionResult> GetAllAsync()
//        {
//            var entities = await _unitOfWork.GetRepository<T>().GetAllAsync();
//            return Ok(entities);
//        }

//        protected virtual async Task<IActionResult> GetByIdAsync(Guid id)
//        {
//            var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
//            if (entity == null)
//                return NotFound();
//            return Ok(entity);
//        }

//        protected virtual async Task<IActionResult> CreateAsync(T entity)
//        {
//            await _unitOfWork.GetRepository<T>().AddAsync(entity);
//            await _unitOfWork.CompleteAsync();
//            return CreatedAtAction(nameof(GetByIdAsync), new { id = GetEntityId(entity) }, entity);
//        }

//        protected virtual async Task<IActionResult> UpdateAsync(Guid id, T entity)
//        {
//            var existingEntity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
//            if (existingEntity == null)
//                return NotFound();

//            _unitOfWork.GetRepository<T>().Update(entity);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        protected virtual async Task<IActionResult> DeleteAsync(Guid id)
//        {
//            var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
//            if (entity == null)
//                return NotFound();

//            _unitOfWork.GetRepository<T>().Delete(entity);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        protected abstract Guid GetEntityId(T entity);
//    }
//} 