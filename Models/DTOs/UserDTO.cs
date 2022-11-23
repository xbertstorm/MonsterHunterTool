using MonsterHunterTool.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Models.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
    public static class UserDTOExts
    {
        public static UserVM ToVM(this UserDTO dto)
        {
            return new UserVM
            {
                ID = dto.ID,
                Account = dto.Account,
                Password = dto.Password,
                UserName = dto.UserName,
            };
        }
        public static UserIndexVM ToIndexVM(this UserDTO dto)
        {
            return new UserIndexVM
            {
                ID = dto.ID,
                Account = dto.Account,
                // Password = dto.Password,
                UserName = dto.UserName,
            };
        }
    }
}
