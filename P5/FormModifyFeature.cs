﻿using System;
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
    public partial class FormModifyFeature : Form
    {
        int _SelectedProjectId;
        int feature;
        FakeFeatureRepository FakeFeature;
        Feature f;
        Feature tmp;
        public FormModifyFeature(int project, int feat)
        {
            InitializeComponent();
            this.CenterToScreen();
            _SelectedProjectId = project;
            feature = feat;
            FakeFeature = new FakeFeatureRepository(_SelectedProjectId);
            f = FakeFeature.GetFeatureByID(feature);
            textBoxTitle.Text = f.Title;
            tmp = new Feature();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            
            tmp.Title = textBoxTitle.Text.Trim();
            tmp.Id = f.Id;
            tmp.ProjectId = f.ProjectId;
            string result = FakeFeature.Modify(tmp);
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


        private void FormModifyFeature_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
