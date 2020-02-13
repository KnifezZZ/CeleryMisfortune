using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using CeleryMisfortune.Model.Base;


namespace CeleryMisfortune.ViewModel.BaseOptionVMs
{
    public partial class BaseOptionListVM : BasePagedListVM<BaseOption_View, BaseOptionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("BaseOption", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<BaseOption_View>> InitGridHeader()
        {
            return new List<GridColumn<BaseOption_View>>{
                this.MakeGridHeader(x => x.PID),
                this.MakeGridHeader(x => x.Text),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<BaseOption_View> GetSearchQuery()
        {
            var query = DC.Set<BaseOption>()
                .CheckEqual(Searcher.PID, x=>x.PID)
                .CheckContain(Searcher.Text, x=>x.Text)
                .Select(x => new BaseOption_View
                {
				    ID = x.ID,
                    PID = x.PID,
                    Text = x.Text,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class BaseOption_View : BaseOption{

    }
}
