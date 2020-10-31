using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class FakeIssueRepository : IIssueRepository
    {
        public const string NO_ERROR = "";
        public const string EMPTY_TITLE_ERROR = "A Title is required";
        public const string EMPTY_DISCOVERY_DATE = "Must select a Discovery Date/Time";
        public const string FUTURE_DISCOVERY_DATE = "Issues can't be fromthe future";
        public const string EMPTY_DISCOVERER_ERROR = "A discoverer is required";

        public string Add(Issue issue)
        {
            throw new NotImplementedException();
        }

        public List<Issue> GetAll(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public Issue GetIssueByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<string> GetIssuesByDiscoverer(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public List<string> GetIssuesByMonth(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberOfIssues(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public string Modify(Issue issue)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Issue issue)
        {
            throw new NotImplementedException();
        }
    }
}
