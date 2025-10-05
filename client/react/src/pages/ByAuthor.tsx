import {useMemo} from "react";
import {useNavigate, useParams} from "react-router-dom";
import BookList from "../components/BookList.tsx";
import {useAtomValue} from "jotai";
import {booksAtom} from "../atoms/BooksAtom.ts";

export default function ByAuthor() {
    const { author } = useParams<{author: string}>();
    const books = useAtomValue(booksAtom);
    const navigate = useNavigate();

    const filteredBooks = useMemo(() => {
        return books.filter((book) => book.author.includes(author as string));
    }, [books, author]);

    return (
        <div className="p-6">
            <div className="flex justify-between items-center mb-4">
                <h1 className="text-2xl font-bold">Books by {author}</h1>
                <button className="btn btn-primary" onClick={() => navigate("/addBook")}>Add Book</button>
            </div>

            <BookList books={filteredBooks} />
        </div>
    )
}