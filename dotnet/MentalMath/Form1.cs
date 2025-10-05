using System;
using System.Windows.Forms;

namespace MentalMath
{
    public partial class Form1 : Form
    {
        private readonly Random _rng = new Random();
        private int _left, _right;
        private char _op;
        private int _correct, _total;

        public Form1()
        {
            InitializeComponent();
            // sensible defaults if you added optional controls
            if (cmbOps != null)
            {
                cmbOps.Items.Clear();
                cmbOps.Items.AddRange(["+", "-", "×", "÷", "Mix"]);
                cmbOps.SelectedIndex = 4; // Mix
            }
            if (numMax != null)
            {
                numMax.Minimum = 5;
                numMax.Maximum = 1000;
                numMax.Value = 10;
            }

            KeyPreview = true; // allow Enter/Space shortcuts
            NewQuestion();
        }

        private void NewQuestion()
        {
            int max = numMax != null ? (int)numMax.Value : 10;
            char op = GetSelectedOperator();

            if (op == '?') // Mix
            {
                char[] ops = { '+', '-', '×', '÷' };
                op = ops[_rng.Next(ops.Length)];
            }
            _op = op;

            // pick operands
            switch (_op)
            {
                case '+':
                    _left = _rng.Next(0, max + 1);
                    _right = _rng.Next(0, max + 1);
                    break;
                case '-':
                    _left = _rng.Next(0, max + 1);
                    _right = _rng.Next(0, max + 1);
                    if (_right > _left) (_left, _right) = (_right, _left); // avoid negatives for beginners
                    break;
                case '×':
                    _left = _rng.Next(0, max + 1);
                    _right = _rng.Next(0, max + 1);
                    break;
                case '÷':
                    // ensure clean integer division: pick result and divisor, then multiply
                    int result = _rng.Next(1, Math.Max(2, max)); // 1..max-1
                    _right = _rng.Next(1, Math.Max(2, max));     // divisor
                    _left = result * _right;                     // dividend
                    break;
            }

            lblQuestion.Text = $"{_left} {_op} {_right} = ?";
            lblFeedback.Text = "";
            txtAnswer.Text = "";
            txtAnswer.Focus();
        }

        private char GetSelectedOperator()
        {
            if (cmbOps == null) return '?';
            string sel = cmbOps.SelectedItem?.ToString() ?? "Mix";
            return sel switch
            {
                "+" => '+',
                "-" => '-',
                "×" => '×',
                "÷" => '÷',
                _ => '?', // Mix
            };
        }

        private double CorrectAnswer()
        {
            return _op switch
            {
                '+' => _left + _right,
                '-' => _left - _right,
                '×' => _left * _right,
                '÷' => (double)_left / _right,
                _ => 0
            };
        }

        private void CheckAnswer()
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                lblFeedback.Text = "Type an answer.";
                return;
            }

            _total++;

            bool isCorrect = false;
            if (_op == '÷')
            {
                // allow decimal; treat small rounding as correct
                if (double.TryParse(txtAnswer.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double user))
                {
                    double correct = CorrectAnswer();
                    isCorrect = Math.Abs(user - correct) < 1e-6;
                }
            }
            else
            {
                if (int.TryParse(txtAnswer.Text, out int userInt))
                {
                    isCorrect = Math.Abs(userInt - CorrectAnswer()) < 1e-9;
                }
            }

            if (isCorrect) { _correct++; lblFeedback.Text = "✅ Correct!"; }
            else { lblFeedback.Text = $"❌ Oops. Correct: {CorrectAnswer()}"; }

            lblScore.Text = $"Score: {_correct}/{_total}";
        }

        // --- Event wiring ---

        private void btnCheck_Click(object sender, EventArgs e) => CheckAnswer();
        private void btnNext_Click(object sender, EventArgs e) => NewQuestion();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) { CheckAnswer(); return true; }
            if (keyData == Keys.Space) { NewQuestion(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
