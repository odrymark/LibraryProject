import {useState, useMemo} from 'react';
import {useNavigate} from "react-router-dom";
import BookList from "../components/BookList.tsx";
import { useAtom} from 'jotai';
import {booksAtom} from "../atoms/BooksAtom.ts";

export default function Books() {
    const [books] = useAtom(booksAtom);
    const [search, setSearch] = useState("");
    const navigate = useNavigate();

    const filteredBooks = useMemo(()=>  {
        return books.filter((book) => book.title.toLowerCase().includes(search.toLowerCase()));
    }, [books, search]);

    return (
        <div className="p-6">
            <div className="flex justify-between items-center mb-4">
                <h1 className="text-2xl font-bold">Books</h1>
                <button className="btn btn-primary" onClick={() => navigate("/addBook")}>Add Book</button>
            </div>

            <input className="input input-bordered w-full mb-4" placeholder="Search" onChange={(e) => setSearch(e.target.value)} value={search}/>
            <BookList books={filteredBooks}/>
        </div>
    )
}