using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Domain.Interface;
using Application.Interface;
using Microsoft.EntityFrameworkCore.Query;
using System.Globalization;
using Amazon.Runtime.Documents;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata;

namespace MultiLang.Controllers;


[Authorize]
public class HomeController : Controller
{
    private readonly IEmployeeServices _employeeServices;
    private readonly IResourceServices _resourceServices;
    private readonly IFollowServices _documentServices;
    private readonly IQuotationServices _quotationServices;
    private readonly ILoginService _loginService;
    private readonly IAttachmentServices _attachmentServices;
    public HomeController(IEmployeeServices employeeServices, IResourceServices resourceServices, IFollowServices documentServices, IQuotationServices quotationServices, ILoginService loginService, IAttachmentServices attachmentServices)
    {
        _employeeServices = employeeServices;
        _resourceServices = resourceServices;
        _documentServices = documentServices;
        _quotationServices = quotationServices;
        _loginService = loginService;
        _attachmentServices = attachmentServices;
    }

    public IActionResult AddUser()
    {
        return View(_resourceServices.GetAllResources());
    }

    [HttpPost]
    public IActionResult AddUser(UserViewModel model)
    {
        if(model != null)
        {
            _loginService.Add(model);
            return RedirectToAction("AddUser", "Home");
        }
        return View("AddUser");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View(_resourceServices.GetAllResources());
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _loginService.Login(model);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Name, user.Email),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Login", "home");
            }
        }
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult Employee()
    {
        return View(_resourceServices.GetAllResources());
    }
   
    [HttpPost]
    public IActionResult AddEmployee(EmployeeViewModel model)
    {
        if(model !=  null)
        {
            var employee = new EmployeeViewModel
            {
                Name = model.Name, 
                Email = model.Email,
                Address = model.Address,
            };
            _employeeServices.AddEmployee(employee);
            return RedirectToAction("Follow", "Home");
        }
        return View("Employee");
    }

    public PartialViewResult search(string searchtext)
    {
        var detail = _documentServices.GetAllDocuments();
        var result = detail.Where(x => x.DocumentNo.ToString().Contains(searchtext)).ToList();
        return PartialView("GetDocumentDtl",result);
    }
    public IActionResult Follow(int id)
    {
        var resources = _resourceServices.GetAllResources();
        var document = _documentServices.Get(id);
        var model = new ResourceDocumentViewModel
        {
            Resource = resources,
            Document = document,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult UploadFile(IFormFile file,int id,string sourceType)
    {
        if (file != null)
        {
            if(file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileExtention = Path.GetExtension(fileName);
                var FileName = string.Concat(Convert.ToString(Guid.NewGuid()),fileExtention);
                
                var details = new AttachmentViewModel
                {
                    Document= fileName,
                };
                if(sourceType == "Follow")
                {
                    details.FollowId = id;
                }
                if (sourceType == "Quotation")
                {
                    details.QuotationId = id;

                }
                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                }
                _attachmentServices.Add(details);
                return RedirectToAction("Follow");
            }
        }
        return View("Follow");
    }

    [HttpPost]
    public IActionResult AddFollow(DocumentViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            var details = new DocumentViewModel
             {
                DocumentNo = model.DocumentNo,
                Date = model.Date,
                BorrowersName = model.BorrowersName,
                SellersName = model.SellersName,
                DocumentType = model.DocumentType,
                PropertyDetails = model.PropertyDetails,
                EDharaCenter = model.EDharaCenter,
                DharaCenterNo = model.DharaCenterNo,
                DharaCenter = model.DharaCenter,
                CitySurveyNo = model.CitySurveyNo,
                CitySurvey = model.CitySurvey,
                CityTalati = model.CityTalati,
                GramPanchayat = model.GramPanchayat,
                DocumentPayment = model.DocumentPayment,
               
            };
            _documentServices.Add(details);
            return RedirectToAction("Follow", "Home");
        }
        return View("Follow");
    }
    [HttpPost]
    public IActionResult EditFollow(DocumentViewModel model)
    {
        if (ModelState.IsValid)
        {
            _documentServices.Edit(model);
            return RedirectToAction("GetDocumentDtl", "Home");
        }
        return View(model);
    }
    public IActionResult DelFollow(int id)
    {
        if(ModelState.IsValid)
        {
            _documentServices.Delete(id);
            return RedirectToAction("GetDocumentDtl", "Home");
        }
       
        return View();
    }
    [HttpGet]
    public IActionResult GetDocumentDtl()
    {
        var detail = _documentServices.GetAllDocuments();
        return View(detail);
    }

    [HttpGet]
    public IActionResult DueDateFollowDtl()
    {
        //var TodayDate = DateOnly.FromDateTime(DateTime.Now);
        var DueDate = _documentServices.GetAllDocuments().Where(d => d.Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));
        return View(DueDate);
    }

    public IActionResult FollowPDF(int id)
    {
         var document = _documentServices.Get(id);
        var resources = _resourceServices.GetAllResources(); 

        var model = new ResourceDocumentViewModel
        {
            Document = document,
            Resource = resources
        };
        return new ViewAsPdf(model);
    }

    public IActionResult Quotation(int id)
    {
        var resources = _resourceServices.GetAllResources();
        var quotation = _quotationServices.Get(id);
        var model = new ResorcesQuotationViewModel
        {
            Resource = resources,
            Quotaion = quotation,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult AddQuotation(QuotationViewModel model)
    {
        if(model != null)
        {
            _quotationServices.Add(model);
            return RedirectToAction("Quotation", "Home");
        }
        return View("Quotation");
    }
    [HttpPost]
    public IActionResult EditQuotation(QuotationViewModel model,int id)
    {
        if(ModelState.IsValid)
        {
            _quotationServices.Edit(model);
            return RedirectToAction("GetQuotationlDtl","home");
        }
        return View(model);
    }

    public IActionResult DeleteQuotation(int id)
    {
        if (ModelState.IsValid)
        {
            _quotationServices.Delete(id);
            return RedirectToAction("GetQuotationlDtl", "home");
        }
        return View();
    }
    [HttpGet]
    public IActionResult GetQuotationlDtl()
    {
        var details =_quotationServices.GetAllQuotation();
        return View(details);
    }

    [HttpGet]
    public IActionResult DueDateQuotationDtl()
    {
        //var TodayDate = DateOnly.FromDateTime(DateTime.Now);
        var DueDate = _quotationServices.GetAllQuotation().Where(d => d.App_Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));
        return View(DueDate);
    }

    public IActionResult QuotationPDF(int id)
    {
        var qutation = _quotationServices.Get(id);
        var resources = _resourceServices.GetAllResources();

        var model = new ResorcesQuotationViewModel
        {
            Quotaion = qutation,
            Resource = resources
        };

        return new ViewAsPdf(model);
    }
    public IActionResult ChangeLanguage(string lang)
    {
        if (!string.IsNullOrEmpty(lang))
        {
            Thread.CurrentThread.CurrentCulture=CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture=new CultureInfo(lang);
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }
        Response.Cookies.Append("Language", lang);
        return Redirect(Request.GetTypedHeaders().Referer.ToString());
    }
}
 