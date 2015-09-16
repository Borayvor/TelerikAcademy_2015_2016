# Abstract Factory (Абстрактна Фабрика)

### 1. Цел.
> Предоставя интерфейс за създаване на семейства взаимосвързани или зависими обекти, без да се задават конкретните им класове.

### 2. Мотивация.
> Когато имаме набор от инструменти за потребителски интерфейс, поддържащ множество стандарти за външен вид, различните външни 
видове дефинират различно представяне и поведение за управляващите елементи на потребителския интерфейс. За да може да се 
пренесе до различни стандарти за външен вид, приложението не трябва да закодира твърдо своите управляващи елементи за определен 
външен вид. Инстанциирането на класове, специфични за даден външен вид в приложението затруднява евентуалната промяна.
> Този проблем може да се реши чрез дефинирането на абстрактен клас, деклариращ интерфейс за създаване на всички основни 
видове управляващи елементи. След това може да се дефинира и абстрактен клас за всеки управляващ елемент, а конкретните 
подкласове да имплементират управляващи елементи за конкретни стандарти за външен вид.

### 3. Приложимост.
Използва се когато:
* дадена система трябва да бъде независима от това, как се създават, композират и представят нейните продукти.
* дадена система трябва да се конфигурира с едно от многото семейства продукти.
* семейство свързани обекти продукти е проектирано за съвместно използване и това ограничение трябва да се наложи.
* искате да представите библиотека класове за продукти и да разкриете само техните интерфейси, а не имплементациите им.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S14_CreationalPatterns/Diagrams/Abstract factory.jpg)

### 5. Участници.
* AbstractFactory:
    * дефинира интерфейс за операции, създаващи абстрактни обекти продукти. 
* ConcreteFactory:
    * имплементира операциите за създаване на конкретни обекти продукти.
* AbstractProduct:
    * декларира интерфейс за типа на даден обект продукт.
* ConcreteProduct:
    * дефинира обект продукт, който да се създаде от съответната конкретна фабрика.
* Client:
    * използва самоинтерфейси, декларирани от класовете AbstractFactory и AbstractProduct.

### 6. Взаимодействия.
* Обикновено по време на изпълнението се създава само по една инстанция на класа ConcreteFactory. Конкретната фабрика 
създава обекти продукти с определена имплементация. За да създадат други обекти продукти, клиентите трябва да 
използват друга конкретна фабрика.
* AbstractFactory делегира създаването на обекти продукти на своя подклас ConcreteFactory.

### 7. Следствия.
* Изолира конкретни класове.
* Улеснява смяната на семействата продукти.
* Допринася за съвместимостта между продуктите.
* Поддържането на нови видове продукти е трудно.

### 8. Примерен код.
```
 abstract class Confectionery
{
  public abstract Cake MakeCake();
  public abstract List<Muffin> MakeMuffins(int number);
  public abstract List<Profiterole> MakeProfiteroles(int number);
}
```
```
abstract class Muffin
{
   public string Name { get; protected set; }

}
abstract class Cake
{
   public string Name { get; protected set; }
}
abstract class Profiterole
{
   public string Name { get; protected set; }
}
```

```
class CityCenterConfectionery : Confectionery
{
   public override Cake MakeCake()
   {
      return new PragueCake("an amazing Prague Cake");
   }

   public override List<Muffin> MakeMuffins(int number)
   {
      List<Muffin> muffins = new List<Muffin>();
      for (int i = 0; i < number; i++)
      {
          muffins.Add(new FrenchMuffin(String.Format("a beautiful French Muffin {0}", i+1)));
      }
      return muffins;
   }

   public override List<Profiterole> MakeProfiteroles(int number)
   {
       List<Profiterole> profiteroles = new List<Profiterole>();
      for (int i = 0; i < number; i++)
      {
          profiteroles.Add(new ChocolateProfiterole(String.Format("a lovely Chocolate Profiterol {0}", i+1)));
      }
       return profiteroles;
   }
}
```

```
class PragueCake: Cake
{
    public PragueCake(string name)
    {
       Name = name;
   }
}
class ChocolateProfiterole : Profiterole
{
   public ChocolateProfiterole(string name)
   {
      Name = name;
   }
}
class FrenchMuffin: Muffin
{
   public FrenchMuffin(string name)
   {
      Name = name;
   }
}
```

```
class Program
{
   static void Main()
   {
     //creating an instance of a confectionery shop     
     var confectionery = new CityCenterConfectionery();

     //order sweets from the city center confectionery shop
     Console.WriteLine(confectionery.MakeCake().Name);
     confectionery.MakeMuffins(7).ForEach((m) => Console.WriteLine(m.Name));
     confectionery.MakeProfiteroles(5).ForEach((p) => Console.WriteLine(p.Name));
   }
}
```

