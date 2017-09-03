﻿using microwf.Definition;
using System.Text;

namespace microwf.Utils
{
  public static class WorkflowDefinitionExtension
  {
    /// <summary>
    /// Exports the workflow definition to a dot diagraph.
    /// See: http://www.webgraphviz.com/
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public static string ToDot(this IWorkflowDefinition workflow, string rankDir = "LR")
    {
      var sb = new StringBuilder();

      sb.AppendLine($"digraph {workflow.WorkflowType} {{");
      sb.AppendLine($"  rankdir = {rankDir};");
      foreach(var t in workflow.Transitions)
      {
        sb.AppendLine($"  {t.State} -> {t.TargetState} [ label = {t.Trigger} ];");
      }
      sb.AppendLine("}");

      return sb.ToString();
    }
  }
}
