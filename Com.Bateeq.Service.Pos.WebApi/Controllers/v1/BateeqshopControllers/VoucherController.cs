using Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService.VoucherServices;
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
    [Route("v{version:apiVersion}/vouchers")]
    [Authorize]
    public class VoucherController : Controller
    {
        protected IIdentityService IdentityService;
        protected readonly IValidateService ValidateService;
        //public readonly IServiceProvider serviceProvider;
        protected readonly IVoucherService Service;
        protected readonly string ApiVersion;
        public VoucherController(IIdentityService identityService, IValidateService validateService, IVoucherService service)
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
        public IActionResult Get(DateTime startDate, DateTime endDate, string voucherType, string code, string name, string keyword)

        {
            try
            {
                VerifyUser();
                var read = Service.Read(startDate, endDate, voucherType, code, name, keyword);

                List<VoucherViewModel> listData = new List<VoucherViewModel>();
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

        [HttpGet]
        [Route("membership")]
        public IActionResult GetVoucherMembership(DateTime startDate, DateTime endDate, string voucherType, string code, string name, string keyword, int membershipId)

        {
            try
            {
                VerifyUser();
                var read = Service.ReadMembership(startDate, endDate, voucherType, code, name, keyword, membershipId);

                List<VoucherViewModel> listData = new List<VoucherViewModel>();
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
    }
}
