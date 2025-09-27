# RBAC-User-Management  

A **Role-Based Access Control (RBAC)** user management system built in **C# (.NET WinForms)** with **SQL Server** as the backend.  
This project was developed during an internship at **Avanza Solutions** as part of a training program to learn about secure user management, approval workflows, and database change tracking.  

---

## 📌 Features  

- **User Management**  
  - Create, update, and deactivate users  
  - Assign users to **roles** and **groups**  
  - Track changes with audit history  

- **Role & Group Management**  
  - Define roles and assign permissions  
  - Manage user groups and group permissions  
  - Maintain a history of updates and deletions  

- **Approval Workflow**  
  - All changes (insert, update, delete) go into a **Pending** state  
  - Changes must be reviewed and approved/rejected by a checker  
  - Ensures **maker-checker** compliance  

- **Audit & Tracking**  
  - **UserHistory** & **UserGroupsHistory** tables for tracking old vs new values  
  - **GroupHistory** & **GroupPermissionHistory** tables for group-level tracking  
  - Allows visibility of who made the change, who approved it, and when  

---

## 🏗️ System Design  

### Database (SQL Server)  
- **Users** – stores system users  
- **Roles** – defines user roles  
- **Groups** – organizes users and permissions  
- **Permissions** – action-level permissions  
- **PendingUsers / PendingUserGroups** – holds unapproved changes  
- **History Tables** – (UserHistory, UserGroupsHistory, GroupHistory, GroupPermissionHistory)  

### Application (C# WinForms)  
- **UserList** – displays users with filtering (Pending / Approved / Rejected)  
- **UserReview** – detailed review window for checkers (approve/reject changes)  
- **Approval Logic** – applies approved changes to main tables, rejects go to history  

---

## ⚙️ Tech Stack  

- **Frontend**: C# WinForms (.NET Framework)  
- **Backend**: SQL Server (T-SQL)  
- **Architecture**: Maker-Checker workflow with change tracking  

---
## 🔑 Skills Learned

- C# WinForms development
- SQL Server database design (constraints, foreign keys, history tracking)
- Role-Based Access Control (RBAC)
- Maker-Checker workflows in enterprise apps
- Transaction handling & audit logging

---
## 📜 License

This project is for learning purposes only.
