import axios from 'axios'
import { action, makeObservable, observable, runInAction } from "mobx";

class Role {

    dataRoles = [];

    constructor() {
        makeObservable(this, {
            dataRoles: observable,
            addRole: action,
            updateRole: action,
            deleteRole: action
        });
        this.getAllRoles();
    }

    getAllRoles() {
        axios.get('https://localhost:7089/api/Role').then(res =>
            this.dataRoles = res.data
        )
    }

    addRole(role) {
        const roleToAdd = {
            name: role.name
        }
        fetch('https://localhost:7089/api/Role', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(roleToAdd)
        }).then((res) => {
            runInAction(() => {
                this.dataRoles.push(res.data);
            })
        })
    }

    updateRole(id, role) {
        const roleToUpdate = {
            name: role.name
        }
        fetch(`https://localhost:7089/api/Role/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(roleToUpdate)
        }).then((res) => {
            runInAction(() => {
                const updatedRole = this.dataRoles.findIndex(r => r.id === id);
                if (updatedRole !== -1) {
                    this.dataRoles[updatedRole] = { ...this.dataRoles[updatedRole], ...roleToUpdate };
                }
            })
        });
    }

    deleteRole(id) {
        fetch(`https://localhost:7089/api/Role/${id}`, {
            method: 'DELETE'
        }).then((res) => {
            const deleteRole = this.dataRoles.findIndex(r => r.id === id);
            if (deleteRole !== -1) {
                this.dataRoles.splice(deleteRole, 1)
            }
        });
    }
}
export default new Role();