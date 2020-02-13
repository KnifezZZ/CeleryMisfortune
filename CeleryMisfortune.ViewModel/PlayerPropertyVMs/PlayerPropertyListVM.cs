using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerPropertyVMs
{
    public partial class PlayerPropertyListVM : BasePagedListVM<PlayerProperty_View, PlayerPropertySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("PlayerProperty", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<PlayerProperty_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerProperty_View>>{
                this.MakeGridHeader(x => x.FK_PlayerGuId),
                this.MakeGridHeader(x => x.TypeId),
                this.MakeGridHeader(x => x.ItemName),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.Value),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PlayerProperty_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerProperty>()
                .CheckContain(Searcher.FK_PlayerGuId, x=>x.FK_PlayerGuId)
                .CheckEqual(Searcher.TypeId, x=>x.TypeId)
                .CheckContain(Searcher.ItemName, x=>x.ItemName)
                .CheckEqual(Searcher.Level, x=>x.Level)
                .Select(x => new PlayerProperty_View
                {
				    ID = x.ID,
                    FK_PlayerGuId = x.FK_PlayerGuId,
                    TypeId = x.TypeId,
                    ItemName = x.ItemName,
                    Level = x.Level,
                    Value = x.Value,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PlayerProperty_View : PlayerProperty{

    }
}
