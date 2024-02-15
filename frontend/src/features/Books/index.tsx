import { Button, FormControl, Grid, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import { useCallback, useState } from "react";
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

    const handleSearchKeyPress = (e: React.KeyboardEvent<HTMLDivElement>) => {
        if (e.key === "Enter") handleSearch();
    }

    //Probably if this was a real world app, I would use React query instead
    const handleSearch = useCallback(() => {

        if (search)
            populateGrid(setError, setBooks, search, searchCriteria);

    }, [search, searchCriteria]);

    return <>
        <Grid container
            direction="column"
            rowGap={4}
            justifyContent="center"
            alignItems="flex-start"
            marginY={5}>
            <Grid item>
                <FormControl sx={{ minWidth: 300 }} size="small">
                    <InputLabel>Search by</InputLabel>
                    <Select
                        value={searchCriteria.toString()} onChange={handleCriteriaChange} label="Search by">
                        <MenuItem value={SearchCriteria.Title}>Title</MenuItem>
                        <MenuItem value={SearchCriteria.Author}>Author</MenuItem>
                        <MenuItem value={SearchCriteria.ISBN}>ISBN</MenuItem>
                    </Select>
                </FormControl>
            </Grid>
            <Grid item>
                <FormControl sx={{ minWidth: 300 }} size="small">
                    <TextField onChange={handleSearchChange} value={search}
                        onKeyDown={handleSearchKeyPress}
                        label="Search term" placeholder="Enter search term"
                        helperText="Type for searching books" variant="standard" />
                </FormControl>
            </Grid>
            <Grid item alignSelf="end">
                <Button sx={{ height: '25px' }} variant="contained"
                    onClick={handleSearch}>Search</Button>
            </Grid>
        </Grid>
        {error ? error :
            <BookList books={books} />}

    </>;
}

export default Books