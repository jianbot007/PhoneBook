# 📞 PhoneBook

A modern ASP.NET MVC PhoneBook web application for efficient contact management.  
_Built with C# and ASP.NET MVC as part of an interview task._

---

## 🌟 Overview

**PhoneBook** is a web application for storing, searching, updating, and managing contact information. It demonstrates clean ASP.NET MVC architecture, robust CRUD operations, and a responsive user interface.

---

## 🚀 Features

- **Add Contacts**: Create new entries with name and phone number
- **View Contacts**: List all saved contacts in a clear table
- **Search**: Find contacts by name or phone number
- **Edit**: Update contact details
- **Delete**: Remove entries securely
- **MVC Architecture**: Clean separation of controller, view, and model logic

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET MVC (C#)
- **View Engine:** Razor
- **Database:** SQL Server (Entity Framework ORM)
- **Frontend:** HTML, CSS (Bootstrap)

---

## 🏁 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/jianbot007/PhoneBook.git
cd PhoneBook
```

### 2. Open Solution in Visual Studio

- Launch Visual Studio
- Open the `.sln` solution file

### 3. Configure Database

- Edit the `Web.config` file:
```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Server=YOUR_SERVER;Database=PhoneBookDB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```
- Run database migrations if using Code First:
  - Open Package Manager Console and run:
    ```bash
    Update-Database
    ```

### 4. Run the Application

- Press **F5** or click **Start** in Visual Studio
- The app will open in your browser at `http://localhost:xxxx`


## 🤝 Contributing

Contributions and feedback are welcome!  
Feel free to fork the repo and open a pull request.

---

## 📜 License
 All right @Kazi Mahfuzur Rahman

---

> **Repository:** [jianbot007/PhoneBook](https://github.com/jianbot007/PhoneBook)  
> _Developed as part of an interview task by [jianbot007](https://github.com/jianbot007)_
