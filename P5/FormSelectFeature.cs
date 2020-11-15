using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Builder
{
    public partial class FormSelectFeature : Form
    {
        public int selected_id;
        FakeFeatureRepository fakeFeatureRepository;
        public int selectedFeatureID;
        DataGridViewRow _selectedRow = new DataGridViewRow();
        public FormSelectFeature(int project_id)
        {
            InitializeComponent();
            this.CenterToParent();
            btnSelect.Enabled = false;
            selected_id = project_id;
            fakeFeatureRepository = new FakeFeatureRepository(selected_id);
            dataGridViewFeatures.ColumnCount = 2;
            dataGridViewFeatures.Columns[0].Name = "ID";
            dataGridViewFeatures.Columns[1].Name = "Title";
            List<Feature> tmp = fakeFeatureRepository.GetAll(selected_id);
            foreach (Feature f in tmp)
            {
                int rowid = dataGridViewFeatures.Rows.Add();
                DataGridViewRow row = dataGridViewFeatures.Rows[rowid];
                row.Cells["ID"].Value = f.Id.ToString();
                row.Cells["Title"].Value = f.Title;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedFeatureID = Convert.ToInt32(_selectedRow.Cells["ID"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridViewFeatures_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFeatures.SelectedRows.Count >= 0)
            {

                _selectedRow = dataGridViewFeatures.SelectedRows[0];
                btnSelect.Enabled = true;
                if (dataGridViewFeatures.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Only the first row will be selected.", "Attention");
                }
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void FormSelectFeature_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
