using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

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
            InitializeComponent();

            this.Generator = new ReleaseNotesGenerator();
            this.comboBoxProject.DisplayMember = "Name";
            this.comboBoxCollection.DataSource = this.Generator.GetCollections();
            browserContent.Navigate("about:blank");
            this.SetUpStyles();

            //this.Generator.Test();

            //this.browserContent.DocumentText = "<p>test</p><br/><p>test2</p>";

        }

        private void SetUpStyles()
        {
            //HtmlElement html = this.browserContent.Document.GetElementsByTagName("html")[0];
            //HtmlElement head = this.browserContent.Document.CreateElement("head");
            //HtmlElement style = this.browserContent.Document.CreateElement("style");
            //style.InnerText = "p { margin-left: 40px; }";
            //head.AppendChild(style);
            //html.AppendChild(head);

            mshtml.IHTMLDocument2 document = browserContent.Document.DomDocument as mshtml.IHTMLDocument2;
            //mshtml.IHTMLStyleSheet style = document.createStyleSheet("style.css", 0);
            mshtml.HTMLStyleSheet style = new mshtml.HTMLStyleSheet();
            style.addRule("h2", "font-family:Arial,San-Serif;");
            style.addRule("p", "font-family:Arial,San-Serif;");
            style.addRule("p", "margin-left:40px;");
            style.ToString();

        }

        private void comboBoxCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var collection = this.comboBoxCollection.SelectedItem as TfsTeamProjectCollection;

            if (collection != null)
            {
                this.comboBoxProject.DataSource = this.Generator.GetProjects(collection);
                this.Generator.Collection = collection;
            }
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var project = this.comboBoxProject.SelectedItem as Project;

            if (project != null)
            {
                this.comboBoxIteration.DataSource = this.Generator.GetProjectIterationPaths(project);
                this.Generator.Project = project;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string notes = this.Generator.GenerateReleaseNotes();
            this.browserContent.Document.Body.InnerHtml = notes;
        }

        private void comboBoxIteration_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Generator.IterationPath = this.comboBoxIteration.SelectedItem as string;
        }
    }
}
