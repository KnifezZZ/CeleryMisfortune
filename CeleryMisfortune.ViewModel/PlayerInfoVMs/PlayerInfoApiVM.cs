using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public partial class PlayerInfoApiVM : BaseCRUDVM<PlayerInfo>
    {

        public PlayerInfoApiVM()
        {
        }

        protected override void InitVM()
        {
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



        public PlayerInfoApiUnitInfo GetUnitInfoVM(PlayerInfo pi)
        {
            var vm = new PlayerInfoApiUnitInfo
            {
                Infos = pi
            };
            vm.Special = DC.Set<PlayerSpecial>().Where(p => p.FK_PlayerGuId == pi.ID.ToString()).FirstOrDefault();
            vm.State = DC.Set<PlayerState>().Where(p => p.FK_PlayerGuId == pi.ID.ToString()).FirstOrDefault();
            vm.Attributes = DC.Set<PlayerAttribute>().Where(p => p.FK_PlayerGuid == pi.ID.ToString()).ToList();
            return vm;
        }
    }
}
