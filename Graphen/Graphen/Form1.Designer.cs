﻿namespace Graphen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.loadGraph = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonGerichtet = new System.Windows.Forms.RadioButton();
            this.radioButtonUngerichtet = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.breitensucheBtn = new System.Windows.Forms.Button();
            this.tiefensucheBtn = new System.Windows.Forms.Button();
            this.numericUpDownStartknoten = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBranchAndBound = new System.Windows.Forms.TextBox();
            this.textBoxAllTours = new System.Windows.Forms.TextBox();
            this.kruskalBtn = new System.Windows.Forms.Button();
            this.primBtn = new System.Windows.Forms.Button();
            this.btnNearestNeighbour = new System.Windows.Forms.Button();
            this.textBoxPrim = new System.Windows.Forms.TextBox();
            this.textBoxKruskal = new System.Windows.Forms.TextBox();
            this.nearestNeighbourtextBox = new System.Windows.Forms.TextBox();
            this.btnDoppelterBaum = new System.Windows.Forms.Button();
            this.textBoxDoppelterBaum = new System.Windows.Forms.TextBox();
            this.btnAllTour = new System.Windows.Forms.Button();
            this.btnBranchAndBound = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDijkstra = new System.Windows.Forms.Button();
            this.btnMooreBellmanFord = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEdmondsKarp = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSource = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTarget = new System.Windows.Forms.NumericUpDown();
            this.source = new System.Windows.Forms.Label();
            this.target = new System.Windows.Forms.Label();
            this.btnCycleCanceling = new System.Windows.Forms.Button();
            this.btnSuccessiveShortestPath = new System.Windows.Forms.Button();
            this.btnMaximaleMatchings = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartknoten)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.loadGraph, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.clearBtn, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1139, 641);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // loadGraph
            // 
            this.loadGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadGraph.Location = new System.Drawing.Point(4, 72);
            this.loadGraph.Margin = new System.Windows.Forms.Padding(4);
            this.loadGraph.Name = "loadGraph";
            this.loadGraph.Size = new System.Drawing.Size(561, 52);
            this.loadGraph.TabIndex = 0;
            this.loadGraph.Text = "Load Graph";
            this.loadGraph.UseVisualStyleBackColor = true;
            this.loadGraph.Click += new System.EventHandler(this.loadGraph_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clearBtn.Location = new System.Drawing.Point(573, 72);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(562, 52);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear Graph";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Visible = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.radioButtonGerichtet, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonUngerichtet, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 132);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(561, 120);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // radioButtonGerichtet
            // 
            this.radioButtonGerichtet.AutoSize = true;
            this.radioButtonGerichtet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonGerichtet.Location = new System.Drawing.Point(283, 2);
            this.radioButtonGerichtet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonGerichtet.Name = "radioButtonGerichtet";
            this.radioButtonGerichtet.Size = new System.Drawing.Size(275, 56);
            this.radioButtonGerichtet.TabIndex = 0;
            this.radioButtonGerichtet.Text = "Gerichteter Graph";
            this.radioButtonGerichtet.UseVisualStyleBackColor = true;
            // 
            // radioButtonUngerichtet
            // 
            this.radioButtonUngerichtet.AutoSize = true;
            this.radioButtonUngerichtet.Checked = true;
            this.radioButtonUngerichtet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonUngerichtet.Location = new System.Drawing.Point(283, 62);
            this.radioButtonUngerichtet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonUngerichtet.Name = "radioButtonUngerichtet";
            this.radioButtonUngerichtet.Size = new System.Drawing.Size(275, 56);
            this.radioButtonUngerichtet.TabIndex = 1;
            this.radioButtonUngerichtet.TabStop = true;
            this.radioButtonUngerichtet.Text = "Ungerichteter Graph";
            this.radioButtonUngerichtet.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 678);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1147, 649);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1147, 649);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 641);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.breitensucheBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tiefensucheBtn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownStartknoten, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(561, 312);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // breitensucheBtn
            // 
            this.breitensucheBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.breitensucheBtn.Location = new System.Drawing.Point(4, 4);
            this.breitensucheBtn.Margin = new System.Windows.Forms.Padding(4);
            this.breitensucheBtn.Name = "breitensucheBtn";
            this.breitensucheBtn.Size = new System.Drawing.Size(272, 44);
            this.breitensucheBtn.TabIndex = 0;
            this.breitensucheBtn.Text = "Breitensuche (iterativ)";
            this.breitensucheBtn.UseVisualStyleBackColor = true;
            this.breitensucheBtn.Click += new System.EventHandler(this.breitensucheBtn_Click);
            // 
            // tiefensucheBtn
            // 
            this.tiefensucheBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.tiefensucheBtn.Location = new System.Drawing.Point(4, 82);
            this.tiefensucheBtn.Margin = new System.Windows.Forms.Padding(4);
            this.tiefensucheBtn.Name = "tiefensucheBtn";
            this.tiefensucheBtn.Size = new System.Drawing.Size(272, 39);
            this.tiefensucheBtn.TabIndex = 1;
            this.tiefensucheBtn.Text = "Tiefensuche (rekursiv)";
            this.tiefensucheBtn.UseVisualStyleBackColor = true;
            this.tiefensucheBtn.Click += new System.EventHandler(this.tiefensucheBtn_Click);
            // 
            // numericUpDownStartknoten
            // 
            this.numericUpDownStartknoten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownStartknoten.Location = new System.Drawing.Point(284, 184);
            this.numericUpDownStartknoten.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownStartknoten.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownStartknoten.Name = "numericUpDownStartknoten";
            this.numericUpDownStartknoten.Size = new System.Drawing.Size(160, 22);
            this.numericUpDownStartknoten.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 78);
            this.label1.TabIndex = 3;
            this.label1.Text = "Startknoten";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.textBoxBranchAndBound, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.textBoxAllTours, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.kruskalBtn, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.primBtn, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnNearestNeighbour, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxPrim, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxKruskal, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.nearestNeighbourtextBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnDoppelterBaum, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.textBoxDoppelterBaum, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnAllTour, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.btnBranchAndBound, 0, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 324);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(560, 313);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // textBoxBranchAndBound
            // 
            this.textBoxBranchAndBound.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxBranchAndBound.Location = new System.Drawing.Point(284, 264);
            this.textBoxBranchAndBound.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBranchAndBound.Name = "textBoxBranchAndBound";
            this.textBoxBranchAndBound.Size = new System.Drawing.Size(132, 22);
            this.textBoxBranchAndBound.TabIndex = 11;
            // 
            // textBoxAllTours
            // 
            this.textBoxAllTours.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxAllTours.Location = new System.Drawing.Point(284, 212);
            this.textBoxAllTours.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAllTours.Name = "textBoxAllTours";
            this.textBoxAllTours.Size = new System.Drawing.Size(132, 22);
            this.textBoxAllTours.TabIndex = 9;
            // 
            // kruskalBtn
            // 
            this.kruskalBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.kruskalBtn.Location = new System.Drawing.Point(4, 4);
            this.kruskalBtn.Margin = new System.Windows.Forms.Padding(4);
            this.kruskalBtn.Name = "kruskalBtn";
            this.kruskalBtn.Size = new System.Drawing.Size(272, 38);
            this.kruskalBtn.TabIndex = 0;
            this.kruskalBtn.Text = "Kruskal";
            this.kruskalBtn.UseVisualStyleBackColor = true;
            this.kruskalBtn.Click += new System.EventHandler(this.kruskalBtn_Click);
            // 
            // primBtn
            // 
            this.primBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.primBtn.Location = new System.Drawing.Point(3, 54);
            this.primBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.primBtn.Name = "primBtn";
            this.primBtn.Size = new System.Drawing.Size(274, 36);
            this.primBtn.TabIndex = 1;
            this.primBtn.Text = "Prim";
            this.primBtn.UseVisualStyleBackColor = true;
            this.primBtn.Click += new System.EventHandler(this.primBtn_Click);
            // 
            // btnNearestNeighbour
            // 
            this.btnNearestNeighbour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNearestNeighbour.Location = new System.Drawing.Point(4, 108);
            this.btnNearestNeighbour.Margin = new System.Windows.Forms.Padding(4);
            this.btnNearestNeighbour.Name = "btnNearestNeighbour";
            this.btnNearestNeighbour.Size = new System.Drawing.Size(272, 36);
            this.btnNearestNeighbour.TabIndex = 4;
            this.btnNearestNeighbour.Text = "Nearest Neighbour";
            this.btnNearestNeighbour.UseVisualStyleBackColor = true;
            this.btnNearestNeighbour.Click += new System.EventHandler(this.btnNearestNeighbour_Click);
            // 
            // textBoxPrim
            // 
            this.textBoxPrim.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxPrim.Location = new System.Drawing.Point(284, 56);
            this.textBoxPrim.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrim.Name = "textBoxPrim";
            this.textBoxPrim.Size = new System.Drawing.Size(132, 22);
            this.textBoxPrim.TabIndex = 2;
            // 
            // textBoxKruskal
            // 
            this.textBoxKruskal.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxKruskal.Location = new System.Drawing.Point(284, 4);
            this.textBoxKruskal.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxKruskal.Name = "textBoxKruskal";
            this.textBoxKruskal.Size = new System.Drawing.Size(132, 22);
            this.textBoxKruskal.TabIndex = 3;
            // 
            // nearestNeighbourtextBox
            // 
            this.nearestNeighbourtextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.nearestNeighbourtextBox.Location = new System.Drawing.Point(284, 108);
            this.nearestNeighbourtextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nearestNeighbourtextBox.Name = "nearestNeighbourtextBox";
            this.nearestNeighbourtextBox.Size = new System.Drawing.Size(132, 22);
            this.nearestNeighbourtextBox.TabIndex = 5;
            // 
            // btnDoppelterBaum
            // 
            this.btnDoppelterBaum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoppelterBaum.Location = new System.Drawing.Point(4, 160);
            this.btnDoppelterBaum.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoppelterBaum.Name = "btnDoppelterBaum";
            this.btnDoppelterBaum.Size = new System.Drawing.Size(272, 36);
            this.btnDoppelterBaum.TabIndex = 6;
            this.btnDoppelterBaum.Text = "Doppelter Baum";
            this.btnDoppelterBaum.UseVisualStyleBackColor = true;
            this.btnDoppelterBaum.Click += new System.EventHandler(this.btnDoppelterBaum_Click);
            // 
            // textBoxDoppelterBaum
            // 
            this.textBoxDoppelterBaum.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxDoppelterBaum.Location = new System.Drawing.Point(284, 160);
            this.textBoxDoppelterBaum.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDoppelterBaum.Name = "textBoxDoppelterBaum";
            this.textBoxDoppelterBaum.Size = new System.Drawing.Size(132, 22);
            this.textBoxDoppelterBaum.TabIndex = 7;
            // 
            // btnAllTour
            // 
            this.btnAllTour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllTour.Location = new System.Drawing.Point(4, 212);
            this.btnAllTour.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllTour.Name = "btnAllTour";
            this.btnAllTour.Size = new System.Drawing.Size(272, 28);
            this.btnAllTour.TabIndex = 8;
            this.btnAllTour.Text = "Alle Touren";
            this.btnAllTour.UseVisualStyleBackColor = true;
            this.btnAllTour.Click += new System.EventHandler(this.btnAllTour_Click);
            // 
            // btnBranchAndBound
            // 
            this.btnBranchAndBound.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBranchAndBound.Location = new System.Drawing.Point(4, 264);
            this.btnBranchAndBound.Margin = new System.Windows.Forms.Padding(4);
            this.btnBranchAndBound.Name = "btnBranchAndBound";
            this.btnBranchAndBound.Size = new System.Drawing.Size(272, 28);
            this.btnBranchAndBound.TabIndex = 10;
            this.btnBranchAndBound.Text = "Branch and Bound";
            this.btnBranchAndBound.UseVisualStyleBackColor = true;
            this.btnBranchAndBound.Click += new System.EventHandler(this.btnBranchAndBound_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnDijkstra, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnMooreBellmanFord, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(572, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(564, 316);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDijkstra.Location = new System.Drawing.Point(4, 4);
            this.btnDijkstra.Margin = new System.Windows.Forms.Padding(4);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Size = new System.Drawing.Size(274, 38);
            this.btnDijkstra.TabIndex = 1;
            this.btnDijkstra.Text = "Dijkstra";
            this.btnDijkstra.UseVisualStyleBackColor = true;
            this.btnDijkstra.Click += new System.EventHandler(this.btnDijkstra_Click);
            // 
            // btnMooreBellmanFord
            // 
            this.btnMooreBellmanFord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMooreBellmanFord.Location = new System.Drawing.Point(3, 160);
            this.btnMooreBellmanFord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMooreBellmanFord.Name = "btnMooreBellmanFord";
            this.btnMooreBellmanFord.Size = new System.Drawing.Size(276, 38);
            this.btnMooreBellmanFord.TabIndex = 2;
            this.btnMooreBellmanFord.Text = "Moore-Bellman-Ford";
            this.btnMooreBellmanFord.UseVisualStyleBackColor = true;
            this.btnMooreBellmanFord.Click += new System.EventHandler(this.btnMooreBellmanFord_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnEdmondsKarp, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnCycleCanceling, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnSuccessiveShortestPath, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.btnMaximaleMatchings, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(573, 324);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(562, 313);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // btnEdmondsKarp
            // 
            this.btnEdmondsKarp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdmondsKarp.Location = new System.Drawing.Point(4, 4);
            this.btnEdmondsKarp.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdmondsKarp.Name = "btnEdmondsKarp";
            this.btnEdmondsKarp.Size = new System.Drawing.Size(273, 38);
            this.btnEdmondsKarp.TabIndex = 0;
            this.btnEdmondsKarp.Text = "Edmonds-Karp";
            this.btnEdmondsKarp.UseVisualStyleBackColor = true;
            this.btnEdmondsKarp.Click += new System.EventHandler(this.btnEdmondsKarp_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownSource, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownTarget, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.source, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.target, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(285, 4);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(273, 70);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // numericUpDownSource
            // 
            this.numericUpDownSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownSource.Location = new System.Drawing.Point(140, 4);
            this.numericUpDownSource.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownSource.Name = "numericUpDownSource";
            this.numericUpDownSource.Size = new System.Drawing.Size(129, 22);
            this.numericUpDownSource.TabIndex = 0;
            // 
            // numericUpDownTarget
            // 
            this.numericUpDownTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownTarget.Location = new System.Drawing.Point(140, 39);
            this.numericUpDownTarget.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownTarget.Name = "numericUpDownTarget";
            this.numericUpDownTarget.Size = new System.Drawing.Size(129, 22);
            this.numericUpDownTarget.TabIndex = 1;
            this.numericUpDownTarget.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // source
            // 
            this.source.AutoSize = true;
            this.source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.source.Location = new System.Drawing.Point(4, 0);
            this.source.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(128, 35);
            this.source.TabIndex = 2;
            this.source.Text = "Source";
            this.source.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // target
            // 
            this.target.AutoSize = true;
            this.target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.target.Location = new System.Drawing.Point(4, 35);
            this.target.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(128, 35);
            this.target.TabIndex = 3;
            this.target.Text = "Target";
            this.target.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCycleCanceling
            // 
            this.btnCycleCanceling.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCycleCanceling.Location = new System.Drawing.Point(3, 81);
            this.btnCycleCanceling.Name = "btnCycleCanceling";
            this.btnCycleCanceling.Size = new System.Drawing.Size(275, 37);
            this.btnCycleCanceling.TabIndex = 2;
            this.btnCycleCanceling.Text = "Cycle-Canceling";
            this.btnCycleCanceling.UseVisualStyleBackColor = true;
            this.btnCycleCanceling.Click += new System.EventHandler(this.btnCycleCanceling_Click);
            // 
            // btnSuccessiveShortestPath
            // 
            this.btnSuccessiveShortestPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuccessiveShortestPath.Location = new System.Drawing.Point(3, 159);
            this.btnSuccessiveShortestPath.Name = "btnSuccessiveShortestPath";
            this.btnSuccessiveShortestPath.Size = new System.Drawing.Size(275, 37);
            this.btnSuccessiveShortestPath.TabIndex = 3;
            this.btnSuccessiveShortestPath.Text = "Successive Shortest Path";
            this.btnSuccessiveShortestPath.UseVisualStyleBackColor = true;
            this.btnSuccessiveShortestPath.Click += new System.EventHandler(this.btnSuccessiveShortestPath_Click);
            // 
            // btnMaximaleMatchings
            // 
            this.btnMaximaleMatchings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaximaleMatchings.Location = new System.Drawing.Point(3, 237);
            this.btnMaximaleMatchings.Name = "btnMaximaleMatchings";
            this.btnMaximaleMatchings.Size = new System.Drawing.Size(275, 35);
            this.btnMaximaleMatchings.TabIndex = 4;
            this.btnMaximaleMatchings.Text = "Maximale Matchings";
            this.btnMaximaleMatchings.UseVisualStyleBackColor = true;
            this.btnMaximaleMatchings.Click += new System.EventHandler(this.btnMaximaleMatchings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 678);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartknoten)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTarget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button loadGraph;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button breitensucheBtn;
        private System.Windows.Forms.Button tiefensucheBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numericUpDownStartknoten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button kruskalBtn;
        private System.Windows.Forms.Button primBtn;
        private System.Windows.Forms.TextBox textBoxPrim;
        private System.Windows.Forms.TextBox textBoxKruskal;
        private System.Windows.Forms.Button btnNearestNeighbour;
        private System.Windows.Forms.TextBox nearestNeighbourtextBox;
        private System.Windows.Forms.Button btnDoppelterBaum;
        private System.Windows.Forms.TextBox textBoxDoppelterBaum;
        private System.Windows.Forms.Button btnAllTour;
        private System.Windows.Forms.TextBox textBoxAllTours;
        private System.Windows.Forms.TextBox textBoxBranchAndBound;
        private System.Windows.Forms.Button btnBranchAndBound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnDijkstra;
        private System.Windows.Forms.RadioButton radioButtonGerichtet;
        private System.Windows.Forms.RadioButton radioButtonUngerichtet;
        private System.Windows.Forms.Button btnMooreBellmanFord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnEdmondsKarp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown numericUpDownSource;
        private System.Windows.Forms.NumericUpDown numericUpDownTarget;
        private System.Windows.Forms.Label source;
        private System.Windows.Forms.Label target;
        private System.Windows.Forms.Button btnCycleCanceling;
        private System.Windows.Forms.Button btnSuccessiveShortestPath;
        private System.Windows.Forms.Button btnMaximaleMatchings;
    }
}

