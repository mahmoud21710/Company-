using AutoMapper;
using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Model;
using Company.G04.PL.ViewModels.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.G04.PL.Controllers
{
	[Authorize]

	public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var project=await _unitOfWork.ProjectRepository.GetAllAsync();
            var result =_mapper.Map<IEnumerable<ProjectViewModel>>(project);
            return View(result);

        }
        public async Task<IActionResult> Create() 
        {
            var department01=await _unitOfWork.DepartmentRepository.GetAllAsync();
            ViewData["department01"] = department01;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            //var department01 = _unitOfWork.DepartmentRepository.GetAll();
            //ViewData["department01"] = department01;
            if (ModelState.IsValid) 
            {
                var result= _mapper.Map<Project>(model);
                await _unitOfWork.ProjectRepository.AddAsync(result);
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
            var project=await _unitOfWork.ProjectRepository.GetAsync(id.Value);
            if(project is null) return NotFound();
            var result =_mapper.Map<ProjectViewModel>(project);
            return View(result);
        }
        public async Task<IActionResult> Edit(int? id) 
        {
            var department01 =await _unitOfWork.DepartmentRepository.GetAllAsync();
            ViewData["department01"] = department01;
            if(id is null) return BadRequest();
            var project=await _unitOfWork.ProjectRepository.GetAsync(id.Value);
            if(project is null) return NotFound();
            var result = _mapper.Map<ProjectViewModel>(project);
            return View(result);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int? id , ProjectViewModel model) 
        {
            try
            {
                if (id != model.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var result =_mapper.Map<Project>(model); 
                    _unitOfWork.ProjectRepository.Update(result);
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
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id is null) return BadRequest();
            var project =await _unitOfWork.ProjectRepository.GetAsync(id.Value);
            if (project is null) return NotFound();
            var result = _mapper.Map<ProjectViewModel>(project);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int? id,ProjectViewModel project) 
        {
            try
            {
                if (id != project.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<Project>(project);
                    _unitOfWork.ProjectRepository.Delete(result);
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
            return View(project);
        }
    }
}
