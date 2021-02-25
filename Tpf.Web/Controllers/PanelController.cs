using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
                var result = new List<ParkVModel>();
                using (var service = new PanelService())
                {
                    result = service.Get();
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Error" + ex.Message);
            }
        }

        public JsonResult Post()
        {
            return Json("Post");
        }

        public JsonResult Put()
        {
            return Json("Put");
        }

        public JsonResult Delete()
        {
            try
            {
                using (var service = new PanelService())
                {
                    service.Delete();
                }
                return Json("Delete");
            }
            catch (Exception ex)
            {
                return Json("Error" + ex.Message);
            }
        }

        public async Task<JsonResult> Patch()
        {
            try
            {
                var result = new List<OpdGovRawVModel>();
                using (var service = new OpdGovService())
                {
                    result = await service.GetData();
                }
                using (var service = new PanelService())
                {
                    service.Patch(result);
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Error" + ex.Message);
            }
        }
    }
}