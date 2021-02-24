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
            return Json("Get");
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
            return Json("Delete");
        }

        public async Task<JsonResult> Patch()
        {
            var result = new List<OpdGovRawVModel>();
            using (var service = new OpdGovService())
            {
                result = await service.GetData();
            }
            using(var service = new PanelService())
            {
                service.Patch(result);
            }
            return Json(result);
        }
    }
}