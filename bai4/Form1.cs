using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString();
            string sdt = txtSDT.Text;
            string gioitinh = "";
            int err = 0;
            if(hoTen == "")
            {
                lblHoTen.ForeColor = Color.Red;
                lblHoTen.Text = "Họ tên không được bỏ trống";
                err++;
            }else
            {
                string str = txtHoTen.Text.Trim();
                Regex trimmer = new Regex(@"\s\s+");
                str = trimmer.Replace(str, " ");
                string[] arrString = str.Split(' ');
                if(arrString.Length < 2)
                {
                    lblHoTen.ForeColor = Color.Red;
                    lblHoTen.Text = "Họ tên phải có ít nhất 2 từ";
                }
                else
                {
                    lblHoTen.ForeColor = Color.Green;
                    lblHoTen.Text = "OK!!!";
                }
                
            }
            if(sdt == "")
            {
                lblSDT.ForeColor = Color.Red;
                lblSDT.Text = "Số điện thoại không được bỏ trống";
                err++;
            }else if(sdt.Length != 10)
            {
                lblSDT.ForeColor = Color.Red;
                lblSDT.Text = "Số điện thoại phải có 10 số";
                err++;
            }
            else
            {
                lblSDT.ForeColor = Color.Green;
                lblSDT.Text = "OK!!!";
            }
            if(cbxNam.Checked == false && cbxNu.Checked == false)
            {
                lblGioiTinh.ForeColor = Color.Red;
                lblGioiTinh.Text = "Bạn phải check nam hoặc nữ";
                err++;
            }
            else
            {
                lblGioiTinh.Text = "";
            }
            if(err == 0)
            {
                if(cbxNam.Checked == true)
                {
                    gioitinh += cbxNam.Text;
                }
                else
                {
                    gioitinh += cbxNu.Text;
                }
                string chuoi = "Họ Tên: " + hoTen + "\n" + "Ngày Sinh: " + ngaySinh + "\n" + " SĐT: " + sdt + "\n" + "Giới Tính: " + gioitinh;
                MessageBox.Show(chuoi, "Kết Quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblGioiTinh.Text = "";lblHoTen.Text = "";lblSDT.Text = "";
        }

        private void cbxNam_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxNam.CheckState == CheckState.Checked)
            {
                cbxNu.Checked = false;
                cbxNu.CheckState = CheckState.Unchecked;
            }

            if (cbxNam.Checked == false && cbxNu.Checked == false)
            {
                lblGioiTinh.ForeColor = Color.Red;
                lblGioiTinh.Text = "Bạn phải check nam hoặc nữ";
            }
            else
            {
                lblGioiTinh.Text = "";
            }
        }

        private void cbxNu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNu.CheckState == CheckState.Checked)
            {
                cbxNam.Checked = false;
                cbxNam.CheckState = CheckState.Unchecked;
            }
            if (cbxNam.Checked == false && cbxNu.Checked == false)
            {
                lblGioiTinh.ForeColor = Color.Red;
                lblGioiTinh.Text = "Bạn phải check nam hoặc nữ";
            }
            else
            {
                lblGioiTinh.Text = "";
            }
        }

        private void HoTen_Changed(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                lblHoTen.ForeColor = Color.Red;
                lblHoTen.Text = "Họ tên không được bỏ trống";
            }
            else
            {
                string str = txtHoTen.Text.Trim();
                Regex trimmer = new Regex(@"\s\s+");
                str = trimmer.Replace(str, " ");
                string[] arrString = str.Split(' ');
                if(arrString.Length < 2)
                {
                    lblHoTen.ForeColor = Color.Red;
                    lblHoTen.Text = "Họ tên phải có ít nhất 2 từ";
                }
                else
                {
                    lblHoTen.ForeColor = Color.Green;
                    lblHoTen.Text = "OK!!!";
                }
               
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isBackspace = e.KeyChar == '\b';
            if (!char.IsDigit(e.KeyChar) && !isBackspace)
            {
                e.Handled = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if(txtSDT.Text == "")
            {
                lblSDT.ForeColor = Color.Red;
                lblSDT.Text = "Số điện thoại không được bỏ trống";
            }else if(txtSDT.Text.Length != 10)
            {
                lblSDT.ForeColor = Color.Red;
                lblSDT.Text = "";
            }
            else
            {
                lblSDT.ForeColor = Color.Green;
                lblSDT.Text = "Số điện thoại hợp lệ";
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isBackspace = e.KeyChar == '\b';
            if (!char.IsLetter(e.KeyChar) && !isBackspace && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
