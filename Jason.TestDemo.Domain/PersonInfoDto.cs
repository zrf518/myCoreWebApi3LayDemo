using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.TestDemo.Domain
{
    /// <summary>
    /// 测试用户
    /// </summary>
    public class PersonInfoDto
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

    }
}
