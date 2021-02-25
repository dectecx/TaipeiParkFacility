using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tpf.Library.Enums;
using Tpf.Library.Services;
using Tpf.Library.ViewModels;

namespace Tpf.Web.Controllers
{
    public class PanelController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            try
            {
                using (var service = new PanelService())
                {
                    var model = service.Get();
                    var result = new ResultVModel<List<ParkVModel>>
                    {
                        Code = CodeEnum.Success,
                        Message = "取得成功",
                        Data = model
                    };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var error = new ResultVModel { Code = CodeEnum.Fail, Message = "Error" + ex.Message };
                return Json(error);
            }
        }

        public JsonResult Post()
        {
            try
            {
                var model = "Post";
                var result = new ResultVModel<string>
                {
                    Code = CodeEnum.Success,
                    Message = "新增成功",
                    Data = model
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                var error = new ResultVModel { Code = CodeEnum.Fail, Message = "Error" + ex.Message };
                return Json(error);
            }
        }

        public JsonResult Put()
        {
            try
            {
                var model = "Put";
                var result = new ResultVModel<string>
                {
                    Code = CodeEnum.Success,
                    Message = "更新成功",
                    Data = model
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                var error = new ResultVModel { Code = CodeEnum.Fail, Message = "Error" + ex.Message };
                return Json(error);
            }
        }

        public JsonResult Delete()
        {
            try
            {
                using (var service = new PanelService())
                {
                    service.Delete();

                    var model = "Delete";
                    var result = new ResultVModel<string>
                    {
                        Code = CodeEnum.Success,
                        Message = "刪除成功",
                        Data = model
                    };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var error = new ResultVModel { Code = CodeEnum.Fail, Message = "Error" + ex.Message };
                return Json(error);
            }
        }

        public async Task<JsonResult> Patch()
        {
            try
            {
                var model = new List<OpdGovRawVModel>();
                using (var service = new OpdGovService())
                {
                    model = await service.GetData();
                }
                using (var service = new PanelService())
                {
                    service.Patch(model);
                }

                var result = new ResultVModel<string>
                {
                    Code = CodeEnum.Success,
                    Message = "介接成功",
                    Data = "Patch"
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                var error = new ResultVModel { Code = CodeEnum.Fail, Message = "Error" + ex.Message };
                return Json(error);
            }
        }
    }
}