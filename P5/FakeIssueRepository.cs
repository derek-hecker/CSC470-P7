using Castle.DynamicProxy.Contributors;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5
{
    public class FakeIssueRepository : IIssueRepository
    {
        public const string NO_ERROR = "";
        public const string EMPTY_TITLE_ERROR = "A Title is required";
        public const string EMPTY_DISCOVERY_DATE = "Must select a Discovery Date/Time";
        public const string FUTURE_DISCOVERY_DATE = "Issues can't be from the future";
        public const string EMPTY_DISCOVERER_ERROR = "A discoverer is required";
        public const string DUPLICATE_TITLE_ERROR = "Issue Title must be unique. ";
        public int _SelectedProjectID;

        public FakeIssueRepository(int selected_project_id)
        {
            _SelectedProjectID = selected_project_id;
        }
        private static List<Issue> _Issues = new List<Issue>();
        public string Add(Issue issue, out int Id)
        {
            Id = 0;
            string newIssueTitle = issue.Title.Trim();
            string newIssueDiscoverer = issue.Discoverer.Trim();
            if (IsDuplicateTitle(newIssueTitle))
            {
                return DUPLICATE_TITLE_ERROR;
            }
            if (newIssueTitle == "")
            {
                return EMPTY_TITLE_ERROR;
            }
            if (newIssueDiscoverer == "")
            {
                return EMPTY_DISCOVERER_ERROR;
            }
            issue.Id = GetNextID();
            issue.ProjectId = _SelectedProjectID ;
            _Issues.Add(issue);
            Id = issue.Id;
            return NO_ERROR;
            
        }

        public List<Issue> GetAll(int ProjectID)
        {

            List<Issue> tmp_list = new List<Issue>();
            
            foreach (Issue i in _Issues)
            {
               if (i.ProjectId == _SelectedProjectID)
                {
                    tmp_list.Add(i);
                }
            }
            return tmp_list;
        }

        public Issue GetIssueByID(int ID)
        {
            Issue issue = new Issue();
            foreach (Issue i in _Issues)
            {
                if (i.Id == ID)
                {
                    issue = i;
                }
            }
            return issue;
        }

        public List<string> GetIssuesByDiscoverer(int ProjectID)
        {
            List<string> name_list = new List<string>();
            List<string> final_list = new List<string>();
            List<Issue> issues = new List<Issue>();
            foreach (Issue i in _Issues)
            {
                if (i.ProjectId == ProjectID)
                {
                    issues.Add(i);
                    if (!name_list.Contains(i.Discoverer))
                    {
                        name_list.Add(i.Discoverer);
                    }
                    
                }
            }
            foreach (string p in name_list)
            {
                int issue_count = 0;
                foreach (Issue i in issues)
                {
                    if (i.Discoverer == p)
                    {
                        issue_count++;
                    }
                }
                string tmp = p + " : " + issue_count.ToString();
                final_list.Add(tmp);
            }
            return final_list;
        }

        public List<string> GetIssuesByMonth(int ProjectID)
        {
            List<string> month_list = new List<string>();
            List<string> final_list = new List<string>();
            List<Issue> issues = new List<Issue>();
            foreach (Issue i in _Issues)
            {
                if (i.ProjectId == ProjectID)
                {
                    issues.Add(i);
                    string tmp = i.DiscoveryDate.Year.ToString() + " " + i.DiscoveryDate.Month.ToString();
                    if (!month_list.Contains(tmp))
                    {
                        month_list.Add(tmp);
                    }

                }
            }
            foreach (string p in month_list)
            {
                int issue_count = 0;
                foreach (Issue i in issues)
                {
                    string tmp2 = i.DiscoveryDate.Year.ToString() + " " + i.DiscoveryDate.Month.ToString();
                    if (tmp2 == p)
                    {
                        issue_count++;
                    }
                }
                string tmp = p + " : " + issue_count.ToString();
                final_list.Add(tmp);
            }
            return final_list;
        }

        public int GetTotalNumberOfIssues(int ProjectID)
        {
            int count = 0;
            foreach (Issue i in _Issues)
            {
                if (i.ProjectId == ProjectID)
                {
                    count++;
                }
            }
            return count;
        }

        public string Modify(Issue issue)
        {
            Issue issue1 = new Issue();
            issue1 = GetIssueByID(issue.Id);
            if (IsDuplicateTitle(issue.Title) && issue.Title != issue1.Title)
            {
                return DUPLICATE_TITLE_ERROR;
            }
            if (issue.Title == "")
            {
                return EMPTY_TITLE_ERROR;
            }
            if (issue.Discoverer == "")
            {
                return EMPTY_DISCOVERER_ERROR;
            }
            int index = 0;
            foreach (Issue i in _Issues)
            {
                if (issue.Id == i.Id) 
                {
                    _Issues[index].Title = issue.Title;
                    _Issues[index].InitialDesscription = issue.InitialDesscription;
                    _Issues[index].DiscoveryDate = issue.DiscoveryDate;
                    _Issues[index].Discoverer = issue.Discoverer;
                    _Issues[index].Component = issue.Component;
                    _Issues[index].IssueStatusId = issue.IssueStatusId;
                    MessageBox.Show("Issue should be replaced");
                    return NO_ERROR;
                }
                index++;
            }
            
            return NO_ERROR;
        }

        public bool Remove(Issue issue)
        {
            int index = 0;
            foreach (Issue i in _Issues)
            {
                if (i.Id == issue.Id)
                {
                    _Issues.RemoveAt(index);
                    return true;
                }
                index++;
            }
            return false;
        }

        public bool IsDuplicateTitle(string issueTitle)
        {
            bool isDuplicate = false;
            foreach (Issue i in _Issues)
            {
                if (issueTitle == i.Title)
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }
        public int GetNextID()
        {
            int currentMaxID = 0;
            foreach (Issue i in _Issues)
            {
                currentMaxID = i.Id;
            }
            return ++currentMaxID;
        }
    }
}
