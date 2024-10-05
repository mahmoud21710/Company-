using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.G04.PL.Controllers
{
	[Authorize]

	public class DepartmentController : Controller
    {     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController( IUnitOfWork unitOfWork, IMapper mapper) //Ask Clr To Create Object 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var department =await _unitOfWork.DepartmentRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DepartmentViewModel>>(department);
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<Department>(model);
                await _unitOfWork.DepartmentRepository.AddAsync(result);
                var count =await _unitOfWork.CompleteAsync();
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            

              return View(model);
            
        }
        public async Task<IActionResult> Detalis(int? id) 
        {
            if(id is null) 
            {
                return BadRequest();
            }

            var dep =await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (dep is null) return NotFound();
            var result = _mapper.Map<DepartmentViewModel>(dep);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id is null)
            {
                return BadRequest();
            }

            var dep =await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (dep is null) return NotFound();
            var result = _mapper.Map<DepartmentViewModel>(dep);
            return View(result);
            //return Detalis(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int? id ,DepartmentViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest(); // 400
                if (ModelState.IsValid)
                {
                    var result  = _mapper.Map<Department>(model);
                    _unitOfWork.DepartmentRepository.Update(result);
                    var count =await _unitOfWork.CompleteAsync();
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var dep =await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (dep is null) return NotFound();
            var result =_mapper.Map<DepartmentViewModel>(dep);
            return View(result);
            //return Detalis(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int? id, DepartmentViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest(); // 400
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<Department>(model);
                    _unitOfWork.DepartmentRepository.Delete(result);
                    var count =await _unitOfWork.CompleteAsync();
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

    }
}
