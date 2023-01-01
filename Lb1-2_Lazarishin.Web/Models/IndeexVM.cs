namespace Lb1_2_Lazarishin.Web.Models
{
    public class IndexVM
    {
        public IndexVM()
        {
            Rows = new List<Row>
            {
                new Row { Question = "Средний бал за выпускные экзамены в школе", MinValueRow = 3, MaxValueRow = 5 },
                new Row { Question = "Работаете ли вы в настоящее время?", MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Получаете ли вы второе высшее образование?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Собираетесь ли вы в будущем работать по вашей специальности?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "В живете в Екатеринбурге?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Вы обучаетесь в институте на платной основе?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Есть ли у вас увлечения, не связанные с учебой?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Умеете ли вы играть в шахматы?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Есть ли у вас родные братья или сестры?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Скольких человек вы считаете своими лучшими друзьями?",MinValueRow = 0, MaxValueRow = 10 },
                new Row { Question = "Есть ли у вас любимый человек ?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Есть ли у вас права на управления автомобилем?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Сколько времени суммарно вы тратите ежедневно на дорогу до и от института (в часах)?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "Сколько часов в день вы проводите за компьютером?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "Есть ли у вас свободный доступ в Интернет ?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Являетесь ли вы активным участником каких-либо социальных сетей в Интернете (одноклассники, вконаткте и т.д)?",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Какой % от вашего рациона составляют свежие фрукты и овощи?",MinValueRow = 0, MaxValueRow = 100 },
                new Row { Question = "Сколько часов в неделю вы занимаетесь спортом?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "Сколько часов в день вы проводите на улице (не считая транспорт, авто)?",MinValueRow = 0, MaxValueRow = 24 },
                new Row { Question = "Употребляете ли вы спиртные напитки:",MinValueRow = 0, MaxValueRow = 1 },
                new Row { Question = "Оцените ваш уровень владения иностранным языком:",MinValueRow = 0, MaxValueRow = 5 },
                new Row { Question = "Средний бал за экзамены (не менее 3-х экзаменов) полученный в предыдущую сессию",MinValueRow = 0, MaxValueRow = 5 },
            };
            //Questions = new List<string>
            //{
            //    "Средний бал за выпускные экзамены в школе",
            //    "Работаете ли вы в настоящее время?",
            //    "Получаете ли вы второе высшее образование?",
            //    "Собираетесь ли вы в будущем работать по вашей специальности?",
            //    "В живете в Екатеринбурге?",
            //    "Вы обучаетесь в институте на платной основе?",
            //    "Есть ли у вас увлечения, не связанные с учебой?",
            //    "Умеете ли вы играть в шахматы?",
            //    "Есть ли у вас родные братья или сестры?",
            //    "Скольких человек вы считаете своими лучшими друзьями?",
            //    "Есть ли у вас любимый человек ?",
            //    "Есть ли у вас права на управления автомобилем?",
            //    "Сколько времени суммарно вы тратите ежедневно на дорогу до и от  института (в часах)?",
            //    "Сколько часов в день вы проводите за компьютером?",
            //    "Есть ли у вас свободный доступ в Интернет ?",
            //    "Являетесь ли вы активным участником каких-либо социальных сетей в Интернете (одноклассники, вконаткте и т.д)?",
            //    "Какой % от вашего рациона составляют свежие фрукты и овощи?",
            //    "Сколько часов в неделю вы занимаетесь спортом?",
            //    "Сколько часов в день вы проводите на улице (не считая транспорт, авто)?",
            //    "Употребляете ли вы спиртные напитки:",
            //    "Оцените ваш уровень владения иностранным языком:",
            //    "Средний бал за экзамены (не менее 3-х экзаменов) полученный в предыдущую сессию",
            //};
        }
        public readonly List<Row> Rows;
        public double R { get; set; }
        //public readonly List<string> Questions;
        public List<Questionnaire> Questionnaires { get; set; }
        public Status Status { get; set; }

    }
}