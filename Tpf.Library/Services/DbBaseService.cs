using Tpf.Library.Models;

namespace Tpf.Library.Services
{
    public abstract class DbBaseService : BaseService
    {
        /// <summary>
        /// 資料庫連線
        /// </summary>
        protected TpfEntities db;

        /// <summary>
        /// 建構子
        /// </summary>
        protected DbBaseService()
        {
            db = new TpfEntities();
        }

        /// <summary>
        /// 建構子
        /// </summary>
        protected DbBaseService(ref TpfEntities db)
        {
            this.db = db;
        }

        /// <summary>
        /// 資源釋放
        /// </summary>
        public override void Dispose()
        {
            if (db == null)
            {
                return;
            }
            db.Dispose();
            db = null;
        }
    }
}
