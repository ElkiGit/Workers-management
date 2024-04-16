// import { observer } from "mobx-react";
// import storeEmployee from '../store/employee'
// import storeRole from '../store/role'
// import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
// import ModeIcon from '@mui/icons-material/Mode';
// import DeleteIcon from '@mui/icons-material/Delete';
// import AddIcon from '@mui/icons-material/Add';
// import { useState } from "react";
// import Button from '@mui/material/Button';
// import AddOrUpdateEmployee from "./addOrUpdateEmployee";
// import * as XLSX from 'xlsx';
// import { reaction } from "mobx";



// const AllEmployees1 = observer(() => {

//     const dataEmployees = storeEmployee.dataEmployees;
//     const [flagAdd, setFlagAdd] = useState(false);
//     const [flagUpdateEmployee, setFlagUpdateEmployee] = useState(false);
//     const [employeeIdForUpdate, setEmployeeIdForUpdate] = useState(null);
//     const dataRoles=storeRole.dataRoles;
//     const searchText=storeEmployee.searchText
    
//     // function filteredEmployees(searchText) {

//     //     // const searchText = storeEmployee.searchText.toLowerCase().trim();
//     //     // console.log(searchText);
//     //     const filteredEmployees = this.data.filter(emp => {
//     //         // Check if any field of the employee object contains the search text
//     //         return Object.values(emp).some(value =>
//     //             value.toString().toLowerCase().includes(this.searchText.toLowerCase())
//     //         );
//     //     });

//     //     this.dataEmployees = filteredEmployees;
//     // }
    

//     const handleUpdateEmployeeClick = (id) => {
//         setFlagUpdateEmployee(true);
//         setEmployeeIdForUpdate(id);
//     };

    
//     const handleDownloadExcel = () => {
//         const filteredEmployees = dataEmployees.filter(emp => {
//             // Check if any field of the employee object contains the search text
//             return Object.values(emp).some(value =>
//                 value.toString().toLowerCase().includes(searchText.toLowerCase())
//             );
//         });

        
//         // Create a workbook
//         const workbook = XLSX.utils.book_new();

//         // Create a worksheet for employees
//         const worksheet = XLSX.utils.json_to_sheet(filteredEmployees);
//         XLSX.utils.book_append_sheet(workbook, worksheet, 'Employees');

//         // Create a worksheet for roles
//         const rolesData = dataEmployees.map(emp => ({
//             Roles: emp.employeeRoles.map(role => {
//                 const matchedRole = dataRoles.find(dataRole => dataRole.id === role.roleId);
//                 return matchedRole ? matchedRole.name : '';
//             }).join(', '),
//             ID: emp.id // Assuming each employee has an ID
//         }));
//         const rolesWorksheet = XLSX.utils.json_to_sheet(rolesData);
//         XLSX.utils.book_append_sheet(workbook, rolesWorksheet, 'Roles');

//         // Define a dropdown list for roles in a side column
//         const dropdownList = {
//             ref: 'A2:A' + (filteredEmployees.length + 1), // Define the range where the dropdown list will be applied
//             data: dataRoles.map(role => ({ v: role.name, t: role.name })),
//         };
//         worksheet['!validations'] = [dropdownList];

//         // Save the workbook as a file
//         XLSX.writeFile(workbook, 'employees.xlsx');
//     };

//     return (
//         <>
//             <AddIcon onClick={() => setFlagAdd(true)}></AddIcon>
//             <Button variant="outlined" onClick={handleDownloadExcel}>Download Excel</Button>
//             <TableContainer component={Paper}>
//                 <Table>
//                     <TableHead>
//                         <TableRow>
//                             <TableCell>First Name</TableCell>
//                             <TableCell>Last Name</TableCell>
//                             <TableCell>Identity</TableCell>
//                             <TableCell>Start Work</TableCell>
//                             <TableCell>Action</TableCell>
//                         </TableRow>
//                     </TableHead>
//                     <TableBody>
//                         {dataEmployees.filter(emp => {
//             // Check if any field of the employee object contains the search text
//             return Object.values(emp).some(value =>
//                 value.toString().toLowerCase().includes(searchText.toLowerCase())
//             );
//         }).map(emp => <OneEmployee key={emp.id} {...emp} onUpdateEmployeeClick={handleUpdateEmployeeClick}></OneEmployee>)}
//                     </TableBody>
//                 </Table>
//             </TableContainer>
//             {flagAdd && <AddOrUpdateEmployee flagCloseForm={setFlagAdd} EmployeeId={null}></AddOrUpdateEmployee>}
//             {flagUpdateEmployee&&<AddOrUpdateEmployee flagCloseForm={setFlagUpdateEmployee} EmployeeId={employeeIdForUpdate}></AddOrUpdateEmployee>}

//         </>
//     )

// })
// export default AllEmployees1;

// const OneEmployee = observer((props) => {

