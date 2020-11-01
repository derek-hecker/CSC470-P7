using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    class FakeIssueStatusRepository : IIssueStatusRepository
    {
        private static List<IssueStatus> issueStatuses = new List<IssueStatus>();
        public void Add(int ID, string val)
        {
            IssueStatus issueStatus = new IssueStatus();
            issueStatus.Id = ID;
            issueStatus.value = val;
            issueStatuses.Add(issueStatus);
        }
        public FakeIssueStatusRepository()
        {
            Add(0, "Open");
            Add(1, "Assigned");
            Add(2, "Fixed");
            Add(3, "Closed - Won't Fix");
            Add(4, "Closed - Fixed");
            Add(5, "Closed - by Design");
        }
        public List<IssueStatus> GetAll()
        {
            return issueStatuses;
        }

        public int GetIdByStatus(string val)
        {
            foreach (IssueStatus i in issueStatuses)
            {
                if (i.value == val)
                {
                    return i.Id;
                }
            }
            return -1;
        }

        public string GetValueById(int ID)
        {
            foreach (IssueStatus i in issueStatuses)
            {
                if (i.Id == ID)
                {
                    return i.value;
                }
            }
            return "Doesn't Exist";
        }
    }
}
