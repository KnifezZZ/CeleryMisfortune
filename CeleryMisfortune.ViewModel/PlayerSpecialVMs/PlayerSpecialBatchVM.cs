﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerSpecialVMs
{
    public partial class PlayerSpecialBatchVM : BaseBatchVM<PlayerSpecial, PlayerSpecial_BatchEdit>
    {
        public PlayerSpecialBatchVM()
        {
            ListVM = new PlayerSpecialListVM();
            LinkedVM = new PlayerSpecial_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerSpecial_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
