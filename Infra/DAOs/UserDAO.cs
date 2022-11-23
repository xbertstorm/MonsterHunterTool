using ISpan.Utility;
using MonsterHunterTool.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Infra.DAOs
{
    public class UserDAO
    {
        public IEnumerable<UserDTO> GetAll()
        {
            string sql = "SELECT * FROM Users";

            var dbHelper = new SqlDbHelper("default");
            // 存放在field裡, 稍後在 grid CellClick事件會需要再度用到它
            return dbHelper.Select(sql, null).AsEnumerable()
                .Select(row => new UserDTO
                {
                    ID = row.Field<int>("ID"),
                    Account = row.Field<string>("Account"),
                    UserName = row.Field<string>("UserName")
                });
        }

        public bool AccountExists(string account)
        {
            string sql = @"SELECT Count(*) as count FROM Users WHERE Account=@Account";

            var parameters = new SqlParameterBuilder().AddNVarchar("Account", 50, account).Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("count") > 0;
        }

        public bool AccountExists(UserDTO model)
        {
            string sql = @"SELECT Count(*) as count FROM Users WHERE Account=@Account AND ID!=@ID";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, model.Account)
                .AddInt("ID", model.ID)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("count") > 0;
        }

        public void Create(UserDTO model)
        {
            string sql = "INSERT INTO Users (Account,Password, UserName) VALUES (@Account,@Password, @UserName)";

            var parameters = new SqlParameterBuilder().AddNVarchar("Account", 50, model.Account).AddNVarchar("Password", 50, model.Password).AddNVarchar("UserName", 50, model.UserName).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }

        public void Update(UserDTO model)
        {
            string sql = "UPDATE Users SET Account=@Account, Password=@Password, UserName=@UserName WHERE ID=@ID";

            var parameters = new SqlParameterBuilder().AddNVarchar("Account", 50, model.Account).AddNVarchar("Password", 50, model.Password).AddNVarchar("UserName", 50, model.UserName).AddInt("ID", model.ID).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public void Delete(int id)
        {
            string sql = @"DELETE FROM Users WHERE ID=@ID";

            var parameters = new SqlParameterBuilder().AddInt("ID", id).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public UserDTO Get(string account)
        {
            string sql = "SELECT * FROM Users WHERE Account=@Account";
            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, account)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                return null;
            }

            // 將找到的一筆記錄由DataTable 轉換到 UserVM
            return ToUserDTO(data.Rows[0]);
        }

        public UserDTO Get(int id)
        {
            string sql = "SELECT * FROM Users WHERE ID=@ID";
            var parameters = new SqlParameterBuilder()
                .AddInt("ID", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                throw new Exception("找不到要編輯的記錄");

            }

            // 將找到的一筆記錄由DataTable 轉換到 ProductVM
            return ToUserDTO(data.Rows[0]);
        }


        private UserDTO ToUserDTO(DataRow row)
        {
            return new UserDTO
            {
                ID = row.Field<int>("ID"),
                Account = row.Field<string>("Account"),
                Password = row.Field<string>("Password"),
                UserName = row.Field<string>("UserName"),
            };
        }
    }
}
