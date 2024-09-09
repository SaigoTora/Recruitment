using System.Windows.Forms;

namespace RecruitmentLibrary.FormUtilities
{
    public class Creator
    {// Клас, який створює елементи форми за зразком
        public Panel MainPanel { get; private set; }// Панель для елементів
        public int Number { get; set; }// Номер для префіксу назви

        public Creator(Panel panel, Control parent, int number, bool visible = true)
        {// Конструктор
            Number = number;
            MainPanel = CreateControl(panel);
            MainPanel.Visible = visible;
            parent.Controls.Add(MainPanel);
        }

        private T CreateControl<T>(T sample) where T : Control, new()
        {// Метод створює базовий клас Control за зразком
            T control = new T()
            {
                Name = sample.Name + Number,
                Location = sample.Location,
                Size = sample.Size,
                BackColor = sample.BackColor,
                ForeColor = sample.ForeColor,
                Font = sample.Font,
                Anchor = sample.Anchor
            };
            MainPanel?.Controls.Add(control);

            return control;
        }

        public Label CreateLabel(Label sample, string text = null)
        {// Метод створює об'єкт класу Label
            Label label = CreateControl(sample);
            label.AutoSize = sample.AutoSize;
            label.Size = sample.Size;
            label.TextAlign = sample.TextAlign;
            label.AutoEllipsis = sample.AutoEllipsis;
            if (text == null) label.Text = sample.Text;
            else label.Text = text;

            return label;
        }
        public TextBox CreateTextBox(TextBox sample)
        {// Метод створює об'єкт класу TextBox
            TextBox textBox = CreateControl(sample);
            textBox.MaxLength = sample.MaxLength;

            return textBox;
        }
        public Button CreateButton(Button sample)
        {
            Button button = CreateControl(sample);
            button.FlatStyle = sample.FlatStyle;
            button.Text = sample.Text;
            button.Cursor = sample.Cursor;

            return button;
        }

        public NumericUpDown CreateNumericUpDown(NumericUpDown sample)
        {// Метод створює об'єкт класу NumericUpDown
            NumericUpDown NUD = CreateControl(sample);
            NUD.Minimum = sample.Minimum;
            NUD.Maximum = sample.Maximum;

            return NUD;
        }
        public ComboBox CreateComboBox(ComboBox sample, int selectedIndex = 0)
        {// Метод створює об'єкт класу ComboBox
            ComboBox CB = CreateControl(sample);
            foreach (string item in sample.Items)// Додаємо елементи комбобоксу
                CB.Items.Add(item);
            CB.SelectedIndex = selectedIndex;// Вибираємо потрібний елемент
            CB.DropDownStyle = sample.DropDownStyle;
            CB.Cursor = sample.Cursor;
            CB.IntegralHeight = sample.IntegralHeight;
            CB.MaxDropDownItems = sample.MaxDropDownItems;

            return CB;
        }
        public DateTimePicker CreateDateTimePicker(DateTimePicker sample)
        {// Метод створює об'єкт класу DateTimePicker
            DateTimePicker DTP = CreateControl(sample);
            DTP.CalendarFont = sample.CalendarFont;
            DTP.MinDate = sample.MinDate;
            DTP.MaxDate = sample.MaxDate;
            DTP.DropDownAlign = sample.DropDownAlign;

            return DTP;
        }
        public PictureBox CreatePictureBox(PictureBox sample)
        {// Метод створює об'єкт класу PictureBox
            PictureBox pictureBox = CreateControl(sample);
            pictureBox.Image = sample.Image;

            return pictureBox;
        }
        public CheckBox CreateCheckBox(CheckBox sample)
        {// Метод створює об'єкт класу CheckBox
            CheckBox checkBox = CreateControl(sample);
            checkBox.Checked = sample.Checked;
            checkBox.Text = sample.Text;
            checkBox.RightToLeft = sample.RightToLeft;

            return checkBox;
        }
    }
}