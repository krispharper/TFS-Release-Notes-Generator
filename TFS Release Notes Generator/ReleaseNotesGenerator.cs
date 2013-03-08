using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.Client;
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
            string result = @"
                <html>
                    <head>
                        <style>
                            p,h3 { font-family:Verdana,San-Serif; }
                            p { margin-left: 40px; }
                        </style>
                    </head>
                    <body>";

            WorkItemCollection workItems = this.GetWorkItemsForRelease();

            if (workItems.Count < 1)
                return result += "<p>Nothing found<p></body></html>";
            
            var bugs = workItems.Cast<WorkItem>().Where(wi => wi.Type.Name == "Bug");
            var features = workItems.Cast<WorkItem>().Where(wi => wi.Type.Name == "Task");
            result += String.Join("", bugs.Select(wi => FormatWorkItemNotes(wi)));
            result += String.Join("", features.Select(wi => FormatWorkItemNotes(wi)));

            return result += "</body></html>";
        }

        internal List<TfsTeamProjectCollection> GetCollections()
        {
            return RegisteredTfsConnections.GetProjectCollections()
                                           .Select(collection => TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collection))
                                           .ToList();
        }

        internal List<Project> GetProjects()
        {
            return this.Collection.GetService<WorkItemStore>().Projects.Cast<Project>().ToList();
        }

        internal List<String> GetProjectIterationPaths()
        {
            var projectIterations = new List<string>();

            foreach (Node node in this.Project.IterationRootNodes)
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
            string result = String.Format("<h3>{0}: {1}</h3><p>", workItem.Id, workItem.Title);
            Field notesField = workItem.Fields.Cast<Field>().FirstOrDefault(field => field.Name == "Release Notes");

            if (notesField != null)
            {
                result += notesField.Value;
            }

            result += "</p>";
            return result;
        }
    }
}
