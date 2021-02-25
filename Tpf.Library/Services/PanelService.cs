using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Tpf.Library.ViewModels;
//using System.Transactions;

namespace Tpf.Library.Services
{
    public class PanelService : DbBaseService
    {
        public List<ParkVModel> Get()
        {
            var model = db.Park.Where(e => !e.IsDelete)
                               .Select(e => new ParkVModel
                               {
                                   ParkName = e.Name,
                                   Dict = e.DictName,
                                   ManagementUnit = e.ManagementUnit,
                                   facilityList = db.ParkFacility.Where(x => !x.IsDelete && x.ParkId == e.Id)
                                                                 .Select(x => new FacilityVModel
                                                                 {
                                                                     Name = db.DimFacility.Where(y => !y.IsDelete && x.FacilityId == y.Id)
                                                                                          .Select(y => y.Name)
                                                                                          .FirstOrDefault(),
                                                                     Cnt = x.Cnt
                                                                 }).ToList()
                               }).ToList();
            return model;
        }

        public void Delete()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in db.ParkFacility)
                    db.ParkFacility.Remove(item);
                foreach (var item in db.Park)
                    db.Park.Remove(item);

                db.SaveChanges();

                scope.Complete();
            }
        }

        public void Patch(List<OpdGovRawVModel> vmodels)
        {
            if (vmodels == null)
            {
                return;
            }

            using (TransactionScope scope = new TransactionScope())
            {
                var dimFacility = db.DimFacility.Where(e => !e.IsDelete).ToList();
                foreach (var item in db.ParkFacility)
                    db.ParkFacility.Remove(item);
                foreach (var item in db.Park)
                    db.Park.Remove(item);
                foreach (var item in vmodels)
                {
                    #region add Park
                    var model = new Models.Park
                    {
                        Name = item.ParkName,
                        DictName = item.Dict,
                        ManagementUnit = item.ManagementUnit,
                        IsDelete = false,
                        CreateTime = DateTime.Now,
                        CreateBy = "user",
                        UpdateTime = DateTime.Now,
                        UpdateBy = "user"
                    };
                    db.Park.Add(model);
                    #endregion

                    #region add ParkFacility
                    if (!string.IsNullOrEmpty(item.CombinedPlayEquipment) && item.CombinedPlayEquipment?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "組合遊具").Select(e => e.Id).First();
                        int.TryParse(item.CombinedPlayEquipment?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.MillstoneSlide) && item.MillstoneSlide?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "磨石滑梯").Select(e => e.Id).First();
                        int.TryParse(item.MillstoneSlide?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Swing) && item.Swing?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "鞦韆").Select(e => e.Id).First();
                        int.TryParse(item.Swing?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Seesaw) && item.Seesaw?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "翹翹板").Select(e => e.Id).First();
                        int.TryParse(item.Seesaw?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Shake) && item.Shake?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "搖搖樂").Select(e => e.Id).First();
                        int.TryParse(item.Shake?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Climbing) && item.Climbing?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "攀爬組").Select(e => e.Id).First();
                        int.TryParse(item.Climbing?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Sandpit) && item.Sandpit?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "戲沙坑").Select(e => e.Id).First();
                        int.TryParse(item.Sandpit?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.SwingBoat) && item.SwingBoat?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "擺盪船索").Select(e => e.Id).First();
                        int.TryParse(item.SwingBoat?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    if (!string.IsNullOrEmpty(item.Other) && item.Other?.Trim() != "0")
                    {
                        var facilityId = dimFacility.Where(e => e.Name == "其他").Select(e => e.Id).First();
                        int.TryParse(item.Other?.Trim(), out int cnt);
                        var fmodel = new Models.ParkFacility
                        {
                            ParkId = model.Id,
                            FacilityId = facilityId,
                            Cnt = cnt,
                            IsDelete = false,
                            CreateTime = DateTime.Now,
                            CreateBy = "user",
                            UpdateTime = DateTime.Now,
                            UpdateBy = "user"
                        };
                        db.ParkFacility.Add(fmodel);
                    }
                    #endregion

                    db.SaveChanges();
                }
                scope.Complete();
            }
        }
    }
}
