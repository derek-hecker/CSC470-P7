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
    public partial class FormSelectRequirement : Form
    {
        int selected_project;
        public int selectedRequirementID;
        FakeFeatureRepository fake;
        FakeRequiremnetRepository fakeRequiremnet;
        DataGridViewRow _selectedRow = new DataGridViewRow();
        public FormSelectRequirement(int project)
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Requirement";
            selected_project = project;
            fake = new FakeFeatureRepository(selected_project);
            fakeRequiremnet = new FakeRequiremnetRepository(selected_project);
        }

        private void FormSelectRequirement_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            this.CenterToParent();
            List<Feature> features = fake.GetAll(selected_project);
            comboBox1.SelectedIndex = 0;
            foreach (Feature f in features)
            {
                comboBox1.Items.Add(f.Title);
            }
            if (comboBox1.Items.Count < 1)
            {
                comboBox1.Enabled = false;
            }
            btnSelect.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                dataGridView1.Enabled = true;
                btnSelect.Enabled = true;
                Feature selected_feature = fake.GetFeatureByTitle(comboBox1.SelectedItem.ToString());
                List<Requirement> list = fakeRequiremnet.GetAll(selected_project);
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                foreach (Requirement r in list)
                {
                    if (r.FeatureId == selected_feature.Id)
                    {
                        int rowid = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowid];
                        row.Cells["ID"].Value = r.Id.ToString();
                        row.Cells["Requirement"].Value = r.Statement;
                    }

                }
                
            }
            else
            {
                dataGridView1.Enabled = false;
                btnSelect.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 0)
            {

                _selectedRow = dataGridView1.SelectedRows[0];
                btnSelect.Enabled = true;
                if (dataGridView1.SelectedRows.Count > 1)
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
            selectedRequirementID = Convert.ToInt32(_selectedRow.Cells["ID"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
