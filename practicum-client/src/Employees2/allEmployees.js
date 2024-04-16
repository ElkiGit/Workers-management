import React, { useState, useEffect } from 'react';
import MUIDataTable from 'mui-datatables';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Collapse,
    Typography,
    Box,
    IconButton,
    Button,
    Container,
    Tooltip, // Import Tooltip component
} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import ClearIcon from '@mui/icons-material/Clear';
import CheckIcon from '@mui/icons-material/Check';
import DeleteEmployee from './deleteEmployee';
import EditEmployee from './editEmployee';
import { observer } from 'mobx-react';
import storeEmployee from '../store/employee';
import storeRole from '../store/role';

const AllEmployee = observer(({ rows }) => {
    const [displayEdit, setDisplayEdit] = useState(false);
    const [displayDelete, setDisplayDelete] = useState(false);
    const [selectedEmployeeId, setSelectedEmployeeId] = useState(null);
    const [selectedEmployee, setSelectedEmployee] = useState(null);
    const dataEmployees = storeEmployee.dataEmployees;
    const rolesData = storeRole.dataRoles;

    const handleEditClick = (employee) => {
        setSelectedEmployee(employee);
        setDisplayEdit(true);
    };

    const handleDeleteClick = (employeeId) => {
        setSelectedEmployeeId(employeeId);
        setDisplayDelete(true);
    };

    const handleCloseEdit = () => {
        setDisplayEdit(false);
    };

    const handleCloseDelete = () => {
        setDisplayDelete(false);
    };

    const data = rows.map((row) => [
        <TableCell style={{ textAlign: 'center' }}>{row.firstName}</TableCell>,
        <TableCell style={{ textAlign: 'center' }}>{row.lastName}</TableCell>,
        <TableCell style={{ textAlign: 'center' }}>{row.identity}</TableCell>, // Convert idNumber to string
        <TableCell style={{ textAlign: 'center' }}>{row.startWork ? new Date(row.startWork).toISOString().split('T')[0] : ''}</TableCell>
    ]);

    const columns = [
        { name: 'firstName', label: 'First Name' },
        { name: 'lastName', label: 'Last Name' },
        { name: 'idNumber', label: 'ID Number' },
        { name: 'dateStartingWork', label: 'Starting Work Date' },
    
        {
            label: 'edit',
            options: {
                customBodyRenderLite: (index) => (
                    <Tooltip title="Edit" arrow >
                        <IconButton onClick={() => handleEditClick(rows[index].id)}>
                            <EditIcon />
                        </IconButton>
                    </Tooltip>
                ),
            },
        },
        {
            name: 'delete',
            options: {
                customBodyRenderLite: (index) => (
                    <Tooltip title="Delete" arrow >
                        <IconButton onClick={() => handleDeleteClick(rows[index].id)}>
                            <DeleteIcon />
                        </IconButton>
                    </Tooltip>
                ),
            },
        },
    ];

    const options = {
        filter: false,
        filterType: 'dropdown',
        responsive: 'standard',
        rowsPerPage: 10,
        expandableRows: false, 
        selectableRows: 'none',
        downloadOptions: {
            filename: 'employee.csv',
            separator: ',',
            filterOptions: {
                useDisplayedColumnsOnly: true,
                useDisplayedRowsOnly: true,
            },
        },
    };
    
    const title = (
        <Button onClick={() => handleEditClick()} startIcon={<AddCircleOutlineIcon />}>
            Add Employee
        </Button>
    );

    return (
        <Container maxWidth="xl">
            <Typography variant="h6" component="div" gutterBottom>
                Employee List
            </Typography>
            {displayEdit && <EditEmployee flagCloseForm={setDisplayEdit} EmployeeId={selectedEmployee} />}
           {displayDelete&& <DeleteEmployee handleClose={handleCloseDelete} open={displayDelete}  id={selectedEmployeeId} />} 
            <MUIDataTable  title={title} data={data} columns={columns} options={options} />
        </Container>
    );
});

export default AllEmployee;
