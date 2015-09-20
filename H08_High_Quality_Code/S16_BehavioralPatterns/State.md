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
* **Context** (Account) :
    * дефинира интерфейса, който представлява интерес за клиентите.
    * поддържа инстанция на подклас на State, дефинираща текущото състояние.
    
* **State** (State) :
    * дефинира интерфейс за капсулиране на поведението, асоциирано с определено състояние на Context.

* **ConcreteState** (RedState, SilverState, GoldState) :
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
 
namespace DoFactory.GangOfFour.State.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// State Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Open a new account
      Account account = new Account("Jim Johnson");
 
      // Apply financial transactions
      account.Deposit(500.0);
      account.Deposit(300.0);
      account.Deposit(550.0);
      account.PayInterest();
      account.Withdraw(2000.00);
      account.Withdraw(1100.00);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'State' abstract class
  /// </summary>
  abstract class State
  {
    protected Account account;
    protected double balance;
 
    protected double interest;
    protected double lowerLimit;
    protected double upperLimit;
 
    // Properties
    public Account Account
    {
      get { return account; }
      set { account = value; }
    }
 
    public double Balance
    {
      get { return balance; }
      set { balance = value; }
    }
 
    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
    public abstract void PayInterest();
  }
 
 
  /// <summary>
  /// A 'ConcreteState' class
  /// <remarks>
  /// Red indicates that account is overdrawn 
  /// </remarks>
  /// </summary>
  class RedState : State
  {
    private double _serviceFee;
 
    // Constructor
    public RedState(State state)
    {
      this.balance = state.Balance;
      this.account = state.Account;
      Initialize();
    }
 
    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = -100.0;
      upperLimit = 0.0;
      _serviceFee = 15.00;
    }
 
    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }
 
    public override void Withdraw(double amount)
    {
      amount = amount - _serviceFee;
      Console.WriteLine("No funds available for withdrawal!");
    }
 
    public override void PayInterest()
    {
      // No interest is paid
    }
 
    private void StateChangeCheck()
    {
      if (balance > upperLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }
 
  /// <summary>
  /// A 'ConcreteState' class
  /// <remarks>
  /// Silver indicates a non-interest bearing state
  /// </remarks>
  /// </summary>
  class SilverState : State
  {
    // Overloaded constructors
 
    public SilverState(State state) :
      this(state.Balance, state.Account)
    {
    }
 
    public SilverState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }
 
    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = 0.0;
      upperLimit = 1000.0;
    }
 
    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }
 
    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }
 
    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }
 
    private void StateChangeCheck()
    {
      if (balance < lowerLimit)
      {
        account.State = new RedState(this);
      }
      else if (balance > upperLimit)
      {
        account.State = new GoldState(this);
      }
    }
  }
 
  /// <summary>
  /// A 'ConcreteState' class
  /// <remarks>
  /// Gold indicates an interest bearing state
  /// </remarks>
  /// </summary>
  class GoldState : State
  {
    // Overloaded constructors
    public GoldState(State state)
      : this(state.Balance, state.Account)
    {
    }
 
    public GoldState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }
 
    private void Initialize()
    {
      // Should come from a database
      interest = 0.05;
      lowerLimit = 1000.0;
      upperLimit = 10000000.0;
    }
 
    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }
 
    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }
 
    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }
 
    private void StateChangeCheck()
    {
      if (balance < 0.0)
      {
        account.State = new RedState(this);
      }
      else if (balance < lowerLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class Account
  {
    private State _state;
    private string _owner;
 
    // Constructor
    public Account(string owner)
    {
      // New accounts are 'Silver' by default
      this._owner = owner;
      this._state = new SilverState(0.0, this);
    }
 
    // Properties
    public double Balance
    {
      get { return _state.Balance; }
    }
 
    public State State
    {
      get { return _state; }
      set { _state = value; }
    }
 
    public void Deposit(double amount)
    {
      _state.Deposit(amount);
      Console.WriteLine("Deposited {0:C} --- ", amount);
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}",
        this.State.GetType().Name);
      Console.WriteLine("");
    }
 
    public void Withdraw(double amount)
    {
      _state.Withdraw(amount);
      Console.WriteLine("Withdrew {0:C} --- ", amount);
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}\n",
        this.State.GetType().Name);
    }
 
    public void PayInterest()
    {
      _state.PayInterest();
      Console.WriteLine("Interest Paid --- ");
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}\n",
        this.State.GetType().Name);
    }
  }
}
```
