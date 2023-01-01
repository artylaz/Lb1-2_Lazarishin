namespace Lb1_2_Lazarishin.Web.Models
{
    public class IndexVM
    {
        public IndexVM()
        {
            Rows = new List<Row>
            {
                new Row { Question = "������� ��� �� ��������� �������� � �����", MinValueRow = 3, MaxValueRow = 5 },
                new Row { Question = "��������� �� �� � ��������� �����?", MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "��������� �� �� ������ ������ �����������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "����������� �� �� � ������� �������� �� ����� �������������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "� ������ � �������������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "�� ���������� � ��������� �� ������� ������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "���� �� � ��� ���������, �� ��������� � ������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "������ �� �� ������ � �������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "���� �� � ��� ������ ������ ��� ������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "�������� ������� �� �������� ������ ������� ��������?",MinValueRow = 0, MaxValueRow = 10 },
                new Row { Question = "���� �� � ��� ������� ������� ?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "���� �� � ��� ����� �� ���������� �����������?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "������� ������� �������� �� ������� ��������� �� ������ �� � �� ��������� (� �����)?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "������� ����� � ���� �� ��������� �� �����������?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "���� �� � ��� ��������� ������ � �������� ?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "��������� �� �� �������� ���������� �����-���� ���������� ����� � ��������� (�������������, ��������� � �.�)?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "����� % �� ������ ������� ���������� ������ ������ � �����?",MinValueRow = 0, MaxValueRow = 100 },
                new Row { Question = "������� ����� � ������ �� ����������� �������?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "������� ����� � ���� �� ��������� �� ����� (�� ������ ���������, ����)?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "������������ �� �� �������� �������:",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "������� ��� ������� �������� ����������� ������:",MinValueRow = 0, MaxValueRow = 5 },
                new Row { Question = "������� ��� �� �������� (�� ����� 3-� ���������) ���������� � ���������� ������",MinValueRow = 0, MaxValueRow = 5 },
            };
            //Questions = new List<string>
            //{
            //    "������� ��� �� ��������� �������� � �����",
            //    "��������� �� �� � ��������� �����?",
            //    "��������� �� �� ������ ������ �����������?",
            //    "����������� �� �� � ������� �������� �� ����� �������������?",
            //    "� ������ � �������������?",
            //    "�� ���������� � ��������� �� ������� ������?",
            //    "���� �� � ��� ���������, �� ��������� � ������?",
            //    "������ �� �� ������ � �������?",
            //    "���� �� � ��� ������ ������ ��� ������?",
            //    "�������� ������� �� �������� ������ ������� ��������?",
            //    "���� �� � ��� ������� ������� ?",
            //    "���� �� � ��� ����� �� ���������� �����������?",
            //    "������� ������� �������� �� ������� ��������� �� ������ �� � ��  ��������� (� �����)?",
            //    "������� ����� � ���� �� ��������� �� �����������?",
            //    "���� �� � ��� ��������� ������ � �������� ?",
            //    "��������� �� �� �������� ���������� �����-���� ���������� ����� � ��������� (�������������, ��������� � �.�)?",
            //    "����� % �� ������ ������� ���������� ������ ������ � �����?",
            //    "������� ����� � ������ �� ����������� �������?",
            //    "������� ����� � ���� �� ��������� �� ����� (�� ������ ���������, ����)?",
            //    "������������ �� �� �������� �������:",
            //    "������� ��� ������� �������� ����������� ������:",
            //    "������� ��� �� �������� (�� ����� 3-� ���������) ���������� � ���������� ������",
            //};
        }
        public readonly List<Row> Rows;
        public double R { get; set; }
        //public readonly List<string> Questions;
        public List<Questionnaire> Questionnaires { get; set; }
        public Status Status { get; set; }

    }
}