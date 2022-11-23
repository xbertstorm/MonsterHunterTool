using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "帳號必須填")]
        public string Account { get; set; }


        [Required(ErrorMessage = "密碼必須填")]
        public string Password { get; set; }
    }
}
