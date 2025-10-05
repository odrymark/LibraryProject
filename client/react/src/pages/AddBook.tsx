import {useState} from "react";
import {handleAddBook} from "../api";

export default function AddBook() {
    const [title, setTitle] = useState('');
    const [pages, setPages] = useState('');
    const [author, setAuthor] = useState('');
    const [genre, setGenre] = useState('');

    const handleSubmit = async () => {
        const authorsArray = author.split(',')
            .map(s => s.trim())
            .filter(s => s.length > 0);

        try {
            await handleAddBook({
                id: 0,
                title: title,
                pages: Number(pages),
                authors: authorsArray,
                genre: genre
            });

            setTitle('');
            setPages('');
            setAuthor('');
            setGenre('');
        } catch (error) {
            console.error("Submission failed.", error);
        }
    };

    return (
        <div className="p-6 max-w-lg mx-auto">
            <h1 className="text-2xl font-bold mb-4">Add Book</h1>
            <div className="form-control gap-3">
                <input className="input input-bordered" type="text" placeholder="Title" value={title} onChange={(e) => setTitle(e.target.value)}/>
                <input className="input input-bordered" type="text" placeholder="Number of pages" value={pages} onChange={(e) => setPages(e.target.value)}/>
                <input className="input input-bordered" type="text" placeholder="Authors seperated by comma" value={author} onChange={(e) => setAuthor(e.target.value)}/>
                <input className="input input-bordered" type="text" placeholder="Genre" value={genre} onChange={(e) => setGenre(e.target.value)}/>
                <br/>
                <button className="btn btn-success mt-4" onClick={() => handleSubmit()}>Confirm</button>
            </div>
        </div>
    )
}