using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public partial class PlayerInfoApiListVM : BasePagedListVM<PlayerInfoApi_View, PlayerInfoApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("PlayerInfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<PlayerInfoApi_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerInfoApi_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.NickName),
                this.MakeGridHeader(x => x.BirthPlace),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.Sect),
                this.MakeGridHeader(x => x.IsAlive),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PlayerInfoApi_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerInfo>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.NickName, x=>x.NickName)
                .CheckContain(Searcher.BirthPlace, x=>x.BirthPlace)
                .CheckEqual(Searcher.Sex, x=>x.Sex)
                .CheckEqual(Searcher.Sect, x=>x.Sect)
                .CheckEqual(Searcher.IsAlive, x=>x.IsAlive)
                .Select(x => new PlayerInfoApi_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    NickName = x.NickName,
                    BirthPlace = x.BirthPlace,
                    Sex = x.Sex,
                    Sect = x.Sect,
                    IsAlive = x.IsAlive,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PlayerInfoApi_View : PlayerInfo{

    }
}
