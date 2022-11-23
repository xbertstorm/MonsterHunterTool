using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISpan.Utility;

namespace MonsterHunterTool.Models.ViewModels
{
    /// <summary>
    /// 給MonsterForm使用，顯示主要畫面
    /// </summary>
    public class MonsterIndexVM
    {
        public int ID { get; set; }
        public string MonsterCategory { get; set; }
        public string MonsterName { get; set; }
        public string MonsterNickName { get; set; }
    }
    /// <summary>
    /// 給CreateMonsterForm、EditMonsterForm使用
    /// </summary>
    public class MonsterVM
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string MonsterName { get; set; }
        public string MonsterNickName { get; set; }
    }
}
