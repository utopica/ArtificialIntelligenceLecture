using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Xps.Packaging;

namespace GeneticAlgorithm
{
    public partial class GAForm : Form
    {
        private GeneticAlgorithm geneticAlgorithm;

        public GAForm()
        {
            InitializeComponent();
        }

        private void DisplayResults()
        {
            panel1.Controls.Clear();
            
            Panel resultsPanel = new Panel();
            resultsPanel.BackColor = Color.Transparent;
            resultsPanel.BorderStyle = BorderStyle.FixedSingle;
            resultsPanel.Width = 250;
            resultsPanel.Height = 120;
            resultsPanel.Location = new Point(397, 224);
            this.Controls.Add(resultsPanel);

            Chromosome bestSolution = geneticAlgorithm.GetBestSolution;
            if (bestSolution != null)
            {
                Label labelTitle = new Label();
                labelTitle.Text = "Optimizasyon Sonuçları";
                labelTitle.ForeColor = Color.White;
                labelTitle.BackColor = Color.Transparent;
                labelTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                labelTitle.AutoSize = true;
                labelTitle.Location = new Point(10, 10);
                resultsPanel.Controls.Add(labelTitle);

                Label labelX = new Label();
                labelX.Text = $"X = {bestSolution.X:F4}";
                labelX.ForeColor = Color.White;
                labelX.BackColor = Color.Transparent;
                labelX.Font = new Font("Segoe UI", 9);
                labelX.AutoSize = true;
                labelX.Location = new Point(10, 35);
                resultsPanel.Controls.Add(labelX);

                Label labelY = new Label();
                labelY.Text = $"Y = {bestSolution.Y:F4}";
                labelY.ForeColor = Color.White;
                labelY.BackColor = Color.Transparent;
                labelY.Font = new Font("Segoe UI", 9);
                labelY.AutoSize = true;
                labelY.Location = new Point(10, 60);
                resultsPanel.Controls.Add(labelY);

                Label labelFitness = new Label();
                labelFitness.Text = $"Amaç Fonksiyon Değeri: {bestSolution.Fitness:F4}";
                labelFitness.ForeColor = Color.White;
                labelFitness.BackColor = Color.Transparent;
                labelFitness.Font = new Font("Segoe UI", 9);
                labelFitness.AutoSize = true;
                labelFitness.Location = new Point(10, 85);
                resultsPanel.Controls.Add(labelFitness);
            }

            PlotFitnessHistory(panel1);
        }

