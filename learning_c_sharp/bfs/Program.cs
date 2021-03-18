using System;
using System.Collections.Generic;

namespace bfs
{
    class Program
    {
        static void AddToGraph(ref Dictionary<string, HashSet<string>> graph, string node1, string node2){
            if(graph.ContainsKey(node1)){
                graph[node1].Add(node2);
            }else{
                HashSet<string> temp_nodes = new HashSet<string>(){node2};
                graph[node1] = temp_nodes;
            }

            if(graph.ContainsKey(node2)){
                graph[node2].Add(node1);
            }else{
                HashSet<string> temp_nodes = new HashSet<string>(){node1};
                graph[node2] = temp_nodes;
            }
        }

        static void bfs(Dictionary<string, HashSet<string>> graph, string root){
            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(root);
            visited.Add(root);

            while(queue.Count > 0){
                string current_root = queue.Dequeue();
                Console.Write(current_root + " ");

                if(graph.ContainsKey(current_root)){
                    foreach(var neighbour in graph[current_root]){
                        if(!visited.Contains(neighbour)){
                            visited.Add(neighbour);
                            queue.Enqueue(neighbour);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var graph = new Dictionary<string, HashSet<string>>();

            AddToGraph(ref graph, "a", "b");
            AddToGraph(ref graph, "a", "c");
            AddToGraph(ref graph, "b", "d");
            AddToGraph(ref graph, "b", "e");
            AddToGraph(ref graph, "d", "h");
            AddToGraph(ref graph, "d", "i");
            AddToGraph(ref graph, "e", "1");
            AddToGraph(ref graph, "e", "2");
            AddToGraph(ref graph, "c", "f");
            AddToGraph(ref graph, "c", "g");

            bfs(graph, "a");

        }
    }
}
