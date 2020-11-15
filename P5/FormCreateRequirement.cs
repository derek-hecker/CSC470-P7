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
    public partial class FormCreateRequirement : Form
    {
        int selected_project;
        FakeFeatureRepository fake;
        FakeRequiremnetRepository fakeRequiremnet;
        public FormCreateRequirement(int project)
        {
            selected_project = project;
            fake = new FakeFeatureRepository(selected_project);
            fakeRequiremnet = new FakeRequiremnetRepository(selected_project);
            InitializeComponent();
        }

        private void FormCreateRequirement_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            List<Feature> features = fake.GetAll(selected_project);
            foreach (Feature f in features)
            {
                comboBox1.Items.Add(f.Title);
            }
            if (comboBox1.Items.Count < 1)
            {
                comboBox1.Enabled = false;
            }
            richTextBox1.Enabled = false;
            btnCreate.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                richTextBox1.Enabled = true;
                btnCreate.Enabled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
