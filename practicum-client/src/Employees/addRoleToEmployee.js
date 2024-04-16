import { observer } from "mobx-react";
import { useForm } from "react-hook-form";
import store from '../store/employee'
import storeRole from '../store/role'


const AddRoleToEmployee=observer((props)=>{
    const { register, handleSubmit, formState: { errors } } = useForm();
    const{flagCloseForm,EmployeeId}=props;
    const dataRole = storeRole.dataRoles;
    function addRole(role){
        store.updateEmployeeRoles(EmployeeId,role);
        flagCloseForm(false);
    }
    return(
        <>
            <form onSubmit={handleSubmit(addRole)}>
            <div>
                    <label>Role Name</label>
                    <select {...register("roleId", { required: true })}>
                        {dataRole.map(role => (
                            <option key={role.id} value={role.id}>{role.name}</option>
                        ))}
                    </select>
                    {errors["roleId"] && <span>This field is required</span>}
                </div>

                <div>
                    <label>Is Director</label>
                    <input {...register("isDirector")} type="checkbox" />
                </div>

                <div>
                    <label>Start Role</label>
                    <input {...register("startRole", { required: true })} type="date" />
                    {errors["startRole"] && <span>This field is required</span>}
                </div>
                <button type="submit">Submit</button>
            </form>
        </>
    )
})
export default AddRoleToEmployee;