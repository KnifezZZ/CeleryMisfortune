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
    public partial class PlayerAttributeBatchVM : BaseBatchVM<PlayerAttribute, PlayerAttribute_BatchEdit>
    {
        public PlayerAttributeBatchVM()
        {
            ListVM = new PlayerAttributeListVM();
            LinkedVM = new PlayerAttribute_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerAttribute_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
