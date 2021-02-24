using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tpf.Library.ViewModels;
//using System.Transactions;

namespace Tpf.Library.Services
{
    public class PanelService : DbBaseService
    {
        public void Patch(List<OpdGovRawVModel> vmodels)
        {
            if (vmodels == null)
            {
                return;
            }

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    scope.Complete();
            //}
            var dimDict = db.DimDict.Where(e => !e.IsDelete).ToList();
            var dimFacility = db.DimFacility.Where(e => !e.IsDelete).ToList();

            foreach(var item in vmodels)
            {
                try
                {
                    var dictId = dimDict.Where(e => e.Name == item.Dict?.Trim() + "區").Select(e => e.Id).FirstOrDefault();
                    var model = new Models.Park
                    {
                        Name = item.ParkName,
                        DictId = dictId,
                        ManagementUnit = item.ManagementUnit,
                        IsDelete = false,
                        CreateTime = DateTime.Now,
                        CreateBy = "user",
                        UpdateTime = DateTime.Now,
                        UpdateBy = "user"
                    };
                    db.Park.Add(model);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    ;
                }
            }
        }
    }
}
