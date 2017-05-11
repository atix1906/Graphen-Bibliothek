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
            OpenFileDialog openFileDialogGetGraph = new OpenFileDialog();

            openFileDialogGetGraph.InitialDirectory = @"C:\Users\atix\Dropbox\Studium\Master\1. Semester\Mathematische Methoden der Informatik\Praktikum\Praktikum 3";
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
                        graph.SetFileGraph(File.ReadAllLines(pathToLastGraph));
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
                int zusammenhangskomponenten = functions.BreitensucheIterativ(graph, (int)numericUpDownStartknoten.Value);
                MessageBox.Show("Breitensuche(iterativ)\nZusammenhangskomponenten: " + zusammenhangskomponenten.ToString());
                    //+"\nElapsed Time: "+sw.Elapsed.ToString());

                sw.Stop();
                ResetUsedVertices();
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
                ResetUsedVertices();
            }
            else
            {
                MessageBox.Show("Bei der Tiefensuche ist etwas schief gegangen.");
            }
        }

        private void ResetGraph()
        {
            graph.ClearGraph();
            graph.SetFileGraph(File.ReadAllLines(pathToLastGraph));
        }
        private void ResetUsedVertices()
        {
            foreach (var item in graph.vertices)
            {
                item.used = false;
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

                double erg = functions.Prim(graph, (int)numericUpDownStartknoten.Value);
                sw.Stop();
                
                textBoxPrim.AppendText(Math.Round(erg, 4).ToString());
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
                textBoxPrim.Clear();
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
                textBoxPrim.Clear();
                //numericUpDownStartknoten.Minimum = 0;
                //numericUpDownStartknoten.Maximum = graph.GetVerticesList().Count - 1;

                Stopwatch sw = new Stopwatch();
                sw.Restart();

                double erg = functions.DoppelterBaum(graph);
                sw.Stop();

                textBoxDoppelterBaum.AppendText(Math.Round(erg, 4).ToString());
                MessageBox.Show("Doppelter Baum\nElapsed Time: " + sw.Elapsed.ToString());

                ResetGraph();
            }
            else
            {
                MessageBox.Show("Beim Doppelter Baum Algorithmus ist etwas schief gegangen.");
            }
        }
    }
}
