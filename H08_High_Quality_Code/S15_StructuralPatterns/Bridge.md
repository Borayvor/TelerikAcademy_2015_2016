# Bridge (Мост)

### 1. Цел.
> Разделя абстракция от нейната имплементация, така че двете да могат да се променят независимо.

### 2. Мотивация.
> Когато една абстракция може да има няколко възможни имплементации, обичайният начин за реализирането им е чрез наследяване. 
Абстрактният клас дефинира интерфейса към абстракцията, а конкретните подкласове я имплементират по различен начин. Този подход 
обаче не винаги е достатъчно гъвкав. Наследяването обвързва имплементацията с абстракцията за постоянно, което затруднява независимата
промяна, разширяването и многократното използване на абстракциите и имплементациите.

### 3. Приложимост.
> Използвайте когато :
* искате да избегнете твърдо обвързване между дадена абстракция и нейната имплементация. Това може да се налага например когато 
имплементацията трябва да се избира или сменя по време на изпълнение.
* както абстракциите, така и техните имплементации трябва да бъдат разширяеми чрез създаване на подкласове. В този случай шаблонът Мост 
дава възможност за комбиниране на различни абстракции и независимото им разширяване.
* промените в имплементацията на дадена абстракция не трябва да влиаят върху клиентите - т.е. да не се налага прекомпилиране на техния код.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S15_StructuralPatterns/Diagrams/bridge.jpg)

### 5. Участници.
* **Abstraction** :
    * дефинира интерфейса на абстракцията.
    * поддържа референция към обект от тип Implementor.
    
* **RefineAbstraction** :
    * разширява интерфейса, дефиниран от Abstraction.

* **Implementor** :
    * дефинира интерфейса на класовете на имплементацията. Този интерфейс не е задължително да отговаря напълно на интерфейса Abstraction, 
    всъщност двата интерфейса могат да са доста различни. Обикновено интерфейсът на Implementor предоставя само елементарни операции, а 
    Abstraction дефинира операции от по-високо ниво, базирайки се на тези елементарни операции.

* **ConcreteImplementor** :
    * дефинира конкретната имплементация на Implementor.


### 6. Взаимодействия.
> Abstraction препредава заявките от клиентите към своя обект Implementor.

### 7. Следствия.
* Разделяне на интерфейса и имплементацията.
* Подобрена разширяемост.
* Скриване на подробности на имплементацията от клиентите.

### 8. Примерен код.
```
using System;
 
namespace DoFactory.GangOfFour.Bridge.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Bridge Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      Abstraction ab = new RefinedAbstraction();
 
      // Set implementation and call
      ab.Implementor = new ConcreteImplementorA();
      ab.Operation();
 
      // Change implemention and call
      ab.Implementor = new ConcreteImplementorB();
      ab.Operation();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Abstraction' class
  /// </summary>
  class Abstraction
  {
    protected Implementor implementor;
 
    // Property
    public Implementor Implementor
    {
      set { implementor = value; }
    }
 
    public virtual void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// The 'Implementor' abstract class
  /// </summary>
  abstract class Implementor
  {
    public abstract void Operation();
  }
 
  /// <summary>
  /// The 'RefinedAbstraction' class
  /// </summary>
  class RefinedAbstraction : Abstraction
  {
    public override void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// The 'ConcreteImplementorA' class
  /// </summary>
  class ConcreteImplementorA : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorA Operation");
    }
  }
 
  /// <summary>
  /// The 'ConcreteImplementorB' class
  /// </summary>
  class ConcreteImplementorB : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorB Operation");
    }
  }
}
```
