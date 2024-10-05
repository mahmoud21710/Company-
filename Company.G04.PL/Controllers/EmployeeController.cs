using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Model;
using Company.G04.PL.Helper;
using Company.G04.PL.ViewModels.Employes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Company.G04.PL.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(  IUnitOfWork unitOfWork ,IMapper mapper  )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string InputSearch)
        {
            var employees =Enumerable.Empty<Employee>() ;
            //IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(InputSearch))
            {
                 employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            }
            else
            {
                 employees = await _unitOfWork.EmployeeRepository.GetByNameAsync(InputSearch);
            }
            var result =  _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(result);
        }
        public async Task<IActionResult> Create() 
        {
            var departments =await _unitOfWork.DepartmentRepository.GetAllAsync();
            ViewData["departments"] = departments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image is not null) 
                    {
                        model.ImageName = DocumentSettings.Upload(model.Image, "images");
                    }
                    var result = _mapper.Map<Employee>(model);
                    await _unitOfWork.EmployeeRepository.AddAsync(result);
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

        public async Task<IActionResult> Detalis(int? id ) 
        {
            if(id is null)
            {
                return BadRequest();
            }
            var employee =await _unitOfWork.EmployeeRepository.GetAsync(id.Value);
            if(employee is  null) return NotFound();
            
            var result = _mapper.Map<EmployeeViewModel>(employee);
            return View(result);
        }
        public async Task<IActionResult> Edit(int? id) 
        {
            var departments =await _unitOfWork.DepartmentRepository.GetAllAsync();
            ViewData["departments"] = departments;
            if (id is null)
            {
                return BadRequest();
            }
            var employee =await _unitOfWork.EmployeeRepository.GetAsync(id.Value);
            if (employee is null) return NotFound();
            var employeeviewmodel =_mapper.Map<EmployeeViewModel>(employee);
            return View(employeeviewmodel);

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int? id , EmployeeViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();
                    if (ModelState.IsValid)
                    {
                    if (model.Image is not null) 
                    {
                        DocumentSettings.Delete(model.ImageName, "Images");
                    }
                        if(model.Image is not null) 
                        {
                          model.ImageName= DocumentSettings.Upload(model.Image, "Images");
                        }
                    var employee= _mapper.Map<Employee>(model);
                         _unitOfWork.EmployeeRepository.Update(employee);
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
            var employee =await _unitOfWork.EmployeeRepository.GetAsync(id.Value);
            if (employee is null) return NotFound();
            
            var employeeviewmodel = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeviewmodel);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute]int? id ,EmployeeViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    if (model.ImageName is not null) 
                    {
                        DocumentSettings.Delete(model.ImageName, "Images");
                    }
                    var employee = _mapper.Map<Employee>(model);    
                     _unitOfWork.EmployeeRepository.Delete(employee);
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
