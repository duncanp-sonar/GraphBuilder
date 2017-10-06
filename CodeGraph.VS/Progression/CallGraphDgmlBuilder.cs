﻿using CodeGraph.Interfaces;
using Microsoft.VisualStudio.Diagrams.View;
using Microsoft.VisualStudio.GraphModel;

namespace CodeGraph.VS.Progression
{
    internal class CallGraphDgmlBuilder
    {
        public static Graph Create(ICallGraph callGraph)
        {
            CallGraphDgmlBuilder builder = new CallGraphDgmlBuilder();
            Graph g = builder.CreateDiagram(callGraph);
            return g;
        }
        
        private CallGraphDgmlBuilder()
        {
            // private constructor
        }

        protected Graph CreateDiagram(ICallGraph model)
        {
            //if (model == null)
            //{
            //    return null;
            //}

            Graph graph = this.CreateGraph();
            return graph;
        }

        private Graph CreateGraph()
        {
            Graph g = DeadCodeSchema.CreateGraph();

            // Apply graph schema
            using (UndoableGraphTransactionScope transactionScope = new UndoableGraphTransactionScope("LayoutGraphLeftToRight"))
            {
                foreach (GraphGroup gg in g.Groups)
                {
                    gg.SetLayoutSettings(GroupLayoutStyle.LeftToRight);
                }
                transactionScope.Complete();
            }

            return g;
        }
    }
}