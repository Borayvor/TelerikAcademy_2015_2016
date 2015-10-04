# Database Systems Overview Homework

## 1. What database models do you know?

#### Logical data models for databases:

+ Hierarchical database model (tree)
+ Network model (graph)
+ Relational model (table)
+ Entity–relationship model
+ Enhanced entity–relationship model
+ Object model
+ Document model
+ Entity–attribute–value model
+ Star schema
+ Object-relational model (combines the two related structures)

#### Physical data models:

+ Inverted index
+ Flat file

#### Other models:

+ Associative model
+ Multidimensional model
+ Multivalue model
+ Semantic model
+ XML database
+ Named graph
+ Triplestore

---

## 2. Which are the main functions performed by a Relational Database Management System (RDBMS) ?

##### A relational database management system (RDBMS) is a database management system (DBMS) that is based on the relational model.

#### RDBMSs typically implement:
+ Creating / altering / deleting tables and relationships between them (database schema)
+ Adding, changing, deleting, searching and retrieving of data stored in the tables
+ Support for the SQL language
+ Transaction management (optional)

#### Popular RDBMS servers:
+ Microsoft SQL Server
+ Oracle Database
+ MySQL
+ IBM DB2
+ PostgreSQL
+ SQLite

---

## 3. Define what is "table" in database terms.

#### A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.
* In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns 
and horizontal rows, the cell being the unit where a row and column intersect. A table has a specified 
number of columns, but can have any number of rows. Each row is identified by one or more values appearing in a particular 
column subset. The columns subset which uniquely identifies a row is called the primary key.

---

## 4. Explain the difference between a primary and a foreign key.

Primary Key | Foreign Key
-----------------------------------------------------|-----------------------------------------------------
Primary key uniquely identify a record in the table. | Foreign key is a field in the table that is primary key in another table.
Primary Key can't accept null values. | Foreign key can accept multiple null value.
By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index. | Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
We can have only one Primary key in a table. | We can have more than one foreign key in a table.   

---

## 5. Explain the different kinds of relationships between tables in relational databases.

#### There are three types of relationships in RDBMSs:

* **One-to-one**: Both tables can have only one record on either side of the relationship. Each primary key value relates to only 
one (or no) record in the related table. They're like spouses—you may or may not be married, but if you are, both you and your 
spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. 
In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.

* **One-to-many**: The primary key table contains only one record that relates to none, one, or many records in the related table. 
This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.

* **Many-to-many**: Each record in both tables can relate to any number of records (or no records) in the other table. For instance, 
if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as 
an associate or linking table, because relational systems can't directly accommodate the relationship.

---

## 6. When is a certain database schema normalized? What are the advantages of normalized databases ?

##### Database normalization (or normalisation) is the process of organizing the columns (attributes) and tables (relations) of a relational database to minimize data redundancy.

Normalization involves decomposing a table into less redundant (and smaller) tables without losing information; defining foreign 
keys in the old table referencing the primary keys of the new ones. The objective is to isolate data so that additions, deletions, 
and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.

Advantages                                       | Disadvantages
-------------------------------------------------|-------------------------------------------------
Smaller database: by eliminating duplicate data. | More tables to join: by spreading data into more tables.
Better performance.                              | Tables contain codes instead of real data.

---

## 7. What are database integrity constraints and when are they used ?

**Constraints are part of a database schema definition.** Integrity constraints are used to ensure accuracy and consistency of data 
in a relational database. Data integrity is handled in a relational database through the concept of referential integrity. Many types 
of integrity constraints play a role in referential integrity.

