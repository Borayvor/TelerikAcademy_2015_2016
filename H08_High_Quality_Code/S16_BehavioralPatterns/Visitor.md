# Visitor (Посетител)

### 1. Цел.
> Представя операции, които се извършват върху елементите на обектна структура. Посетител дава възможност да се дефинира нова операция, 
без да се променят класовете на елементите, върху които работи тя.

### 2. Мотивация.
> Ако имаме компилатор, който представя програмите във вид на абстрактни дървета на разбора. Той ще трябва да извършва операции 
върху абстрактните дървета на разбора за анализ на "семантичната им семантика", като например дали всички променливи са дефинирани. 
Това означава, че може да дефинира операции за проверка на типа, оптимизиране на кода, анализ на потока, проверка за присвояване на 
стойности на променливите преди те да бъдат използвани, и т.н. Освен това бихме могли да използваме абстрактни дървета на разбора за 
преформатиране на текста на програмите, пренареждане на операторите, инструментиране на кода и изчисляване на различни характеристики 
на програмите.

> Повечето от тези операции ще трябва да третират възлите, представляващи инструкции за присвояване, различно от възлите, които 
представляват променливи или аритметични изрази. От това следва, че ще има един клас за инструкции за присвояване, друг за достъп до 
променливи, трети за аритметични изрази и т.н. Наборът от класове за възли зависи, разбира се, от компилаторния език, но той не се 
променя съществено за даден език.

### 3. Приложимост.
> Използвайте когато :
* някоя структура от обекти съдържа много класове обекти с различни интерфейси и искате върху тези обекти да извършвате операции, 
зависещи от конкретния им клас.
* много различни и несвързани операции трябва да се извършват над обекти от дадена структура и искате да избегнете натоварването на 
класовете им с тези операции. Шаблонът Посетител дава възможност тези операции да останат заедно, дефинирани в един клас. Когато 
структурата от обекти се споделя от много приложения, използвайте шаблона Посетител, за да поставите операциите само в онези приложения, 
които имат нужда от тях.
* класовете, дефиниращи структура от обекти, рядко се променят, но често искате да дефинирате нови опрации върху структурата. 
Промяната на класовете на структурата от обекти изисква предефиниране на интерфейса на всички посетители, което може да е скъпо. 
Ако класовете на структурата от обекти се променя често, вероятно е по-добре тези операции да се дефинират в тези класове.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S16_BehavioralPatterns/Diagrams/visitor.jpg)


### 5. Участници.
* **Visitor** (Visitor) :
    * декларира операция Visit за всеки клас ConcreteElement в структурата от обекти. Името и структурата на операцията идентифицират класа, 
    изпращащ заявката Visit до посетителя. Това дава възможност на посетителя да определи конкретния клас на посетения елемент. След това 
    посетителят може да осъществи достъп до елемента директно през съответния интерфейс.
    
* **ConcreteVisitor** (IncomeVisitor, VacationVisitor) :
    * имплементира всички операции, декларирани от Visitor. Всяка операция имплементира част от алгоритъм, дефинирана за съответния клас 
    обекти в структурата. ConcreteVisitor предоставя контекста на алгоритъма и съхранява локалното му съдържание. Това състояние 
    често акумулира резултати по време на обхождането на структурата.

* **Element** (Element) :
    * дефинира операция Accept, приемаща за аргумент някой посетител.

* **ConcreteElement** (Employee) :
    * имплементира операция Accept, приемаща за аргумент някой посетител.
    
* **ObjectStructure** (Employees) :
    * може да изброи своите елементи.
    * може да предостави интерфейс от високо ниво, за да даде възможност на посетителя да посети негоеите елементи.
    * може да бъде или композиция (шаблон), или колекция, например списък или множество.

### 6. Взаимодействия.
* Клиент който използва шаблона Посетител, трябва да създаде ConcreteVisitor обект и след това да обходи структурата от обекти, 
посещавайки чрез посетителя всеки елемент.
* Когато даден елемент бъде посетен, той извиква операцията Visitor, отговаряща за неговия клас. Елементът предоставя себе си като 
аргумент на тази операция, за да може посетителят да осъществи достъп до състоянието му, ако е необходимо.

### 7. Следствия.
* Шаблонът Посетител улеснява добавянето на нови операции.
* Посетителят събира накуп свързаните операции и разделя несвързаните.
* Добавянето на нов клас ConcreteElement е трудно.
* Посещения в различни йерархии от класове.
* Акумулиране на състояние.
* Нарушаване на капсулирането.

### 8. Примерен код.
```
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Visitor.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Visitor Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Setup employee collection
      Employees e = new Employees();
      e.Attach(new Clerk());
      e.Attach(new Director());
      e.Attach(new President());
 
      // Employees are 'visited'
      e.Accept(new IncomeVisitor());
      e.Accept(new VacationVisitor());
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Visitor' interface
  /// </summary>
  interface IVisitor
  {
    void Visit(Element element);
  }
 
  /// <summary>
  /// A 'ConcreteVisitor' class
  /// </summary>
  class IncomeVisitor : IVisitor
  {
    public void Visit(Element element)
    {
      Employee employee = element as Employee;
 
      // Provide 10% pay raise
      employee.Income *= 1.10;
      Console.WriteLine("{0} {1}'s new income: {2:C}",
        employee.GetType().Name, employee.Name,
        employee.Income);
    }
  }
 
  /// <summary>
  /// A 'ConcreteVisitor' class
  /// </summary>
  class VacationVisitor : IVisitor
  {
    public void Visit(Element element)
    {
      Employee employee = element as Employee;
 
      // Provide 3 extra vacation days
      Console.WriteLine("{0} {1}'s new vacation days: {2}",
        employee.GetType().Name, employee.Name,
        employee.VacationDays);
    }
  }
 
  /// <summary>
  /// The 'Element' abstract class
  /// </summary>
  abstract class Element
  {
    public abstract void Accept(IVisitor visitor);
  }
 
  /// <summary>
  /// The 'ConcreteElement' class
  /// </summary>
  class Employee : Element
  {
    private string _name;
    private double _income;
    private int _vacationDays;
 
    // Constructor
    public Employee(string name, double income,
      int vacationDays)
    {
      this._name = name;
      this._income = income;
      this._vacationDays = vacationDays;
    }
 
    // Gets or sets the name
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
 
    // Gets or sets income
    public double Income
    {
      get { return _income; }
      set { _income = value; }
    }
 
    // Gets or sets number of vacation days
    public int VacationDays
    {
      get { return _vacationDays; }
      set { _vacationDays = value; }
    }
 
    public override void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
 
  /// <summary>
  /// The 'ObjectStructure' class
  /// </summary>
  class Employees
  {
    private List<Employee> _employees = new List<Employee>();
 
    public void Attach(Employee employee)
    {
      _employees.Add(employee);
    }
 
    public void Detach(Employee employee)
    {
      _employees.Remove(employee);
    }
 
    public void Accept(IVisitor visitor)
    {
      foreach (Employee e in _employees)
      {
        e.Accept(visitor);
      }
      Console.WriteLine();
    }
  }
 
  // Three employee types
 
  class Clerk : Employee
  {
    // Constructor
    public Clerk()
      : base("Hank", 25000.0, 14)
    {
    }
  }
 
  class Director : Employee
  {
    // Constructor
    public Director()
      : base("Elly", 35000.0, 16)
    {
    }
  }
 
  class President : Employee
  {
    // Constructor
    public President()
      : base("Dick", 45000.0, 21)
    {
    }
  }
}
```
