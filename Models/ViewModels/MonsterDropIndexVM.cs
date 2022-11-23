using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterTool.Models.ViewModels
{
    public class MonsterDropIndexVM
    {
        public int ID { get; set; }
        public string MonsterNickName { get; set; }
        public string Item { get; set; }
        public string TheLevel { get; set; }
    }
    public class MonsterDropVM
    {
        public int ID { get; set; }
        public int MonsterID { get; set; }
        public string Item { get; set; }
        public int MonsterLevel { get; set; }
    }
}
