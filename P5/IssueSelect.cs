using Castle.Components.DictionaryAdapter;
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
            dataGridViewIssues.Columns[5].Name = "Componenent";
            dataGridViewIssues.Columns[6].Name = "Status";
            dataGridViewIssues.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            List<Issue> tmp_list = _IssueRepo.GetAll(p_id);
            foreach (Issue i in tmp_list)
            {
                dataGridViewIssues.Rows.Add(i.Id.ToString(), i.Title, i.DiscoveryDate, i.Discoverer, i.InitialDesscription, i.Component, fake.GetValueById(i.IssueStatusId));

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
                MessageBox.Show(dataGridViewIssues.SelectedRows.Count.ToString());
                int index = 2;
                DataGridViewRow dgvr = dataGridViewIssues.Rows[index];
                selectedIssueID = Convert.ToInt32(dgvr.Cells["ID"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
