using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Graphen
{
    public partial class Form1 : Form
    {
        private Graph graph;
        private Functions functions;
        private Stopwatch sw;

        private string pathToLastGraph;
        public Form1()
        {
            InitializeComponent();
            graph = new Graph();
            functions = new Functions(graph);
            sw = new Stopwatch();
        }

        private void loadGraph_Click(object sender, EventArgs e)
        {
            textBoxPrim.Clear();
            textBoxKruskal.Clear();
            if (graph != null)
            {
                graph.ClearGraph();
                this.graph = new Graph();
            }

            OpenFileDialog openFileDialogGetGraph = new OpenFileDialog();

            openFileDialogGetGraph.InitialDirectory = @"C:\Users\atix\Dropbox\Studium\Master\1. Semester\Mathematische Methoden der Informatik\Praktikum\Praktikum 9";
            openFileDialogGetGraph.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogGetGraph.FilterIndex = 2;
            openFileDialogGetGraph.RestoreDirectory = true;

            if (openFileDialogGetGraph.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(openFileDialogGetGraph.FileName))
                    {
                        pathToLastGraph = openFileDialogGetGraph.FileName;
                        if (radioButtonGerichtet.Checked)
                        {
                            graph.SetFileGraph(File.ReadAllLines(pathToLastGraph), true);
                        }
                        else if (radioButtonUngerichtet.Checked)
                        {
                            graph.SetFileGraph(File.ReadAllLines(pathToLastGraph), false);
                        }
                        else
                        {
                            graph.SetFileGraph(File.ReadAllLines(pathToLastGraph));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            textBoxPrim.Clear();
            textBoxKruskal.Clear();
            graph.ClearGraph();
            this.graph = new Graph();
        }

        private void breitensucheBtn_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                sw.Restart();
                var zusammenhangskomponenten = functions.BreitensucheIterativ(graph, (int)numericUpDownStartknoten.Value);
                MessageBox.Show("Breitensuche(iterativ)\nZusammenhangskomponenten: " + zusammenhangskomponenten.Item1.ToString());
                //+"\nElapsed Time: "+sw.Elapsed.ToString());

                sw.Stop();
                graph.ResetUsedVertices();
            }
            else
            {
                MessageBox.Show("Bei der Breitensuche ist etwas schief gegangen.");
            }
        }

        private void tiefensucheBtn_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.StartTiefensucheRekursiv(graph, (int)numericUpDownStartknoten.Value);
                MessageBox.Show("Tiefensuche(rekursiv)\nZusammenhangskomponenten: " + erg.Item1.ToString());
                //+"\nElapsed Time: " + sw.Elapsed.ToString());

                sw.Stop();
                ResetGraph();
            }
            else
            {
                MessageBox.Show("Bei der Tiefensuche ist etwas schief gegangen.");
            }
        }

        private void ResetGraph()
        {
            graph.ClearGraph();
            if (radioButtonGerichtet.Checked)
            {
                graph.SetFileGraph(File.ReadAllLines(pathToLastGraph), true);
            }
            else if (radioButtonUngerichtet.Checked)
            {
                graph.SetFileGraph(File.ReadAllLines(pathToLastGraph), false);
            }
            else
            {
                graph.SetFileGraph(File.ReadAllLines(pathToLastGraph));
            }
        }

        private void kruskalBtn_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                textBoxKruskal.Clear();
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.Kruskal(graph);
                sw.Stop();
                textBoxKruskal.AppendText(Math.Round(erg.Item1, 4).ToString());
                MessageBox.Show("Kruskal\nElapsed Time: " + sw.Elapsed.ToString());
                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Kruskal Algorithmus ist etwas schief gegangen.");
            }
        }

        private void primBtn_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                textBoxPrim.Clear();
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.Prim(graph, (int)numericUpDownStartknoten.Value);
                sw.Stop();

                textBoxPrim.AppendText(Math.Round(erg.Item1, 4).ToString());
                MessageBox.Show("Prim\nElapsed Time: " + sw.Elapsed.ToString());

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Prim Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnNearestNeighbour_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                nearestNeighbourtextBox.Clear();
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                double erg = functions.NearestNeighbour(graph, (int)numericUpDownStartknoten.Value);
                sw.Stop();

                nearestNeighbourtextBox.AppendText(Math.Round(erg, 4).ToString());
                MessageBox.Show("Nearest Neighbour\nElapsed Time: " + sw.Elapsed.ToString());

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Nearest Neighbour Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnDoppelterBaum_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                textBoxDoppelterBaum.Clear();
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.DoppelterBaum(graph, (int)numericUpDownStartknoten.Value);
                sw.Stop();

                textBoxDoppelterBaum.AppendText(Math.Round(erg.Item1, 4).ToString());
                MessageBox.Show("Doppelter Baum\nElapsed Time: " + sw.Elapsed.ToString());

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Doppelter Baum Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnAllTour_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                textBoxAllTours.Clear();
                numericUpDownStartknoten.Minimum = 0;
                numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.TryAllTours(graph);
                sw.Stop();

                textBoxAllTours.AppendText(Math.Round(erg.Item1, 4).ToString());
                string bestPath = erg.Item2[0].sourceVertex.name.ToString();
                for (int i = 0; i < erg.Item2.Count; i++)
                {
                    bestPath += "->";
                    bestPath += erg.Item2[i].destinationVertex.name.ToString();
                }
                MessageBox.Show("All Tours\nElapsed Time: " + sw.Elapsed.ToString() + "\nBest Path: " + bestPath);

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim All Tours Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnBranchAndBound_Click(object sender, EventArgs e)
        {
            try
            {

                if (graph != null && functions != null)
                {
                    textBoxBranchAndBound.Clear();
                    numericUpDownStartknoten.Minimum = 0;
                    numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                    Stopwatch sw = new Stopwatch();
                    sw.Restart();

                    var erg = functions.BranchAndBound(graph);
                    sw.Stop();

                    textBoxBranchAndBound.AppendText(Math.Round(erg.Item1, 4).ToString());
                    try
                    {
                        string bestPath = erg.Item2[0].sourceVertex.name.ToString();
                        for (int i = 0; i < erg.Item2.Count; i++)
                        {
                            bestPath += "->";
                            bestPath += erg.Item2[i].destinationVertex.name.ToString();
                        }
                        MessageBox.Show("Branch and Bound\nElapsed Time: " + sw.Elapsed.ToString() + "\nBest Path: " + bestPath);

                    }
                    catch
                    {

                    }

                    ResetGraph();
                }
                else
                {
                    MessageBox.Show("Beim Branch and Bound Algorithmus ist etwas schief gegangen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            try
            {
                if (graph != null && functions != null)
                {
                    numericUpDownStartknoten.Minimum = 0;
                    numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                    Stopwatch sw = new Stopwatch();
                    sw.Restart();
                    int count = graph.vertices.Count;
                    List<Vertex> erg = functions.Dijkstra(graph, (int)numericUpDownStartknoten.Value);
                    sw.Stop();
                    string filepath = @"C:\Users\atix\Dropbox\Studium\Master\1. Semester\Mathematische Methoden der Informatik\Praktikum\Praktikum 5\Ergebnis_Dijkstra.txt";
                    //string output = "";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(filepath);
                    List<string> output = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        output.Add("1");
                    }
                    for (int i = 0; i < erg.Count; i++)
                    {
                        output[erg[i].name] = "Knoten " + erg[i].name.ToString() + "\tdistStart(v): " + erg[i].distToStart.ToString();
                        //output[erg[i].destinationVertex.name] = "Knoten " + erg[i].destinationVertex.name.ToString() + "\tdistStart(v): " + erg[i].destinationVertex.distToStart.ToString();
                        //output = "V_" + erg[i].sourceVertex.name + "\t--" + Math.Round(erg[i].destinationVertex.distToStart, 2) + "->" + "\tV_" + erg[i].destinationVertex.name;
                    }
                    foreach (var item in output)
                    {
                        file.WriteLine(item);
                    }
                    file.Close();

                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = filepath
                    };

                    process.Start();
                    process.WaitForExit();

                    ResetGraph();
                }
                else
                {
                    MessageBox.Show("Beim Dijkstra Algorithmus ist etwas schief gegangen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMooreBellmanFord_Click(object sender, EventArgs e)
        {
            try
            {

                if (graph != null && functions != null)
                {
                    numericUpDownStartknoten.Minimum = 0;
                    numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                    Stopwatch sw = new Stopwatch();
                    sw.Restart();

                    var erg = functions.MooreBellmanFord(graph, (int)numericUpDownStartknoten.Value);
                    sw.Stop();
                    string filename = "C:\\Users\\atix\\Dropbox\\Studium\\Master\\1. Semester\\Mathematische Methoden der Informatik\\Praktikum\\Praktikum 5\\Ergebnis_MBF.txt";
                    if (!erg.Item3)
                    {

                        string output = "";
                        StreamWriter file = new StreamWriter(filename);

                        for (int i = 0; i < erg.Item1.Count; i++)
                        {
                            if (erg.Item1[i].distToStart == double.PositiveInfinity)
                            {
                                output = "Knoten " + erg.Item1[i].name + "\tdistStart(v): inf\t\tpred(v): null";
                            }
                            else
                            {
                                output = "Knoten " + erg.Item1[i].name + "\tdistStart(v): " + erg.Item1[i].distToStart + "\t\tpred(v): " + erg.Item1[i].parent.name;

                            }
                            file.WriteLine(output);
                        }

                        file.Close();

                        var process = new Process();
                        process.StartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = filename
                        };

                        process.Start();
                        process.WaitForExit();

                    }

                    ResetGraph();
                }
                else
                {
                    MessageBox.Show("Beim Moore-Bellman-Ford Algorithmus ist etwas schief gegangen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEdmondsKarp_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                numericUpDownSource.Minimum = 0;
                numericUpDownSource.Maximum = graph.GetVerticesList().Count - 1;

                numericUpDownTarget.Minimum = 0;
                numericUpDownTarget.Maximum = graph.GetVerticesList().Count - 1;


                Stopwatch sw = new Stopwatch();
                sw.Restart();

                var erg = functions.EdmondsKarp(graph, (int)numericUpDownSource.Value, (int)numericUpDownTarget.Value);
                sw.Stop();

                MessageBox.Show("Edmonds-Karp\nElapsed Time: " + sw.Elapsed.ToString() + "\nMaximaler Fluss: " + erg.Item1);

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Edmonds-Karp Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnCycleCanceling_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();

                double erg = functions.CycleCanceling(graph);
                sw.Stop();
                if (!double.IsNaN(erg))
                {
                    MessageBox.Show("Cycle-Canceling\nElapsed Time: " + sw.Elapsed.ToString() + "\nKostenminimaler Fluss: " + erg);
                }

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Cycle-Canceling Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnSuccessiveShortestPath_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();

                double erg = functions.SuccessiveShortestPath(graph);
                sw.Stop();
                if (!double.IsNaN(erg))
                {
                    MessageBox.Show("Successive Shortest Path\nElapsed Time: " + sw.Elapsed.ToString() + "\nKostenminimaler Fluss: " + erg);
                }

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Successive Shortest Path Algorithmus ist etwas schief gegangen.");
            }
        }

        private void btnMaximaleMatchings_Click(object sender, EventArgs e)
        {
            if (graph != null && functions != null)
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();

                List<Edge> erg = functions.MaximalMatchings(graph);
                sw.Stop();

                MessageBox.Show("Maximale Matchings\nElapsed Time: " + sw.Elapsed.ToString() + "\nAnzahl Matchingkanten: " + erg.Count);

                string filename = "C:\\Users\\atix\\Dropbox\\Studium\\Master\\1. Semester\\Mathematische Methoden der Informatik\\Praktikum\\Praktikum 9\\Ergebnis_MaxMatching.txt";
                if (erg.Count > 0)
                {

                    string output = "";
                    StreamWriter file = new StreamWriter(filename);

                    for (int i = 0; i < erg.Count; i++)
                    {
                        output = erg[i].sourceVertex.name + "-->" + erg[i].destinationVertex.name;

                        file.WriteLine(output);
                    }

                    file.Close();

                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = filename
                    };

                    process.Start();
                    process.WaitForExit();

                }

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Maximale-Matchings-Algorithmus ist etwas schief gegangen.");
            }
        }
    }
}
