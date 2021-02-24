using System;

namespace Tpf.Library.Services
{
    public abstract class BaseService : IDisposable
    {
        /// <summary>
        /// 建構子
        /// </summary>
        protected BaseService()
        {
        }

        /// <summary>
        /// 資源釋放
        /// </summary>
        public virtual void Dispose()
        {
            return;
        }
    }
}
