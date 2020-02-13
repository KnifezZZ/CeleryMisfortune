using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace CeleryMisfortune.Model.Base
{
    public class BaseOption:BasePoco
    {

        [Display(Name = "基类编码")]
        public new int ID { get; set; }

        [Display(Name = "父类编码")]
        public int PID { get; set; }

        [Display(Name = "基类名称")]
        [StringLength(255)]
        public string Text { get; set; }
    }
}
