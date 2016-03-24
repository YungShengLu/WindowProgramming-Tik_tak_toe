using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74039025_W5 {
    public partial class Main : Form {
        Button[] btn_tale;
        int[] user = new int[3];
        int[] comp = new int[3];
        bool turn;

        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            // Set initial turn.
            turn = true;
            label_turn.Text = "O's turn.";

            // Set buttons.
            btn_tale = new Button[9];
            btn_tale[0] = btn_1_1;
            btn_tale[1] = btn_1_2;
            btn_tale[2] = btn_1_3;
            btn_tale[3] = btn_2_1;
            btn_tale[4] = btn_2_2;
            btn_tale[5] = btn_2_3;
            btn_tale[6] = btn_3_1;
            btn_tale[7] = btn_3_2;
            btn_tale[8] = btn_3_3;
        }

        private void button_Click(object sender, EventArgs e) {
            Button button = (Button)sender;
            button.Font = new Font("微軟正黑體", 30, FontStyle.Bold);
            button.TextAlign = ContentAlignment.MiddleCenter;

            if (button.Text != "O" && button.Text != "X") {
                if (turn == true) {
                    button.ForeColor = Color.Blue;
                    button.Text = "O";
                }
                else {
                    button.ForeColor = Color.Red;
                    button.Text = "X";
                }

                // Check current status.
                DialogResult restart;
                if (isFinished(btn_tale) > 0) {
                    label_turn.ForeColor = Color.Blue;
                    label_turn.Text = "O is win!";

                    restart = MessageBox.Show("O is win!", "Winning", MessageBoxButtons.YesNo);
                    if (restart == DialogResult.Yes) {
                        label_turn.Text = "O's turn.";
                        for (int i = 0; i < 9; ++i)
                            btn_tale[i].Text = "";
                    }
                }
                else if (isFinished(btn_tale) < 0) {
                    label_turn.ForeColor = Color.Red;
                    label_turn.Text = "X is win!";

                    restart = MessageBox.Show("X is win!", "Winning", MessageBoxButtons.YesNo);
                    if (restart == DialogResult.Yes) {
                        label_turn.Text = "X's turn.";
                        for (int i = 0; i < 9; ++i)
                            btn_tale[i].Text = "";
                    }
                }
                else {
                    // Set next player's turn.
                    setTurn(ref turn);

                    if (turn == true) {
                        label_turn.ForeColor = Color.Blue;
                        label_turn.Text = "O's turn.";
                    }
                    else {
                        label_turn.ForeColor = Color.Red;
                        label_turn.Text = "X's turn.";
                    }
                }
            }
            else {
                MessageBox.Show("You cannot click here!", "Error", MessageBoxButtons.OK);
            }
        }

        // Set the next player's turn.
        private void setTurn(ref bool turn) {
            if (turn == false)
                turn = true;
            else
                turn = false;
        }

        private int isFinished(Button[] curr) {
            for (int i = 0; i < 3; ++i) {
                // Check row line.
                if (curr[i * 3].Text == curr[i * 3 + 1].Text && curr[i * 3 + 1].Text == curr[i * 3 + 2].Text) {
                    if (string.Compare(curr[i * 3].Text, "O", true) == 0)
                        return 1;
                    else if (string.Compare(curr[i * 3].Text, "X", true) == 0)
                        return -1;
                }

                // Check col line.
                if (curr[i].Text == curr[1 * 3 + i].Text && curr[1 * 3 + i].Text == curr[2 * 3 + i].Text) {
                    if (string.Compare(curr[i].Text, "O", true) == 0)
                        return 1;
                    else if (string.Compare(curr[i].Text, "X", true) == 0)
                        return -1;
                }
            }

            // Check diag line.
            if (curr[0].Text == curr[4].Text && curr[4].Text == curr[8].Text) {
                if (string.Compare(curr[4].Text, "O", true) == 0)
                    return 1;
                else if (string.Compare(curr[4].Text, "X", true) == 0)
                    return -1;
            }
            else if (curr[2].Text == curr[4].Text && curr[4].Text == curr[6].Text) {
                if (string.Compare(curr[4].Text, "O", true) == 0)
                    return 1;
                else if (string.Compare(curr[4].Text, "X", true) == 0)
                    return -1;
            }

            return 0;
        }

        // Restart.
        private void button10_Click(object sender, EventArgs e) {
            DialogResult restart = MessageBox.Show("Are you sure to restart?", "Restart", MessageBoxButtons.YesNo);

            if (restart == DialogResult.Yes) {
                for (int i = 0; i < 9; ++i)
                    btn_tale[i].Text = "";
            }

            turn = true;
        }
    }
}
