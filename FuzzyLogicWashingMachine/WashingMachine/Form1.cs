using FontAwesome.Sharp;
using System.Data;

namespace WashingMachine
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView;
        private Dictionary<string, double[]> fuzzyRanges;


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 10;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 0.1M;

            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 10;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = 0.1M;

            numericUpDown3.Minimum = 0;
            numericUpDown3.Maximum = 10;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = 0.1M;

            btnStart.Click += StartButton_Click;
            
            InitializeFuzzyRanges();
        }

        private void InitializeFuzzyRanges()
        {
            fuzzyRanges = new Dictionary<string, double[]>
            {
                // HASSASLIK
                { "saglam_hassaslik", [-4, -1.5, 2, 4] }, // yamuk
                { "orta_hassaslik", [3, 5, 7] }, // ��gen
                { "hassas_hassaslik", [5.5, 8, 12.5, 14] }, // yamuk

                // M�KTAR
                { "kucuk_miktar", [-4, -1.5, 2, 4] },
                { "orta_miktar", [3, 5, 7] },
                { "buyuk_miktar", [5.5, 8, 12.5, 14] },

                // K�RL�L�K
                { "kucuk_kirlilik", [-4.5, -2.5, 2, 4.5] },
                { "orta_kirlilik", [3, 5, 7] },
                { "buyuk_kirlilik", [5.5, 8, 12.5, 15] },

                //DONUS HIZI
                { "hassas_donusHizi", [-5.8, -2.8, 0.5, 1.5] },
                { "normal_hassas_donusHizi", [0.5, 2.75, 5] },
                { "orta_donusHizi", [2.75, 5, 7.25] },
                { "normal_guclu_donusHizi", [5, 7.25, 9.5] },
                { "guclu_donusHizi", [8.5, 9.5, 12.8, 15.2] },

                //SURE
                { "kisa_sure", [-46.5, -25.28, 22.3, 39.9] },
                { "normal_kisa_sure", [22.3, 39.9, 57.5] },
                { "orta_sure", [39.9, 57.5, 75.1] },
                { "normal_uzun_sure", [57.5, 75.1, 92.7] },
                { "uzun_sure", [75, 92.7, 111.6, 130] },

                //DETERJAN
                { "cok_az_deterjan", [0, 0, 20, 85] },
                { "az_deterjan", [20, 85, 150] },
                { "orta_deterjan", [85, 150, 215] },
                { "fazla_deterjan", [150, 215, 280] },
                { "cok_fazla_deterjan", [215, 280, 300, 300] },
            };
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            var rules =
                new List<(string Hassaslik, string Miktar, string Kirlilik, string DonusHizi, string Sure, string
                    Deterjan)>
                {
                    ("hassas_hassaslik", "kucuk_miktar", "kucuk_kirlilik", "hassas_donusHizi", "kisa_sure",
                        "cok_az_deterjan"),
                    ("hassas_hassaslik", "kucuk_miktar", "orta_kirlilik", "normal_hassas_donusHizi", "kisa_sure",
                        "az_deterjan"),
                    ("hassas_hassaslik", "kucuk_miktar", "buyuk_kirlilik", "orta_donusHizi", "normal_kisa_sure",
                        "orta_deterjan"),
                    ("hassas_hassaslik", "orta_miktar", "kucuk_kirlilik", "hassas_donusHizi", "kisa_sure",
                        "orta_deterjan"),
                    ("hassas_hassaslik", "orta_miktar", "orta_kirlilik", "normal_hassas_donusHizi", "normal_kisa_sure",
                        "orta_deterjan"),
                    ("hassas_hassaslik", "orta_miktar", "buyuk_kirlilik", "orta_donusHizi", "orta_sure",
                        "fazla_deterjan"),
                    ("hassas_hassaslik", "buyuk_miktar", "kucuk_kirlilik", "normal_hassas_donusHizi",
                        "normal_kisa_sure", "orta_deterjan"),
                    ("hassas_hassaslik", "buyuk_miktar", "orta_kirlilik", "normal_hassas_donusHizi", "orta_sure",
                        "fazla_deterjan"),
                    ("hassas_hassaslik", "buyuk_miktar", "buyuk_kirlilik", "orta_donusHizi", "normal_uzun_sure",
                        "fazla_deterjan"),
                    ("orta_hassaslik", "kucuk_miktar", "kucuk_kirlilik", "normal_hassas_donusHizi", "normal_kisa_sure",
                        "az_deterjan"),
                    ("orta_hassaslik", "kucuk_miktar", "orta_kirlilik", "orta_donusHizi", "kisa_sure", "orta_deterjan"),
                    ("orta_hassaslik", "kucuk_miktar", "buyuk_kirlilik", "normal_guclu_donusHizi", "orta_sure",
                        "fazla_deterjan"),
                    ("orta_hassaslik", "orta_miktar", "kucuk_kirlilik", "normal_hassas_donusHizi", "normal_kisa_sure",
                        "orta_deterjan"),
                    ("orta_hassaslik", "orta_miktar", "orta_kirlilik", "orta_donusHizi", "orta_sure", "orta_deterjan"),
                    ("orta_hassaslik", "orta_miktar", "buyuk_kirlilik", "hassas_donusHizi", "uzun_sure",
                        "fazla_deterjan"),
                    ("orta_hassaslik", "buyuk_miktar", "kucuk_kirlilik", "hassas_donusHizi", "orta_sure",
                        "orta_deterjan"),
                    ("orta_hassaslik", "buyuk_miktar", "orta_kirlilik", "hassas_donusHizi", "normal_uzun_sure",
                        "fazla_deterjan"),
                    ("orta_hassaslik", "buyuk_miktar", "buyuk_kirlilik", "hassas_donusHizi", "uzun_sure",
                        "cok_fazla_deterjan"),
                    ("saglam_hassaslik", "kucuk_miktar", "kucuk_kirlilik", "orta_donusHizi", "orta_sure",
                        "az_deterjan"),
                    ("saglam_hassaslik", "kucuk_miktar", "orta_kirlilik", "normal_guclu_donusHizi", "orta_sure",
                        "orta_deterjan"),
                    ("saglam_hassaslik", "kucuk_miktar", "buyuk_kirlilik", "guclu_donusHizi", "normal_uzun_sure",
                        "fazla_deterjan"),
                    ("saglam_hassaslik", "orta_miktar", "kucuk_kirlilik", "orta_donusHizi", "orta_sure",
                        "orta_deterjan"),
                    ("saglam_hassaslik", "orta_miktar", "orta_kirlilik", "normal_guclu_donusHizi", "normal_uzun_sure",
                        "orta_deterjan"),
                    ("saglam_hassaslik", "orta_miktar", "buyuk_kirlilik", "guclu_donusHizi", "orta_sure",
                        "cok_fazla_deterjan"),
                    ("saglam_hassaslik", "buyuk_miktar", "kucuk_kirlilik", "normal_guclu_donusHizi", "normal_uzun_sure",
                        "fazla_deterjan"),
                    ("saglam_hassaslik", "buyuk_miktar", "orta_kirlilik", "normal_guclu_donusHizi", "uzun_sure",
                        "fazla_deterjan"),
                    ("saglam_hassaslik", "buyuk_miktar", "buyuk_kirlilik", "guclu_donusHizi", "uzun_sure",
                        "cok_fazla_deterjan")
                };


            dataGridView.Rows.Clear();

            int rowIndex = 1;
            foreach (var rule in rules)
            {
                dataGridView.Rows.Add(rowIndex, rule.Hassaslik, rule.Miktar, rule.Kirlilik, rule.DonusHizi, rule.Sure,
                    rule.Deterjan);
                rowIndex++;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ProcessFuzzyLogic();
        }

        private double CalculateMembership(double value, string setName)
        {
            if (!fuzzyRanges.ContainsKey(setName))
                return 0;

            var points = fuzzyRanges[setName];

            if (points.Length == 3)
            {
                // ��gen �yelik
                double a = points[0];
                double b = points[1];
                double c = points[2];

                if (value <= a || value >= c)
                    return 0;
                else if (value == b)
                    return 1;
                else if (value < b)
                    return (value - a) / (b - a);
                else
                    return (c - value) / (c - b);
            }
            else if (points.Length == 4)
            {
                // Yamuk �yelik
                double a = points[0];
                double b = points[1];
                double c = points[2];
                double d = points[3];

                if (value <= a || value >= d)
                    return 0;
                else if (value >= b && value <= c)
                    return 1;
                else if (value > a && value < b)
                    return (value - a) / (b - a);
                else // value > c && value < d
                    return (d - value) / (d - c);
            }

            return 0;
        }


        private List<(string SetName, double Value)> Fuzzify(double value, string[] sets, string category)
        {
            var memberships = new List<(string SetName, double Value)>();

            foreach (var set in sets)
            {
                double membership = CalculateMembership(value, set);

                if (membership > 0)
                {
                    memberships.Add((set, membership));
                }
            }

            return memberships;
        }


        private void ProcessFuzzyLogic()
        {
            double hassaslik = (double)numericUpDown1.Value;
            double miktar = (double)numericUpDown2.Value;
            double kirlilik = (double)numericUpDown3.Value;

            string[] hassaslikSets = { "hassas_hassaslik", "orta_hassaslik", "saglam_hassaslik" };
            string[] miktarSets = { "kucuk_miktar", "orta_miktar", "buyuk_miktar" };
            string[] kirlilikSets = { "kucuk_kirlilik", "orta_kirlilik", "buyuk_kirlilik" };

            var hassaslikMemberships = Fuzzify(hassaslik, hassaslikSets, "Hassaslik");
            var miktarMemberships = Fuzzify(miktar, miktarSets, "Miktar");
            var kirlilikMemberships = Fuzzify(kirlilik, kirlilikSets, "Kirlilik");


            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Style.BackColor = Color.White;
                }
            }

            var ruleStrengths = new Dictionary<int, double>();
            var donusHiziOutput = new Dictionary<string, double>();
            var sureOutput = new Dictionary<string, double>();
            var deterjanOutput = new Dictionary<string, double>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Index >= 0 && row.Cells[0].Value != null)
                {
                    string rowHassaslik = row.Cells[1].Value.ToString();
                    string rowMiktar = row.Cells[2].Value.ToString();
                    string rowKirlilik = row.Cells[3].Value.ToString();
                    
                    double hassaslikMembership = GetMembershipValue(hassaslikMemberships, rowHassaslik);
                    double miktarMembership = GetMembershipValue(miktarMemberships, rowMiktar);
                    double kirlilikMembership = GetMembershipValue(kirlilikMemberships, rowKirlilik);
                    
                    if (hassaslikMembership <= 0 || miktarMembership <= 0 || kirlilikMembership <= 0)
                        continue;

                    double ruleStrength = Math.Min(Math.Min(hassaslikMembership, miktarMembership), kirlilikMembership);
                    ruleStrengths[row.Index] = ruleStrength;

                    row.Cells[1].Style.BackColor = Color.LightYellow;
                    row.Cells[2].Style.BackColor = Color.LightYellow;
                    row.Cells[3].Style.BackColor = Color.LightYellow;

                    string donusHizi = row.Cells[4].Value.ToString();
                    string sure = row.Cells[5].Value.ToString();
                    string deterjan = row.Cells[6].Value.ToString();

                    if (!donusHiziOutput.ContainsKey(donusHizi) || donusHiziOutput[donusHizi] < ruleStrength)
                        donusHiziOutput[donusHizi] = ruleStrength;

                    if (!sureOutput.ContainsKey(sure) || sureOutput[sure] < ruleStrength)
                        sureOutput[sure] = ruleStrength;

                    if (!deterjanOutput.ContainsKey(deterjan) || deterjanOutput[deterjan] < ruleStrength)
                        deterjanOutput[deterjan] = ruleStrength;
                }
            }

            double donusHiziResult = WeightedAverageDefuzzify(donusHiziOutput);
            double sureResult = WeightedAverageDefuzzify(sureOutput);
            double deterjanResult = WeightedAverageDefuzzify(deterjanOutput);

            lblDonusHiziSonuc.Text = donusHiziResult.ToString("F2");
            lblSureSonuc.Text = sureResult.ToString("F2");
            lblDeterjanSonuc.Text = deterjanResult.ToString("F2");
        }


        private double GetMembershipValue(List<(string SetName, double Value)> memberships, string setName)
        {
            var found = memberships.FirstOrDefault(m => m.SetName == setName);
            return found.Equals(default((string, double))) ? 0 : found.Value;
        }


        private double WeightedAverageDefuzzify(Dictionary<string, double> outputSets)
        {
            double numerator = 0;
            double denominator = 0;

            foreach (var set in outputSets)
            {
                double centerOfSet = GetCenterOfSet(set.Key);
                numerator += centerOfSet * set.Value;
                denominator += set.Value;
            }

            return denominator == 0 ? 0 : numerator / denominator;
        }

        private double GetCenterOfSet(string setName)
        {
            if (!fuzzyRanges.ContainsKey(setName))
                return 5; 

            var points = fuzzyRanges[setName];

            if (points.Length == 3)
            {
                return points[1];
            }
            if (points.Length == 4)
            {
                return (points[1] + points[2]) / 2;
            }
            return 1;
        }
    }
}