using System;
using System.Security.Cryptography.X509Certificates;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;// Klavye olaylar�n� Form �zerinde yakalamak i�in.

            // Formun boyutlar�n� ve minimum boyutunu ayarlama
            this.Width = 350;
            this.Height = 500;
            this.MinimumSize = new Size(340, 430);

            // Form i�indeki layout panellerin boyutunu dinamik olarak ayarlama
            tableLayoutPanel1.Height = (int)(this.Height * 0.70);
            tableLayoutPanel2.Height = this.ClientSize.Height - tableLayoutPanel1.Height;

            // Yaz� tiplerinin boyutlar�n� ayarlama
            float fontSize = this.Height * 0.06f;
            lblText.Font = new Font(lblText.Font.FontFamily, fontSize);

            float fontSize1 = this.Height * 0.03f;
            lblText1.Font = new Font(lblText1.Font.FontFamily, fontSize1);
            lblText1.ForeColor = Color.FromArgb(128, 169, 169, 169);// lblText1 i�in gri tonlu renk ayar�

            // T�m say� ve i�lem butonlar�na t�klama olaylar�n� atama
            button0.Click += ButtonClickHandler;
            button1.Click += ButtonClickHandler;
            button2.Click += ButtonClickHandler;
            button3.Click += ButtonClickHandler;
            button4.Click += ButtonClickHandler;
            button5.Click += ButtonClickHandler;
            button6.Click += ButtonClickHandler;
            button7.Click += ButtonClickHandler;
            button8.Click += ButtonClickHandler;
            button9.Click += ButtonClickHandler;
            // ��lem butonlar� i�in ayr� bir handler
            btnAdd.Click += ButtonClickHandler1;
            btnDivision.Click += ButtonClickHandler1;
            btnMultiplication.Click += ButtonClickHandler1;
            btnSubtraction.Click += ButtonClickHandler1;

            // Aray�z renklerini ayarlama
            this.BackColor = ColorTranslator.FromHtml("#202020");
            this.ForeColor = Color.Black;
            this.Text = "Calculator";
            //this.Icon = new Icon("icon.ico");


            lblText.BackColor = ColorTranslator.FromHtml("#202020");
            lblText1.BackColor = ColorTranslator.FromHtml("#202020");
            button0.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button1.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button2.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button3.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button4.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button5.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button6.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button7.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button8.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            button9.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            btnDecimal.BackColor = ColorTranslator.FromHtml("#3b3b3b");
            btnToggleSign.BackColor = ColorTranslator.FromHtml("#323232");
            btnAdd.BackColor = ColorTranslator.FromHtml("#323232");
            btnSubtraction.BackColor = ColorTranslator.FromHtml("#323232");
            btnDivision.BackColor = ColorTranslator.FromHtml("#323232");
            btnMultiplication.BackColor = ColorTranslator.FromHtml("#323232");
            btnEqual.BackColor = ColorTranslator.FromHtml("#323232");
            btnReciprocal.BackColor = ColorTranslator.FromHtml("#323232");
            btnClear.BackColor = ColorTranslator.FromHtml("#323232");
            btnClearEntry.BackColor = ColorTranslator.FromHtml("#323232");
            btnBackspace.BackColor = ColorTranslator.FromHtml("#323232");
            bntSquare.BackColor = ColorTranslator.FromHtml("#323232");
            bntSquareRoot.BackColor = ColorTranslator.FromHtml("#323232");
        }

        bool isClick = false; // Hesapla butonuna bas�ld� m�?
        double result; // Hesaplama sonucunu saklar
        String num1String; // �lk say� string format�nda
        String num2String; // �kinci say� string format�nda
        char currentOperator; // �u anki i�lemci operat�r (+, -, x, /)

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (this.ActiveControl != btnEqual) btnEqual.Focus();
                    btnEqual.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    button0.PerformClick();
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    button1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    button2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    button3.PerformClick();
                    break;
                case Keys.D4:
                    if (e.Shift) btnAdd.PerformClick();
                    else button4.PerformClick(); break;
                case Keys.D5:
                case Keys.NumPad5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    if (e.Shift) btnMultiplication.PerformClick();
                    else button6.PerformClick();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    button7.PerformClick();
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    button8.PerformClick();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    button9.PerformClick();
                    break;
                case Keys.Back:
                    btnBackspace.PerformClick();
                    break;
                case Keys.Delete:
                    btnClear.PerformClick();
                    break;
                case Keys.OemMinus:
                    btnSubtraction.PerformClick();
                    break;
                case Keys.OemQuestion:
                    btnDivision.PerformClick();
                    break;
            }
        }

        // Form yeniden boyutland�r�ld���nda boyut ve fontlar� g�ncelle
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Height = (int)(this.Height * 0.70);
            tableLayoutPanel2.Height = this.ClientSize.Height - tableLayoutPanel1.Height;

            float fontSize = this.Height * 0.06f;
            lblText.Font = new Font(lblText.Font.FontFamily, fontSize);

            float fontSize1 = this.Height * 0.03f;
            lblText1.Font = new Font(lblText1.Font.FontFamily, fontSize1);
        }

        // Yaz� ekleme fonksiyonu
        private void AddText(String newText)
        {
            lblText.Text += newText;
        }

        private void UpdateText()
        {
            int charCount = lblText.Text.Length;

            // Grafik nesnesi olu�tur, metnin geni�li�ini hesaplamak i�in
            using (Graphics g = lblText.CreateGraphics())
            {
                // �u anki font ile metnin geni�li�ini �l�
                SizeF textSize = g.MeasureString(lblText.Text, lblText.Font);

                // E�er metnin geni�li�i maksimum geni�li�i a�arsa
                if (charCount > 13)
                {
                    lblText.Text = lblText.Text.Substring(0, lblText.Text.Length - 1);
                }
            }
        }

        private void OverFlow()
        {
            if (!string.IsNullOrEmpty(lblText.Text)) // lblText bo� de�ilse devam et
            {
                if (double.TryParse(lblText.Text, out double lblTextCheck)) // lblText double'a d�n��t�r�lebiliyorsa lblTextCheck'e atayacak.
                {
                    if (double.IsInfinity(lblTextCheck)) // E�er double de�i�keni s�n�rlar� a�arsa
                    {
                        lblText.Text = "OverFlow";
                        DeactivateAllButtonsExcept(btnClear, btnClear);
                    }
                }
            }
        }
        private void ButtonClickHandler(object? sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // T�klanan butonu al
            Char check = lblText.Text[0];
            if (lblText.Text.Length == 1)
            {
                if (check == '0') { lblText.Text = ""; }
            }
            string newText = clickedButton.Text.ToString();
            AddText(newText); // Butonun yaz�s�n� ekle
            isClick = false;  // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
            UpdateText();

        }

        private void ButtonClickHandler1(object? sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            String operation = clickedButton.Text.ToString(); // T�klanan butonun i�lemini al
            String text = lblText.Text;
            lblText1.Text = text + operation; // lblText1'e i�lemi yaz
            lblText.Text = "0"; // lblText'i s�f�rla
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        // Hesaplama i�lemi i�in bir metot
        private double Calculate(String num1String, String num2String, char operation)
        {
            double num1;
            double num2;
            num1String = num1String.Substring(0, num1String.Length - 1); // ��lem sembol�n� kald�r
            bool isValidDouble = double.TryParse(num1String, out num1); // Say�n�n ge�erli olup olmad���n� kontrol et
            num2 = Convert.ToDouble(num2String);
            // MessageBox.Show(num1.ToString() + num2.ToString());

            if (isValidDouble)
            {
                // ��lem t�r�ne g�re sonucu d�nd�r
                return operation switch
                {
                    '+' => num1 + num2,
                    '-' => num1 - num2,
                    'x' => num1 * num2,
                    '/' => num1 / num2,
                };
            }
            else return 0; // Ge�ersiz giri� durumu
        }

        private void DeactivateAllButtonsExcept(Button activeButton, Button activeButton1)
        {
            // TableLayoutPanel'deki t�m butonlar� devre d��� b�rak
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Sadece belirtilen iki buton aktif kals�n
                if (control is Button && control != activeButton && control != activeButton1)
                {
                    control.Enabled = false;
                }
            }
        }

        private void ActivateAllButtons()
        {
            // TableLayoutPanel'deki t�m butonlar� tekrar aktif et
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = true;
                }
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // �ki label'�n dolu olup olmad���n� kontrol et
            if (!string.IsNullOrEmpty(lblText.Text) && !string.IsNullOrEmpty(lblText1.Text))
            {
                if (isClick == true)
                {
                    // Daha �nce i�lem yap�lm��sa birinci say� ile i�lem yap
                    num1String = lblText.Text + " ";
                    result = Calculate(num1String, num2String, currentOperator); // Hesaplama fonksiyonu
                    lblText.Text = result.ToString();
                    lblText1.Text = num1String.Substring(0, num1String.Length - 1) + currentOperator + num2String + "="; // ��lem ge�mi�ini g�ncelle
                }
                else
                {
                    // �lk i�lem yap�lacaksa ikinci say�y� ve operat�r� belirle
                    num2String = lblText.Text;
                    num1String = lblText1.Text;
                    char lastChar = lblText1.Text[^1]; //^ i�areti sondan listeleme yapar.

                    // Operat�re g�re hesaplama yap
                    if (lastChar == '+')
                    {
                        result = Calculate(num1String, num2String, '+');
                        lblText.Text = result.ToString();
                        currentOperator = '+';
                        lblText1.Text = num1String + num2String + "=";
                    }
                    else if (lastChar == '-')
                    {
                        result = Calculate(num1String, num2String, '-');
                        lblText.Text = result.ToString();
                        currentOperator = '-';
                        lblText1.Text = num1String + num2String + "=";
                    }
                    else if (lastChar == 'x')
                    {
                        result = Calculate(num1String, num2String, 'x');
                        lblText.Text = result.ToString();
                        currentOperator = 'x';
                        lblText1.Text = num1String + num2String + "=";
                    }
                    else
                    {
                        // B�lme i�lemi s�ras�nda ikinci say� s�f�r olursa
                        if (num2String == "0")
                        {
                            DeactivateAllButtonsExcept(btnClear, btnClearEntry); // Sadece temizleme butonlar�n� aktif b�rak
                            lblText.Text = "Cannot divide by 0"; // Hata mesaj�
                        }
                        else
                        {
                            result = Calculate(num1String, num2String, '/');
                            lblText.Text = result.ToString();
                            currentOperator = '/';
                            lblText1.Text = num1String + num2String + "=";
                        }
                    }

                }

            }
            isClick = true; // Hesaplaya bir kez bas�ld���n� i�aretle
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ActivateAllButtons(); // T�m butonlar� aktif et
            lblText.Text = "0"; // Ekran� s�f�rla
            lblText1.Text = ""; // ��lem ge�mi�ini temizle
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            ActivateAllButtons();
            lblText.Text = "0"; // Ekran� s�f�rla
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblText.Text.Length == 1) // Tek haneli bir say�ysa
            {
                lblText.Text = "0"; // Ekran� s�f�rla
            }
            else
            {
                if (lblText.Text != result.ToString()) // Sonu� de�ilse
                {
                    String oldText = lblText.Text;
                    String newText = oldText.Substring(0, oldText.Length - 1); // Son karakteri sil
                    lblText.Text = newText;
                }
                else
                {
                    lblText1.Text = ""; // ��lem ge�mi�ini temizle
                    lblText.Text = "0"; // Ekran� s�f�rla
                }
            }
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            if (lblText.Text != "0") // S�f�r de�ilse i�aret de�i�tir
            {
                Char condition = lblText.Text[0];
                if (condition == '-') // say� zaten negatif ise
                {
                    lblText.Text = lblText.Text.Substring(1); // Negatif i�areti kald�r
                }
                else // Say� pozitif ise
                {
                    lblText.Text = "-" + lblText.Text; // Negatif i�areti ekle
                }
            }
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void bntSquareRoot_Click(object sender, EventArgs e)
        {
            double rootNum = Convert.ToDouble(lblText.Text); // Say�y� al
            if (rootNum < 0) // Negatif say�ysa
            {
                DeactivateAllButtonsExcept(btnClear, btnClear); // Butonlar� devre d��� b�rak
                lblText1.Text = lblText.Text; // Ekrandaki say�y� i�lem ge�mi�ine koy
                lblText.Text = "Invalid Input"; // Hata mesaj� ver
            }
            else
            {
                double rootResult = Math.Sqrt(rootNum); // Karek�k hesapla
                lblText1.Text = "\u221A" + rootNum + "="; // ��lem ge�mi�ini g�ncelle
                lblText.Text = rootResult.ToString(); // Sonucu g�ster
                isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            }
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void bntSquare_Click(object sender, EventArgs e)
        {
            double squareNum = Convert.ToDouble(lblText.Text); // Say�y� al
            double squareResult = Math.Pow(squareNum, 2); // Karesini hesapla
            lblText1.Text = "sqr(" + squareNum + ")"; // ��lem ge�mi�ini g�ncelle
            lblText.Text = squareResult.ToString(); // Sonucu g�ster
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(lblText.Text); // Say�y� al
            double resultNumber = 1 / number; // Kar��t�n� hesapla
            lblText1.Text = "1/(" + number + ")"; // ��lem ge�mi�ini g�ncelle
            lblText.Text = resultNumber.ToString(); // Sonucu g�ster
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!lblText.Text.Contains(".")) // Nokta i�eriyor mu kontrol et
            {
                string newText = btnDecimal.Text.ToString(); // Noktay� ekle
                AddText(newText); // Metni g�ncelle
            }
            isClick = false; // Hesapla butonuna bas�lmad� olarak i�aretle
            this.ActiveControl = null; // Oda�� s�f�rla
            UpdateText();
        }

        private void lblText_TextChanged(object sender, EventArgs e)
        {
            OverFlow();
        }
    }
}
