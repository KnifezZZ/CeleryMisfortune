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
    public partial class PlayerStateListVM : BasePagedListVM<PlayerState_View, PlayerStateSearcher>
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

        protected override IEnumerable<IGridColumn<PlayerState_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerState_View>>{
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

        public override IOrderedQueryable<PlayerState_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerState>()
                .CheckContain(Searcher.FK_PlayerGuId, x=>x.FK_PlayerGuId)
                .CheckContain(Searcher.StateLevel, x=>x.StateLevel)
                .CheckEqual(Searcher.CurrentLife, x=>x.CurrentLife)
                .CheckEqual(Searcher.Money, x=>x.Money)
                .CheckEqual(Searcher.Gold, x=>x.Gold)
                .Select(x => new PlayerState_View
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

    public class PlayerState_View : PlayerState{

    }
}
