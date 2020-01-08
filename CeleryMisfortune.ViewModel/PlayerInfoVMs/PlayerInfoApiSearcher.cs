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
    public partial class PlayerInfoApiSearcher : BaseSearcher
    {
        public String Name { get; set; }
        public String NickName { get; set; }
        public String BirthPlace { get; set; }
        public Int32? Sex { get; set; }
        public Int32? Sect { get; set; }
        public string CreateBy { get; set; }
        protected override void InitVM()
        {
        }

    }
}
