using Practic.Data.Interfaces;
using Practic.Data.Models;

namespace Practic.Data.Mocks
{
    public class MockAim: IAllAims
    {
        private readonly IAimCategory _categoryAim = new MockCategory();
        public IEnumerable<Aim> Aims
        {
            get
            {
                return new List<Aim>
                {
                    new Aim{
                        Name = "Ознаколмление",
                        //shortDescription = "Изучение типов данных в языке C#",
                        Image = "/img/datatypes.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Математические операции",
                        //shortDescription = "Математические операции с числами",
                        Image = "/img/mathoperations.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Условные операторы",
                        //shortDescription = "Изучение if/else",
                        Image = "/img/ifelse.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Циклы",
                        //shortDescription = "Изучение while, do, for",
                        Image = "/img/cycles.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Конструкция switch",
                        //shortDescription = "Изучение while, do, for",
                        Image = "/img/switch.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Массивы",
                        //shortDescription = "Изучение массивов",
                        Image = "/img/array.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.First()
                    },
                    new Aim{
                        Name = "Классы",
                        //shortDescription = "Изучение классов",
                        Image = "/img/class.jpg",
                        Avaliable = true,
                        category = _categoryAim.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Aim> GetAvaliableAims { get; set; }

        public IEnumerable<Aim> GetUnavaliableAims { get; set; }

        public Aim getObjectAim(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
