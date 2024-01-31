type Book = {
    id: number,
    title: string,
    firstName: string,
    lastName: string,
    totalCopies: string,
    copiesInUse: string,
    type: string | null,
    iSBN: string | null,
    category: string | null,
}

export default Book;