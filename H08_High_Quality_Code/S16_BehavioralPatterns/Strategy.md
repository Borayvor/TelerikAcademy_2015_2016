# Strategy (Стратегия)

### 1. Цел.
> Дефинира семейство алгоритми, капсулира всеки от тях и ги прави ваимнозаменяеми. Стратегия дава възможност на алгоритмите да се 
променят независимо от клиентите, които ги използват.

### 2. Мотивация.
> Съществуват много алгоритми за разделянето на поток текст на редове. Твърдото закодиране на всички такива алгоритми в класове, 
на които са им необходими, не е желателно поради няколко причини :
* Клиентите, които имат нужда от разделяне на текста на редове, стават по-сложни, ако включват и кода за имплементацията му. 
Това прави клиентите по-големи и по-трудни за поддръжка, особено ако поддържат множество алгоритми за разделяне на редове.
* Различните алгоритми ще са подходящи за различни случаи. Не е добре да се поддържат множество алгоритми за разделяне на 
редове, ако не се използват всичките.
* Трудно се добавят нови и се променят съществуващи алгоритми, когато разделянето на редове е неразделна част от клиента.

> Тези проблеми могат да се избегнат чрез дефинирането на класове, капсулиращи различни алгоритми за разделяне на редове. 
Капсулиран по такъв начин алгоритъм се нарича Стратегия (Strategy).

### 3. Приложимост.
> Използвайте когато :
* много на брой свързани класове се различават само по поведението си. Стратегиите представляват начин за конфигуриране на 
даден клас с едно от много поведения.
* ви трябват различни варианти на един алгоритъм. Можете например да дефинирате алгоритми, съответстващи на различни изисквания 
за памет и скорост. Когато тези варианти се имплементират като йерархия от класове, може да използвате стратегии.
* някой алгоритъм използва данни, които не трябва да са известни на клиентите. Използвайте шаблона Стратегия, за да избегнете 
разкриването на сложни, зависими от алгоритмите, структури от данни.
* един клас дефинира много поведения и те се появяват под формата на множество условни оператори в неговите операции. Вместо 
множество условия, преместете съответните условни разклонения в техен собствен клас Strategy.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S16_BehavioralPatterns/Diagrams/strategy.jpg)

### 5. Участници.
* **Strategy** (SortStrategy) :
    * декларира интерфейс, общ за всички поддържани алгоритми. Context използва този интерфейс, за да извика алгоритъма, 
    дефиниран от ConcreteStrategy.
    
* **ConcreteStrategy** (QuickSort, ShellSort, MergeSort) :
    * имплементира алгоритъма посредством интерфейса на Strategy.

* **Context** (SortedList) :
    * конфигурира се чрез обект ConcreteStrategy.
    * пази референция към обект Strategy.
    * може да дефинира интерфейс, даващ възможност на Strategy да осъществява достъп до неговите данни.

### 6. Взаимодействия.
> Strategy и Context си взаимодействат, за да имплементират избрания алгоритъм. Контекстът може да предаде на стратегията 
всички необходими на алгоритъма данни при извикването му. Друга възможност е контекстът да предава себе си като аргумент 
на операциите на Strategy. Това дава възможност на стратегията при нужда да извика обратно контекста.

> Context препредава заявки от своите клиенти към своята стратегия. Клиентите обикновено създават и предават на контекста 
обект ConcreteStrategy, от този момент нататък клиентите взаимодействат директно с контекста. Често клиентите могат 
да си избират от цяло семейство от класове ConcreteStrategy.

### 7. Следствия.
* Семейства свързани алгоритми.
* Алтернатива на създаването на подкласове.
* Стратегиите елиминират условните оператори.
* Избор на имплементации.
* Клиентите трябва да знаят за различните стратегии.
* Допълнителна комуникация между Strategy и Context.
* Увеличен брой обекти.

### 8. Примерен код.
```
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Strategy.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Strategy Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Two contexts following different strategies
      SortedList studentRecords = new SortedList();
 
      studentRecords.Add("Samual");
      studentRecords.Add("Jimmy");
      studentRecords.Add("Sandra");
      studentRecords.Add("Vivek");
      studentRecords.Add("Anna");
 
      studentRecords.SetSortStrategy(new QuickSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new ShellSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new MergeSort());
      studentRecords.Sort();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Strategy' abstract class
  /// </summary>
  abstract class SortStrategy
  {
    public abstract void Sort(List<string> list);
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class QuickSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      list.Sort(); // Default is Quicksort
      Console.WriteLine("QuickSorted list ");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ShellSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      //list.ShellSort(); not-implemented
      Console.WriteLine("ShellSorted list ");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class MergeSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      //list.MergeSort(); not-implemented
      Console.WriteLine("MergeSorted list ");
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class SortedList
  {
    private List<string> _list = new List<string>();
    private SortStrategy _sortstrategy;
 
    public void SetSortStrategy(SortStrategy sortstrategy)
    {
      this._sortstrategy = sortstrategy;
    }
 
    public void Add(string name)
    {
      _list.Add(name);
    }
 
    public void Sort()
    {
      _sortstrategy.Sort(_list);
 
      // Iterate over list and display results
      foreach (string name in _list)
      {
        Console.WriteLine(" " + name);
      }
      Console.WriteLine();
    }
  }
}
```
