using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerAttributeVMs
{
    public partial class PlayerAttributeApiListVM : BasePagedListVM<PlayerAttributeApi_View, PlayerAttributeApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("PlayerAttribute", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<PlayerAttributeApi_View>> InitGridHeader()
        {
            return new List<GridColumn<PlayerAttributeApi_View>>{
                this.MakeGridHeader(x => x.FK_PlayerGuid),
                this.MakeGridHeader(x => x.AttrName),
                this.MakeGridHeader(x => x.AttrValue),
                this.MakeGridHeader(x => x.AttributeType),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PlayerAttributeApi_View> GetSearchQuery()
        {
            var query = DC.Set<PlayerAttribute>()
                .CheckContain(Searcher.FK_PlayerGuid, x=>x.FK_PlayerGuid)
                .CheckContain(Searcher.AttrName, x=>x.AttrName)
                .CheckEqual(Searcher.AttributeType, x=>x.AttributeType)
                .Select(x => new PlayerAttributeApi_View
                {
				    ID = x.ID,
                    FK_PlayerGuid = x.FK_PlayerGuid,
                    AttrName = x.AttrName,
                    AttrValue = x.AttrValue,
                    AttributeType = x.AttributeType,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PlayerAttributeApi_View : PlayerAttribute{

    }
}
