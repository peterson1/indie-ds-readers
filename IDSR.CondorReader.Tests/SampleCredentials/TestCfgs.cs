using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.CondorReader.Tests.SampleCredentials
{
    class TestCfgs
    {
        internal static DatabaseCredentials Local_2017Jan21()
            => new DatabaseCredentials
            {
                DbType    = DbTypes.SQLite3,
                ServerURL = @"C:\Users\Pete\Desktop\2017-01-21 BK Reports\2017-01-21_BK_orig.sqlite",
            };
    }
}
