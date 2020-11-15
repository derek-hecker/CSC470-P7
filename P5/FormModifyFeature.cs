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
    public partial class FormModifyFeature : Form
    {
        int _SelectedProjectId;
        int feature;
        FakeFeatureRepository FakeFeatureRepository = new FakeFeatureRepository();
        Feature f;
        public FormModifyFeature(int project, int feat)
        {
            InitializeComponent();
            this.CenterToScreen();
            _SelectedProjectId = project;
            feature = feat;
            f = FakeFeatureRepository.GetFeatureByID(feature);
            textBoxTitle.Text = f.Title;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Feature tmp = new Feature();
            tmp.Title = textBoxTitle.Text.Trim();
            tmp.Id = f.Id;
            tmp.ProjectId = f.ProjectId;
            MessageBox.Show(textBoxTitle.Text.Trim());
            string result = FakeFeatureRepository.Modify(tmp);
            if (result != FakeFeatureRepository.NO_ERROR)
            {
                MessageBox.Show("Error modifying feature. Error: " + result);
            }
            else
            {
                MessageBox.Show("Feature modification successful.", "Information");
                this.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormModifyFeature_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.CenterToScreen();

        }
    }
}