##### Common kinds of constraints are:
+ **NOT NULL** - each value in a column must not be NULL
+ **UNIQUE** - value(s) in specified column(s) must be unique for each row in a table
+ **PRIMARY KEY** - value(s) in specified column(s) must be unique for each row in a table and not be NULL; normally each table in a database should have a primary key - it is used to identify individual records
+ **FOREIGN KEY** - value(s) in specified column(s) must reference an existing record in another table (via it's primary key or some other unique constraint)
+ **CHECK** - an expression is specified, which must evaluate to true for constraint to be satisfied

---

## 8. Point out the pros and cons of using indexes in a database.

> A database index is a data structure that improves the speed of data retrieval operations on a database table at the cost of additional 
writes and storage space to maintain the index data structure. Indexes are used to quickly locate data without having to search every 
row in a database table every time a database table is accessed. Indexes can be created using one or more columns of a database table.

#### Advantages

##### There are three main advantages to using an index-organized table:
* Increased performance: There is no need to access a row in the database from an index structure, so you can reduce the total number of I/O operations needed to retrieve data.
* Reduced table space: Because you do not need to link to a row in a table, there is no need to store the ROWID in the index. The overall space required for the table is reduced.
* Presorted data: The data in the leaf nodes is already sorted by the value of the primary key.

#### Disadvantages

##### Saving space and eliminating I/O operations sound like great ways to enhance performance in your relational database management system, and they are. But index-organized tables also have disadvantages:
* You must have a primary key on the table with a unique value.
* You cannot have any other indexes on the data.
* You cannot partition an index-organized table.
* An index-organized table cannot be a part of a cluster.

---

## 9. What's the main purpose of the SQL language ?

##### SQL (Structured Query Language) is standardized declarative language for manipulation of relational databases. SQL-99 is currently 
in use in most databases. SQL language supports:
* Creating, altering, deleting tables and other objects in the database
* Searching, retrieving, inserting, modifying and deleting table data (rows)

>  Briefly said the purpose of SQL Structured Query Language is to provide a **Structured** way by which one can **Query** information 
in database using a standard **Language**.

---

## 10. What are transactions used for? Give an example.

#### A transaction symbolizes a unit of work performed within a database management system (or similar system) against a database, and treated in a coherent and reliable way independent of other transactions. A transaction generally represents any change in database. Transactions in a database environment have two main purposes:
* To provide reliable units of work that allow correct recovery from failures and keep a database consistent even in cases of system 
failure, when execution stops (completely or partially) and many operations upon a database remain uncompleted, with unclear status.
* To provide isolation between programs accessing a database concurrently. If this isolation is not provided, the programs' outcomes 
are possibly erroneous.

#### A simple explanation:

> You need to transfer 100$ from account A to account B. You can either do:

```
accountA -= 100;
accountB += 100;
```

or

```
accountB += 100;
accountA -= 100;
```

> If something goes wrong between the first and the second operation in the pair you have a problem - either 100$ have disappeared 
or they have appeared out of nowhere.

> A transaction is a mechanism that allows you to mark a group of operations and execute them in such a way thet either they 
all execute (commit) or the system state will be as if they have not started to execute at all (rollback).

```
beginTransaction;
accountB += 100;
accountA -= 100;
commitTransaction;
```

> will either transfer 100$ or leave both account in the initial state.

---

## 11. What is a NoSQL database ?

#### A NoSQL (originally referring to "non SQL" or "non relational") database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases.

#### NoSQL Database key "features":
* Use document-based model (non-relational)
* Schema-free document storage
* Still support CRUD operations(create, read, update, delete)
* Still support indexing and querying
* Still supports concurrency  and transactions
* Highly optimized for append / retrieve
* Great performance and scalability

---

## 12. Explain the classical non-relational data models.

#### Document database expands on the basic idea of key-value stores where “documents” are more complex, in that they contain data and each document is assigned a unique key, which is used to retrieve the document. These are designed for storing, retrieving, and managing document-oriented information, also known as semi-structured data. Examples include: MongoDB and CouchDB.

## 13. Give few examples of NoSQL databases and their pros and cons.

#### There are four general types of NoSQL databases, each with their own specific attributes:
* **Key-Value store** – we start with this type of database because these are some of the least complex NoSQL options. These databases are designed for storing data in a schema-less way. In a key-value store, all of the data within consists of an indexed key and a value, hence the name. Examples of this type of database include: Cassandra, DyanmoDB, Azure Table Storage (ATS), Riak, BerkeleyDB.
* **Column store** – (also known as wide-column stores) instead of storing data in rows, these databases are designed for storing data tables as sections of columns of data, rather than as rows of data. While this simple description sounds like the inverse of a standard database, wide-column stores offer very high performance and a highly scalable architecture. Examples include: HBase, BigTable and HyperTable.
* **Document database** – expands on the basic idea of key-value stores where “documents” are more complex, in that they contain data and each document is assigned a unique key, which is used to retrieve the document. These are designed for storing, retrieving, and managing document-oriented information, also known as semi-structured data. Examples include: MongoDB and CouchDB.
* **Graph database** – Based on graph theory, these databases are designed for data whose relations are well represented as a graph and has elements which are interconnected, with an undetermined number of relations between them. Examples include: Neo4J and Polyglot.

#### The following table lays out some of the key attributes that should be considered when evaluating NoSQL databases.

Datamodel       | Performance | Scalability     | Flexibility | Complexity | Functionality
----------------|-------------|-----------------|-------------|------------|-----------------
Key-value store | High        | High            | High        | None       | Variable (None)
Column Store    | High        | High            | Moderate    | Low        | Minimal
Document Store  | High        | Variable (High) | High        | Low        | Variable (Low)
Graph Database  | Variable    | Variable        | High        | High       | Graph Theory