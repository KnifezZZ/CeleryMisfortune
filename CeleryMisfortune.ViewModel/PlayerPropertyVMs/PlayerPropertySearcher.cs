using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerPropertyVMs
{
    public partial class PlayerPropertySearcher : BaseSearcher
    {
        [Display(Name = "关联角色")]
        public String FK_PlayerGuId { get; set; }
        [Display(Name = "类型")]
        public Int32? TypeId { get; set; }
        [Display(Name = "资产名称")]
        public String ItemName { get; set; }
        [Display(Name = "当前级别")]
        public Int32? Level { get; set; }

        protected override void InitVM()
        {
        }

    }
}
