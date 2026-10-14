# Task Management REST API

დავალებების მართვის მარტივი RESTful API, შექმნილი ASP.NET Core Web API-ის გამოყენებით. პროექტი უზრუნველყოფს დავალებების სრულ CRUD (Create, Read, Update, Delete) ფუნქციონალს, ვალიდაციებსა და სტატუსის მიხედვით გაფილტვრას.

---

## 🛠 გამოყენებული ტექნოლოგიები (Tech Stack)

- **Platform:** .NET Core / C#
- **Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** SQL Server / SQLite
- **Documentation:** Swagger / OpenAPI
- **Architecture:** Repository & Service Pattern, DTOs (Data Transfer Objects)

---

## 🚀 ფუნქციონალი და Endpoint-ები

| HTTP Method | Endpoint | აღწერა |
| :--- | :--- | :--- |
| `GET` | `/api/tasks` | ყველა დავალების მიღება |
| `GET` | `/api/tasks?status={Status}` | დავალებების გაფილტვრა სტატუსის მიხედვით (`Pending`, `InProgress`, `Completed`) |
| `GET` | `/api/tasks/{id}` | კონკრეტული დავალების მიღება ID-ით |
| `POST` | `/api/tasks` | ახალი დავალების შექმნა (`201 Created`) |
| `PATCH` | `/api/tasks/{id}` | არსებული დავალების ნაწილობრივი განახლება |
| `DELETE` | `/api/tasks/{id}` | დავალების წაშლა (`204 No Content`) |

---

## ⚙️ პროექტის გაშვება და გამართვა (Setup & Run)

### 1. წინაპირობები (Prerequisites)
- [.NET SDK](https://dotnet.microsoft.com/download) (ვერსია 8.0 ან უახლესი)
- [Git](https://git-scm.com/)

### 2. პროექტის კლონირება
```bash
git clone https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git
cd YOUR_REPOSITORY
```

### 3. მონაცემთა ბაზის კონფიგურაცია
1. შეამოწმეთ `appsettings.json` ფაილი და საჭიროებისამებრ ჩაასწორეთ `ConnectionStrings`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=TasksDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```
2. (თუ იყენებთ `.env` ფაილს): შექმენით `.env` ფაილი პროექტის ძირში `.env.example`-ის მიხედვით.

### 4. ბაზის მიგრაციების გაშვება (EF Core)
ტერმინალში გაუშვით შემდეგი ბრძანება ბაზისა და ცხრილების ასაგებად:
```bash
dotnet ef database update
```

### 5. პროექტის გაშვება
```bash
dotnet run
```

პროექტის გაშვების შემდეგ Swagger UI ხელმისაწვდომი იქნება ბრაუზერში:
👉 **`https://localhost:XXXX/swagger`** (სადაც `XXXX` არის პორტის ნომერი).

---

## 📁 პროექტის სტრუქტურა

```text
├── Context/            # DbContext და ბაზის კონფიგურაცია
├── Controllers/        # API Controller-ები (HTTP მოთხოვნების დამუშავება)
├── DTOs/               # Requests & Responses DTO-ები (ვალიდაციებით)
│   ├── Requests/
│   └── Responses/
├── Models/             # Domain Entity-ები და Enum-ები
├── Repositories/       # Data Access Layer (Repository Pattern)
├── Services/           # Business Logic Layer
├── appsettings.json    # პროექტის პარამეტრები
└── README.md           # დოკუმენტაცია
```

---

