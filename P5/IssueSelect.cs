using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace P5
{
    public partial class IssueSelect : Form
    {
        FakeIssueRepository _IssueRepo;
        FakeIssueStatusRepository fake = new FakeIssueStatusRepository();
        public int selectedIssueID;
        int p_id;
        public IssueSelect(AppUser _CurrentAppUser, int selected_id)
        {
            InitializeComponent();
            this.CenterToParent();
            p_id = selected_id;
            _IssueRepo = new FakeIssueRepository(selected_id);
            dataGridViewIssues.ColumnCount = 7;
            dataGridViewIssues.Columns[0].Name = "ID";
            dataGridViewIssues.Columns[1].Name = "Title";
            dataGridViewIssues.Columns[2].Name = "DiscoveryDate";
            dataGridViewIssues.Columns[3].Name = "Discoverer";
            dataGridViewIssues.Columns[4].Name = "InitialDescription";
            dataGridViewIssues.Columns[5].Name = "Component";
            dataGridViewIssues.Columns[6].Name = "Status";
            dataGridViewIssues.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            List<Issue> tmp_list = _IssueRepo.GetAll(p_id);
            foreach (Issue i in tmp_list)
            {
                int rowid = dataGridViewIssues.Rows.Add();
                DataGridViewRow row = dataGridViewIssues.Rows[rowid];
                row.Cells["ID"].Value = i.Id.ToString();
                row.Cells["Title"].Value = i.Title;
                row.Cells["DiscoveryDate"].Value = i.DiscoveryDate;
                row.Cells["Discoverer"].Value = i.Discoverer;
                row.Cells["InitialDescription"].Value = i.InitialDesscription;
                row.Cells["Component"].Value = i.Component;
                row.Cells["Status"].Value = fake.GetValueById(i.IssueStatusId);

            }
        }

        private void IssueSelect_Load(object sender, EventArgs e)
        {
            InitializeComponent();

        }

        private void dataGridViewIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewIssues.SelectedRows.Count < 0)
            {
                MessageBox.Show("An issue must be selected.", "Attention");
            }else
            {
                MessageBox.Show(dataGridViewIssues.Rows[0].Cells[0].Value.ToString());
                int index = 2;
                DataGridViewRow dgvr = dataGridViewIssues.Rows[index];
                selectedIssueID = Convert.ToInt32(dgvr.Cells["ID"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
