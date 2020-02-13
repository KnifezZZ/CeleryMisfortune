using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerAttributeVMs
{
    public partial class PlayerAttributeSearcher : BaseSearcher
    {
        [Display(Name = "关联角色ID")]
        public String FK_PlayerGuid { get; set; }
        [Display(Name = "属性名称")]
        public String AttrName { get; set; }
        [Display(Name = "属性类型")]
        public Int32? AttributeType { get; set; }

        protected override void InitVM()
        {
        }

    }
}
