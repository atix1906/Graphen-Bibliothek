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

            openFileDialogGetGraph.InitialDirectory = @"C:\Users\atix\Dropbox\Studium\Master\1. Semester\Mathematische Methoden der Informatik\Praktikum";
            openFileDialogGetGraph.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogGetGraph.FilterIndex = 2;
            openFileDialogGetGraph.RestoreDirectory = true;

            if (openFileDialogGetGraph.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(openFileDialogGetGraph.FileName))
                    {
                        graph.SetFileGraph(File.ReadAllLines(openFileDialogGetGraph.FileName));
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

                int zusammenhangskomponenten = functions.StartTiefensucheRekursiv(graph, (int)numericUpDownStartknoten.Value);
                MessageBox.Show("Tiefensuche(rekursiv)\nZusammenhangskomponenten: " + zusammenhangskomponenten.ToString());
                //+"\nElapsed Time: " + sw.Elapsed.ToString());

                sw.Stop();
                ResetUsedVertices();
            }
            else
            {
                MessageBox.Show("Bei der Tiefensuche ist etwas schief gegangen.");
            }
        }


        private void ResetUsedVertices()
        {
            foreach (var item in graph.vertices)
            {
                item.used = false;
            }
        }
    }
}
