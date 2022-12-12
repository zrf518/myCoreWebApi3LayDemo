using Jason.TestDemo.Contracts;
using Jason.TestDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.TestDemo.Application
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public class Test001Service : ITest001Interface
    {
        public async Task<List<PersonInfoDto>> Dotest001()
        {
            await Task.CompletedTask;
            return new List<PersonInfoDto> {
                new PersonInfoDto {
                  id=110,PersonName="小张",BirthDay=DateTime.Now.AddYears(-10)
                },
                new PersonInfoDto {
                  id=111,PersonName="方法",BirthDay=DateTime.Now.AddYears(-12)
                },
                new PersonInfoDto {
                  id=112,PersonName="刚刚",BirthDay=DateTime.Now.AddYears(-5)
                }
            };
        }
    }
}
