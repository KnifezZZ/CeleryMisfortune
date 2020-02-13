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
    public partial class PlayerAttributeApiBatchVM : BaseBatchVM<PlayerAttribute, PlayerAttributeApi_BatchEdit>
    {
        public PlayerAttributeApiBatchVM()
        {
            ListVM = new PlayerAttributeApiListVM();
            LinkedVM = new PlayerAttributeApi_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class PlayerAttributeApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
