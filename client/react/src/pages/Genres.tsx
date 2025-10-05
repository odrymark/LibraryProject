import {useState} from "react";
import {genresAtom} from "../atoms/GenresAtom.ts";
import {useAtom} from "jotai";

export default function Genres() {
    const [genres] = useAtom(genresAtom);
    const [search, setSearch] = useState("");

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Genres</h1>
            <input className="input input-bordered w-full mb-4" placeholder="Search" onChange={(e) => setSearch(e.target.value)} value={search}/>
            <ul className="menu bg-base-200 rounded-box p-4">
                {genres
                    .filter((genre) => genre.name.toLowerCase().includes(search.toLowerCase()))
                    .map((genre, index) => (
                        <li key={index}><a href={`/booksByGenre/${encodeURIComponent(genre.name)}`}>{genre.name} <span className="badge">{genre.numOfBooks}</span></a></li>
                    ))}
            </ul>
        </div>
    )
}