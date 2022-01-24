

using System;
using System.Data.SqlClient;

namespace SharedFrameWork.Application
{
    public interface IContextHelper:IDisposable
    {
        SqlConnection Create();
    }
}
