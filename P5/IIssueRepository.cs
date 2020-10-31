using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public interface IIssueRepository
    {
        string Add(Issue issue, out int Id);
        List<Issue> GetAll(int ProjectID);
        bool Remove(Issue issue);
        string Modify(Issue issue);
        int GetTotalNumberOfIssues(int ProjectID);
        List<string> GetIssuesByMonth(int ProjectID);
        List<string> GetIssuesByDiscoverer(int ProjectID);
        Issue GetIssueByID(int ID);

    }
}
