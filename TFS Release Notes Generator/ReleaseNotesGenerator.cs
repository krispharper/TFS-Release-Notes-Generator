using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TfsReleaseNotesGenerator
{
    sealed class ReleaseNotesGenerator
    {
        internal TfsTeamProjectCollection Collection
        {
            get;
            set;
        }

        internal Project Project
        {
            get;
            set;
        }

        internal String IterationPath
        {
            get;
            set;
        }

        internal string GenerateReleaseNotes()
        {
            string result = "";
            WorkItemCollection workItems = this.GetWorkItemsForRelease();

            if (workItems.Count < 1)
                return "<p>Nothing found<p>";
            
            //foreach(WorkItem item in workItems)
            //{
                
            //}

            //WorkItem test = workItems.Cast<WorkItem>().First();
            //string test2 = test.Fields.Cast<Field>().Where(field => field.Name == "Release Notes").First().Value as string;

            var bugs = workItems.Cast<WorkItem>().Where(wi => wi.Type.Name == "Bug");
            var features = workItems.Cast<WorkItem>().Where(wi => wi.Type.Name == "Task");
            result += String.Join("", bugs.Select(wi => FormatWorkItemNotes(wi)));
            result += String.Join("", features.Select(wi => FormatWorkItemNotes(wi)));
            //result += String.Join("</p><p>", workItems.Cast<WorkItem>()
            //                                          .Select(wi => wi.Fields
            //                                                          .Cast<Field>()
            //                                                          .First(field => field.Name == "Release Notes")
            //                                                          .Value)
            //                                          .ToList());
            //result += "</p>";

            return result;
        }

        internal List<TfsTeamProjectCollection> GetCollections()
        {
            return RegisteredTfsConnections.GetProjectCollections()
                                           .Select(collection => TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collection))
                                           .ToList();
        }

        internal List<Project> GetProjects(TfsTeamProjectCollection collection)
        {
            return collection.GetService<WorkItemStore>().Projects.Cast<Project>().ToList();
        }

        internal List<String> GetProjectIterationPaths(Project project)
        {
            var projectIterations = new List<string>();

            foreach (Node node in project.IterationRootNodes)
            {
                GetLeafPaths(node, projectIterations);
            }

            return projectIterations;
        }

        private static void GetLeafPaths(Node node, List<string> paths)
        {
            if (node.HasChildNodes)
            {
                foreach (Node child in node)
                {
                    GetLeafPaths(child, paths);
                }
            }
            else
            {
                paths.Add(node.Path);
            }
        }

        private WorkItemCollection GetWorkItemsForRelease()
        {
            return this.Collection.GetService<WorkItemStore>().Query(String.Format(
            @"
            SELECT
                [Id],
                [Work Item Type],
                [Title],
                [Release Notes]
            FROM
                WorkItems
            WHERE
                [Iteration Path] = '{0}'
                AND [Include in Release Notes] = 'Yes'
            ", this.IterationPath));
        }

        private string FormatWorkItemNotes(WorkItem workItem)
        {
            string result = String.Format("<h1>{0}: {1}</h1><p>", workItem.Id, workItem.Title);
            Field notesField = workItem.Fields.Cast<Field>().FirstOrDefault(field => field.Name == "Release Notes");

            if (notesField != null)
            {
                result += notesField.Value;
            }

            result += "</p>";
            return result;
        }

        //private string FormatCollectionNotes(IEnumerable<WorkItem> workItems)
        //{
        //    result += 
        //}

    }
}
