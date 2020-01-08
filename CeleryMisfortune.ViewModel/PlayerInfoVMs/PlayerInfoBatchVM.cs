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
    public partial class PlayerInfoBatchVM : BaseBatchVM<PlayerInfo, PlayerInfo_BatchEdit>
    {
        public PlayerInfoBatchVM()
        {
            ListVM = new PlayerInfoListVM();
            LinkedVM = new PlayerInfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
