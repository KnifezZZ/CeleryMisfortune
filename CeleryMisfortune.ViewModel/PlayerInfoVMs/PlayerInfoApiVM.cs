using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;
using KnifeZ.SignalRKit;

namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public partial class PlayerInfoApiVM : BaseCRUDVM<PlayerInfo>
    {
        private readonly ServerNotifyHub snh;
        public PlayerInfoApiVM(ServerNotifyHub _snh)
        {
            snh = _snh;
        }

        protected override void InitVM()
        {
            _ = snh.SendInfoAsync("hello!");
        }

        public override void DoAdd()
        {
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
