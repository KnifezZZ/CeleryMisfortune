using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerSpecialVMs
{
    public partial class PlayerSpecialApiListVM : BasePagedListVM<PlayerSpecialApi_View, PlayerSpecialApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("PlayerSpecial", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<PlayerSpecialApi_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerSpecialApi_View>>{
                this.MakeGridHeader(x => x.FK_PlayerGuId),
                this.MakeGridHeader(x => x.Strength),
                this.MakeGridHeader(x => x.Perception),
                this.MakeGridHeader(x => x.Endurance),
                this.MakeGridHeader(x => x.Charisma),
                this.MakeGridHeader(x => x.Intelligence),
                this.MakeGridHeader(x => x.Agility),
                this.MakeGridHeader(x => x.Luck),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PlayerSpecialApi_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerSpecial>()
                .CheckContain(Searcher.FK_PlayerGuId, x=>x.FK_PlayerGuId)
                .CheckEqual(Searcher.Strength, x=>x.Strength)
                .CheckEqual(Searcher.Perception, x=>x.Perception)
                .CheckEqual(Searcher.Endurance, x=>x.Endurance)
                .CheckEqual(Searcher.Charisma, x=>x.Charisma)
                .CheckEqual(Searcher.Intelligence, x=>x.Intelligence)
                .CheckEqual(Searcher.Agility, x=>x.Agility)
                .CheckEqual(Searcher.Luck, x=>x.Luck)
                .Select(x => new PlayerSpecialApi_View
                {
				    ID = x.ID,
                    FK_PlayerGuId = x.FK_PlayerGuId,
                    Strength = x.Strength,
                    Perception = x.Perception,
                    Endurance = x.Endurance,
                    Charisma = x.Charisma,
                    Intelligence = x.Intelligence,
                    Agility = x.Agility,
                    Luck = x.Luck,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PlayerSpecialApi_View : PlayerSpecial{

    }
}
