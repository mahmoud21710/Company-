using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Departments;
using Company.G04.PL.ViewModels.Dependents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.G04.PL.Controllers
{
	[Authorize]

	public class DependentController  :Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DependentController(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var dependent=await _unitOfWork.DependentRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DependentViewModel>>(dependent);
            return View(result);
        }   
        public async Task<IActionResult> Create() 
        {
            var employees=await _unitOfWork.EmployeeRepository.GetAllAsync();
            ViewData["employees"] = employees;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DependentViewModel model) 
        {
            //var employees = _unitOfWork.EmployeeRepository.GetAll();
            //ViewData["employees"] = employees;
            if (ModelState.IsValid) 
            {
                var result = _mapper.Map<Dependent>(model);
                await _unitOfWork.DependentRepository.AddAsync(result);
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
            if (id is null) return BadRequest();
            var dependent=await _unitOfWork.DependentRepository.GetAsync(id.Value);
            if(dependent is null) return NotFound();
            var result = _mapper.Map<DependentViewModel>(dependent);
            return View(result);
        }
        public async Task<IActionResult> Edit(int? id) 
        {
            var employees=await _unitOfWork.EmployeeRepository.GetAllAsync();
            ViewData["employees"] = employees;
            if(id is null) return BadRequest();
            var dependent =await _unitOfWork.DependentRepository.GetAsync(id.Value);
            var result = _mapper.Map<DependentViewModel>(dependent);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int? id , DependentViewModel dependent) 
        {
            try
            {
                if (id != dependent.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<Dependent>(dependent);
                    _unitOfWork.DependentRepository.Update(result);
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
            return View(dependent);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id is null) return BadRequest();
            var dependent =await _unitOfWork.DependentRepository.GetAsync(id.Value);
            if(dependent is null) return NotFound();
            var result = _mapper.Map<DependentViewModel>(dependent);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int? id,DependentViewModel dependent)
        {
            try
            {
                if (id != dependent.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<Dependent>(dependent);
                    _unitOfWork.DependentRepository.Delete(result);
                    var count =await _unitOfWork.CompleteAsync();
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }
            return View(dependent);
        }

    }
}
