# State (Състояние)

### 1. Цел.
> Позволява на даден обект да променя поведението си, когато вътрешното му състояние се променя. Отвън ще изглежда сякаш обекта се е 
превърнал в обект от друг клас.

### 2. Мотивация.
> TCPConnection е клас представляващ мрежова връзка. Обектът TCPConnection може да е в едно от няколко възможни състояния: Established, 
Listening, Closed. Когато обектът TCPConnection получи заявки от други обекти, той отговаря по различен начин в зависимост от състоянието 
в което се намира. Например резултатът от заявката Open зависи зависи от това, дали връзката е в състояние Closed или Established. 
Шаблонът Състояние описва как TCPConnection може да демонстрира различно поведение във всяко състояние.

### 3. Приложимост.
> Използвайте когато :
* Ако поведението на даден обект зависи от състоянието му и той трябва да променя своето поведение по време на изпълнение в зависимост 
от това състояние.
* Ако операциите имат големи условни оператори с много малки части, зависещи от състоянието на обекта. Това състояние обикновено се 
представя чрез една или повече числови константи. В много случай, няколко операции ще съдържат една и съща условна структура. 
Шаблонът състояние поставя всеки клон на условието в отделен клас. Това дава възможност да се третира състоянието на обекта като 
обект, който може да варира независимо от останалите обекти.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S16_BehavioralPatterns/Diagrams/state.jpg)

### 5. Участници.
* **Context** :
    * дефинира интерфейса, който представлява интерес за клиентите.
    * поддържа инстанция на подклас на State, дефинираща текущото състояние.
    
* **State** :
    * дефинира интерфейс за капсулиране на поведението, асоциирано с определено състояние на Context.

* **ConcreteState** :
    * всеки подклас имплементира поведение, свързано с едно състояние на Context.

### 6. Взаимодействия.
* Context делегира заявките, зависещи от състоянието, на текущия обект ConcreteState.
* Контекстът може да предава себе си като аргумент на обекта State, обработващ заявката. Това дава възможност на обекта State 
да осъществява достъп до контекста, ако е необходимо.
* Context е основният интерфейс за клиентите. Те могат да конфигурират контекста чрез неговите обекти State. След като даден контекст 
бъде конфигуриран, неговите клиенти не трябва да боравят директно с обектите State.
* Или Context или подкласовете на ConcreteState, могат да вземат решение кое състояние след кое идва и при какви обстоятелства.

### 7. Следствия.
* Локализира поведение, зависещо от едно състояние, и разделя поведението при различните състояния.
* Прави смяната на състоянията ясна.
* Обектите State могат да се споделят.

### 8. Примерен код.
```
using System;
 
namespace DoFactory.GangOfFour.State.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// State Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Setup context in a state
      Context c = new Context(new ConcreteStateA());
 
      // Issue requests, which toggles state
      c.Request();
      c.Request();
      c.Request();
      c.Request();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'State' abstract class
  /// </summary>
  abstract class State
  {
    public abstract void Handle(Context context);
  }
 
  /// <summary>
  /// A 'ConcreteState' class
  /// </summary>
  class ConcreteStateA : State
  {
    public override void Handle(Context context)
    {
      context.State = new ConcreteStateB();
    }
  }
 
  /// <summary>
  /// A 'ConcreteState' class
  /// </summary>
  class ConcreteStateB : State
  {
    public override void Handle(Context context)
    {
      context.State = new ConcreteStateA();
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class Context
  {
    private State _state;
 
    // Constructor
    public Context(State state)
    {
      this.State = state;
    }
 
    // Gets or sets the state
    public State State
    {
      get { return _state; }
      set
      {
        _state = value;
        Console.WriteLine("State: " +
          _state.GetType().Name);
      }
    }
 
    public void Request()
    {
      _state.Handle(this);
    }
  }
}  
```
