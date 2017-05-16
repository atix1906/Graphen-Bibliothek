namespace Graphen
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
            this.kruskalBtn = new System.Windows.Forms.Button();
            this.primBtn = new System.Windows.Forms.Button();
            this.textBoxPrim = new System.Windows.Forms.TextBox();
            this.textBoxKruskal = new System.Windows.Forms.TextBox();
            this.btnNearestNeighbour = new System.Windows.Forms.Button();
            this.nearestNeighbourtextBox = new System.Windows.Forms.TextBox();
            this.btnDoppelterBaum = new System.Windows.Forms.Button();
            this.textBoxDoppelterBaum = new System.Windows.Forms.TextBox();
            this.btnAllTour = new System.Windows.Forms.Button();
            this.textBoxAllTours = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartknoten)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(852, 519);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // loadGraph
            // 
            this.loadGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadGraph.Location = new System.Drawing.Point(3, 58);
            this.loadGraph.Name = "loadGraph";
            this.loadGraph.Size = new System.Drawing.Size(420, 42);
            this.loadGraph.TabIndex = 0;
            this.loadGraph.Text = "Load Graph";
            this.loadGraph.UseVisualStyleBackColor = true;
            this.loadGraph.Click += new System.EventHandler(this.loadGraph_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clearBtn.Location = new System.Drawing.Point(429, 58);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(420, 42);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear Graph";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 106);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 97);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 551);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(858, 525);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 519);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 253);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // breitensucheBtn
            // 
            this.breitensucheBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.breitensucheBtn.Location = new System.Drawing.Point(3, 3);
            this.breitensucheBtn.Name = "breitensucheBtn";
            this.breitensucheBtn.Size = new System.Drawing.Size(204, 36);
            this.breitensucheBtn.TabIndex = 0;
            this.breitensucheBtn.Text = "Breitensuche (iterativ)";
            this.breitensucheBtn.UseVisualStyleBackColor = true;
            this.breitensucheBtn.Click += new System.EventHandler(this.breitensucheBtn_Click);
            // 
            // tiefensucheBtn
            // 
            this.tiefensucheBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.tiefensucheBtn.Location = new System.Drawing.Point(3, 66);
            this.tiefensucheBtn.Name = "tiefensucheBtn";
            this.tiefensucheBtn.Size = new System.Drawing.Size(204, 32);
            this.tiefensucheBtn.TabIndex = 1;
            this.tiefensucheBtn.Text = "Tiefensuche (rekursiv)";
            this.tiefensucheBtn.UseVisualStyleBackColor = true;
            this.tiefensucheBtn.Click += new System.EventHandler(this.tiefensucheBtn_Click);
            // 
            // numericUpDownStartknoten
            // 
            this.numericUpDownStartknoten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownStartknoten.Location = new System.Drawing.Point(213, 147);
            this.numericUpDownStartknoten.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownStartknoten.Name = "numericUpDownStartknoten";
            this.numericUpDownStartknoten.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStartknoten.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "Startknoten";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 262);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(420, 254);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // kruskalBtn
            // 
            this.kruskalBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.kruskalBtn.Location = new System.Drawing.Point(3, 3);
            this.kruskalBtn.Name = "kruskalBtn";
            this.kruskalBtn.Size = new System.Drawing.Size(204, 31);
            this.kruskalBtn.TabIndex = 0;
            this.kruskalBtn.Text = "Kruskal";
            this.kruskalBtn.UseVisualStyleBackColor = true;
            this.kruskalBtn.Click += new System.EventHandler(this.kruskalBtn_Click);
            // 
            // primBtn
            // 
            this.primBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.primBtn.Location = new System.Drawing.Point(2, 44);
            this.primBtn.Margin = new System.Windows.Forms.Padding(2);
            this.primBtn.Name = "primBtn";
            this.primBtn.Size = new System.Drawing.Size(206, 29);
            this.primBtn.TabIndex = 1;
            this.primBtn.Text = "Prim";
            this.primBtn.UseVisualStyleBackColor = true;
            this.primBtn.Click += new System.EventHandler(this.primBtn_Click);
            // 
            // textBoxPrim
            // 
            this.textBoxPrim.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxPrim.Location = new System.Drawing.Point(213, 45);
            this.textBoxPrim.Name = "textBoxPrim";
            this.textBoxPrim.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrim.TabIndex = 2;
            // 
            // textBoxKruskal
            // 
            this.textBoxKruskal.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxKruskal.Location = new System.Drawing.Point(213, 3);
            this.textBoxKruskal.Name = "textBoxKruskal";
            this.textBoxKruskal.Size = new System.Drawing.Size(100, 20);
            this.textBoxKruskal.TabIndex = 3;
            // 
            // btnNearestNeighbour
            // 
            this.btnNearestNeighbour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNearestNeighbour.Location = new System.Drawing.Point(3, 87);
            this.btnNearestNeighbour.Name = "btnNearestNeighbour";
            this.btnNearestNeighbour.Size = new System.Drawing.Size(204, 29);
            this.btnNearestNeighbour.TabIndex = 4;
            this.btnNearestNeighbour.Text = "Nearest Neighbour";
            this.btnNearestNeighbour.UseVisualStyleBackColor = true;
            this.btnNearestNeighbour.Click += new System.EventHandler(this.btnNearestNeighbour_Click);
            // 
            // nearestNeighbourtextBox
            // 
            this.nearestNeighbourtextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.nearestNeighbourtextBox.Location = new System.Drawing.Point(213, 87);
            this.nearestNeighbourtextBox.Name = "nearestNeighbourtextBox";
            this.nearestNeighbourtextBox.Size = new System.Drawing.Size(100, 20);
            this.nearestNeighbourtextBox.TabIndex = 5;
            // 
            // btnDoppelterBaum
            // 
            this.btnDoppelterBaum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoppelterBaum.Location = new System.Drawing.Point(3, 129);
            this.btnDoppelterBaum.Name = "btnDoppelterBaum";
            this.btnDoppelterBaum.Size = new System.Drawing.Size(204, 29);
            this.btnDoppelterBaum.TabIndex = 6;
            this.btnDoppelterBaum.Text = "Doppelter Baum";
            this.btnDoppelterBaum.UseVisualStyleBackColor = true;
            this.btnDoppelterBaum.Click += new System.EventHandler(this.btnDoppelterBaum_Click);
            // 
            // textBoxDoppelterBaum
            // 
            this.textBoxDoppelterBaum.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxDoppelterBaum.Location = new System.Drawing.Point(213, 129);
            this.textBoxDoppelterBaum.Name = "textBoxDoppelterBaum";
            this.textBoxDoppelterBaum.Size = new System.Drawing.Size(100, 20);
            this.textBoxDoppelterBaum.TabIndex = 7;
            // 
            // btnAllTour
            // 
            this.btnAllTour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllTour.Location = new System.Drawing.Point(3, 171);
            this.btnAllTour.Name = "btnAllTour";
            this.btnAllTour.Size = new System.Drawing.Size(204, 23);
            this.btnAllTour.TabIndex = 8;
            this.btnAllTour.Text = "Alle Touren";
            this.btnAllTour.UseVisualStyleBackColor = true;
            this.btnAllTour.Click += new System.EventHandler(this.btnAllTour_Click);
            // 
            // textBoxAllTours
            // 
            this.textBoxAllTours.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxAllTours.Location = new System.Drawing.Point(213, 171);
            this.textBoxAllTours.Name = "textBoxAllTours";
            this.textBoxAllTours.Size = new System.Drawing.Size(100, 20);
            this.textBoxAllTours.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 551);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartknoten)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
    }
}

