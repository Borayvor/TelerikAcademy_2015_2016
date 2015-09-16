# Builder (Строител)

### 1. Цел.
> Разделя създаването на сложен обект от неговото представяне, така че един и същи процес 
да може да създава обекти с различно представяне.

### 2. Мотивация.
* Създаване на сложен обект.
* Преобразуване на обект от едно представяне към друго: Например - конвертиране на текст от един формат в друг 

### 3. Приложимост.
Използва се когато:
* дадена система трябва да бъде независима от това, как се създават, композират и представят нейните продукти.
* дадена система трябва да се конфигурира с едно от многото семейства продукти.
* семейство свързани обекти продукти е проектирано за съвместно използване и това ограничение трябва да се наложи.
* искате да представите библиотека класове за продукти и да разкриете само техните интерфейси, а не имплементациите им.

### 4. Структура.
![схема](https://github.com/Borayvor/TelerikAcademy_2015_2016/blob/master/H08_High_Quality_Code/S14_CreationalPatterns/Diagrams/Builder.jpg)

### 5. Участници.
* Director:
    * конструира обект посредством Builder. 
* Builder:
    * абстрактен клас или интерфейс за създаване на части от обект.
* ConcreteBuilder:
    * Конструира и сглобява части от продукта чрез имплементация на Builder.
	* Дефинира и следи създаваните от него представяния.
	* Предоставя интерфейс за извличане на крайния продукт.

### 6. Взаимодействия.
* Клиентът създава обекта Director и го конфигурира с желания обект Builder.
* Директорът извиква метод на строителя за да изгради някоя част от продукта.
* Builder обработва заявките от директора и добавя части към продукта.
* Клиентът получава продукта от строителя.

### 7. Следствия.
* Дава възможност да променяте вътрешното представяне на продукт.
* Изолира кода за конструиране и представяне.
* Предоставя по-прецизен контрол върху процеса на конструиране.

### 8. Примерен код.
```
 public abstract class MazeBuilder
{
	public virtual void BuildMaze()
	{}
	
	public virtual void BuildRoom(int roomNumber)
	{}
	
	public virtual void BuildDoor(int roomFrom, int roomTo)
	{}
	
	public virtual Maze GetMaze()
	{ return null; }
}
```

```
public interface MazeBuilder
{
	void BuildMaze();	
	void BuildRoom(int roomNumber);	
	void BuildDoor(int roomFrom, int roomTo);

	Maze GetMaze();
}
```

```
public class StandartMazeBuilder : MazeBuilder
{
	Maze currentMaze;

	public StandartMazeBuilder()
	{ currentMaze = null; }
	
	public override void BuildMaze()
	{ currentMaze = new Maze(); }
	
	public override void BuildDoor(int roomFrom, int roomTo)
	{
		// build door between the rooms
	}
	
	public override void BuildRoom(int roomNumber)
	{ 
		// build room... 
	}
	
	public override Maze GetMaze()
	{ return currentMaze; }
}
```

```
public class CountingMazeBuilder : MazeBuilder
{
	private int doors;
	private int rooms;

	public CountingMazeBuilder()
	{}
	
	public override void BuildMaze()
	{ doors = 0; rooms = 0; }
	
	public override void BuildDoor(int roomFrom, int roomTo)
	{ doors++; }
	
	public override void BuildRoom(int roomNumber)
	{ rooms++; }
	
	public void GetCounts(out int roomsCount, out int doorsCount)
	{ 
		doorsCount = doors; roomsCount = rooms;
	}
}
```

```
public class Client
{
	public static void Demo1()
	{
		MazeGame game = new MazeGame();
		StandartMazeBuilder builder = new StandartMazeBuilder();
		Maze maze = game.CreateMaze(builder);
	}
	
	public static void Demo2()
	{
		int rooms = 0; 
		int doors = 0;
		
		MazeGame game = new MazeGame();
		
		CountingMazeBuilder builder = new CountingMazeBuilder();
		
		game.CreateMaze(builder);
		builder.GetCounts(out rooms, out doors);
		
		Console.WriteLine("Maze has {0} rooms and {1} doors", 
			rooms, doors);
	}
}
```