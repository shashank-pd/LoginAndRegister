# 🔐 Login and Registration System

## 📋 Overview
This project is a Windows Forms application developed in C# that provides a basic user authentication system. The application allows users to register with a username and password, and subsequently log in using those credentials. The project connects to a SQL Server database to store and verify user information.

## ✨ Features
- **📝 User Registration**: Create a new account with a username and password.
- **🔑 User Login**: Log in using registered credentials.
- **👁️ Password Visibility Toggle**: Option to show/hide password.
- **🔄 Form Navigation**: Easy navigation between login and registration forms.

## 📸 Screenshots

### 🔓 Login Form
![image](https://github.com/shashank-pd/LoginAndRegister/assets/110643754/7be58fdc-4991-4fa8-99b8-4eacfa3f05e7)


### 📝 Registration Form
![image](https://github.com/shashank-pd/LoginAndRegister/assets/110643754/6282a1dd-14e0-44d0-9275-9fb82e23a949)


## 🛠️ Prerequisites
- 🖥️ Visual Studio
- 🗄️ SQL Server

## 🚀 Setup Instructions

1. **📥 Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/LoginPage.git
    ```

2. **💻 Open the solution in Visual Studio:**
    Open the `LoginPage.sln` file.

3. **⚙️ Configure the Database:**
    - Ensure SQL Server is running.
    - Create a database named `login`.
    - Create a table named `login` with the following schema:
      ```sql
      CREATE TABLE login (
          username NVARCHAR(50) PRIMARY KEY,
          password NVARCHAR(50)
      );
      ```

4. **🔧 Update the connection string:**
    Update the connection string in the `frmlogin` and `frmRegister` forms to match your SQL Server configuration:
    ```csharp
    SqlConnection con = new SqlConnection(@"Data Source=YOUR_SERVER_NAME;Initial Catalog=login;Integrated Security=True");
    ```

5. **🏃‍♂️ Build and Run:**
    Build the solution and run the application.
