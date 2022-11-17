using Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService;
using Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels;
using Com.Danliris.Service.Inventory.Lib.Services;
using Com.Danliris.Service.Inventory.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Pos.WebApi.Controllers.v1.BateeqshopControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/customer")]
    [Authorize]
    public class CustomerController : Controller
    {
        protected IIdentityService IdentityService;
        protected readonly IValidateService ValidateService;
        //public readonly IServiceProvider serviceProvider;
        protected readonly ICustomerService Service;
        protected readonly string ApiVersion;
        public CustomerController(IIdentityService identityService, IValidateService validateService, ICustomerService service)
        { 
            //this.serviceProvider = serviceProvider;
            IdentityService = identityService;
            ValidateService = validateService;
            Service = service;
            ApiVersion = "1.0.0";
        }

        protected void VerifyUser()
        {
            IdentityService.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
            IdentityService.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
            IdentityService.TimezoneOffset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
        }

        [HttpGet]
        public IActionResult Get( string email, string name, string phoneNumber,  string dobFrom,  string dobTo,  string membershipTier)
        
            {
            try
            {
                VerifyUser();
                var read = Service.Read( email, name,phoneNumber, dobFrom, dobTo, membershipTier);

                List<CustomerViewModel> listData = new List<CustomerViewModel>();
                listData = read.ToList();
                return Ok(new
                {
                    apiVersion = ApiVersion,
                    statusCode = General.OK_STATUS_CODE,
                    message = General.OK_MESSAGE,
                    data = listData,
                    info = new Dictionary<string, object>
                    {
                        { "count", listData.Count },
                        { "total", read.Count() }
                   
                    },
                });
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                VerifyUser();
                var read = Service.ReadById(id);

                List<CustomerViewModel> listData = new List<CustomerViewModel>();
                listData = read.ToList();
                return Ok(new
                {
                    apiVersion = ApiVersion,
                    statusCode = General.OK_STATUS_CODE,
                    message = General.OK_MESSAGE,
                    data = listData,
                    info = new Dictionary<string, object>
                    {
                        { "count", listData.Count },
                        { "total", read.Count() }

                    },
                });
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }
        [HttpGet("address/{id}")]
        public IActionResult GetAddressBookId([FromRoute] int id)
        {
            try
            {
                VerifyUser();
                var read = Service.ReadAddressById(id);

                List<AddressBookViewModel> listData = new List<AddressBookViewModel>();
                listData = read.ToList();
                return Ok(new
                {
                    apiVersion = ApiVersion,
                    statusCode = General.OK_STATUS_CODE,
                    message = General.OK_MESSAGE,
                    data = listData,
                    info = new Dictionary<string, object>
                    {
                        { "count", listData.Count },
                        { "total", read.Count() }

                    },
                });
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }
        [HttpGet("order/{id}")]
        public IActionResult GetOrderByUserId([FromRoute] int id)
        {
            try
            {
                VerifyUser();
                var read = Service.ReadOrderByUserId(id);

                List<OrderViewModel> listData = new List<OrderViewModel>();
                listData = read.ToList();
                return Ok(new
                {
                    apiVersion = ApiVersion,
                    statusCode = General.OK_STATUS_CODE,
                    message = General.OK_MESSAGE,
                    data = listData,
                    info = new Dictionary<string, object>
                    {
                        { "count", listData.Count },
                        { "total", read.Count() }

                    },
                });
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }

        [HttpGet("membership")]
        public IActionResult GetMembership()
        {
            try
            {
                VerifyUser();
                var read = Service.ReadMembership();

                List<MembershipViewModel> listData = new List<MembershipViewModel>();
                listData = read.ToList();
                return Ok(new
                {
                    apiVersion = ApiVersion,
                    statusCode = General.OK_STATUS_CODE,
                    message = General.OK_MESSAGE,
                    data = listData,
                    info = new Dictionary<string, object>
                    {
                        { "count", listData.Count },
                        { "total", read.Count() }

                    },
                });
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }

        [HttpGet("download")]
        public IActionResult GetXls(string email, string name, string phoneNumber, string dobFrom, string dobTo, string membershipTier)
        {
            //Console.WriteLine("sampai sini");
            try
            {
                VerifyUser();
                byte[] xlsInBytes;
                int offset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
                string accept = Request.Headers["Accept"];

                var xls = Service.GenerateExcel(email, name, phoneNumber, dobFrom, dobTo, membershipTier);
                string filename = String.Format("Customer - {0}.xlsx", DateTime.UtcNow.ToString("ddMMyyyy"));

                xlsInBytes = xls.ToArray();
                var file = File(xlsInBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
                return file;

            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                   .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }

        }

    }
}
