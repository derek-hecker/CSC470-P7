using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    interface IIssueRepository
    {
        string Add(Issue issue);
        List<Issue> GetAll(int ProjectID);
        bool Remove(Issue issue);
        string Modify(Issue issue);
        int GetTotalNumberOfIssues(int ProjectID);
        List<string> GetIssuesByMonth(int ProjectID);
        List<string> GetIssuesByDiscoverer(int ProjectID);
        Issue GetIssueByID(int ID);

    }
}
