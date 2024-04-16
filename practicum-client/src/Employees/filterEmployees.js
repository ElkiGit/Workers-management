import { observer } from "mobx-react";
import { TextField } from '@mui/material';
import storeEmployee from '../store/employee';

const FilterEmployees = observer(() => {
    const handleSearchChange = (event) => {
        console.log(event.target.value);
        const searchText = event.target.value;
        storeEmployee.setSearchText(searchText); // Set the search text in the store
    };

    return (
        <TextField
            label="Search"
            variant="outlined"
            onChange={handleSearchChange}
        />
    );
});

export default FilterEmployees;