//     const { id, firstName, lastName, identity, startWork ,onUpdateEmployeeClick } = props;
//     return (
//         <>
//             <TableRow>
//                 <TableCell>{firstName}</TableCell>
//                 <TableCell>{lastName}</TableCell>
//                 <TableCell>{identity}</TableCell>
//                 <TableCell>{startWork}</TableCell>
//                 <TableCell><Button variant="text" onClick={() => onUpdateEmployeeClick(id)}>Update Employee</Button></TableCell>
//                 <TableCell><ModeIcon /></TableCell>
//                 <TableCell><DeleteIcon onClick={() => storeEmployee.deleteEmployee(id)} /></TableCell>
//             </TableRow>
//         </>
//     )
// })
// import React, { useState, useEffect } from 'react';
// import MUIDataTable from 'mui-datatables';
// import {
//     Table,
//     TableBody,
//     TableCell,
//     TableContainer,
//     TableHead,
//     TableRow,
//     Paper,
//     Collapse,
//     Typography,
//     Box,
//     IconButton,
//     Button,
//     Container,
//     Tooltip, // Import Tooltip component
// } from '@mui/material';
// import DeleteIcon from '@mui/icons-material/Delete';
// import EditIcon from '@mui/icons-material/Edit';
// import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
// import ClearIcon from '@mui/icons-material/Clear';
// import CheckIcon from '@mui/icons-material/Check';
// import DeleteEmployee from './deleteEmployee';
// import EditEmployee from './editEmployee';
// import { observer } from 'mobx-react';
// import storeEmployee from '../store/employee';
// import storeRole from '../store/role';

// const AllEmployee = observer(({ rows }) => {
//     const [displayEdit, setDisplayEdit] = useState(false);
//     const [displayDelete, setDisplayDelete] = useState(false);
//     const [selectedEmployeeId, setSelectedEmployeeId] = useState(null);
//     const [selectedEmployee, setSelectedEmployee] = useState(null);
//     const dataEmployees = storeEmployee.dataEmployees;
//     const rolesData = storeRole.dataRoles;

//     const handleEditClick = (employee) => {
//         setSelectedEmployee(employee);
//         setDisplayEdit(true);
//     };

//     const handleDeleteClick = (employeeId) => {
//         setSelectedEmployeeId(employeeId);
//         setDisplayDelete(true);
//     };

//     const handleCloseEdit = () => {
//         setDisplayEdit(false);
//     };

//     const handleCloseDelete = () => {
//         setDisplayDelete(false);
//     };

//     const data = rows.map((row) => [
//         <TableCell style={{ textAlign: 'center' }}>{row.firstName}</TableCell>,
//         <TableCell style={{ textAlign: 'center' }}>{row.lastName}</TableCell>,
//         <TableCell style={{ textAlign: 'center' }}>{row.identity}</TableCell>, // Convert idNumber to string
//         <TableCell style={{ textAlign: 'center' }}>{row.startWork ? new Date(row.startWork).toISOString().split('T')[0] : ''}</TableCell>
//     ]);

//     const columns = [
//         { name: 'firstName', label: 'First Name' },
//         { name: 'lastName', label: 'Last Name' },
//         { name: 'idNumber', label: 'ID Number' },
//         { name: 'dateStartingWork', label: 'Starting Work Date' },
    
//         {
//             label: 'edit',
//             options: {
//                 customBodyRenderLite: (index) => (
//                     <Tooltip title="Edit" arrow >
//                         <IconButton onClick={() => handleEditClick(rows[index].id)}>
//                             <EditIcon />
//                         </IconButton>
//                     </Tooltip>
//                 ),
//             },
//         },
//         {
//             name: 'delete',
//             options: {
//                 customBodyRenderLite: (index) => (
//                     <Tooltip title="Delete" arrow >
//                         <IconButton onClick={() => handleDeleteClick(rows[index].id)}>
//                             <DeleteIcon />
//                         </IconButton>
//                     </Tooltip>
//                 ),
//             },
//         },
//     ];

//     const options = {
//         filter: false,
//         filterType: 'dropdown',
//         responsive: 'standard',
//         rowsPerPage: 10,
//         expandableRows: false, 
//         selectableRows: 'none',
//         downloadOptions: {
//             filename: 'employee.csv',
//             separator: ',',
//             filterOptions: {
//                 useDisplayedColumnsOnly: true,
//                 useDisplayedRowsOnly: true,
//             },
//         },
//     };
    
//     const title = (
//         <Button onClick={() => handleEditClick()} startIcon={<AddCircleOutlineIcon />}>
//             Add Employee
//         </Button>
//     );

//     return (
//         <Container maxWidth="xl">
//             <Typography variant="h6" component="div" gutterBottom>
//                 Employee List
//             </Typography>
//             {displayEdit && <EditEmployee flagCloseForm={setDisplayEdit} EmployeeId={selectedEmployee} />}
//            {displayDelete&& <DeleteEmployee handleClose={handleCloseDelete}  id={selectedEmployeeId} />} 
//             <MUIDataTable  title={title} data={data} columns={columns} options={options} />
//         </Container>
//     );
// });

// export default AllEmployee;
