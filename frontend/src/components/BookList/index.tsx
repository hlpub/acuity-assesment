import {
    Paper, Table, TableBody, TableCell, TableContainer,
    TableHead, TableRow
} from "@mui/material";
import Book from "../../shared/book";

const BookList: React.FC<{
    books: Book[] | null
}> = ({ books }) => {

    return books && books.length > 0  ? <TableContainer component={Paper} >
        <Table sx={{ minWidth: 950 }} aria-label="simple table">
            <TableHead>
                <TableRow>
                    <TableCell>Book Title</TableCell>
                    <TableCell>Authors</TableCell>
                    <TableCell>Type</TableCell>
                    <TableCell>ISBN</TableCell>
                    <TableCell>Category</TableCell>
                    <TableCell align="right">Available Copies</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {books.map(book => (
                    <TableRow key={book.id}>
                        <TableCell>{book.title}</TableCell>
                        <TableCell>{book.firstName + " " + book.lastName}</TableCell>
                        <TableCell>{book.type}</TableCell>
                        <TableCell>{book.isbn}</TableCell>
                        <TableCell>{book.category}</TableCell>
                        <TableCell align="right">{book.copiesInUse}/{book.totalCopies}</TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>
    </TableContainer> : <>There are no results</>;
}

export default BookList