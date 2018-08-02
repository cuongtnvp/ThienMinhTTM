using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// Call save change from Db context
        /// </summary>
        void Commit();
    }
}
