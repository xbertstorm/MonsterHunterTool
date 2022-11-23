using MonsterHunterTool.Infra.DAOs;
using MonsterHunterTool.Models.DTOs;
using MonsterHunterTool.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Models.Services
{
    public class UserService
    {
        private UserDAO _dao;

        public UserService()
        {
            _dao = new UserDAO();
        }

        public void Create(UserDTO model)
        {
            bool isExists = _dao.AccountExists(model.Account);
            if (isExists) throw new Exception("帳號已存在");

            new UserDAO().Create(model);

        }

        private UserIndexVM ParseToIndexVM(DataRow row)
        {
            return new UserIndexVM
            {
                ID = row.Field<int>("ID"),
                Account = row.Field<string>("Account"),
                UserName = row.Field<string>("UserName")
            };
        }

        internal void Update(UserDTO model)
        {
            bool isExists = _dao.AccountExists(model);
            if (isExists) throw new Exception("帳號已存在");

            new UserDAO().Update(model);
        }

        internal void Delete(int id)
        {
            _dao.Delete(id);
        }

        public bool Authenticate(LoginVM model)
        {
            var user = _dao.Get(model.Account);
            if (user == null) return false; // 找不到符合的帳號

            return (user.Password == model.Password);
        }
    }
}
