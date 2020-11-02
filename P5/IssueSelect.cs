using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P5;

namespace Builder
{
    public partial class IssueSelect : Form
    {
        public IssueSelect()
        {
            InitializeComponent();
        }
        FakeIssueRepository _IssueRepo;
        FakeIssueStatusRepository fake = new FakeIssueStatusRepository();
        public int selectedIssueID;
        DataGridViewRow _selectedRow = new DataGridViewRow();
        int p_id;
        public IssueSelect(AppUser _CurrentAppUser, int selected_id)
        {
            InitializeComponent();
            this.CenterToParent();
            btnSelect.Enabled = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IssueSelect_Load(object sender, EventArgs e)
        {

            
        }

        private void dataGridViewIssues_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridViewIssues.SelectedRows.Count >= 0)
            {
                
                _selectedRow = dataGridViewIssues.SelectedRows[0];
                btnSelect.Enabled = true;
                if (dataGridViewIssues.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Only the first row will be selected.", "Attention");
                }
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectedIssueID = Convert.ToInt32(_selectedRow.Cells["ID"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
