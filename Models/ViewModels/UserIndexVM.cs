using MonsterHunterTool.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Models.ViewModels
{
    public class UserIndexVM
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
    }
    public class UserVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "帳號必須填。")]
        public string Account { get; set; }

        [Required(ErrorMessage = "密碼必須填。")]
        public string Password { get; set; }

        [Required(ErrorMessage = "會員名稱必須填。")]
        public string UserName { get; set; }
    }
    public static class UserVMExts
    {
        public static UserDTO ToDTO(this UserVM vm)
        {
            return new UserDTO
            {
                ID = vm.ID,
                Account = vm.Account,
                Password = vm.Password,
                UserName = vm.UserName
            };
        }
    }
}
