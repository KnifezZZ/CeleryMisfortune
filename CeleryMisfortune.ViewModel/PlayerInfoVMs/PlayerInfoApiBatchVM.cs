using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public partial class PlayerInfoApiBatchVM : BaseBatchVM<PlayerInfo, PlayerInfoApi_BatchEdit>
    {
        public PlayerInfoApiBatchVM()
        {
            ListVM = new PlayerInfoApiListVM();
            LinkedVM = new PlayerInfoApi_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerInfoApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