        private void PlotFitnessHistory(Panel panel)
        {
            List<double> bestFitnessHistory = geneticAlgorithm.GetBestFitnessHistory();
            List<Point> dataPoints = new List<Point>();
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            panel.Paint += new PaintEventHandler((sender, e) =>
            {
                if (bestFitnessHistory == null || bestFitnessHistory.Count < 2)
                    return;

                int margin = 50;
                int xAxisStart = margin;
                int xAxisEnd = panel.Width - margin;
                int yAxisStart = panel.Height - margin;
                int yAxisEnd = margin;
                int graphWidth = xAxisEnd - xAxisStart;
                int graphHeight = yAxisStart - yAxisEnd;

                using (Pen axisPen = new Pen(Color.White, 2))
                using (Pen gridPen = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                using (Pen linePen = new Pen(Color.Red, 2))
                using (Brush textBrush = new SolidBrush(Color.White))
                using (Brush titleBrush = new SolidBrush(Color.White))
                using (Font axisFont = new Font("Arial", 8))
                using (Font titleFont = new Font("Arial", 12, FontStyle.Bold))
                using (StringFormat formatRight = new StringFormat { Alignment = StringAlignment.Far })
                using (StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center })
                {
                    // Başlık
                    e.Graphics.DrawString("Yakınsama Grafiği", titleFont, titleBrush,
                        new Rectangle(xAxisStart, 10, graphWidth, 30), formatCenter);

                    // Eksenler
                    e.Graphics.DrawLine(axisPen, xAxisStart, yAxisStart, xAxisEnd, yAxisStart);
                    e.Graphics.DrawLine(axisPen, xAxisStart, yAxisStart, xAxisStart, yAxisEnd);

                    double minFitness = bestFitnessHistory.Min();
                    double maxFitness = bestFitnessHistory.Max();
                    double range = maxFitness - minFitness;
                    double padding = range * 0.1;
                    double yMin = Math.Max(0, minFitness - padding);
                    double yMax = maxFitness + padding;

                    // Izgara çizgileri ve etiketler
                    int xGridCount = 10;
                    int yGridCount = 5;

                    for (int i = 0; i <= xGridCount; i++)
                    {
                        int x = xAxisStart + (i * graphWidth / xGridCount);
                        int generation = i * bestFitnessHistory.Count / xGridCount;

                        if (i > 0 && i < xGridCount)
                            e.Graphics.DrawLine(gridPen, x, yAxisEnd, x, yAxisStart);

                        e.Graphics.DrawLine(axisPen, x, yAxisStart, x, yAxisStart + 5);

                        if (generation < bestFitnessHistory.Count)
                            e.Graphics.DrawString(generation.ToString(), axisFont, textBrush,
                                x, yAxisStart + 7, formatCenter);
                    }

                    for (int i = 0; i <= yGridCount; i++)
                    {
                        int y = yAxisStart - (i * graphHeight / yGridCount);
                        double value = yMin + (i * (yMax - yMin) / yGridCount);

                        if (i > 0 && i < yGridCount)
                            e.Graphics.DrawLine(gridPen, xAxisStart, y, xAxisEnd, y);

                        e.Graphics.DrawLine(axisPen, xAxisStart - 5, y, xAxisStart, y);

                        string valueLabel = value.ToString("F2");
                        e.Graphics.DrawString(valueLabel, axisFont, textBrush,
                            xAxisStart - 8, y - 6, formatRight);
                    }

                    // Eksen etiketleri
                    e.Graphics.DrawString("Jenerasyon", axisFont, textBrush,
                        new Rectangle(xAxisStart, yAxisStart + 25, graphWidth, 20), formatCenter);

                    e.Graphics.TranslateTransform(xAxisStart - 35, yAxisStart / 2);
                    e.Graphics.RotateTransform(-90);
                    e.Graphics.DrawString("Fitness Değeri", axisFont, textBrush, 0, 0);
                    e.Graphics.ResetTransform();

                    // Veri noktaları ve çizgi
                    if (bestFitnessHistory.Count > 1)
                    {
                        dataPoints.Clear();
                        for (int i = 0; i < bestFitnessHistory.Count; i++)
                        {
                            double normalizedX = (double)i / (bestFitnessHistory.Count - 1);
                            double normalizedY = (bestFitnessHistory[i] - yMin) / (yMax - yMin);
                            int x = xAxisStart + (int)(normalizedX * graphWidth);
                            int y = yAxisStart - (int)(normalizedY * graphHeight);
                            dataPoints.Add(new Point(x, y));
                        }

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.DrawLines(linePen, dataPoints.ToArray());

                        // Veri noktalarını göster ve tooltip ekle
                        using (Brush pointBrush = new SolidBrush(Color.Yellow))
                        {
                            for (int i = 0; i < dataPoints.Count; i += Math.Max(1, dataPoints.Count / 20))
                            {
                                Point p = dataPoints[i];
                                Rectangle pointArea = new Rectangle(p.X - 5, p.Y - 5, 10, 10);
                                e.Graphics.FillEllipse(pointBrush, pointArea);
                                
                                // Her nokta için ayrı tooltip
                                string tooltipText = $"Jenerasyon: {i}\nFitness: {bestFitnessHistory[i]:F4}";
                                toolTip.SetToolTip(panel, tooltipText);
                            }
                        }
                    }
                }
            });

            // Mouse move event handler ekle
            panel.MouseMove += (sender, e) =>
            {
                foreach (Point p in dataPoints)
                {
                    Rectangle pointArea = new Rectangle(p.X - 5, p.Y - 5, 10, 10);
                    if (pointArea.Contains(e.Location))
                    {
                        int index = dataPoints.IndexOf(p);
                        string tooltipText = $"Jenerasyon: {index}\nFitness: {bestFitnessHistory[index]:F4}";
                        toolTip.SetToolTip(panel, tooltipText);
                        break;
                    }
                }
            };

            panel.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int populationSize, eliteSize, generationCount;
            double crossoverRate, mutationRate;

            if (!int.TryParse(textBox1.Text, out populationSize) || populationSize <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir popülasyon boyutu girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox2.Text, out crossoverRate) || crossoverRate < 0 || crossoverRate > 1)
            {
                MessageBox.Show("Lütfen geçerli bir çaprazlama oranı girin (0 ile 1 arasında).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox3.Text, out mutationRate) || mutationRate < 0 || mutationRate > 1)
            {
                MessageBox.Show("Lütfen geçerli bir mutasyon oranı girin (0 ile 1 arasında).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox4.Text, out eliteSize) || eliteSize < 0 || eliteSize > populationSize)
            {
                MessageBox.Show("Lütfen geçerli bir seçkinlik oranı girin (0 ile popülasyon boyutu arasında).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox5.Text, out generationCount) || generationCount <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir jenerasyon sayısı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            geneticAlgorithm = new GeneticAlgorithm(populationSize, crossoverRate, mutationRate, eliteSize, generationCount);

            geneticAlgorithm.Solve();

            DisplayResults();

            PlotFitnessHistory(panel1);
        }

        private void GAForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
