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
    public partial class PlayerStateApiBatchVM : BaseBatchVM<PlayerState, PlayerStateApi_BatchEdit>
    {
        public PlayerStateApiBatchVM()
        {
            ListVM = new PlayerStateApiListVM();
            LinkedVM = new PlayerStateApi_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerStateApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
