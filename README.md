# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## ChatGPT Spatial Vision Management System

**Purpose**

The purpose of the site is to provide every manager/inspector/head of Tzot with the means to manage Ovadiv in a fast and convenient way and to advertise new positions for staffing.

**Database Design**

### Tables
- **Employee**: Contains employee details and links to position and manager tables.
- **Position**: Includes the name of the position (e.g., secretary, supervisor, teacher) and job location.
- **Employee_Position**: Represents the relationship between employees and their positions, including start date and whether it's a management position.
- **Manager**: Holds manager information, login credentials, and a link to the employee table.

**Server-Side Implementation**

- Administrators have permissions to edit and delete employee details they own.
- Admins can add new positions and reactivate employees (sends an email for approval).
- Employees can edit and delete their own details.
- Registration and accessing the list of employees do not require special permissions.
- Deleted employees are logically removed from the system.

**Client-Side Features**

- Unregistered users can view basic employee details.
- Users can register, log in, and access their personal area.
- Admins see a list of employees under their supervision, categorized as active and inactive.
- Admins and employees have specific permissions as outlined above.

**External Connections**

- Google Maps Integration: Allows users to check if the job location is near their home.
- Gmail Integration: Enables sending messages to employees for confirmation of return to work.

**Usage**

1. Clone the repository.
2. Set up the database according to the provided schema.
3. Configure server-side scripts and client-side interfaces.
4. Ensure proper authentication and permissions handling.
5. Integrate external services as needed.

**Contributors**

- [Your Name]
- [Your Team Members]

**License**

This project is licensed under the [License Name] License - see the LICENSE.md file for details.

# System Under Construction: Siat Dashmia

**Note: This system is currently under construction. Changes and updates will be made over the next month until the finished product is released.**

**What is in the system now?**

**Database:**
- Creation of an employee table containing employee details as well as a link to the table of positions and positions.
- A table of positions containing a position name such as secretary/supervisor/teacher.
- The employee position relationship table containing additional details such as the start date of this job and whether it was taken as a management position.

**Server Side:**
- Each employee can edit and delete the information of other employees.

**Client Side:**
- A person logging in can see basic details of all employees registered in the system.
- Users can add their personal items and log in as regular employees.
- Users can edit and delete any employee's details.

**Technologies Used:**
- Server side developed in .NET using code-first method by EF (Entity Framework).
- Client side developed in React with Material-UI (MUI) design.

# Client-Side (React)

The client-side interface includes a table displaying the details of employees, with options to add, update, and delete employees. Each employee entry includes a field for a list of roles, and during the addition of a new employee, there's the flexibility to dynamically add roles.

**Features:**
- **Employee Table:** Displays a comprehensive list of employee details.
- **Add Employee:** Enables adding new employees to the list.
- **Update Employee:** Allows updating employee information.
- **Delete Employee:** Supports logical deletion of employees to maintain data integrity.
- **Roles:** Each employee can have multiple roles, and roles can be dynamically added during employee addition.
- **Export to Excel:** Provides functionality to export the employee list to an Excel file for download.

**Additional Feature:**
- **Role Addition:** Administrators can add new roles to the system.

# Server-Side (.NET 6)

The server-side is implemented using .NET 6, featuring an API for storing employee data. Data is stored in an SQL database, following a layered project structure.

**Features:**
- **API Endpoints:** Implements endpoints for handling CRUD operations on employee data.
- **Logical Deletion:** Utilizes logical deletion when removing employees to maintain data consistency.

This application streamlines the management of an organization's employee list, offering flexibility in role management and efficient data storage and retrieval. The client-side React interface provides a user-friendly experience, while the robust .NET 6 backend ensures secure and reliable data handling.