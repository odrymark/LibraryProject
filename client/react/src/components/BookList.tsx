import { type Book } from '../api';

interface BookListProps {
    books: Book[];
}

export default function BookList({ books }: BookListProps) {
    if (books.length === 0) {
        return <p className="text-center text-gray-500">No books match your criteria.</p>;
    }

    return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {books.map((book) => (
                <div key={book.id} className="card bg-base-200 shadow-md p-4">
                    <h2 className="card-title">{book.title}</h2>
                    <p><b>Pages:</b> {book.pages}</p>
                    <p><b>Authors:</b> {book.author.join(", ")}</p>
                    <p><b>Genre:</b> {book.genre}</p>
                </div>
            ))}
        </div>
    );
}