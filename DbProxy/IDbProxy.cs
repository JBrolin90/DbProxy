using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProxy;

public interface IDbProxy
{
    DbConnection connection { get; }
    DbCommand command { get; }
    DbDataAdapter adapter { get; }
    public DbCommandBuilder commandBuilder { get; }

    public DbCommand BaseTablesCommand();

}
