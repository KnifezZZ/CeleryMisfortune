using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerStateVMs
{
    public partial class PlayerStateBatchVM : BaseBatchVM<PlayerState, PlayerState_BatchEdit>
    {
        public PlayerStateBatchVM()
        {
            ListVM = new PlayerStateListVM();
            LinkedVM = new PlayerState_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerState_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
