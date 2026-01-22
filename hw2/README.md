# Порушення принципу підстановки Лісков (LSP)

## Що таке LSP

Принцип підстановки Лісков (Liskov Substitution Principle) говорить: **об’єкти підкласу повинні коректно замінювати об’єкти базового класу без зміни очікуваної поведінки програми**.

Нижче наведено 3 приклади порушення LSP (без прикладу з Квадратом і Прямокутником), пояснення проблем і варіанти перепроєктування на C#.



## Приклад 1: Bird → Penguin

### Порушення

```csharp
class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
}

class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly");
    }
}
```

### Чому це порушує LSP

Код, який працює з `Bird`, очікує, що метод `Fly()` завжди доступний. Але при підстановці `Penguin` виникає виняток, тобто підклас не може повноцінно замінити базовий клас.

### Проблеми

* runtime-помилки
* непередбачувана поведінка

### Перепроєктування (дотримання LSP)

```csharp
interface IFlyingBird
{
    void Fly();
}

class Bird { }

class Sparrow : Bird, IFlyingBird
{
    public void Fly()
    {
        Console.WriteLine("Sparrow is flying");
    }
}

class Penguin : Bird { }
```



## Приклад 2: File → ReadOnlyFile

### Порушення

```csharp
class File
{
    public virtual void Write(string text)
    {
        Console.WriteLine("Writing to file");
    }
}

class ReadOnlyFile : File
{
    public override void Write(string text)
    {
        throw new InvalidOperationException("File is read-only");
    }
}
```

### Чому це порушує LSP

Базовий клас дозволяє запис у файл, але підклас забороняє цю операцію. Це змінює очікувану поведінку і порушує контракт базового класу.

### Проблеми

* помилки під час виконання
* ламання клієнтського коду

### Перепроєктування

```csharp
interface IReadableFile
{
    string Read();
}

interface IWritableFile
{
    void Write(string text);
}

class File : IReadableFile, IWritableFile
{
    public string Read() => "data";
    public void Write(string text) { }
}

class ReadOnlyFile : IReadableFile
{
    public string Read() => "data";
}
```



## Висновок

Порушення принципу підстановки Лісков призводить до нестабільної роботи програми, появи неочікуваних винятків і ускладнення підтримки коду. Якщо підклас не може безпечно замінити базовий клас, клієнтський код стає залежним від конкретних реалізацій. Дотримання LSP досягається через правильне проєктування ієрархії класів, використання інтерфейсів та чітке визначення контрактів поведінки.
