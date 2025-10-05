import {useState} from "react";
import {useAtom} from "jotai";
import {authorsAtom} from "../atoms/AuthorsAtom.ts";

export default function Authors() {
    const [authors] = useAtom(authorsAtom);
    const [search, setSearch] = useState("");

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Authors</h1>
            <input className="input input-bordered w-full mb-4" placeholder="Search" onChange={(e) => setSearch(e.target.value)} value={search}/>
            <ul className="menu bg-base-200 rounded-box p-4">
                {authors
                    .filter((author) => author.name.toLowerCase().includes(search.toLowerCase()))
                    .map((author, index) => (
                        <li key={index}><a href={`/booksByAuthor/${encodeURIComponent(author.name)}`}>{author.name} <span className="badge">{author.numOfBooks}</span></a></li>
                    ))}
            </ul>
        </div>
    )
}