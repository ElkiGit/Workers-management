import { observer } from "mobx-react";
import { useForm,useFieldArray } from "react-hook-form";
import store from '../store/employee'
import storeRole from '../store/role'

const AddOrUpdateEmployee = observer(({ flagCloseForm ,EmployeeId}) => {
    const dataRole = storeRole.dataRoles;
    const { register, handleSubmit, formState: { errors }, control } = useForm();
    const { fields, append, remove } = useFieldArray({
        control,
        name: "employeeRoles"
    });
    function addOrUpdateEmployeeToStore(employee) {
        
        store.addEmployee(employee);
        
        flagCloseForm(false);
    }
    return (
        <>
            <form onSubmit={handleSubmit(addOrUpdateEmployeeToStore)}>
                <div>
                    <label>First Name</label>
                    <input {...register("firstName", { required: true })} />
                    {errors.firstName && <span>This field is required</span>}
                </div>

                <div>
                    <label>Last Name</label>
                    <input {...register("lastName", { required: true })} />
                    {errors.lastName && <span>This field is required</span>}
                </div>

                <div>
                    <label>Identity</label>
                    <input {...register("identity", { required: true })} />
                    {errors.identity && <span>This field is required</span>}
                </div>

                <div>
                    <label>Start Work</label>
                    <input {...register("startWork", { required: true })} type="date" />
                    {errors.startWork && <span>This field is required</span>}
                </div>

                <div>
                    <label>BirthDate</label>
                    <input {...register("birthDate", { required: true })} type="date" />
                    {errors.birthDate && <span>This field is required</span>}
                </div>

                <div>
                    <label>Type</label>
                    <div>
                        <input type="radio" {...register("type", { required: true })} value="0" />
                        <label>Male</label>
                    </div>
                    <div>
                        <input type="radio" {...register("type", { required: true })} value="1" />
                        <label>Female</label>
                    </div>
                    {errors.type && <span>This field is required</span>}
                </div>
                {fields.map((role, index) => (
                    <div key={role.id}>
                        <label>Role Name</label>
                        <select {...register(`employeeRoles[${index}].roleId`, { required: true })}>
                            {dataRole.map(role => (
                                <option key={role.id} value={role.id}>{role.name}</option>
                            ))}
                        </select>
                        {errors[`employeeRoles[${index}].roleId`] && <span>This field is required</span>}
                        <div>
                            <label>Is Director</label>
                            <input {...register(`employeeRoles[${index}].isDirector`)} type="checkbox" />
                        </div>

                        <div>
                            <label>Start Role</label>
                            <input {...register(`employeeRoles[${index}].startRole`, { required: true })} type="date" />
                            {errors[`employeeRoles[${index}].startRole`] && <span>This field is required</span>}
                        </div>
                        <button type="button" onClick={() => remove(index)}>Remove Role</button>
                    </div>
                ))}
                <button type="button" onClick={() => append({})}>Add Role</button>
                <button type="submit">Submit</button>
            </form>
        </>
    )

})
export default AddOrUpdateEmployee;




