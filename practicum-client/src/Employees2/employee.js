// import React, { useEffect, useState, useRef } from 'react';

// //import EmployeeTable from "./employeeTable.jsx";
// import EmployeeStore from '../store/employee.js';
// import { observer } from 'mobx-react';
// import AllEmployee from './allEmployees.js';

// const EmployeeC = observer(() => {
//     const employeeDetails = EmployeeStore.dataEmployees;
//     const formatRoles = (roles) => {
//         return roles.map((role) => role.name).join(', ');
//     };

//     const csvData = employeeDetails.map(row => {
//         const { roles, ...rest } = row;
//         return { ...rest, roles: formatRoles(roles) };
//     });

//     return (
//         <> 
//             {/* <EmployeeTable rows={employeeDetails} /> */}
//             <AllEmployee rows={employeeDetails}></AllEmployee>
//         </>
//     )
// });
// export default EmployeeC;
import React, { useEffect, useState } from 'react';
import EmployeeStore from '../store/employee.js';
import { observer } from 'mobx-react';
import AllEmployee from './allEmployees.js';

const EmployeeC = observer(() => {
    const [employeeDet, setEmployeeDet] = useState([]);
    const employeeDetails=EmployeeStore.dataEmployees;

    useEffect(() => {
        const fetchEmployeeData = async () => {
            try {
                // Fetch employee data asynchronously
                await EmployeeStore.getAllEmployees();
                // Once the data is fetched, update the state
                setEmployeeDet(EmployeeStore.dataEmployees);
            } catch (error) {
                console.error("Error fetching employee data:", error);
            }
        };

        // Call the fetchEmployeeData function
        fetchEmployeeData();
    }, []); // Empty dependency array ensures the effect runs only once after initial render

    return (
        <AllEmployee rows={employeeDetails} />
    );
});

export default EmployeeC;