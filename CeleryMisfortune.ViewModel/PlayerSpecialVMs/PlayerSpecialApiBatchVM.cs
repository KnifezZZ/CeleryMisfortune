using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerSpecialVMs
{
    public partial class PlayerSpecialApiBatchVM : BaseBatchVM<PlayerSpecial, PlayerSpecialApi_BatchEdit>
    {
        public PlayerSpecialApiBatchVM()
        {
            ListVM = new PlayerSpecialApiListVM();
            LinkedVM = new PlayerSpecialApi_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerSpecialApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
