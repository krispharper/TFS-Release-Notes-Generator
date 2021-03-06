﻿using System;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TfsReleaseNotesGenerator.Properties;

namespace TfsReleaseNotesGenerator
{
    public partial class MainWindow : Form
    {
        ReleaseNotesGenerator Generator
        {
            get;
            set;
        }

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                this.Generator = new ReleaseNotesGenerator();
                this.comboBoxProject.DisplayMember = "Name";
                this.comboBoxCollection.DataSource = this.Generator.GetCollections();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var collection = this.comboBoxCollection.SelectedItem as TfsTeamProjectCollection;

                if (collection != null)
                {
                    this.Generator.Collection = collection;
                    this.comboBoxProject.DataSource = this.Generator.GetProjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var project = this.comboBoxProject.SelectedItem as Project;

                if (project != null)
                {
                    this.Generator.Project = project;
                    this.comboBoxIteration.DataSource = this.Generator.GetProjectIterationPaths();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                this.htmlPanelContent.Text = this.Generator.GenerateReleaseNotes();
                this.htmlPanelContent.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxIteration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Generator.IterationPath = this.comboBoxIteration.SelectedItem as string;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowLocation != null)
                this.Location = Settings.Default.WindowLocation;

            if (Settings.Default.WindowSize != null)
                this.Size = Settings.Default.WindowSize;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.WindowLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
                Settings.Default.WindowSize = this.Size;
            else
                Settings.Default.WindowSize = this.RestoreBounds.Size;

            Settings.Default.Save();
        }
    }
}
