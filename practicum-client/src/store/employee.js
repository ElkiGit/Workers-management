import axios from 'axios'
import { action, makeObservable, observable, runInAction } from "mobx";


class Employee {

    dataEmployees = [];
    data=[];
    searchText="";
    constructor() {
        makeObservable(this, {
            dataEmployees: observable,
            addEmployee: action,
            updateEmployee: action,
            updateEmployeeRoles: action,
            deleteEmployee: action,
            searchText: observable,
            setSearchText: action
        });
        this.getAllEmployees();
    }
    setSearchText(text) {
        console.log(text);
        this.searchText = text;
      
    }

    getAllEmployees() {
        axios.get('https://localhost:7089/api/Employee').then(res =>
            runInAction(() => {
                this.dataEmployees = res.data;
                this.data=res.data;
            })
        )
    }

    getEmployeeById(id) {
     return this.dataEmployees.find(e=>e.id===id);
    }

    addEmployee(employee) {
        const employeeToAdd = {
            firstName: employee.firstName,
            lastName: employee.lastName,
            identity: employee.identity,
            startWork: employee.startWork,
            birthDate: employee.birthDate,
            type: parseInt(employee.type),
            employeeRoles: employee.employeeRoles.map(role => ({
                roleId: role.roleId,
                isDirector: role.isDirector,
                startRole: role.startRole
            }))
        };

        fetch('https://localhost:7089/api/Employee', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(employeeToAdd)
        }).then((res) => {
           
            if (res.status === 200) {
                res.json().then(data => {
                    runInAction(() => {
                        this.dataEmployees.push(data);
                    });
                });
            }

        })
    }

    updateEmployee(id, employee) {
        const EmployeeRoles = employee.employeeRoles.map((
            { roleId, isDirector, startRole }) => ({ roleId, isDirector, startRole }));
        const employeeToUpdate = {
            firstName: employee.firstName,
            lastName: employee.lastName,
            identity: employee.identity,
            startWork: employee.startWork,
            birthDate: employee.birthDate,
            type: parseInt(employee.type),
            employeeRoles: EmployeeRoles
        }
        fetch(`https://localhost:7089/api/Employee/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(employeeToUpdate)
        }).then((res) => {
            runInAction(() => {
                const updatedEmployee = this.dataEmployees.findIndex(emp => emp.id === id);
                if (updatedEmployee !== -1) {
                    this.dataEmployees[updatedEmployee] = { ...this.dataEmployees[updatedEmployee], ...employeeToUpdate };
                }
            })
        });
    }
    updateEmployeeRoles(id, employeeRoles) {
        const employeeRoleToAdd = {
            roleId: employeeRoles.roleId,
            isDirector: employeeRoles.isDirector,
            startRole: employeeRoles.startRole
        }
        console.log(employeeRoleToAdd);
        fetch(`https://localhost:7089/api/Employee/EmployeeRole/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(employeeRoleToAdd)
        }).then((res) => {
            
            if (res.status === 200) {
                runInAction(() => {
                    const updatedEmployeeIndex = this.dataEmployees.findIndex(emp => emp.id === id);
                    if (updatedEmployeeIndex !== -1) {
                        const updatedEmployee = this.dataEmployees[updatedEmployeeIndex];
                        const existingRoleIndex = updatedEmployee.EmployeeRoles.findIndex(role => role.roleId === employeeRoleToAdd.roleId);
                        if (existingRoleIndex === -1) {
                            updatedEmployee.EmployeeRoles.push(employeeRoleToAdd);
                        } else {
                            updatedEmployee.EmployeeRoles[existingRoleIndex] = employeeRoleToAdd;
                        }
                    }
                });
            }

        });
    }
    deleteEmployee(id) {
        fetch(`https://localhost:7089/api/Employee/${id}`, {
            method: 'DELETE'
        }).then((res) => {
            const deleteEmployee = this.dataEmployees.findIndex(emp => emp.id === id);
            if (deleteEmployee !== -1) {
                runInAction(() => {
                    this.dataEmployees.splice(deleteEmployee, 1)
                });
                
            }
        });
    }
}
export default new Employee();