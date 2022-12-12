using Jason.TestDemo.Domain;

namespace Jason.TestDemo.Contracts
{
    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITest001Interface
    {
        /// <summary>
        /// 测试函数
        /// </summary>
        /// <returns></returns>
        Task<List<PersonInfoDto>> Dotest001(); 
    }
}
