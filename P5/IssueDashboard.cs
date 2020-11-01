using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5
{
    public partial class IssueDashboard : Form
    {
        AppUser _currentAppUser;
        int _SelectedProjectId;
        FakeIssueRepository IssueRepository;
        public IssueDashboard(AppUser _CurrentAppUser, int selected_id)
        {
            _currentAppUser = _CurrentAppUser;
            _SelectedProjectId = selected_id;
            IssueRepository = new FakeIssueRepository(selected_id);
            InitializeComponent();
        }

        private void IssueDashboard_Load(object sender, EventArgs e)
        {
            List<string> text = IssueRepository.GetIssuesByDiscoverer(_SelectedProjectId);
            foreach (string s in text)
            {
                listbxDiscoverer.Items.Add(s);
            }
            List<string> months = IssueRepository.GetIssuesByMonth(_SelectedProjectId);
            foreach (string m in months)
            {
                listbxMonth.Items.Add(m);
            }

        }
    }
}
