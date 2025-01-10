using System;
using System.Security.Cryptography.X509Certificates;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;// Klavye olaylarýný Form üzerinde yakalamak için.

            // Formun boyutlarýný ve minimum boyutunu ayarlama
            this.Width = 350;
            this.Height = 500;
            this.MinimumSize = new Size(340, 430);

            // Form içindeki layout panellerin boyutunu dinamik olarak ayarlama
            tableLayoutPanel1.Height = (int)(this.Height * 0.70);
            tableLayoutPanel2.Height = this.ClientSize.Height - tableLayoutPanel1.Height;

            // Yazý tiplerinin boyutlarýný ayarlama
            float fontSize = this.Height * 0.06f;
            lblText.Font = new Font(lblText.Font.FontFamily, fontSize);

            float fontSize1 = this.Height * 0.03f;
            lblText1.Font = new Font(lblText1.Font.FontFamily, fontSize1);
            lblText1.ForeColor = Color.FromArgb(128, 169, 169, 169);// lblText1 için gri tonlu renk ayarý

            // Tüm sayý ve iþlem butonlarýna týklama olaylarýný atama
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
            // Ýþlem butonlarý için ayrý bir handler
            btnAdd.Click += ButtonClickHandler1;
            btnDivision.Click += ButtonClickHandler1;
            btnMultiplication.Click += ButtonClickHandler1;
            btnSubtraction.Click += ButtonClickHandler1;

            // Arayüz renklerini ayarlama
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

        bool isClick = false; // Hesapla butonuna basýldý mý?
        double result; // Hesaplama sonucunu saklar
        String num1String; // Ýlk sayý string formatýnda
        String num2String; // Ýkinci sayý string formatýnda
        char currentOperator; // Þu anki iþlemci operatör (+, -, x, /)

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

        // Form yeniden boyutlandýrýldýðýnda boyut ve fontlarý güncelle
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Height = (int)(this.Height * 0.70);
            tableLayoutPanel2.Height = this.ClientSize.Height - tableLayoutPanel1.Height;

            float fontSize = this.Height * 0.06f;
            lblText.Font = new Font(lblText.Font.FontFamily, fontSize);

            float fontSize1 = this.Height * 0.03f;
            lblText1.Font = new Font(lblText1.Font.FontFamily, fontSize1);
        }

        // Yazý ekleme fonksiyonu
        private void AddText(String newText)
        {
            lblText.Text += newText;
        }

        private void UpdateText()
        {
            int charCount = lblText.Text.Length;

            // Grafik nesnesi oluþtur, metnin geniþliðini hesaplamak için
            using (Graphics g = lblText.CreateGraphics())
            {
                // Þu anki font ile metnin geniþliðini ölç
                SizeF textSize = g.MeasureString(lblText.Text, lblText.Font);

                // Eðer metnin geniþliði maksimum geniþliði aþarsa
                if (charCount > 13)
                {
                    lblText.Text = lblText.Text.Substring(0, lblText.Text.Length - 1);
                }
            }
        }

        private void OverFlow()
        {
            if (!string.IsNullOrEmpty(lblText.Text)) // lblText boþ deðilse devam et
            {
                if (double.TryParse(lblText.Text, out double lblTextCheck)) // lblText double'a dönüþtürülebiliyorsa lblTextCheck'e atayacak.
                {
                    if (double.IsInfinity(lblTextCheck)) // Eðer double deðiþkeni sýnýrlarý aþarsa
                    {
                        lblText.Text = "OverFlow";
                        DeactivateAllButtonsExcept(btnClear, btnClear);
                    }
                }
            }
        }
        private void ButtonClickHandler(object? sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // Týklanan butonu al
            Char check = lblText.Text[0];
            if (lblText.Text.Length == 1)
            {
                if (check == '0') { lblText.Text = ""; }
            }
            string newText = clickedButton.Text.ToString();
            AddText(newText); // Butonun yazýsýný ekle
            isClick = false;  // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
            UpdateText();

        }

        private void ButtonClickHandler1(object? sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            String operation = clickedButton.Text.ToString(); // Týklanan butonun iþlemini al
            String text = lblText.Text;
            lblText1.Text = text + operation; // lblText1'e iþlemi yaz
            lblText.Text = "0"; // lblText'i sýfýrla
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        // Hesaplama iþlemi için bir metot
        private double Calculate(String num1String, String num2String, char operation)
        {
            double num1;
            double num2;
            num1String = num1String.Substring(0, num1String.Length - 1); // Ýþlem sembolünü kaldýr
            bool isValidDouble = double.TryParse(num1String, out num1); // Sayýnýn geçerli olup olmadýðýný kontrol et
            num2 = Convert.ToDouble(num2String);
            // MessageBox.Show(num1.ToString() + num2.ToString());

            if (isValidDouble)
            {
                // Ýþlem türüne göre sonucu döndür
                return operation switch
                {
                    '+' => num1 + num2,
                    '-' => num1 - num2,
                    'x' => num1 * num2,
                    '/' => num1 / num2,
                };
            }
            else return 0; // Geçersiz giriþ durumu
        }

        private void DeactivateAllButtonsExcept(Button activeButton, Button activeButton1)
        {
            // TableLayoutPanel'deki tüm butonlarý devre dýþý býrak
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Sadece belirtilen iki buton aktif kalsýn
                if (control is Button && control != activeButton && control != activeButton1)
                {
                    control.Enabled = false;
                }
            }
        }

        private void ActivateAllButtons()
        {
            // TableLayoutPanel'deki tüm butonlarý tekrar aktif et
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
            // Ýki label'ýn dolu olup olmadýðýný kontrol et
            if (!string.IsNullOrEmpty(lblText.Text) && !string.IsNullOrEmpty(lblText1.Text))
            {
                if (isClick == true)
                {
                    // Daha önce iþlem yapýlmýþsa birinci sayý ile iþlem yap
                    num1String = lblText.Text + " ";
                    result = Calculate(num1String, num2String, currentOperator); // Hesaplama fonksiyonu
                    lblText.Text = result.ToString();
                    lblText1.Text = num1String.Substring(0, num1String.Length - 1) + currentOperator + num2String + "="; // Ýþlem geçmiþini güncelle
                }
                else
                {
                    // Ýlk iþlem yapýlacaksa ikinci sayýyý ve operatörü belirle
                    num2String = lblText.Text;
                    num1String = lblText1.Text;
                    char lastChar = lblText1.Text[^1]; //^ iþareti sondan listeleme yapar.

                    // Operatöre göre hesaplama yap
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
                        // Bölme iþlemi sýrasýnda ikinci sayý sýfýr olursa
                        if (num2String == "0")
                        {
                            DeactivateAllButtonsExcept(btnClear, btnClearEntry); // Sadece temizleme butonlarýný aktif býrak
                            lblText.Text = "Cannot divide by 0"; // Hata mesajý
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
            isClick = true; // Hesaplaya bir kez basýldýðýný iþaretle
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ActivateAllButtons(); // Tüm butonlarý aktif et
            lblText.Text = "0"; // Ekraný sýfýrla
            lblText1.Text = ""; // Ýþlem geçmiþini temizle
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            ActivateAllButtons();
            lblText.Text = "0"; // Ekraný sýfýrla
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblText.Text.Length == 1) // Tek haneli bir sayýysa
            {
                lblText.Text = "0"; // Ekraný sýfýrla
            }
            else
            {
                if (lblText.Text != result.ToString()) // Sonuç deðilse
                {
                    String oldText = lblText.Text;
                    String newText = oldText.Substring(0, oldText.Length - 1); // Son karakteri sil
                    lblText.Text = newText;
                }
                else
                {
                    lblText1.Text = ""; // Ýþlem geçmiþini temizle
                    lblText.Text = "0"; // Ekraný sýfýrla
                }
            }
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            if (lblText.Text != "0") // Sýfýr deðilse iþaret deðiþtir
            {
                Char condition = lblText.Text[0];
                if (condition == '-') // sayý zaten negatif ise
                {
                    lblText.Text = lblText.Text.Substring(1); // Negatif iþareti kaldýr
                }
                else // Sayý pozitif ise
                {
                    lblText.Text = "-" + lblText.Text; // Negatif iþareti ekle
                }
            }
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void bntSquareRoot_Click(object sender, EventArgs e)
        {
            double rootNum = Convert.ToDouble(lblText.Text); // Sayýyý al
            if (rootNum < 0) // Negatif sayýysa
            {
                DeactivateAllButtonsExcept(btnClear, btnClear); // Butonlarý devre dýþý býrak
                lblText1.Text = lblText.Text; // Ekrandaki sayýyý iþlem geçmiþine koy
                lblText.Text = "Invalid Input"; // Hata mesajý ver
            }
            else
            {
                double rootResult = Math.Sqrt(rootNum); // Karekök hesapla
                lblText1.Text = "\u221A" + rootNum + "="; // Ýþlem geçmiþini güncelle
                lblText.Text = rootResult.ToString(); // Sonucu göster
                isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            }
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void bntSquare_Click(object sender, EventArgs e)
        {
            double squareNum = Convert.ToDouble(lblText.Text); // Sayýyý al
            double squareResult = Math.Pow(squareNum, 2); // Karesini hesapla
            lblText1.Text = "sqr(" + squareNum + ")"; // Ýþlem geçmiþini güncelle
            lblText.Text = squareResult.ToString(); // Sonucu göster
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(lblText.Text); // Sayýyý al
            double resultNumber = 1 / number; // Karþýtýný hesapla
            lblText1.Text = "1/(" + number + ")"; // Ýþlem geçmiþini güncelle
            lblText.Text = resultNumber.ToString(); // Sonucu göster
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!lblText.Text.Contains(".")) // Nokta içeriyor mu kontrol et
            {
                string newText = btnDecimal.Text.ToString(); // Noktayý ekle
                AddText(newText); // Metni güncelle
            }
            isClick = false; // Hesapla butonuna basýlmadý olarak iþaretle
            this.ActiveControl = null; // Odaðý sýfýrla
            UpdateText();
        }

        private void lblText_TextChanged(object sender, EventArgs e)
        {
            OverFlow();
        }
    }
}
