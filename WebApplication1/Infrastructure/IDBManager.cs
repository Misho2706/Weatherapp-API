using System.Threading.Tasks;

namespace WebApplication1.Infrastructure
{
    public interface IDBManager
    {
        public Task SaveDataToDBCurr(responseCurr res, string url, bool toggleSwitchUnits);

        public Task SaveDataToDBFore(responseFore res, string url, bool toggleSwitchUnits);

        public Task SaveUserLogToDB(string mail, string ip, string mac, string username, int role);
    }
}
