using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P5
{
    public partial class RecordIssue : Form
    {
        int _SelectedProjectID;
        AppUser curUser;
        FakeIssueRepository issueRepository;
        FakeIssueStatusRepository fakeIssueStatusRepository;
        public RecordIssue(AppUser _CurrentAppUser, int selected, FakeIssueRepository issueRepo)
        {
            curUser = _CurrentAppUser;
            _SelectedProjectID = selected;
            issueRepository = issueRepo;
            fakeIssueStatusRepository = new FakeIssueStatusRepository();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating Issue
            Issue issue = new Issue();
            issue.Title = textBox2.Text.Trim();
            issue.InitialDesscription = richTextBoxDescription.Text.Trim();
            issue.Discoverer = comboBoxDiscoverer.SelectedItem.ToString();
            issue.Component = textBox3.Text.Trim();
            issue.DiscoveryDate = dateTimePicker1.Value;
            string result = issueRepository.Add(issue, out _SelectedProjectID);
            if (result == FakeIssueRepository.NO_ERROR)
            {
                MessageBox.Show("Issue Added Successfully");
            }
            else
            {
                MessageBox.Show("Issue not created, " + result, "Attention.");
            }
            this.Close();
        }

        private void RecordIssue_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            textBox1.Text = issueRepository.GetNextID().ToString();
            List<IssueStatus> issueStatuses = fakeIssueStatusRepository.GetAll();
            foreach(IssueStatus issue in issueStatuses)
            {
                comboBoxStatus.Items.Add(issue.value);
            }
            comboBoxStatus.SelectedIndex = 0;
            FakeAppUserRepository fakeAppUserRepository = new FakeAppUserRepository();
            List<AppUser> appUsers = fakeAppUserRepository.GetAll();
            foreach (AppUser user in appUsers)
            {
                comboBoxDiscoverer.Items.Add(user.UserName);
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
