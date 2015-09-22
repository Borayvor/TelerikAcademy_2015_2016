# Mediator (Посредник)

### 1. Цел.
> Дефинира обект, капсулиращ взаимоотношенията в даден набор от обекти. Посредник съдейства за разхлабване на връзките, като не 
позволява на обектите да се обръщат изрично един към друг и дава възможност свободно да се променят взаимоотношенията им.

### 2. Мотивация.
> Обектно-ориентираният дизайн насърчава разпределението на поведението сред повече обекти. Подобно разпределение може да доведе до 
обектна структура с много връзки между обектите - в най-лошия случай, накрая всеки обект ще знае за всички останали.

> Въпреки, че раздробяването на една система на много обекти по принцип подобрява възможността за многократно използване, нарояването 
на взаимовръзки обикновено го намалява. Многото взаимовръзки намаляват вероятността даден обект да може да работи без поддръжката на 
други - системата ще се държи все едно, че е монолитна. Освен това може да е трудно променянето на системата по значителен начин, 
тъй като поведението е разпределено сред много обекти. В резултат на това може да се наложи да се дефинират много класове , за да се 
настрои поведението на системата.

### 3. Приложимост.
> Използвайте когато :
* множество обекти комуникират по добре дефинирани, но сложни начини. Резултатните взаимоотношения са неструктурирани и трудни 
за разбиране.
* многократното използване на даден обект е трудно, защото той има връзки и комуникира с много други обекти.
* едно поведение, разпределено между няколко класове, трябва да бъде настройвано без създаване на много подкласове.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S16_BehavioralPatterns/Diagrams/mediator.jpg)


### 5. Участници.
* **Mediator** (IChatroom) :
    * дефинира интерфейс за комуникация с Colleague обекти.
    
* **ConcreteMediator** (Chatroom) :
    * имплементира кооперативно поведение чрез координация на Colleague обекти.
    * знае и пази връзки към своите колеги.

* **Colleague classes** (Participant) :
    * всеки клас Colleague знае своя Mediator обект.
    * всеки колега комуникира със своя посредник, когато иначе би комуникирал с друг колега.

### 6. Взаимодействия.
* Колегите изпращат и получават заявки от Mediator обект. Посредникът имплементира кооперативното поведение като препраща заявките 
между съответните колеги.

### 7. Следствия.
* Ограничава създаването на подкласове.
* Разделя колегите.
* Опростява обектните протоколи.
* Прави абстракция на това, как обектите си сътрудничат.
* Централизира контрола.

### 8. Примерен код.
```
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Mediator.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Mediator Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create chatroom
      Chatroom chatroom = new Chatroom();
 
      // Create participants and register them
      Participant George = new Beatle("George");
      Participant Paul = new Beatle("Paul");
      Participant Ringo = new Beatle("Ringo");
      Participant John = new Beatle("John");
      Participant Yoko = new NonBeatle("Yoko");
 
      chatroom.Register(George);
      chatroom.Register(Paul);
      chatroom.Register(Ringo);
      chatroom.Register(John);
      chatroom.Register(Yoko);
 
      // Chatting participants
      Yoko.Send("John", "Hi John!");
      Paul.Send("Ringo", "All you need is love");
      Ringo.Send("George", "My sweet Lord");
      Paul.Send("John", "Can't buy me love");
      John.Send("Yoko", "My sweet love");
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Mediator' abstract class
  /// </summary>
  abstract class AbstractChatroom
  {
    public abstract void Register(Participant participant);
    public abstract void Send(
      string from, string to, string message);
  }
 
  /// <summary>
  /// The 'ConcreteMediator' class
  /// </summary>
  class Chatroom : AbstractChatroom
  {
    private Dictionary<string,Participant> _participants = 
      new Dictionary<string,Participant>();
 
    public override void Register(Participant participant)
    {
      if (!_participants.ContainsValue(participant))
      {
        _participants[participant.Name] = participant;
      }
 
      participant.Chatroom = this;
    }
 
    public override void Send(
      string from, string to, string message)
    {
      Participant participant = _participants[to];
 
      if (participant != null)
      {
        participant.Receive(from, message);
      }
    }
  }
 
  /// <summary>
  /// The 'AbstractColleague' class
  /// </summary>
  class Participant
  {
    private Chatroom _chatroom;
    private string _name;
 
    // Constructor
    public Participant(string name)
    {
      this._name = name;
    }
 
    // Gets participant name
    public string Name
    {
      get { return _name; }
    }
 
    // Gets chatroom
    public Chatroom Chatroom
    {
      set { _chatroom = value; }
      get { return _chatroom; }
    }
 
    // Sends message to given participant
    public void Send(string to, string message)
    {
      _chatroom.Send(_name, to, message);
    }
 
    // Receives message from given participant
    public virtual void Receive(
      string from, string message)
    {
      Console.WriteLine("{0} to {1}: '{2}'",
        from, Name, message);
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class Beatle : Participant
  {
    // Constructor
    public Beatle(string name)
      : base(name)
    {
    }
 
    public override void Receive(string from, string message)
    {
      Console.Write("To a Beatle: ");
      base.Receive(from, message);
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class NonBeatle : Participant
  {
    // Constructor
    public NonBeatle(string name)
      : base(name)
    {
    }
 
    public override void Receive(string from, string message)
    {
      Console.Write("To a non-Beatle: ");
      base.Receive(from, message);
    }
  }
}
```
