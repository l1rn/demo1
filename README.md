# 🏎️ Старт (Модуль 1)
Нам надо скачать зависимости перед тем, как работать в проекте.
![dependencies](docs/1.png)
## 🔭 Структура
```
.
└── demo (папка проекта/корень)
    └── ui (тут можно разместить все формы)
    │   └── Главная форма
    │   └── Форма добавления
    │   └── Карточка для представления продукта
    │   └── Форма показа всех продукта
    │   └── Форма редактирования
    ├── core
    │   └── ... (Рассмотрю ниже)
    ├── data
    │   └── Все Excel таблички
    ├── assets
    │    └── Иконки проекта
    └── ApplicationContext.cs
    └── ExcelReader.cs
    └── Program.cs
```
![alt text](docs/2.png)
## 🦧 Модели (core)
Здесь надо просто зайти в одну из Excel таблиц и переписать все столбцы в наш класс.<br>
Для примера возьму таблицу `Materials_import.xlsx`
![materials table](docs/3.png)
Ну и после просто создаем наш класс в папке `core/Material.cs` и делаем его публичным
![class](docs/4.png)
### Ну соответсвенно
`Name` = `Наименование материала`
`MaterialTypeId` = `Тип Материала`
и т.д. <br>
Также у нас Entity Framework позволяет виртуально создавать объекты по ID. Вот например `materialType` связан по `MaterialTypeId` и мы можем пользоваться всеми его полями как захотим. 
### Визуально это выглядит так
![](docs/5.png)

## 😶‍🌫️ ApplicationContext
``` c#
namespace demo1
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public ApplicationContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123");
        }
    }
}
```

- `DbSet<T>` создает сеты моделей для всех объектов 
- Конструктор создает БД `Database.EnsureCreated();`
            
- Подключаемся к бд `optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123");`

## 📖 Создадим класс для чтения Excel таблиц
Расмотрим один пример с чтением `Material_type_import.xlsx`
``` c#
public class ExcelReader
{
    public void ReadMaterialTypeFromExcelFile(ApplicationContext db, string excelFile)
    {
        ExcelPackage.License.SetNonCommercialPersonal("sadasdfasdgdrafhbrtshrthbtfghfgcgf"); // тут просто чтобы читать задаем, что мы не коммерческая орга
        using var package = new ExcelPackage(new FileInfo(excelFile)); // читаем наш файл
        var worksheet = package.Workbook.Worksheets[0]; // открываем первый лист
        for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // проходимся по каждой строчке
        {
            var name = worksheet.Cells[row, 1].Text;
            var breakPercent = worksheet.Cells[row, 2].Text;

            MaterialType sample = new MaterialType { 
                Name = name, 
                PercentBreak = float.Parse(breakPercent.Replace("%", "")) 
            };

            db.MaterialTypes.Add(sample);
            db.SaveChanges();   
            // добавляем и сохраняем данные в бд
        }
    }
}
```
Остальные методы можно посмотреть в [репозитории](https://github.com/l1rn/demo1/blob/main/ExcelReader.cs)
я
# 👁️ Интерфейс (Модуль 2)
#### 1. Создаем карточку из объекта UserControl
![user control](docs/6.png)
#### 2. Настраиваем по заданию
![user control](docs/7.png)
#### 3. Для удобства создаем [DAO](https://ru.wikipedia.org/wiki/Data_Access_Object) объект в `core/ProductCardData.cs`, чтобы передавать его в эту "карточку"

``` c#
namespace demo1.core
{
    public class ProductCardData
    {
        public int ProductId { get; set; }
        public string? Type { get; set; }
        public string? ProductName { get; set; }
        public string? Article { get; set; }
        public double MinPriceForPartner { get; set; }
        public double Width { get; set; }
        public double Price { get; set; }
        public virtual Product? product { get; set; }
        public virtual Material? material { get; set; }
    }
}
```
<b>Так вот почему именно такой?</b> Абстрактно даем каждому полю в карточке свой параметр на картинке по понятнее
![explanation](docs/8.png)
Также прикрепил `Product` и `Material` для удобства в дальнейшем

# 😮‍💨 Опять исключения и интерфейсы другими словами (3 модуль)
### Создаем окошки
#### 1. Главная форма 
![main](docs/9.png)
- Я задал текст элементам через код
    ![addition](docs/11.png)

#### 2. Делаем форму добавления и редактирования одной формой, потом просто поменяем логику кнопок
![add](docs/10.png)

#### 3. Форма просмотра
Делаем такую же как и [Главная форма](#1-главная-форма), только вместо кнопок у нас будет `Panel` с параметром `Dock.Fill`
![show](docs/12.png)

# 🎴 Создаем метод (4 модуль)
``` c#
using (ApplicationContext db = new ApplicationContext()) {
    var products = db.Products.ToDictionary(p => p.Name, p => p.Width); // создаем словарь на продукты
    var productTypes = db.ProductTypes.ToDictionary(pt => pt.Id, pt => pt.Name); // создаем словарь на тип продуктов

    if(!products.TryGetValue(_productName, out float pWidth))
    {
        MessageBox.Show("Не получилось найти продукт");
        return;
    }
    Product p = db.Products.Where(p => p.Name == _productName).FirstOrDefault();

    float p1 = float.Parse(textBox1.Text); // параметр 1 - сколько нужно продукта
    float p2 = pWidth; // параметр 2 - ширина продукта
    float p3 = db.ProductTypes.Find(p.ProductTypeId).TypeCoef; // тип коэффициента продукт, тип продукта

    float m1Divide = _material.QuantityInPackage; // сколько материала в упаковке
    float m2 = _material.QuantityInStorage; // надо высчитывать, сколько на складе есть высчитывать с минимальным количеством
    float m3 = db.MaterialTypes.Find(_material.MaterialTypeId).PercentBreak; // процент брака

    float first = p1 * p2 * p3 * m3;
    float result = first / m1Divide;
    MessageBox.Show($"Материала потребуется: {result:0.00}");
}
```
