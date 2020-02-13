using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerStateVMs
{
    public partial class PlayerStateApiListVM : BasePagedListVM<PlayerStateApi_View, PlayerStateApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("PlayerState", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<PlayerStateApi_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerStateApi_View>>{
                this.MakeGridHeader(x => x.FK_PlayerGuId),
                this.MakeGridHeader(x => x.StateLevel),
                this.MakeGridHeader(x => x.LevelExp),
                this.MakeGridHeader(x => x.LifeRemark),
                this.MakeGridHeader(x => x.MaxLifeTime),
                this.MakeGridHeader(x => x.CurrentLife),
                this.MakeGridHeader(x => x.Energy),
                this.MakeGridHeader(x => x.Money),
                this.MakeGridHeader(x => x.Gold),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PlayerStateApi_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerState>()
                .CheckContain(Searcher.FK_PlayerGuId, x=>x.FK_PlayerGuId)
                .CheckEqual(Searcher.LevelExp, x=>x.LevelExp)
                .CheckEqual(Searcher.Gold, x=>x.Gold)
                .Select(x => new PlayerStateApi_View
                {
				    ID = x.ID,
                    FK_PlayerGuId = x.FK_PlayerGuId,
                    StateLevel = x.StateLevel,
                    LevelExp = x.LevelExp,
                    LifeRemark = x.LifeRemark,
                    MaxLifeTime = x.MaxLifeTime,
                    CurrentLife = x.CurrentLife,
                    Energy = x.Energy,
                    Money = x.Money,
                    Gold = x.Gold,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PlayerStateApi_View : PlayerState{

    }
}
