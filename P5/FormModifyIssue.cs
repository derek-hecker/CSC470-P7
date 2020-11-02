using P5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builder
{
    public partial class FormModifyIssue : Form
    {
        FakeIssueStatusRepository fakeIssueStatus = new FakeIssueStatusRepository();
        FakeIssueRepository fake;
        int selected;
        int project;
        public FormModifyIssue(int selected_issue, int selected_project)
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Now;
            selected = selected_issue;
            project = selected_project;
            fake = new FakeIssueRepository(project);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FormModifyIssue_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            List<IssueStatus> issueStatuses = fakeIssueStatus.GetAll();
            foreach (IssueStatus i in issueStatuses)
            {
                comboBoxStatus.Items.Add(i.value);
            }
            comboBoxStatus.SelectedIndex = 0;
            FakeAppUserRepository fakeAppUserRepository = new FakeAppUserRepository();
            List<AppUser> appUsers = fakeAppUserRepository.GetAll();
            foreach (AppUser user in appUsers)
            {
                comboBoxDiscoverer.Items.Add(user.UserName);
            }
            Issue issue = fake.GetIssueByID(selected);
            textBox1.Text = issue.Id.ToString();
            textBox2.Text = issue.Title;
            dateTimePicker1.Value = issue.DiscoveryDate;
            comboBoxDiscoverer.SelectedItem = issue.Discoverer;
            comboBoxStatus.SelectedIndex = issue.IssueStatusId;
            textBox3.Text = issue.Component;
            richTextBoxDescription.Text = issue.InitialDesscription;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Issue tmp = new Issue();
            tmp.Id = Convert.ToInt32(textBox1.Text);
            tmp.Title = textBox2.Text.Trim();
            tmp.DiscoveryDate = dateTimePicker1.Value;
            tmp.Discoverer = comboBoxDiscoverer.SelectedItem.ToString();
            tmp.IssueStatusId = fakeIssueStatus.GetIdByStatus(comboBoxStatus.SelectedItem.ToString());
            tmp.InitialDesscription = richTextBoxDescription.Text.Trim();
            tmp.Component = textBox3.Text.Trim();
            string result = fake.Modify(tmp);
            if (result != FakeIssueRepository.NO_ERROR)
            {
                MessageBox.Show("Error modifying project. Error: " + result);
            }
            else
            {
                MessageBox.Show("Issue modification successful.", "Information");
                this.Close();
            } 
        }
    }
}
