import { Button, Grid, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import { useState } from "react";
import BookList from "../../components/BookList";
import Book from "../../shared/book";
import { populateGrid } from "./data";
import { SearchCriteria } from "../../shared/searchCriteria";

const Books = () => {

    const [search, setSearch] = useState("");
    const [searchCriteria, setSearchCriteria] = useState(SearchCriteria.Title);
    const [books, setBooks] = useState<Book[] | null>(null);
    const [error, setError] = useState("");

    const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    }

    const handleCriteriaChange = (e: SelectChangeEvent) => {
        setSearchCriteria(parseInt(e.target.value));
    }

    //Probably if this was a real world app, I would use React query instead
    const handleSearch = () => {
        populateGrid(setError, setBooks, search, searchCriteria);
    }

    return <>
        <Grid container marginBottom={5} minWidth={700}>
            <Grid item xs={5} flexDirection="column" display="flex" gap={2} alignItems="center">
                <div>Search By <Select value="1" onChange={handleCriteriaChange}>
                    <MenuItem value={1}>Title</MenuItem>
                    <MenuItem value={2}>Author</MenuItem>
                    <MenuItem value={3}>ISBN</MenuItem>
                </Select>
                </div>
                <div>
                    <TextField onChange={handleSearchChange} value={search}
                        label="Search" helperText="Type for search books" variant="standard" />
                </div>
                <Button sx={{ height: '25px' }} variant="contained"
                    onClick={handleSearch}>Search</Button>
            </Grid>
        </Grid>
        {error ? error :
            <BookList books={books} />}

    </>;
}

export default Books