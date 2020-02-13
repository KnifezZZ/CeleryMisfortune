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
    public partial class PlayerPropertyBatchVM : BaseBatchVM<PlayerProperty, PlayerProperty_BatchEdit>
    {
        public PlayerPropertyBatchVM()
        {
            ListVM = new PlayerPropertyListVM();
            LinkedVM = new PlayerProperty_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerProperty_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
